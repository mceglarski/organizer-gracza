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

  public events: EventTeam[];
  public eventTeamResults: EventTeamResult[];
  public teams: Team[];
  public user: User;

  private LEAGUEOFLEGENDS = 'League of Legends';
  private WORLDOFTANKS = 'World of Tanks';
  private VALORANT = 'Valorant';
  private CSGO = 'Counter Strike: Global Offensive';
  private DOTA = 'Dota 2';
  private STARCRAFT = 'StarCraft 2';
  private COD = 'Call of Duty: Warzone';
  private TARKOV = 'Escape from Tarkov';
  private CELESTE = 'Celeste';
  private FORTNITE = 'Fortnite';

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
      this.events = events;
      this.events = this.events
        .sort((a, b) => new Date(a.startDate).getTime() - new Date(b.startDate).getTime());

      this.eventTeamResultsService.getEventsTeamResults().subscribe(r => {
        // @ts-ignore
        this.eventTeamResults = r;
        // @ts-ignore
        this.eventTeamResults = this.eventTeamResults.sort((a, b) => b.eventTeamResultId - a.eventTeamResultId);
        this.teamsService.getTeams().subscribe(m => {
          // @ts-ignore
          this.teams = m;
          this.eventTeamResults.forEach(e => {
            // @ts-ignore
            e.eventTeamName = this.events.find(f => f.eventTeamId === e.eventTeamId).name;
          });
        });
        return;
      });
    });
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
