import {Component, Input, OnChanges} from '@angular/core';
import {StatisticsService} from "../../_services/statistics.service";
import {Game, GameStatistics, GeneralStatistics, Member} from "../../model/model";
import {AccountService} from "../../_services/account.service";
import {GameService} from "../../_services/game.service";

@Component({
  selector: 'app-member-statistics',
  templateUrl: './member-statistics.component.html',
  styleUrls: ['./member-statistics.component.css']
})
export class MemberStatisticsComponent implements OnChanges {

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


  ngOnChanges() {
    this.memberId = this.member.id;
    this.loadGames();
    this.loadGeneralStatistics();
  }

  public loadGameStatistics(gameId: number): void {
    this.statisticsService.getGameStatisticsForUser(this.memberId, gameId).subscribe(statistic => {
      // @ts-ignore
      this.gameStatistic = statistic;
    });
  }

  private loadGames(): void {
    this.gameService.getGames().subscribe(games => {
      // @ts-ignore
      this.games = games;
    });
  }

  private loadGeneralStatistics(): void {
    this.statisticsService.getGeneralStatisticsByUserId(this.memberId).subscribe(generalStats => {
      // @ts-ignore
      this.generalStatistics = generalStats;
    });
  }

}

