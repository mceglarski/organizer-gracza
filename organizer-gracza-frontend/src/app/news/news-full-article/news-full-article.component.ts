import { Component, OnInit } from '@angular/core';
import {ActivatedRoute} from "@angular/router";

@Component({
  selector: 'app-news-full-article',
  templateUrl: './news-full-article.component.html',
  styleUrls: ['./news-full-article.component.css']
})
export class NewsFullArticleComponent implements OnInit {

  public newsId: string | null;

  constructor(private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.newsId = this.route.snapshot.paramMap.get('newsId');
  }

}
