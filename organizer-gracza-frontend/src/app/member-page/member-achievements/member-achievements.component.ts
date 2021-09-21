import { Component, OnInit } from '@angular/core';
import {MemberContentComponent} from "../member-content/member-content.component";

@Component({
  selector: 'app-member-achievements',
  templateUrl: './member-achievements.component.html',
  styleUrls: ['./member-achievements.component.css']
})
export class MemberAchievementsComponent implements OnInit {

  constructor(public memberContent: MemberContentComponent) { }

  ngOnInit(): void {
  }

}
