import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EventsSoloUpdateComponent } from './events-solo-update.component';

describe('EventsSoloUpdateComponent', () => {
  let component: EventsSoloUpdateComponent;
  let fixture: ComponentFixture<EventsSoloUpdateComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EventsSoloUpdateComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EventsSoloUpdateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
