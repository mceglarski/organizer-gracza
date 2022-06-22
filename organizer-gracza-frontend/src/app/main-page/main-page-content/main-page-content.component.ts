import { Component } from '@angular/core';
import {News} from "../../model/model";

@Component({
  selector: 'app-main-page-content',
  templateUrl: './main-page-content.component.html',
  styleUrls: ['./main-page-content.component.css']
})
export class MainPageContentComponent {

  public news?: News = {
    articlesId: 1,
    title: '',
    content: '',
    publicationDate: new Date(),
    photoUrl: '',
    userId: 1};

  public getExtendedNews(news: News): void {
    this.news = news;
  }

}
