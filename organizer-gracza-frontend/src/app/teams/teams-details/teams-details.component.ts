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

  public team: Team;
  public user: User;
  public model = {};
  public memberId: number;
  public teamUsers: TeamUser[];


  constructor(public route: ActivatedRoute,
              private teamService: TeamsService,
              private memberService: MembersService,
              private accountService: AccountService,
              private toastr: ToastrService)
  {
      this.accountService.currentUser$.pipe(take(1)).subscribe(user => {
      this.user = user;
    })
  }

  ngOnInit(): void {
    this.loadTeam();
    this.loadMember();
  }

  public joinTeam(): void {
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

  private loadTeam(): void {
    // @ts-ignore
    this.teamService.getTeamByName(this.route.snapshot.paramMap.get('name')).subscribe(specifiedTeam => {
      // @ts-ignore
      this.team = specifiedTeam;
      this.loadUsersInTeam();
    })
  }

  private loadMember(): void {
    this.memberService.getMemberIdByUsername(this.user.username).subscribe(memberId =>{
      this.memberId = memberId;
    })
  }

  private loadUsersInTeam(): void {
    this.teamService.getUsersInTeam(this.team.teamId).subscribe(teamUsers => {
      // @ts-ignore
      this.teamUsers = teamUsers;
      return;
    });
  }

}
