import { TestBed } from '@angular/core/testing';

import { BusyService } from './busy.service';
import {HttpClientTestingModule} from "@angular/common/http/testing";

describe('BusyService', () => {
  let service: BusyService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule]
    });
    service = TestBed.inject(BusyService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
