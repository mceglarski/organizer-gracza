import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-news-short',
  templateUrl: './news-short.component.html',
  styleUrls: ['./news-short.component.css']
})
export class NewsShortComponent implements OnInit {

  public newsArray: string[] = [];

  constructor() { }

  ngOnInit(): void {
    this.newsArray = ['news1', 'news2', 'news3'];
  }

}
