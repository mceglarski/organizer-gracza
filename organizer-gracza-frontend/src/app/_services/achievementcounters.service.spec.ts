import { TestBed } from '@angular/core/testing';

import { AchievementcountersService } from './achievementcounters.service';
import {HttpClientTestingModule} from "@angular/common/http/testing";

describe('AchievementcountersService', () => {
  let service: AchievementcountersService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule]
    });
    service = TestBed.inject(AchievementcountersService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
