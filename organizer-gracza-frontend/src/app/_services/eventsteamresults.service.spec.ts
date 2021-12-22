import { TestBed } from '@angular/core/testing';

import { eventteamsresultsService } from './eventteamsresults.service';

describe('eventsteamresultsService', () => {
  let service: eventteamsresultsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(eventteamsresultsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
