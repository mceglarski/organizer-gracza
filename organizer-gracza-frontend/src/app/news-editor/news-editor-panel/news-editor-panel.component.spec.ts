import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NewsEditorPanelComponent } from './news-editor-panel.component';
import {HttpClientTestingModule} from "@angular/common/http/testing";

describe('NewsEditorPanelComponent', () => {
  let component: NewsEditorPanelComponent;
  let fixture: ComponentFixture<NewsEditorPanelComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      declarations: [ NewsEditorPanelComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(NewsEditorPanelComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
