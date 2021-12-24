import { Component, OnInit } from '@angular/core';
import {EventTeam, EventTeamRegistration, Team, User} from "../../model/model";
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

  public teams: Team[];
  public event: EventTeam;
  public user: User
  public newTeamRegistrationForm: FormGroup;
  public model: { eventTeamId: number; teamId: number };
  public teamRegistrations: EventTeamRegistration[];


  constructor(public route: ActivatedRoute,
              private eventsService: EventsService,
              private teamService: TeamsService,
              private accountService: AccountService,
              private memberService: MembersService,
              private toastr: ToastrService,
              private modalService: NgbModal) {
    this.accountService.currentUser$.pipe(take(1)).subscribe(user => {
      this.user = user;
    })
  }

  ngOnInit(): void {
    this.loadEvent();
    if (this.user) {
      this.loadTeamsForUser();
      this.initializeAddTeamForEvent();
    }
  }

  public joinEvent(): void {
    this.model = {
      teamId: this.newTeamRegistrationForm.value.teamId,
      eventTeamId: this.event.eventTeamId
    }
    this.eventsService.addTeamEventRegistration(this.model).subscribe(response =>{
      this.toastr.success("Zapisałeś drużyne do wydarzenia")
    }, error => {
      this.toastr.error("Nie udało się dołączyć do wydarzenia")
    })
  }

  public open(content: any): void {
    this.modalService.open(content, {ariaLabelledBy: 'modal-basic-title'});
  }

  private loadEvent(): void {
    // @ts-ignore
    this.eventsService.getTeamEvent(this.route.snapshot.paramMap.get('eventTeamId')).subscribe(specifiedEvent => {
      // @ts-ignore
      this.event = specifiedEvent;
      if (this.user) {
        this.loadTeamRegistrations();
      }
    })
  }

  private loadTeamRegistrations(): void {
    this.eventsService.getTeamEventRegistration(this.event.eventTeamId).subscribe(teamRegistrations => {
      // @ts-ignore
      this.teamRegistrations = teamRegistrations;
    })
  }

  private loadTeamsForUser(): void {
    // @ts-ignore
    this.teamService.getTeamsForUser(this.user.username).subscribe(teams => {
      // @ts-ignore
      this.teams = teams;
    })
  }

  private initializeAddTeamForEvent(): void {
    this.newTeamRegistrationForm = new FormGroup({
      teamId: new FormControl('', Validators.required),
    })
  }

}
