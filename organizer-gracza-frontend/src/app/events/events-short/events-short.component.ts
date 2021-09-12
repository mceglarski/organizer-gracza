import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-events-short',
  templateUrl: './events-short.component.html',
  styleUrls: ['./events-short.component.css']
})
export class EventsShortComponent implements OnInit {

  public events: string[] = [];

  constructor() { }

  ngOnInit(): void {
    this.events = ['event1', 'event2', 'event3','event4', 'event5', 'event6'];
  }

}
