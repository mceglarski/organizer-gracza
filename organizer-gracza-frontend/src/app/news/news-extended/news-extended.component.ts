import {Component, Input, OnInit} from '@angular/core';
import {News} from "../../model/model";

@Component({
  selector: 'app-news-extended',
  templateUrl: './news-extended.component.html',
  styleUrls: ['./news-extended.component.css']
})
export class NewsExtendedComponent implements OnInit {

  @Input()
  public newsInput?: News;

  constructor() { }

  ngOnInit(): void {
  }

}
