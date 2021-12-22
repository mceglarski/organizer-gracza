import { TestBed } from '@angular/core/testing';

import { EventuserresultsService } from './eventuserresults.service';

describe('EventuserresultsService', () => {
  let service: EventuserresultsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(EventuserresultsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
