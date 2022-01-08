import { TestBed } from '@angular/core/testing';

import { SteamService } from './steam.service';
import {HttpClientTestingModule} from "@angular/common/http/testing";

describe('SteamService', () => {
  let service: SteamService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule]
    });
    service = TestBed.inject(SteamService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
