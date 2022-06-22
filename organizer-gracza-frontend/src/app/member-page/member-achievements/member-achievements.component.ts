import {Component, Input, OnChanges} from '@angular/core';
import {Member, UserAchievement} from "../../model/model";
import {AchievementsService} from "../../_services/achievements.service";
import {UserachievementService} from "../../_services/userachievement.service";

@Component({
  selector: 'app-member-achievements',
  templateUrl: './member-achievements.component.html',
  styleUrls: ['./member-achievements.component.css']
})
export class MemberAchievementsComponent implements OnChanges {

  @Input() public member: Member;
  public memberAchievements: UserAchievement[] = [];

  constructor(private userAchievementService: UserachievementService,
              private achievementService: AchievementsService) {
  }


  ngOnChanges() {
    this.loadMemberAchievement();
  }

  private loadMemberAchievement(): void {
    this.userAchievementService.getUserAchievementsByUserId(this.member.id).subscribe(memberAchievement => {
      // @ts-ignore
      this.memberAchievements = memberAchievement;

    })
  }

}
