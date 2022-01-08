import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NewsEditorUpdateComponent } from './news-editor-update.component';
import {HttpClientTestingModule} from "@angular/common/http/testing";

describe('NewsEditorUpdateComponent', () => {
  let component: NewsEditorUpdateComponent;
  let fixture: ComponentFixture<NewsEditorUpdateComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      declarations: [ NewsEditorUpdateComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(NewsEditorUpdateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
