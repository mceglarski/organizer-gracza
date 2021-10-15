import {Component, Input, OnInit} from '@angular/core';
import {Member, Team} from "../../model/model";

@Component({
  selector: 'app-teams-card',
  templateUrl: './teams-card.component.html',
  styleUrls: ['./teams-card.component.css']
})
export class TeamsCardComponent implements OnInit {
  // @ts-ignore
  @Input() team: Team;

  constructor() { }

  ngOnInit(): void {
  }

}
