import { Component, OnInit } from '@angular/core';
import {Member, Pagination, User, PagintationParams, Game} from "../../model/model";
import {MembersService} from "../../_services/members.service";
import {AccountService} from "../../_services/account.service";
import {take} from "rxjs/operators";
import {GameService} from "../../_services/game.service";

@Component({
  selector: 'app-member-list',
  templateUrl: './member-list.component.html',
  styleUrls: ['./member-list.component.css']
})
export class MemberListComponent implements OnInit {

  public members: Member[];
  public membersToShow: Member[];
  public pagination: Pagination;
  public userNameSearch: string = '';
  public userGameSearch: string;
  public games: Game[];

  private userParams: PagintationParams;
  private user: User;

  constructor(private memberService: MembersService,
              private accountService: AccountService,
              private gameService: GameService) {
    this.accountService.currentUser$.pipe(take(1)).subscribe(user => {
      this.user = user;
      this.userParams = new PagintationParams();
    });
  }

  ngOnInit(): void {
    this.loadMembers();
    this.loadGames();
  }

  public pageChanged(event: any): void {
    this.userParams.pageNumber = event.page;
    this.loadMembers();
  }

  public onUserNameSearch(name: string): void {
    this.membersToShow = this.members.filter(m => m.nickname.includes(name));
  }


  public onUserGameSearch(gameId: number): void {
    if (gameId == -1) {
      this.membersToShow = this.members;
    }
    else {
      this.membersToShow = [];
      this.members.forEach(member => {
        member.userGames?.forEach(game => {
          if (game.gameId == gameId) {
            this.membersToShow.push(member);
          }
        });
      });
    }
  }

  private loadMembers(): void {
    this.memberService.getMembers(this.userParams).subscribe(response => {
      this.members = response.result;
      this.membersToShow = this.members;
      this.pagination = response.pagination;
    });
  }

  private loadGames(): void {
    this.gameService.getGames().subscribe( game => {
      // @ts-ignore
      this.games = game;
      return;
    })
  }

}
