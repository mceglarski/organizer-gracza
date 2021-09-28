import { Component, OnInit } from '@angular/core';
import {MemberContentComponent} from "../member-content/member-content.component";
import {PresenceService} from "../../_services/presence.service";

@Component({
  selector: 'app-member-image',
  templateUrl: './member-image.component.html',
  styleUrls: ['./member-image.component.css']
})
export class MemberImageComponent implements OnInit {

  constructor(public memberContent: MemberContentComponent, public presence: PresenceService) { }

  ngOnInit(): void {
  }

}
