import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EventsExtendedComponent } from './events-extended.component';

describe('EventsExtendedComponent', () => {
  let component: EventsExtendedComponent;
  let fixture: ComponentFixture<EventsExtendedComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EventsExtendedComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EventsExtendedComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
