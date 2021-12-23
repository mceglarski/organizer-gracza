import { Component, OnInit } from '@angular/core';
import {MemberContentComponent} from "../member-content/member-content.component";
import {Achievements, Member, UserAchievement} from "../../model/model";
import {AchievementsService} from "../../_services/achievements.service";
import {ActivatedRoute} from "@angular/router";
import {UserachievementService} from "../../_services/userachievement.service";

@Component({
  selector: 'app-member-achievements',
  templateUrl: './member-achievements.component.html',
  styleUrls: ['./member-achievements.component.css']
})
export class MemberAchievementsComponent implements OnInit {

  public memberAchievements: UserAchievement[] = [];
  public member: Member;


  constructor(public memberContent: MemberContentComponent,
              private userAchievementService: UserachievementService,
              private achievementService: AchievementsService,
              private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.route.data.subscribe(data => {
      this.member = data.member;
    });
    this.loadMemberAchievement();
  }

  private loadMemberAchievement(): void {
    this.userAchievementService.getUserAchievementsByUserId(this.member.id).subscribe(a => {
      // @ts-ignore
      this.memberAchievements = a;
    })
  }
}
