import {ChangeDetectorRef, Component, Input, OnChanges, OnInit} from '@angular/core';
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
export class MemberAchievementsComponent implements OnInit, OnChanges {

  @Input() public member: Member;
  public memberAchievements: UserAchievement[] = [];

  constructor(private userAchievementService: UserachievementService,
              private achievementService: AchievementsService) { }

  ngOnInit(): void {
  }

  ngOnChanges() {
    this.loadMemberAchievement();
  }

  private loadMemberAchievement(): void {
    this.userAchievementService.getUserAchievementsByUserId(this.member.id).subscribe( memberAchievement => {
      // @ts-ignore
      this.memberAchievements = memberAchievement;
      return;
    })
  }

}
