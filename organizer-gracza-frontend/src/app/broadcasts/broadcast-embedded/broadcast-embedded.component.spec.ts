import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BroadcastEmbeddedComponent } from './broadcast-embedded.component';

describe('BroadcastEmbeddedComponent', () => {
  let component: BroadcastEmbeddedComponent;
  let fixture: ComponentFixture<BroadcastEmbeddedComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BroadcastEmbeddedComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(BroadcastEmbeddedComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
