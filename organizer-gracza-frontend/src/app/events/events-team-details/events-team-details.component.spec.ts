import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EventsTeamDetailsComponent } from './events-team-details.component';

describe('EventsTeamDetailsComponent', () => {
  let component: EventsTeamDetailsComponent;
  let fixture: ComponentFixture<EventsTeamDetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EventsTeamDetailsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EventsTeamDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
