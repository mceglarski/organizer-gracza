import {Component, Input, OnInit} from '@angular/core';
import {Member, Photo, User} from "../../model/model";
import {FileUploader} from "ng2-file-upload";
import {environment} from "../../../environments/environment";
import {AccountService} from "../../_services/account.service";
import {take} from "rxjs/operators";
import {MembersService} from "../../_services/members.service";

@Component({
  selector: 'app-member-photo-editor',
  templateUrl: './member-photo-editor.component.html',
  styleUrls: ['./member-photo-editor.component.css']
})
export class MemberPhotoEditorComponent implements OnInit {
  @Input() public member: Member;
  public uploader: FileUploader;
  public hasBaseDropzoneOver = false;
  public baseUrl = environment.apiUrl;
  public user: User;


  constructor(private accountService: AccountService,
              private memberService: MembersService) {
    this.accountService.currentUser$.pipe(take(1)).subscribe(user => this.user = user);
  }

  ngOnInit(): void {
    this.initializeUploader();
  }

  public fileOverBase(event: any){
    this.hasBaseDropzoneOver = event;
  }

  // @ts-ignore
  public setMainPhoto(photo: Photo){
    this.memberService.setMainPhoto(photo.photoId).subscribe(() => {
      this.user.photoUrl = photo.url;
      this.accountService.setCurrentUser(this.user);
      this.member.photoUrl = photo.url;
      this.member.photos.forEach(p => {
        if(p.isMain)
            p.isMain = false;
        if(p.photoId === photo.photoId)
            p.isMain = true;
      })
    })
  }

  public deletePhoto(photoId: number){
    this.memberService.deletePhoto(photoId).subscribe(() => {
      this.member.photos = this.member.photos.filter(x => x.photoId !== photoId);
    })
  }

  initializeUploader(){
    this.uploader = new FileUploader({
      url: this.baseUrl + 'users/add-photo',
      authToken: 'Bearer ' + this.user.token,
      isHTML5: true,
      allowedFileType: ['image'],
      removeAfterUpload: true,
      autoUpload: false,
      maxFileSize: 10 * 1024 * 1024
    });

    this.uploader.onAfterAddingFile = (file) => {
      file.withCredentials = false;
    }

    this.uploader.onSuccessItem = (item, response, status, headers) => {
      if(response){
        const photo: Photo = JSON.parse(response);
        this.member.photos.push(photo);
        if(photo.isMain){
          this.user.photoUrl = photo.url;
          this.member.photoUrl = photo.url;
          this.accountService.setCurrentUser(this.user);
        }
      }
    }
  }
}
