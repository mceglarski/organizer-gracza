import { ComponentFixture, TestBed } from '@angular/core/testing';
import { MainCalendarComponent } from './main-calendar.component';
import {MatDialogModule} from "@angular/material/dialog";
import {HttpClientTestingModule} from "@angular/common/http/testing";
import {ToastrModule} from "ngx-toastr";
import {RouterTestingModule} from "@angular/router/testing";

describe('MainCalendarComponent', () => {
  let component: MainCalendarComponent;
  let fixture: ComponentFixture<MainCalendarComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [MatDialogModule, HttpClientTestingModule, ToastrModule.forRoot(), RouterTestingModule],
      declarations: [ MainCalendarComponent ]
    })
      .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MainCalendarComponent);
    component = fixture.componentInstance;
    component.user = {id: 1, photoUrl: 'aaa', roles: [], nickname: 'a', username: 'a', description: '', steamId: '', token: ''}
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
