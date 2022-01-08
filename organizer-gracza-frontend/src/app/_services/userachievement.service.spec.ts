import { TestBed } from '@angular/core/testing';

import { UserachievementService } from './userachievement.service';
import {HttpClientTestingModule} from "@angular/common/http/testing";

describe('UserachievementService', () => {
  let service: UserachievementService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule]
    });
    service = TestBed.inject(UserachievementService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
