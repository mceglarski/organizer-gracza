import { Component, OnInit } from '@angular/core';
import {EventTeam, EventTeamResult, Team, User} from "../../model/model";
import {EventsService} from "../../_services/events.service";
import {EventTeamsResultsService} from "../../_services/event-teams-results.service";
import {TeamsService} from "../../_services/teams.service";
import {AccountService} from "../../_services/account.service";
import {take} from "rxjs/operators";

@Component({
  selector: 'app-events-team-list',
  templateUrl: './events-team-list.component.html',
  styleUrls: ['./events-team-list.component.css']
})
export class EventsTeamListComponent implements OnInit {

  public eventsToShow: EventTeam[] = [];
  public eventsAll: EventTeam[] = [];
  public eventsFinished: EventTeam[] = [];
  public eventsComing: EventTeam[] = [];
  public comingSelected = true;
  public finishedSelected = false;
  public allSelected = false;
  public eventTeamResults: EventTeamResult[];
  public teams: Team[];
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
              private eventTeamResultsService: EventTeamsResultsService,
              private teamsService: TeamsService,
              private accountService: AccountService) {
    this.accountService.currentUser$.pipe(take(1)).subscribe(user => this.user = user);
  }

  ngOnInit(): void {
    this.loadTeamEvents();
  }

  private loadTeamEvents(): void {
    this.eventService.getTeamEvents().subscribe(events => {
      // @ts-ignore
      this.eventsToShow = events;
      this.eventsToShow
        .sort((a, b) => new Date(a.startDate).getTime() - new Date(b.startDate).getTime());
      this.eventsAll = this.eventsToShow;
      this.eventTeamResultsService.getEventsTeamResults().subscribe(r => {
        // @ts-ignore
        this.eventTeamResults = r;
        this.eventTeamResults.forEach(e => {
          if (e.eventTeam) {
            // @ts-ignore
            this.eventsFinished.push(this.eventsAll.find(a => a.eventTeamId == e.eventTeamId));
          }
        });
        this.eventsComing = this.eventsAll.filter(e => !this.eventsFinished.includes(e));
        this.eventsToShow = this.eventsComing;
        // @ts-ignore
        this.eventTeamResults = this.eventTeamResults.sort((a, b) => b.eventTeamResultId - a.eventTeamResultId);
        this.teamsService.getTeams().subscribe(m => {
          // @ts-ignore
          this.teams = m;
          this.eventTeamResults.forEach(e => {
            // @ts-ignore
            e.eventTeamName = this.eventsAll.find(f => f.eventTeamId === e.eventTeamId).name;
          });
        });

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
