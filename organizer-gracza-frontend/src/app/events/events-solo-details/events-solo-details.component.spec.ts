import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EventsSoloDetailsComponent } from './events-solo-details.component';

describe('EventsSoloDetailsComponent', () => {
  let component: EventsSoloDetailsComponent;
  let fixture: ComponentFixture<EventsSoloDetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EventsSoloDetailsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EventsSoloDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
