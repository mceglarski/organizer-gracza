import {Component, Inject, OnInit} from '@angular/core';
import {MAT_DIALOG_DATA} from "@angular/material/dialog";
import {FileUploader} from "ng2-file-upload";
import {environment} from "../../../environments/environment";
import {Photo, User} from "../../model/model";

@Component({
  selector: 'app-upload-image-modal',
  templateUrl: './upload-image-modal.component.html',
  styleUrls: ['./upload-image-modal.component.css']
})
export class UploadImageModalComponent implements OnInit {

  public uploader: FileUploader;
  public hasBaseDropzoneOver = false;

  private baseUrl = environment.apiUrl;

  constructor(
    @Inject(MAT_DIALOG_DATA) public data: {
      path: String,
      user: User
    }
  ) { }

  ngOnInit(): void {
    this.initializeUploader();
  }

  fileOverBase(e: any) {
    this.hasBaseDropzoneOver = e;
  }

  initializeUploader() {
    this.uploader = new FileUploader({
      url: this.baseUrl + this.data.path,
      authToken: 'Bearer ' + this.data.user.token,
      isHTML5: true,
      allowedFileType: ['image'],
      removeAfterUpload: true,
      autoUpload: false,
      maxFileSize: 10 * 1024 * 1024
    });

    this.uploader.onSuccessItem = (item, response, status, headers) => {
      if (response) {
        // this.loadTeam();
        // console.log(this.team)
        // const photo: Photo = JSON.parse(response);
        // console.log(photo)
        // this.team.photoUrl = photo.url;
      }
    }
  }

}
