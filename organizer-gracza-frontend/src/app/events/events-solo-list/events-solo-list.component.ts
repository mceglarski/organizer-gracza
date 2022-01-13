import {ChangeDetectorRef, Component, OnInit} from '@angular/core';
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

  public eventsAll: EventUser[] = [];
  public eventsToShow: EventUser[] = [];
  public eventsFinished: EventUser[] = [];
  public eventsComing: EventUser[] = [];
  public comingSelected = true;
  public finishedSelected = false;
  public allSelected = false;
  public eventUserResults: EventUserResult[];
  public members: Member[];
  public user: User;

  private readonly LEAGUEOFLEGENDS = 'League of Legends';
  private readonly WORLDOFTANKS = 'World of Tanks';
  private readonly VALORANT = 'Valorant';
  private readonly CSGO = 'Counter Strike: Global Offensive';
  private readonly DOTA = 'Dota 2';
  private readonly STARCRAFT = 'StarCraft 2';
  private readonly COD = 'Call of Duty: Warzone';
  private readonly TARKOV = 'Escape from Tarkov';
  private readonly CELESTE = 'Celeste';
  private readonly FORTNITE = 'Fortnite';

  constructor(private eventService: EventsService,
              private eventUserResultsService: EventUserResultsService,
              private membersService: MembersService,
              private accountService: AccountService,
              private cd: ChangeDetectorRef) {
    this.accountService.currentUser$.pipe(take(1)).subscribe(user => this.user = user);
  }

  ngOnInit(): void {
    this.loadSoloEvents();
  }

  private loadSoloEvents(): void {
    this.eventService.getUserEvents().subscribe(events => {
      // @ts-ignore
      this.eventsToShow = events;
      this.eventsToShow
        .sort((a, b) => new Date(a.startDate).getTime() - new Date(b.startDate).getTime());
      this.eventsAll = this.eventsToShow;
      this.eventUserResultsService.getEventsUserResults().subscribe(r => {
        // @ts-ignore
        this.eventUserResults = r;
        this.eventUserResults.forEach(e => {
          if (e.eventUser) {
            // @ts-ignore
            this.eventsFinished.push(this.eventsAll.find(a => a.eventUserId == e.eventUserId));
          }
        });
        this.eventsComing = this.eventsAll.filter(e => !this.eventsFinished.includes(e));
        this.eventsToShow = this.eventsComing;
        // @ts-ignore
        this.eventUserResults = this.eventUserResults.sort((a, b) => b.eventUserResultId - a.eventUserResultId);
        this.membersService.getMembers({pageNumber: 1, pageSize: 99999}).subscribe(m => {
          this.members = m.result;
          this.eventUserResults.forEach(e => {
            // @ts-ignore
            e.eventUserName = this.eventsAll.find(ea => ea.eventUserId == e.eventUserId)?.name;
            // @ts-ignore
            e.user?.photoUrl = this.members.find(f => f.id === e.userId)?.photoUrl;
          });
        });
        return;
      });
    });
  }

  public showFinishedEvents(): void {
    this.eventsToShow = this.eventsFinished;
    this.comingSelected = false;
    this.finishedSelected = true;
    this.allSelected = false;
  }

  public showAllEvents(): void {
    this.eventsToShow = this.eventsAll;
    this.comingSelected = false;
    this.finishedSelected = false;
    this.allSelected = true;
  }

  public showComingEvents(): void {
    this.eventsToShow = this.eventsComing;
    this.comingSelected = true;
    this.finishedSelected = false;
    this.allSelected = false;
  }

  public checkClassName(game: string): string {
    if (game === this.LEAGUEOFLEGENDS) {
      return 'event-solo-list-lol';
    }
    if (game === this.WORLDOFTANKS) {
      return 'event-solo-list-wot';
    }
    if (game === this.VALORANT) {
      return 'event-solo-list-valorant';
    }
    if (game === this.CSGO) {
      return 'event-solo-list-csgo';
    }
    if (game === this.DOTA) {
      return 'event-solo-list-dota';
    }
    if (game === this.STARCRAFT) {
      return 'event-solo-list-starcraft';
    }
    if (game === this.COD) {
      return 'event-solo-list-cod';
    }
    if (game === this.TARKOV) {
      return 'event-solo-list-tarkov';
    }
    if (game === this.CELESTE) {
      return 'event-solo-list-celeste';
    }
    if (game === this.FORTNITE) {
      return 'event-solo-list-fortnite';
    }
    return '';
  }

}
