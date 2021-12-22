import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ForumAddNewThreadComponent } from './forum-add-new-thread.component';

describe('ForumAddNewThreadComponent', () => {
  let component: ForumAddNewThreadComponent;
  let fixture: ComponentFixture<ForumAddNewThreadComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ForumAddNewThreadComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ForumAddNewThreadComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});