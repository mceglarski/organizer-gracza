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

  public member: Member;

  constructor(private memberService: MembersService,
              private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.loadMember();
  }

  public loadMember(): void {
    // @ts-ignore
    this.memberService.getMember(this.route.snapshot.paramMap.get('username')).subscribe(member => {
      this.member = member;
    })
  }
}
