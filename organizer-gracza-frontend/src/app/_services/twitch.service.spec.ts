import { TestBed } from '@angular/core/testing';

import { TwitchService } from './twitch.service';
import {HttpClientTestingModule} from "@angular/common/http/testing";

describe('TwitchService', () => {
  let service: TwitchService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule]
    });
    service = TestBed.inject(TwitchService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
