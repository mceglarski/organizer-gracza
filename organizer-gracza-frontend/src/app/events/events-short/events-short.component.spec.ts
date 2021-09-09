import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EventsShortComponent } from './events-short.component';

describe('EventsShortComponent', () => {
  let component: EventsShortComponent;
  let fixture: ComponentFixture<EventsShortComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EventsShortComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EventsShortComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
