import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EventsSoloListComponent } from './events-solo-list.component';

describe('EventsSoloListComponent', () => {
  let component: EventsSoloListComponent;
  let fixture: ComponentFixture<EventsSoloListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EventsSoloListComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EventsSoloListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
