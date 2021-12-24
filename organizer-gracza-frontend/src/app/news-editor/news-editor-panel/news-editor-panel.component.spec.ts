import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NewsEditorPanelComponent } from './news-editor-panel.component';

describe('NewsEditorPanelComponent', () => {
  let component: NewsEditorPanelComponent;
  let fixture: ComponentFixture<NewsEditorPanelComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
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
