import { Component, OnInit } from '@angular/core';
import {News} from "../../model/model";
@Component({
  selector: 'app-news-short',
  templateUrl: './news-short.component.html',
  styleUrls: ['./news-short.component.css']
})
export class NewsShortComponent implements OnInit {

  public newsArray: News[] = [];

  constructor() { }

  ngOnInit(): void {
    this.newsArray = [{
      IdArticles: 1,
      Title: 'Witam w moim niusie',
      Content: 'AAAAAAAaaaaaaaaAAAAAAaaaaa',
      PublicationDate: new Date()
    }];
  }

  consoling(any: any): void {
    console.log(any);
  }

}
