import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NewsEditorUpdateComponent } from './news-editor-update.component';

describe('NewsEditorUpdateComponent', () => {
  let component: NewsEditorUpdateComponent;
  let fixture: ComponentFixture<NewsEditorUpdateComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
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
