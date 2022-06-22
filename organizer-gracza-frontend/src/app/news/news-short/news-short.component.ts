import {Component, EventEmitter, OnInit, Output} from '@angular/core';
import {News} from "../../model/model";
import {ArticlesService} from "../../_services/articles.service";

@Component({
  selector: 'app-news-short',
  templateUrl: './news-short.component.html',
  styleUrls: ['./news-short.component.css']
})
export class NewsShortComponent implements OnInit {

  @Output()
  public articlesExtended = new EventEmitter<News>();
  public selectedArticle: number = 0;
  public articleArray: News[] = [];

  constructor(private articlesService: ArticlesService) {
  }

  ngOnInit(): void {
    this.articlesService.getArticles().subscribe(article => {
      // @ts-ignore
      this.articleArray = article;
      this.articleArray.sort((a, b) => {
        return new Date(b.publicationDate).getTime() - new Date(a.publicationDate).getTime();
      });
      this.articleArray = this.articleArray.slice(0, 3);
      this.sendExtendedNews(this.articleArray[0]);
    });
  }

  public sendExtendedNews(news: News): void {
    this.articlesExtended.emit(news);
  }

}
