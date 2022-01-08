import { TestBed } from '@angular/core/testing';

import { EventTeamsResultsService } from './event-teams-results.service';
import {HttpClientTestingModule} from "@angular/common/http/testing";

describe('eventsteamresultsService', () => {
  let service: EventTeamsResultsService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule]
    });
    service = TestBed.inject(EventTeamsResultsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
