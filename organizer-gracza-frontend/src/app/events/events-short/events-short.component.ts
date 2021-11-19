import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-events-short',
  templateUrl: './events-short.component.html',
  styleUrls: ['./events-short.component.css',
    '../../../../node_modules/primeng/resources/themes/arya-green/theme.css',
    '../../../../node_modules/primeng/resources/primeng.min.css',
    '../../../../node_modules/primeicons/primeicons.css',]
})
export class EventsShortComponent implements OnInit {

  public events: string[] = [];
  public responsiveOptions: any;

  constructor() {
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
    this.events = ['event1', 'event2', 'event3','event4', 'event5', 'event6'];
  }

}
