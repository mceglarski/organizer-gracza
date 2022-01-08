import { TestBed } from '@angular/core/testing';

import { PreventUnsavedChangesGuard } from './prevent-unsaved-changes.guard';
import {HttpClientTestingModule} from "@angular/common/http/testing";

describe('PreventUnsavedChangesGuard', () => {
  let guard: PreventUnsavedChangesGuard;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule]
    });
    guard = TestBed.inject(PreventUnsavedChangesGuard);
  });

  it('should be created', () => {
    expect(guard).toBeTruthy();
  });
});
