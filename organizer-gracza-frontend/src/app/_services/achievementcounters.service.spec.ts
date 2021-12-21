import { TestBed } from '@angular/core/testing';

import { AchievementcountersService } from './achievementcounters.service';

describe('AchievementcountersService', () => {
  let service: AchievementcountersService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AchievementcountersService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
