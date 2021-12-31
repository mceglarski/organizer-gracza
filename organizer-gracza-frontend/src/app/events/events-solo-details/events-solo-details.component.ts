import {Component, OnInit} from '@angular/core';
import {EventsService} from "../../_services/events.service";
import {ActivatedRoute} from "@angular/router";
import {EventUser, EventUserRegistration, EventUserResult, Member, User} from "../../model/model";
import {TeamsService} from "../../_services/teams.service";
import {MembersService} from "../../_services/members.service";
import {take} from "rxjs/operators";
import {AccountService} from "../../_services/account.service";
import {ToastrService} from "ngx-toastr";
import {EventUserResultsService} from "../../_services/event-user-results.service";
import {ReminderService} from "../../_services/reminder.service";

@Component({
  selector: 'app-events-solo-details',
  templateUrl: './events-solo-details.component.html',
  styleUrls: ['./events-solo-details.component.css']
})
export class EventsSoloDetailsComponent implements OnInit {

  public event: EventUser;
  public eventId: string;
  public model: { eventUserId: number; userId: number };
  public user: User
  public memberId: number;
  public userRegistrations: EventUserRegistration[];
  public members: Member[] = [];
  public UsersId: number[] = [];
  public eventUserResult: EventUserResult[];
  public eventFinished: EventUserResult;

  constructor(public route: ActivatedRoute,
              private eventsService: EventsService,
              private teamService: TeamsService,
              private memberService: MembersService,
              private accountService: AccountService,
              private reminderService: ReminderService,
              private toastr: ToastrService,
              private eventUserResultsService: EventUserResultsService)
  {
    this.accountService.currentUser$.pipe(take(1)).subscribe(user => {
      this.user = user;
    });
  }

  ngOnInit(): void {
    this.eventId = <string>this.route.snapshot.paramMap.get('eventUserId');
    this.loadEvent();
    if (this.user) {
      this.loadMemberId();
    }
    this.loadEventUserResults();
  }


  public joinEvent(): void {
    this.model = {
      userId: this.memberId,
      eventUserId: this.event.eventUserId
    }
    this.eventsService.addUserEventRegistration(this.model).subscribe(response =>{
      this.reminderService.addReminder({
        title: this.event.name,
        startDate: this.event.startDate,
        userId: this.memberId
      }).subscribe();
      window.location.reload();
      this.toastr.success("Dołączyłeś do wydarzenia")
    }, error => {
      this.toastr.error("Nie udało się dołączyć do wydarzenia")
    })
  }

  private loadEvent(): void {
    // @ts-ignore
    this.eventsService.getUserEvent(this.eventId).subscribe(specifiedEvent => {
      // @ts-ignore
      this.event = specifiedEvent;
      if (this.user) {
        this.loadUserRegistrations();
      }
    });
  }

  private loadEventUserResults(): void {
    this.eventUserResultsService.getEventsUserResults().subscribe(r => {
      // @ts-ignore
      this.eventUserResult = r;
      // @ts-ignore
      this.eventFinished = this.eventUserResult.find(f => f.eventUserId == this.eventId);
    });
  }

  private loadMemberId(): void {
    this.memberService.getMemberIdByUsername(this.user.username).subscribe(memberId =>{
      this.memberId = memberId;
    })
  }

  private loadUserRegistrations(): void {
    this.eventsService.getUserEventRegistration(this.event.eventUserId).subscribe(userRegistration => {
      // @ts-ignore
      this.userRegistrations = userRegistration;
      this.loadUsersIds();
    })
  }

  private loadUsersIds(): void {
    for(let user of this.userRegistrations)
    {
      this.UsersId.push(user.userId);
    }
    this.loadMembers();
  }

  private loadMembers(): void {
    this.UsersId.forEach((value,index) =>{
      this.memberService.getMemberById(value).subscribe(member =>{
        // this.Members = member;
        this.members.push(member);
      });
    })
  }
}
