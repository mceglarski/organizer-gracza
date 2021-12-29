import { Component, OnInit } from '@angular/core';
import {EventsService} from "../../_services/events.service";
import {EventUser, EventUserResult, Member, User} from "../../model/model";
import {EventUserResultsService} from "../../_services/event-user-results.service";
import {MembersService} from "../../_services/members.service";
import {take} from "rxjs/operators";
import {AccountService} from "../../_services/account.service";

@Component({
  selector: 'app-events-solo-list',
  templateUrl: './events-solo-list.component.html',
  styleUrls: ['./events-solo-list.component.css']
})
export class EventsSoloListComponent implements OnInit {

  public events: EventUser[];
  public eventUserResults: EventUserResult[];
  public members: Member[];
  public user: User;

  constructor(private eventService: EventsService,
              private eventUserResultsService: EventUserResultsService,
              private membersService: MembersService,
              private accountService: AccountService) {
    this.accountService.currentUser$.pipe(take(1)).subscribe(user => this.user = user);
  }

  ngOnInit(): void {
    this.loadSoloEvents();
  }

  private loadSoloEvents(): void {
    this.eventService.getUserEvents().subscribe(events => {
      // @ts-ignore
      this.events = events;
      this.events = this.events
        .sort((a, b) => new Date(a.startDate).getTime() - new Date(b.startDate).getTime());
      this.eventUserResultsService.getEventsUserResults().subscribe(r => {
        // @ts-ignore
        this.eventUserResults = r;
        // @ts-ignore
        this.eventUserResults = this.eventUserResults.sort((a, b) => b.eventUserResultId - a.eventUserResultId);
        this.membersService.getMembers({pageNumber: 1, pageSize: 99999}).subscribe(m => {
          this.members = m.result;
          this.eventUserResults.forEach(e => {
            // @ts-ignore
            e.eventUserName = this.events.find(f => f.eventUserId === e.eventUserId)?.name;
            // @ts-ignore
            e.user?.photoUrl = this.members.find(f => f.id === e.userId)?.photoUrl;
          });
        });
        return;
      });
    });
  }

}
