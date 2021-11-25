import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EventsTeamUpdateComponent } from './events-team-update.component';

describe('EventsTeamUpdateComponent', () => {
  let component: EventsTeamUpdateComponent;
  let fixture: ComponentFixture<EventsTeamUpdateComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EventsTeamUpdateComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EventsTeamUpdateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
