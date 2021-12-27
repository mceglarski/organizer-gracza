import { TestBed } from '@angular/core/testing';

import { EventUserResultsService } from './event-user-results.service';

describe('EventuserresultsService', () => {
  let service: EventUserResultsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(EventUserResultsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
