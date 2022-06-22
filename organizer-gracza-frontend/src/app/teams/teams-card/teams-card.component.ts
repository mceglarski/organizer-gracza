import {Component, Input} from '@angular/core';
import {Team} from "../../model/model";

@Component({
  selector: 'app-teams-card',
  templateUrl: './teams-card.component.html',
  styleUrls: ['./teams-card.component.css']
})
export class TeamsCardComponent {

  @Input() team: Team;

}
