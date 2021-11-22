import { Component, OnInit } from '@angular/core';
import {AchievementsService} from "../_services/achievements.service";

@Component({
  selector: 'app-achievements',
  templateUrl: './achievements.component.html',
  styleUrls: ['./achievements.component.css']
})
export class AchievementsComponent implements OnInit {

  constructor(private achievementsService: AchievementsService) { }

  ngOnInit(): void {
  }

}
