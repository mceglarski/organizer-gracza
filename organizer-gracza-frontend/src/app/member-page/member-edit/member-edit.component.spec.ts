import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MemberEditComponent } from './member-edit.component';
import {MatDialogModule} from "@angular/material/dialog";
import {HttpClientTestingModule} from "@angular/common/http/testing";
import {ToastrModule} from "ngx-toastr";
import {RouterTestingModule} from "@angular/router/testing";

describe('MemberEditComponent', () => {
  let component: MemberEditComponent;
  let fixture: ComponentFixture<MemberEditComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [MatDialogModule, HttpClientTestingModule, ToastrModule.forRoot(), RouterTestingModule],
      declarations: [ MemberEditComponent ]
    })
      .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MemberEditComponent);
    component = fixture.componentInstance;
    component.user = {id: 1, photoUrl: 'aaa', roles: [], nickname: 'a', username: 'a', description: '', steamId: '', token: ''}
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should format steam url and delete slash character', () => {
    fixture.detectChanges();
    let steamUrl = 'https://steamcommunity.com/profiles/76561198048151457/';
    let formattedUrl = component.formatSteamUrl(steamUrl);
    fixture.detectChanges();
    expect(formattedUrl).toEqual('https://steamcommunity.com/profiles/76561198048151457');
  });
});
