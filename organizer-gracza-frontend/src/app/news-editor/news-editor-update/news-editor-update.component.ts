import { Component, OnInit } from '@angular/core';
import {FormControl, FormGroup, Validators} from "@angular/forms";
import {FileUploader} from "ng2-file-upload";
import {News, Photo} from "../../model/model";
import {environment} from "../../../environments/environment";
import {MembersService} from "../../_services/members.service";
import {ArticlesService} from "../../_services/articles.service";
import {ToastrService} from "ngx-toastr";
import {ActivatedRoute, Router} from "@angular/router";

@Component({
  selector: 'app-news-editor-update',
  templateUrl: './news-editor-update.component.html',
  styleUrls: ['./news-editor-update.component.css']
})
export class NewsEditorUpdateComponent implements OnInit {

  public articleForm = new FormGroup({
    title: new FormControl('', [Validators.required, this.noWhitespaceValidator]),
    content: new FormControl('', [Validators.required, this.noWhitespaceValidator])
  });
  public uploader: FileUploader;
  public hasBaseDropzoneOver = false;
  public photoUploaded: Photo;
  public editedNews: News;

  private newsId: number;
  private currentUserId: number;
  private baseUrl = environment.apiUrl;

  constructor(private membersService: MembersService,
              private articleService: ArticlesService,
              private toastr: ToastrService,
              private router: Router,
              private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.newsId = <number><unknown>this.route.snapshot.paramMap.get('newsId');
    this.membersService.getCurrentlyLoggedMemberId().subscribe( m => {
      // @ts-ignore
      this.currentUserId = m;
      return;
    });
    this.articleService.getArticle(this.newsId).subscribe(a => {
      // @ts-ignore
      this.editedNews = a;
      this.articleForm.setValue({
        title: this.editedNews.title,
        content: this.editedNews.content
      });
      return;
    });
    this.initializeUploader();
  }

  public noWhitespaceValidator(control: FormControl) {
    const isWhitespace = (control.value || '').trim().length === 0;
    const isValid = !isWhitespace;
    return isValid ? null : { 'whitespace': true };
  }

  public onSubmit(): void {
    if (this.articleForm.valid && !this.photoUploaded) {
      this.articleService.updateArticle({
        title: this.articleForm.value.title.trim(),
        content: this.articleForm.value.content.trim()
      }, this.newsId).subscribe(r => {
        window.location.reload();
        this.toastr.success('Artykuł zaktualizowany');
      });
    }
    if (this.articleForm.valid && this.photoUploaded) {
      this.articleService.updateArticle({
        title: this.articleForm.value.title.trim(),
        content: this.articleForm.value.content.trim(),
        photoUrl: this.photoUploaded.url
      }, this.newsId).subscribe(response => {
        window.location.reload();
        this.toastr.success('Artykuł zaktualizowany');
        return;
      }, error => {
        this.toastr.error('Wystąpił błąd podczas aktualizowania artykułu');
        console.log(error);
        return;
      });
    }
    else {
      if (!this.articleForm.valid) {
        this.toastr.error('Uzupełnij wszystkie pola');
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
