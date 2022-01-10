import { Component, OnInit } from '@angular/core';
import {News} from "../../model/model";

@Component({
  selector: 'app-main-page-content',
  templateUrl: './main-page-content.component.html',
  styleUrls: ['./main-page-content.component.css']
})
export class MainPageContentComponent implements OnInit {

  public news?: News = {
    articlesId: 1,
    title: '',
    content: '',
    publicationDate: new Date(),
    photoUrl: '',
    userId: 1};

  constructor() { }

  ngOnInit(): void {
  }

  public getExtendedNews(news: News): void {
    this.news = news;
  }

}
