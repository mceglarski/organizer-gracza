import { Component, OnInit } from '@angular/core';
import {Member} from "../../model/model";
import {MembersService} from "../../_services/members.service";
import {ActivatedRoute} from "@angular/router";

@Component({
  selector: 'app-member-content',
  templateUrl: './member-content.component.html',
  styleUrls: ['./member-content.component.css']
})
export class MemberContentComponent implements OnInit {
  // @ts-ignore
  member: Member;
  // @ts-ignore
  // members: Member[];

  constructor(private memberService: MembersService, private route: ActivatedRoute) { }

  ngOnInit(): void {
    // this.loadMembers();
    this.loadMember();
  }

  // loadMembers(){
  //   this.memberService.getMembers().subscribe(members => {
  //     this.members = members;
  //   })
  // }

  loadMember(){
    // @ts-ignore
    this.memberService.getMember(this.route.snapshot.paramMap.get('nickname')).subscribe(member => {
      this.member = member;
    })
  }
}
