import { TestBed } from '@angular/core/testing';

import { UserachievementService } from './userachievement.service';

describe('UserachievementService', () => {
  let service: UserachievementService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(UserachievementService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
