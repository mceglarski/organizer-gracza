import { Component, OnInit } from '@angular/core';
import {EventsService} from "../../_services/events.service";
import {EventUser} from "../../model/model";

@Component({
  selector: 'app-events-solo-list',
  templateUrl: './events-solo-list.component.html',
  styleUrls: ['./events-solo-list.component.css']
})
export class EventsSoloListComponent implements OnInit {

  public events: EventUser[];

  constructor(private eventService: EventsService) { }

  ngOnInit(): void {
    this.loadSoloEvents();
  }

  loadSoloEvents(){
    this.eventService.getUserEvents().subscribe(events => {
      // @ts-ignore
      this.events = events;
    })
  }
}
