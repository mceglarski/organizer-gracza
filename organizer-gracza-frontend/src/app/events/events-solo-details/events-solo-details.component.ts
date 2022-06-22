import {ChangeDetectorRef, Component, OnInit} from '@angular/core';
import {EventsService} from "../../_services/events.service";
import {ActivatedRoute} from "@angular/router";
import {EventUser, EventUserRegistration, EventUserResult, Member, Reminder, User} from "../../model/model";
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
  public eventId: number;
  public model: { eventUserId: number; userId: number };
  public user: User
  public memberId: number;
  public userRegistrations: EventUserRegistration[];
  public members: Member[] = [];
  public registeredMembers: Member[] = [];
  // public usersId: number[] = [];
  public eventUserResult: EventUserResult[];
  public eventFinished: EventUserResult;
  public isMemberSigned: boolean = false;

  private memberReminders: Reminder[] = [];
  private reminderToDelete: number;

  constructor(public route: ActivatedRoute,
              private eventsService: EventsService,
              private teamService: TeamsService,
              private memberService: MembersService,
              private accountService: AccountService,
              private reminderService: ReminderService,
              private toastr: ToastrService,
              private eventUserResultsService: EventUserResultsService,
              private cd: ChangeDetectorRef)
  {
    this.accountService.currentUser$.pipe(take(1)).subscribe(user => {
      this.user = user;
    });
  }

  ngOnInit(): void {
    // @ts-ignore
    this.eventId = this.route.snapshot.paramMap.get('eventUserId');
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
    this.eventsService.addUserEventRegistration(this.model).subscribe(() =>{
      this.reminderService.addReminder({
        title: this.event.name,
        startDate: this.event.startDate,
        userId: this.memberId
      }).subscribe();
      window.location.reload();
      this.toastr.success("Dołączyłeś do wydarzenia");
    }, () => {
      this.toastr.error("Jesteś już zapisany na to wydarzenie");
    })
  }

  public resignEvent(): void {
    this.eventsService.deleteUserEventRegistration(this.eventId, this.memberId).subscribe(() => {
      this.toastr.success('Zgłoszenie zostało wycofane');
      this.reminderService.getRemindsForUserById(this.memberId).subscribe(r => {
        // @ts-ignore
        this.memberReminders = r;
        // @ts-ignore
        this.reminderToDelete = this.memberReminders.find(r => r.title === this.event.name).reminderId;
        this.reminderService.deleteReminder(this.reminderToDelete).subscribe();
      });
      window.location.reload();
    }, error => {
      this.toastr.error('Wystąpił błąd z wycofaniem zgłoszenia');
      console.log(error);
    });
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
    });
  }

  private loadUserRegistrations(): void {
    this.eventsService.getUserEventRegistration(this.event.eventUserId).subscribe(userRegistration => {
      // @ts-ignore
      this.userRegistrations = userRegistration;
      this.cd.detectChanges();
      this.loadMembers();
      this.cd.detectChanges();
    });
  }

  private loadMembers(): void {
    this.memberService.getMembers({pageNumber: 1, pageSize: 99999}).subscribe(members => {
      this.members = members.result;
      this.members.forEach(m => {
        if (this.userRegistrations.find(u => u.userId === m.id)) {
          this.registeredMembers.push(m);
          this.isMemberSigned = !!this.registeredMembers.find(mm => mm.id === this.memberId);
          this.cd.detectChanges();
        }
        this.cd.detectChanges();
      });
      this.cd.detectChanges();
    });
    this.cd.detectChanges();
  }

}
