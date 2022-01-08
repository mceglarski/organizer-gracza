import { TestBed } from '@angular/core/testing';

import { ReminderService } from './reminder.service';
import {HttpClientTestingModule} from "@angular/common/http/testing";

describe('ReminderService', () => {
  let service: ReminderService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule]
    });
    service = TestBed.inject(ReminderService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
