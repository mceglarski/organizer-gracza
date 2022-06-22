import { Component, OnInit } from '@angular/core';
import {MembersService} from "../../_services/members.service";
import {ArticlesService} from "../../_services/articles.service";
import {FormControl, FormGroup, Validators} from "@angular/forms";
import {FileUploader} from "ng2-file-upload";
import {environment} from "../../../environments/environment";
import {Photo} from "../../model/model";
import {ToastrService} from "ngx-toastr";
import {Router} from "@angular/router";

@Component({
  selector: 'app-news-editor-panel',
  templateUrl: './news-editor-panel.component.html',
  styleUrls: ['./news-editor-panel.component.css']
})
export class NewsEditorPanelComponent implements OnInit {

  public articleForm = new FormGroup({
    title: new FormControl('', [Validators.required, this.noWhitespaceValidator]),
    content: new FormControl('', [Validators.required, this.noWhitespaceValidator])
  });
  public uploader: FileUploader;
  public hasBaseDropzoneOver = false;
  public photoUploaded: Photo;

  private currentUserId: number;
  private baseUrl = environment.apiUrl;

  constructor(private membersService: MembersService,
              private articleService: ArticlesService,
              private toastr: ToastrService,
              private router: Router) { }

  ngOnInit(): void {
    this.membersService.getCurrentlyLoggedMemberId().subscribe( m => {
      // @ts-ignore
      this.currentUserId = m;

    });
    this.initializeUploader();
  }

  public noWhitespaceValidator(control: FormControl) {
    const isWhitespace = (control.value || '').trim().length === 0;
    const isValid = !isWhitespace;
    return isValid ? null : { 'whitespace': true };
  }

  public onSubmit(): void {
    if (this.articleForm.valid && this.photoUploaded) {
      this.articleService.addArticle({
        title: this.articleForm.value.title.trim(),
        content: this.articleForm.value.content.trim(),
        publicationDate: new Date(),
        photoUrl: this.photoUploaded.url,
        userId: this.currentUserId
      }).subscribe(response => {
        this.router.navigate(["/news"]);

      }, error => {
        this.toastr.error('Wystąpił błąd podczas dodawania artykułu');
        console.log(error);

      });
    }
    else {
      if (!this.articleForm.valid) {
        this.toastr.error('Uzupełnij wszystkie pola');
      }
      else {
        this.toastr.error('Dodaj zdjęcie artykułu');
      }
    }
  }

  public fileOverBase(event: any){
    this.hasBaseDropzoneOver = event;
  }

  private initializeUploader(): void {
    this.uploader = new FileUploader({
      url: this.baseUrl + 'users/add-photo-article',
      // @ts-ignore
      authToken: 'Bearer ' + JSON.parse(localStorage.getItem('user')).token,
      isHTML5: true,
      allowedFileType: ['image'],
      removeAfterUpload: true,
      autoUpload: false
    });

    this.uploader.onAfterAddingFile = (file) => {
      file.withCredentials = false;
    }

    this.uploader.onSuccessItem = (item, response, status, headers) => {
      if(response) {
        const photo: Photo = JSON.parse(response);
        this.photoUploaded = photo;
      }
    }
  }

}
