import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EventsSoloResultComponent } from './events-solo-result.component';

describe('EventsSoloResultComponent', () => {
  let component: EventsSoloResultComponent;
  let fixture: ComponentFixture<EventsSoloResultComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EventsSoloResultComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EventsSoloResultComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
