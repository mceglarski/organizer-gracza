import {Component, OnInit} from '@angular/core';
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
export class MemberStatisticsComponent implements OnInit {
  public gameStatistics: GameStatistics[] = [];
  public gameStatistic: GameStatistics;
  public generalStatistics: GeneralStatistics;
  private user: User;
  public games: Game[];
  public game: Game;
  private memberId: number;
  private member: Member;
  public gameId: number;

  constructor(private accountService: AccountService,
              private statisticsService: StatisticsService,
              private gameService: GameService,
              private memberService: MembersService,
              private route: ActivatedRoute) {
    this.accountService.currentUser$.pipe(take(1)).subscribe(user => this.user = user);
  }

  ngOnInit(): void {
    this.loadMember();
    this.loadGames();
  }

  loadGameStatistics() {
    this.statisticsService.getGameStatisticsByUserId(this.memberId).subscribe(gameStats => {
      // @ts-ignore
      this.gameStatistics = gameStats;
    });
  }

  loadGeneralStatistics() {
    this.statisticsService.getGeneralStatisticsByUserId(this.memberId).subscribe(generalStats => {
      // @ts-ignore
      this.generalStatistics = generalStats;
    });
  }

  loadGames() {
    this.gameService.getGames().subscribe(games => {
      // @ts-ignore
      this.games = games;
    })
  }

  loadGame() {
    this.gameService.getGame(this.gameId).subscribe(game => {
      // @ts-ignore
      this.game = game;
      this.loadGameStatisticsForUser();
    })
  }

  loadMember() {
    // @ts-ignore
    this.memberService.getMember(this.route.snapshot.paramMap.get('nickname')).subscribe(member => {
      this.member = member;
      this.loadMemberId();
    })
  }

  loadMemberId() {
    this.memberService.getMemberIdByUsername(this.member.username).subscribe(memberId => {
      this.memberId = memberId;
      this.loadGameStatistics();
      this.loadGeneralStatistics();
    })
  }

  loadGameStatisticsForUser() {
    this.statisticsService.getGameStatisticsForUser(this.memberId, this.gameId).subscribe(statistic => {
      // @ts-ignore
      this.gameStatistic = statistic;
    })
  }
}

