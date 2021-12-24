import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SteamInformationComponent } from './steam-information.component';

describe('SteamInformationComponent', () => {
  let component: SteamInformationComponent;
  let fixture: ComponentFixture<SteamInformationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SteamInformationComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SteamInformationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
