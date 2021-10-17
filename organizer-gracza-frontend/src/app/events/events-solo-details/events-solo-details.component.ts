import { Component, OnInit } from '@angular/core';
import {EventsService} from "../../_services/events.service";
import {ActivatedRoute} from "@angular/router";
import {EventUser, EventUserRegistration, Member, User} from "../../model/model";
import {TeamsService} from "../../_services/teams.service";
import {MembersService} from "../../_services/members.service";
import {take} from "rxjs/operators";
import {AccountService} from "../../_services/account.service";
import {ToastrService} from "ngx-toastr";

@Component({
  selector: 'app-events-solo-details',
  templateUrl: './events-solo-details.component.html',
  styleUrls: ['./events-solo-details.component.css']
})
export class EventsSoloDetailsComponent implements OnInit {
  // @ts-ignore
  event: EventUser;
  // @ts-ignore
  model: { eventUserId: number; userId: number };
  // @ts-ignore
  user: User
  // @ts-ignore
  memberId: number;
  // @ts-ignore
  userRegistrations: EventUserRegistration[];
  // @ts-ignore
  Members: Member[] = [];
  // @ts-ignore
  UsersId: number[] = [];

  constructor(private eventsService: EventsService, public route: ActivatedRoute, private teamService: TeamsService,
              private memberService: MembersService, private accountService: AccountService,
              private toastr: ToastrService)
  {
    this.accountService.currentUser$.pipe(take(1)).subscribe(user => {
      this.user = user;
    })
  }

  ngOnInit(): void {
    this.loadEvent();
    this.loadMemberId();
  }

  loadEvent(){
    // @ts-ignore
    this.eventsService.getUserEvent(this.route.snapshot.paramMap.get('eventUserId')).subscribe(specifiedEvent => {
      // @ts-ignore
      this.event = specifiedEvent;
      this.loadUserRegistrations()
    })
  }

  joinEvent(){
    this.model = {
      userId: this.memberId,
      eventUserId: this.event.eventUserId
    }
    this.eventsService.addUserEventRegistration(this.model).subscribe(response =>{
      this.toastr.success("Dołączyłeś do wydarzenia")
    }, error => {
      this.toastr.error("Nie udało się dołączyć do wydarzenia")
    })
  }

  loadMemberId(){
    this.memberService.getMemberIdByUsername(this.user.username).subscribe(memberId =>{
      this.memberId = memberId;
    })
  }

  loadUserRegistrations(){
    this.eventsService.getUserEventRegistration(this.event.eventUserId).subscribe(userRegistration => {
      // @ts-ignore
      this.userRegistrations = userRegistration;
      this.loadUsersIds();
    })
  }

  loadUsersIds(){
    for(let user of this.userRegistrations)
    {
      this.UsersId.push(user.userId);
    }
    this.loadMembers();
  }

  loadMembers(){
    this.UsersId.forEach((value,index) =>{
      this.memberService.getMemberById(value).subscribe(member =>{
        // this.Members = member;
        this.Members.push(member);
      })
    })
  }

  // loadMember(){
  //   this.memberService.getMemberById(this.event.eventUserId).subscribe(memberId =>{
  //     this.memberId = memberId;
  //   })
  // }
}
