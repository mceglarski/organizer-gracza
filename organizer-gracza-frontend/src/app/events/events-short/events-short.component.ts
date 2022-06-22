import {Component, OnInit} from '@angular/core';
import {EventsService} from "../../_services/events.service";

@Component({
  selector: 'app-events-short',
  templateUrl: './events-short.component.html',
  styleUrls: ['./events-short.component.css']
})
export class EventsShortComponent implements OnInit {

  public events: any = [];
  public responsiveOptions: any;

  constructor(private eventsService: EventsService) {
    this.responsiveOptions = [
      {
        breakpoint: '1024px',
        numVisible: 3,
        numScroll: 3
      },
      {
        breakpoint: '768px',
        numVisible: 2,
        numScroll: 2
      },
      {
        breakpoint: '560px',
        numVisible: 1,
        numScroll: 1
      }
    ];
  }

  ngOnInit(): void {
    this.eventsService.getUserEvents().subscribe(event => {
      this.addUrlToUserEventArray(event);
      this.events = this.events.concat(event);
    });
    this.eventsService.getTeamEvents().subscribe(event => {
      this.addUrlToTeamEventArray(event);
      this.events = this.events.concat(event);
    });

  }

  private addUrlToUserEventArray(event: any): void {
    event.forEach((e: any, index: number) => {
      e = {...e,
      eventUrl: '/events/eventsuser/'+e.eventUserId};
      event[index] = e;

    });
  }

  private addUrlToTeamEventArray(event: any): void {
    event.forEach((e: any, index: number) => {
      e = {...e,
        eventUrl: '/events/eventsteam/'+e.eventTeamId};
      event[index] = e;

    });
  }

}
