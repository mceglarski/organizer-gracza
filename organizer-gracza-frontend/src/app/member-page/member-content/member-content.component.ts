import {ChangeDetectorRef, Component, OnInit} from '@angular/core';
import {Game, Member, User, UserGame} from "../../model/model";
import {MembersService} from "../../_services/members.service";
import {ActivatedRoute} from "@angular/router";
import {UsergameService} from "../../_services/usergame.service";
import {GameService} from "../../_services/game.service";

@Component({
  selector: 'app-member-content',
  templateUrl: './member-content.component.html',
  styleUrls: ['./member-content.component.css']
})
export class MemberContentComponent implements OnInit {

  public user: User;
  public member: Member;
  public userGames: UserGame[];
  public gamesToShow: string[] = [];

  private games: Game[];

  constructor(private memberService: MembersService,
              private userGameService: UsergameService,
              private gameService: GameService,
              private route: ActivatedRoute,
              private cd: ChangeDetectorRef) {
  }

  ngOnInit(): void {
    // @ts-ignore
    this.user = JSON.parse(localStorage.getItem('user'));
    this.route.params.subscribe(params => {
      const name = params['username'];
      this.memberService.getMember(name).subscribe(m => {
        this.member = m;
        this.cd.detectChanges();
        this.userGameService.getUserGameForUser(this.member.id).subscribe(userGame => {
          // @ts-ignore
          this.userGames = userGame;
          this.gameService.getGames().subscribe(game => {
            // @ts-ignore
            this.games = game;
            this.userGames.forEach(g => {
              // @ts-ignore
              this.gamesToShow.push(this.games.find(f => f.gameId === g.gameId).title);
            });

          });
        });

      });

    });

    this.cd.detectChanges();
  }

}
