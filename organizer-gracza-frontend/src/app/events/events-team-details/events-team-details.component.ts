import { Component, OnInit } from '@angular/core';
import {EventTeam, EventTeamRegistration, EventTeamResult, Team, TeamUser, User} from "../../model/model";
import {EventsService} from "../../_services/events.service";
import {ActivatedRoute} from "@angular/router";
import {TeamsService} from "../../_services/teams.service";
import {take} from "rxjs/operators";
import {AccountService} from "../../_services/account.service";
import {FormControl, FormGroup, Validators} from "@angular/forms";
import {MembersService} from "../../_services/members.service";
import {ToastrService} from "ngx-toastr";
import {NgbModal} from "@ng-bootstrap/ng-bootstrap";
import {EventTeamsResultsService} from "../../_services/event-teams-results.service";

@Component({
  selector: 'app-events-team-details',
  templateUrl: './events-team-details.component.html',
  styleUrls: ['./events-team-details.component.css']
})
export class EventsTeamDetailsComponent implements OnInit {

  public teams: TeamUser[];
  public memberTeamsRegistrated: TeamUser[] = [];
  public eventId: number;
  public event: EventTeam;
  public user: User
  public newTeamRegistrationForm: FormGroup;
  public deleteTeamRegistrationForm: FormGroup = new FormGroup({
    teamId: new FormControl('', Validators.required),
  });
  public model: { eventTeamId: number; teamId: number };
  public teamRegistrations: EventTeamRegistration[];
  public eventTeamResults: EventTeamResult[];
  public eventFinished: EventTeamResult;


  constructor(public route: ActivatedRoute,
              private eventsService: EventsService,
              private teamService: TeamsService,
              private accountService: AccountService,
              private memberService: MembersService,
              private eventTeamsResultsService: EventTeamsResultsService,
              private toastr: ToastrService,
              private modalService: NgbModal) {
    this.accountService.currentUser$.pipe(take(1)).subscribe(user => {
      this.user = user;
    })
  }

  ngOnInit(): void {
    // @ts-ignore
    this.eventId = this.route.snapshot.paramMap.get('eventTeamId');
    this.loadEvent();
    if (this.user) {
      this.initializeAddTeamForEvent();
    }
    this.loadEventTeamResults();
  }

  public joinEvent(): void {
    this.model = {
      teamId: this.newTeamRegistrationForm.value.teamId,
      eventTeamId: this.event.eventTeamId
    }
    this.eventsService.addTeamEventRegistration(this.model).subscribe(response => {
      window.location.reload();
      this.toastr.success("Zapisałeś drużyne do wydarzenia");
    }, error => {
      this.toastr.error("Wybrana drużyna bierze już udział w wydarzeniu");
    })
  }

  public deleteEventRegistration(): void {
    const deletedTeamId: number = this.deleteTeamRegistrationForm.value.teamId;
    this.eventsService.deleteTeamEventRegistration(this.eventId, deletedTeamId).subscribe(r => {
      window.location.reload();
      this.toastr.success('Wypisano drużynę z wydarzenia');
    }, error => {
      console.log(error);
    })
  }

  public open(content: any): void {
    this.modalService.open(content, {ariaLabelledBy: 'modal-basic-title'});
  }

  private loadEvent(): void {
    // @ts-ignore
    this.eventsService.getTeamEvent(this.eventId).subscribe(specifiedEvent => {
      // @ts-ignore
      this.event = specifiedEvent;
      if (this.user) {
        this.loadTeamRegistrations();
      }
    });
  }

  private loadEventTeamResults(): void {
    this.eventTeamsResultsService.getEventsTeamResults().subscribe(r => {
      // @ts-ignore
      this.eventTeamResults = r;
      // @ts-ignore
      this.eventFinished = this.eventTeamResults.find(f => f.eventTeamId == this.eventId);
    });
  }

  private loadTeamRegistrations(): void {
    this.eventsService.getTeamEventRegistration(this.event.eventTeamId).subscribe(teamRegistrations => {
      // @ts-ignore
      this.teamRegistrations = teamRegistrations;
      // @ts-ignore
      this.teamService.getTeamsForUser(this.user.username).subscribe(teams => {
        // @ts-ignore
        this.teams = teams;
        this.teams.forEach(team => {
          if (this.teamRegistrations.find(t => t.teamId == team.teamId)) {
            this.memberTeamsRegistrated.push(team);
          }
        });
        console.log(this.memberTeamsRegistrated);
      });
    })
  }

  private initializeAddTeamForEvent(): void {
    this.newTeamRegistrationForm = new FormGroup({
      teamId: new FormControl('', Validators.required),
    });
  }

}
