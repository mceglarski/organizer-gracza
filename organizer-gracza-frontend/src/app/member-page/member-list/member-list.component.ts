import { Component, OnInit } from '@angular/core';
import {Member} from "../../model/model";
import {MembersService} from "../../_services/members.service";

@Component({
  selector: 'app-member-list',
  templateUrl: './member-list.component.html',
  styleUrls: ['./member-list.component.css']
})
export class MemberListComponent implements OnInit {
  // @ts-ignore
  members: Member[];

  constructor(private memberService: MembersService) { }

  ngOnInit(): void {
    this.loadMembers();
  }

  loadMembers(){
    this.memberService.getMembers().subscribe(members => {
      this.members = members;
    })
  }

}
