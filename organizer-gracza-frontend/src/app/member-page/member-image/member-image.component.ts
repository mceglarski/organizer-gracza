import { Component, OnInit } from '@angular/core';
import {MemberContentComponent} from "../member-content/member-content.component";

@Component({
  selector: 'app-member-image',
  templateUrl: './member-image.component.html',
  styleUrls: ['./member-image.component.css']
})
export class MemberImageComponent implements OnInit {

  constructor(public memberContent: MemberContentComponent) { }

  ngOnInit(): void {
  }

}
