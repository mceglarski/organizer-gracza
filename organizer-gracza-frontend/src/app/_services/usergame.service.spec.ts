import { TestBed } from '@angular/core/testing';

import { UsergameService } from './usergame.service';
import {HttpClientTestingModule} from "@angular/common/http/testing";

describe('UsergameService', () => {
  let service: UsergameService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule]
    });
    service = TestBed.inject(UsergameService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
