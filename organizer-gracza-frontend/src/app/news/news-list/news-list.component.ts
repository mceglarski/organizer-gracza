import { Component, OnInit } from '@angular/core';
import {News} from "../../model/model";
import {ArticlesService} from "../../_services/articles.service";

@Component({
  selector: 'app-news-list',
  templateUrl: './news-list.component.html',
  styleUrls: ['./news-list.component.css']
})
export class NewsListComponent implements OnInit {

  public articleArray: News[] = [];

  constructor(private articlesService: ArticlesService) { }

  ngOnInit(): void {
    this.articlesService.getArticles().subscribe(article => {
      // @ts-ignore
      this.articleArray = article;
      console.log(this.articleArray);
    });
  }

}
