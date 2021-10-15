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
      console.log(this.event.eventUserId);
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
    this.memberService.getMemberById(this.user.username).subscribe(memberId =>{
      this.memberId = memberId;
    })
  }


  // loadMember(){
  //   this.memberService.getMemberById(this.event.eventUserId).subscribe(memberId =>{
  //     this.memberId = memberId;
  //   })
  // }
}
