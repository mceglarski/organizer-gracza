import { Component, OnInit } from '@angular/core';
import {EventTeam, EventUser, Team, User} from "../../model/model";
import {EventsService} from "../../_services/events.service";
import {ActivatedRoute} from "@angular/router";
import {TeamsService} from "../../_services/teams.service";
import {take} from "rxjs/operators";
import {AccountService} from "../../_services/account.service";
import {FormControl, FormGroup, Validators} from "@angular/forms";
import {MembersService} from "../../_services/members.service";
import {ToastrService} from "ngx-toastr";
import {NgbModal} from "@ng-bootstrap/ng-bootstrap";

@Component({
  selector: 'app-events-team-details',
  templateUrl: './events-team-details.component.html',
  styleUrls: ['./events-team-details.component.css']
})
export class EventsTeamDetailsComponent implements OnInit {

  // @ts-ignore
  teams: Team[];
  // @ts-ignore
  event: EventTeam;
  // @ts-ignore
  user: User
  // @ts-ignore
  newTeamRegistrationForm: FormGroup;
  // @ts-ignore
  model: { eventTeamId: number; teamId: number };


  constructor(private eventsService: EventsService, public route: ActivatedRoute, private teamService: TeamsService,
              private accountService: AccountService, private memberService: MembersService,
              private toastr: ToastrService,  private modalService: NgbModal) {
    this.accountService.currentUser$.pipe(take(1)).subscribe(user => {
      this.user = user;
    })
  }

  ngOnInit(): void {
    this.loadEvent();
    this.loadTeamsForUser();
    this.initializeAddTeamForEvent();
  }

  open(content: any) {
    this.modalService.open(content, {ariaLabelledBy: 'modal-basic-title'});
  }

  loadEvent(){
    // @ts-ignore
    this.eventsService.getTeamEvent(this.route.snapshot.paramMap.get('eventTeamId')).subscribe(specifiedEvent => {
      // @ts-ignore
      this.event = specifiedEvent;
    })
  }

  loadTeamsForUser(){
    // @ts-ignore
    this.teamService.getTeamsForUser(this.user.username).subscribe(teams => {
      // @ts-ignore
      this.teams = teams;
    })
  }

  joinEvent(){
    this.model = {
      teamId: this.newTeamRegistrationForm.value.teamId,
      eventTeamId: this.event.eventTeamId
    }
    this.eventsService.addTeamEventRegistration(this.model).subscribe(response =>{
      this.toastr.success("Zapisałeś drużyne do wydarzenia")
    }, error => {
      this.toastr.error("Nie udało się dołączyć do wydarzenia")
    })
    console.log(this.teams);
  }

  initializeAddTeamForEvent(){
    this.newTeamRegistrationForm = new FormGroup({
      teamId: new FormControl('', Validators.required),
    })
  }

}
