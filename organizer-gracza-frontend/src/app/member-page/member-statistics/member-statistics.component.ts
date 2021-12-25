import {Component, Input, OnChanges, OnInit} from '@angular/core';
import {StatisticsService} from "../../_services/statistics.service";
import {Game, GameStatistics, GeneralStatistics, Member, User} from "../../model/model";
import {AccountService} from "../../_services/account.service";
import {take} from "rxjs/operators";
import {GameService} from "../../_services/game.service";
import {MembersService} from "../../_services/members.service";
import {ActivatedRoute} from "@angular/router";
import {FormControl} from "@angular/forms";

@Component({
  selector: 'app-member-statistics',
  templateUrl: './member-statistics.component.html',
  styleUrls: ['./member-statistics.component.css']
})
export class MemberStatisticsComponent implements OnInit, OnChanges {

  @Input() public member: Member;
  public gameStatistics: GameStatistics[] = [];
  public gameStatistic: GameStatistics;
  public generalStatistics: GeneralStatistics;

  public games: Game[];
  public game: Game;
  private memberId: number;
  public gameId: number;

  constructor(private accountService: AccountService,
              private statisticsService: StatisticsService,
              private gameService: GameService) {
  }

  ngOnInit(): void {
  }

  ngOnChanges() {
    this.memberId = this.member.id;
    this.loadGames();
    this.loadGeneralStatistics();
  }

  public loadGameStatistics(gameId: number): void {
    this.statisticsService.getGameStatisticsForUser(this.memberId, gameId).subscribe(statistic => {
      // @ts-ignore
      this.gameStatistic = statistic;
      return;
    });
  }

  private loadGames(): void {
    this.gameService.getGames().subscribe(games => {
      // @ts-ignore
      this.games = games;
      return;
    });
  }

  private loadGeneralStatistics(): void {
    this.statisticsService.getGeneralStatisticsByUserId(this.memberId).subscribe(generalStats => {
      // @ts-ignore
      this.generalStatistics = generalStats;
      return;
    });
  }

}

