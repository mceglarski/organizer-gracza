import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EventsTeamResultComponent } from './events-team-result.component';

describe('EventsTeamResultComponent', () => {
  let component: EventsTeamResultComponent;
  let fixture: ComponentFixture<EventsTeamResultComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EventsTeamResultComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EventsTeamResultComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
