import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EventsSoloEditComponent } from './events-solo-edit.component';

describe('EventsSoloEditComponent', () => {
  let component: EventsSoloEditComponent;
  let fixture: ComponentFixture<EventsSoloEditComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EventsSoloEditComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EventsSoloEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
