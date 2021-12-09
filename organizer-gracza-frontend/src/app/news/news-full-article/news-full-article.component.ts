import { Component, OnInit } from '@angular/core';
import {ActivatedRoute} from "@angular/router";
import {ArticlesService} from "../../_services/articles.service";
import {News} from "../../model/model";

@Component({
  selector: 'app-news-full-article',
  templateUrl: './news-full-article.component.html',
  styleUrls: ['./news-full-article.component.css']
})
export class NewsFullArticleComponent implements OnInit {

  public newsId: number;
  public news: News;

  constructor(private route: ActivatedRoute,
              private articlesService: ArticlesService) { }

  ngOnInit(): void {
    this.newsId = <number><unknown>this.route.snapshot.paramMap.get('newsId');
    this.articlesService.getArticle(this.newsId).subscribe(a => {
      // @ts-ignore
      this.news = a;
      console.log(a);
      return;
    })
  }

}
