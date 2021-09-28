import {Component, Input, OnInit} from '@angular/core';
import {Member} from "../../model/model";
import {PresenceService} from "../../_services/presence.service";

@Component({
  selector: 'app-member-card',
  templateUrl: './member-card.component.html',
  styleUrls: ['./member-card.component.css']
})
export class MemberCardComponent implements OnInit {
  // @ts-ignore
  @Input() member: Member;

  constructor(public presenceService: PresenceService) { }

  ngOnInit(): void {
  }

}
