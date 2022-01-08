import { TestBed } from '@angular/core/testing';

import { EventUserResultsService } from './event-user-results.service';
import {HttpClientTestingModule} from "@angular/common/http/testing";

describe('EventuserresultsService', () => {
  let service: EventUserResultsService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule]
    });
    service = TestBed.inject(EventUserResultsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
