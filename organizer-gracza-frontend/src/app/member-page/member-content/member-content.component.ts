import {ChangeDetectorRef, Component, OnInit} from '@angular/core';
import {Game, Member, UserGame} from "../../model/model";
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

  public member: Member;
  public userGames: UserGame[];

  private games: Game[];

  constructor(private memberService: MembersService,
              private userGameService: UsergameService,
              private gameService: GameService,
              private route: ActivatedRoute,
              private cd: ChangeDetectorRef) { }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      const name = params['username'];
      this.memberService.getMember(name).subscribe(m => {
        this.member = m;
        this.cd.detectChanges();
        return;
      });
      return;
    });
    this.cd.detectChanges();

    this.userGameService.getUserGameForUser(this.member.id).subscribe(userGame => {
      // @ts-ignore
      this.userGames = userGame;
      this.gameService.getGames().subscribe(game => {
        // @ts-ignore
        this.games = game;

        // this.games = this.games.filter(g => g.gameId === )
        return;
      })
    });
  }

}
