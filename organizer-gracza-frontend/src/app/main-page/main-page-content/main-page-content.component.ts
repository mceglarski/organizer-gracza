import { Component, OnInit } from '@angular/core';
import {News} from "../../model/model";

@Component({
  selector: 'app-main-page-content',
  templateUrl: './main-page-content.component.html',
  styleUrls: ['./main-page-content.component.css']
})
export class MainPageContentComponent implements OnInit {

  public news?: News;

  constructor() { }

  ngOnInit(): void {
  }

  public getExtendedNews(news: News): void {
    this.news = news;
  }

}
