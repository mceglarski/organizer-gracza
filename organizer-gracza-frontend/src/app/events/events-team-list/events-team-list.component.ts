import { Component, OnInit } from '@angular/core';
import {EventTeam, EventTeamResult, EventUser, Team} from "../../model/model";
import {EventsService} from "../../_services/events.service";
import {EventTeamsResultsService} from "../../_services/event-teams-results.service";
import {TeamsService} from "../../_services/teams.service";

@Component({
  selector: 'app-events-team-list',
  templateUrl: './events-team-list.component.html',
  styleUrls: ['./events-team-list.component.css']
})
export class EventsTeamListComponent implements OnInit {

  public events: EventTeam[];
  public eventTeamResults: EventTeamResult[];
  public teams: Team[];

  constructor(private eventService: EventsService,
              private eventTeamResultsService: EventTeamsResultsService,
              private teamsService: TeamsService) { }

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
}
