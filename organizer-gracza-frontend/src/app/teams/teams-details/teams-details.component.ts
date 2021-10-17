import {Component, OnInit} from '@angular/core';
import {ActivatedRoute} from "@angular/router";
import {TeamsService} from "../../_services/teams.service";
import {MembersService} from "../../_services/members.service";
import {AccountService} from "../../_services/account.service";
import {take} from "rxjs/operators";
import {Member, PagintationParams, Participiant, Team, TeamUser, User} from "../../model/model";
import {ToastrService} from "ngx-toastr";

@Component({
  selector: 'app-teams-details',
  templateUrl: './teams-details.component.html',
  styleUrls: ['./teams-details.component.css']
})
export class TeamsDetailsComponent implements OnInit {
  // @ts-ignore
  team: Team;
  // @ts-ignore
  user: User;
  // @ts-ignore
  model = {};
  // @ts-ignore
  memberId: number;
  // @ts-ignore
  teamUsers: TeamUser[];


  constructor(private teamService: TeamsService, public route: ActivatedRoute, private memberService: MembersService,
              private accountService: AccountService, private toastr: ToastrService)
  {
      this.accountService.currentUser$.pipe(take(1)).subscribe(user => {
      this.user = user;
    })
  }

  ngOnInit(): void {
    this.loadTeam();
    this.loadMember();
  }

  loadTeam() {
    // @ts-ignore
    this.teamService.getTeamByName(this.route.snapshot.paramMap.get('name')).subscribe(specifiedTeam => {
      // @ts-ignore
      this.team = specifiedTeam;
      this.loadUsersInTeam();
    })
  }

  loadMember(){
    this.memberService.getMemberIdByUsername(this.user.username).subscribe(memberId =>{
      this.memberId = memberId;
    })
  }

  loadUsersInTeam(){
    this.teamService.getUsersInTeam(this.team.teamId).subscribe(teamUsers => {
      // @ts-ignore
      this.teamUsers = teamUsers;
    })
  }


  joinTeam(){
    this.model = {
      userId: this.memberId,
      teamId: this.team.teamId
    }
    this.teamService.addTeamUser(this.model).subscribe(response =>{
      this.toastr.success("Dołączyłeś do drużyny")
    }, error => {
      this.toastr.error("Nie udało się dołączyć do drużyny")
    })
  }
}
