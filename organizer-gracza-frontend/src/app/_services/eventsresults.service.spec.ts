import { TestBed } from '@angular/core/testing';

import { EventsresultsService } from './eventsresults.service';

describe('EventsresultsService', () => {
  let service: EventsresultsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(EventsresultsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
