import {Component} from '@angular/core';
import {MemberContentComponent} from "../member-content/member-content.component";
import {PresenceService} from "../../_services/presence.service";

@Component({
  selector: 'app-member-image',
  templateUrl: './member-image.component.html',
  styleUrls: ['./member-image.component.css']
})
export class MemberImageComponent {

  constructor(public memberContent: MemberContentComponent,
              public presence: PresenceService) {
  }


}
