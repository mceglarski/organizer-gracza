import { TestBed } from '@angular/core/testing';

import { EventTeamsResultsService } from './event-teams-results.service';

describe('eventsteamresultsService', () => {
  let service: EventTeamsResultsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(EventTeamsResultsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
