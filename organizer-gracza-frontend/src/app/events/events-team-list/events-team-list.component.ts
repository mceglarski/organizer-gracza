import { Component, OnInit } from '@angular/core';
import {EventTeam, EventUser} from "../../model/model";
import {EventsService} from "../../_services/events.service";

@Component({
  selector: 'app-events-team-list',
  templateUrl: './events-team-list.component.html',
  styleUrls: ['./events-team-list.component.css']
})
export class EventsTeamListComponent implements OnInit {
  // @ts-ignore
  events: EventTeam[];

  constructor(private eventService: EventsService) { }

  ngOnInit(): void {
    this.loadTeamEvents();
  }

  loadTeamEvents(){
    this.eventService.getTeamEvents().subscribe(events => {
      // @ts-ignore
      this.events = events;
    })
  }
}
