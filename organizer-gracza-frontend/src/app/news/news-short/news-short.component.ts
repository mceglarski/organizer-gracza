import {Component, OnInit, Output, EventEmitter} from '@angular/core';
import {News} from "../../model/model";
import {ArticlesService} from "../../_services/articles.service";
import {takeUntil} from "rxjs/operators";
@Component({
  selector: 'app-news-short',
  templateUrl: './news-short.component.html',
  styleUrls: ['./news-short.component.css']
})
export class NewsShortComponent implements OnInit {

  @Output()
  public articlesExtended = new EventEmitter<News>();
  public selectedArticle: number = -1;
  public articleArray: News[] = [];

  constructor(private articlesService: ArticlesService) { }

  ngOnInit(): void {
    this.articlesService.getArticles().subscribe(article => {
      // @ts-ignore
      this.articleArray = article;
      this.articleArray.splice(0,2);
      this.sendExtendedNews(this.articleArray[0]);
    });
  }

  public sendExtendedNews(news: News): void {
    this.articlesExtended.emit(news);
  }

}
