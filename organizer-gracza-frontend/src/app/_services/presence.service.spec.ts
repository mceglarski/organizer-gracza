import { TestBed } from '@angular/core/testing';

import { PresenceService } from './presence.service';
import {HttpClientTestingModule} from "@angular/common/http/testing";

describe('PresenceService', () => {
  let service: PresenceService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule]
    });
    service = TestBed.inject(PresenceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
