import {Component, OnInit} from '@angular/core';
import {ActivatedRoute} from "@angular/router";
import {TeamsService} from "../../_services/teams.service";
import {MembersService} from "../../_services/members.service";
import {AccountService} from "../../_services/account.service";
import {take} from "rxjs/operators";
import {Member, PagintationParams, Participiant, User} from "../../model/model";
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
  members: Member[];
  // @ts-ignore
  memberId: number;
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
    this.loadTeamMembers();
  }

  loadTeam() {
    // @ts-ignore
    this.teamService.getTeamByName(this.route.snapshot.paramMap.get('name')).subscribe(specifiedTeam => {
      // @ts-ignore
      this.team = specifiedTeam;
    })
  }

  loadMember(){
    this.memberService.getMemberById(this.user.username).subscribe(memberId =>{
      this.memberId = memberId;
    })
  }

  loadTeamMembers(){
    this.teamService.getTeamUser(1).subscribe(response => {
      // @ts-ignore
      this.members = response.result;
    });
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
