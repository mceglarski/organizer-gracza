import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MemberEditComponent } from './member-edit.component';
import {HttpClientTestingModule} from "@angular/common/http/testing";

describe('MemberEditComponent', () => {
  let component: MemberEditComponent;
  let fixture: ComponentFixture<MemberEditComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      declarations: [ MemberEditComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MemberEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should correctly format steam ID', () => {
    const steamUrl = 'https://steamcommunity.com/profiles/76561198048151453';
    component.formatSteamUrl(steamUrl);
    expect(component.steamUrl).toEqual('76561198048151453');
  });
});
