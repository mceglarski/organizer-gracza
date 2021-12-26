import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ActivateMailComponent } from './activate-mail.component';

describe('ActivateMailComponent', () => {
  let component: ActivateMailComponent;
  let fixture: ComponentFixture<ActivateMailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ActivateMailComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ActivateMailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
