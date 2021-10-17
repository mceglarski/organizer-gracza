import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EventsTeamEditComponent } from './events-team-edit.component';

describe('EventsTeamEditComponent', () => {
  let component: EventsTeamEditComponent;
  let fixture: ComponentFixture<EventsTeamEditComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EventsTeamEditComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EventsTeamEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
