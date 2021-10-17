import {Component, OnInit, Output, EventEmitter} from '@angular/core';
import {News} from "../../model/model";
@Component({
  selector: 'app-news-short',
  templateUrl: './news-short.component.html',
  styleUrls: ['./news-short.component.css']
})
export class NewsShortComponent implements OnInit {

  @Output()
  public newsExtended = new EventEmitter<News>();

  public newsArray: News[] = [];

  constructor() { }

  ngOnInit(): void {
    this.newsArray = [{
      IdArticles: 1,
      Title: 'Podsumowanie 2021 roku',
      Content: 'Opisujemy najciekawsze momenty e-sportowe 2021 roku',
      PublicationDate: new Date()
    },
    {
      IdArticles: 2,
      Title: 'Zmiany w zasadach rozgrywek CS:GO',
      Content: 'Czekają nas niedługo zmiany w oficjalnych rozgrywkach CS:GO',
      PublicationDate: new Date()
    },
    {
      IdArticles: 3,
      Title: 'DreamHack: znamy miejsce wydarzenia!',
      Content: 'Nareszcie wiemy, że to Warszawa będzie hostem dla DreamHack Event.',
      PublicationDate: new Date()
    }];
    this.sendExtendedNews(this.newsArray[0])
  }

  public sendExtendedNews(news: News): void {
    this.newsExtended.emit(news);
  }

}
