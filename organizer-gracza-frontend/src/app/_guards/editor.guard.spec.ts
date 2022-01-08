import { TestBed } from '@angular/core/testing';

import { EditorGuard } from './editor.guard';
import {HttpClientTestingModule} from "@angular/common/http/testing";

describe('EditorGuard', () => {
  let guard: EditorGuard;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule]
    });
    guard = TestBed.inject(EditorGuard);
  });

  it('should be created', () => {
    expect(guard).toBeTruthy();
  });
});
