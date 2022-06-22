import {Component, Input} from '@angular/core';
import {News} from "../../model/model";

@Component({
  selector: 'app-news-extended',
  templateUrl: './news-extended.component.html',
  styleUrls: ['./news-extended.component.css']
})
export class NewsExtendedComponent {

  @Input()
  public newsInput?: News;

}
