import { Component, OnInit } from '@angular/core';
import {MemberContentComponent} from "../member-content/member-content.component";
import {Achievements, Member} from "../../model/model";
import {AchievementsService} from "../../_services/achievements.service";
import {ActivatedRoute} from "@angular/router";

@Component({
  selector: 'app-member-achievements',
  templateUrl: './member-achievements.component.html',
  styleUrls: ['./member-achievements.component.css']
})
export class MemberAchievementsComponent implements OnInit {

  public memberAchievement: Achievements[] = [];
  public member: Member;


  constructor(public memberContent: MemberContentComponent,
              private achievementService: AchievementsService,
              private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.route.data.subscribe(data => {
      this.member = data.member;
    });
    this.loadMemberAchievement();
  }

  private loadMemberAchievement(): void {
    console.log(this.member.Id)
    this.achievementService.getAchievementsByUserId(this.member.Id).subscribe(a => {
      // @ts-ignore
      this.memberAchievement = a;
      console.log(a);
    })
  }

}
