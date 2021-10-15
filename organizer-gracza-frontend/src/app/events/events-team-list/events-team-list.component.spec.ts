import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EventsTeamListComponent } from './events-team-list.component';

describe('EventsTeamListComponent', () => {
  let component: EventsTeamListComponent;
  let fixture: ComponentFixture<EventsTeamListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EventsTeamListComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EventsTeamListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
