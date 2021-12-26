import {ChangeDetectionStrategy, Component, HostListener, OnInit, ViewChild} from '@angular/core';
import {Game, Member, User, UserGame} from "../../model/model";
import {AccountService} from "../../_services/account.service";
import {MembersService} from "../../_services/members.service";
import {take} from "rxjs/operators";
import {ToastrService} from "ngx-toastr";
import {NgForm} from "@angular/forms";
import {UsergameService} from "../../_services/usergame.service";
import {GameService} from "../../_services/game.service";

@Component({
  selector: 'app-member-edit',
  templateUrl: './member-edit.component.html',
  styleUrls: ['./member-edit.component.css'],
  changeDetection: ChangeDetectionStrategy.Default
})
export class MemberEditComponent implements OnInit {

  @ViewChild('editForm') public editForm: NgForm;
  public member: Member;
  public user: User;
  public userGames: UserGame[] = [];
  public games: Game[] = [];
  public steamUrl: string;

  @HostListener('window:beforeunload', ['$event']) unloadNotification($event: any) {
      if (this.editForm.dirty) {
        $event.returnValue = true;
      }
  }

  constructor(private accountService: AccountService,
              private memberService: MembersService,
              private userGameService: UsergameService,
              private gameService: GameService,
              private toastr: ToastrService) {
    this.accountService.currentUser$.pipe(take(1)).subscribe(user => this.user = user);
  }

  ngOnInit(): void {
    this.loadMember();
    this.getUserInterestedGames();
  }

  public checkUserGamesInput(gameId: any): boolean {
    return !!this.userGames.find(u => u.gameId === gameId);
  }

  public onGameCheckboxChanged(gameId: any, checked: boolean): void {
    if (checked) {
      this.userGames.push({gameId: gameId, userId: this.user.id});
    } else {
      this.userGames = this.userGames.filter( u => u.gameId !== gameId);
    }
  }

  private loadMember(): void {
    this.memberService.getMember(this.user.username).subscribe(member => {
      this.steamUrl = 'https://steamcommunity.com/profiles/' + member.steamId;
      this.member = member;
      return;
    });
  }

  private getUserInterestedGames(): void {
    this.userGameService.getUserGameForUser(this.user.id).subscribe( interestedGames => {
      // @ts-ignore
      this.userGames = interestedGames;
      this.gameService.getGames().subscribe(games => {
        // @ts-ignore
        this.games = games;
      });
      return;
    });
  }

  public updateMember() {
    if (this.steamUrl.slice(-1) === '/') {
      this.steamUrl = this.steamUrl.substring(0, this.steamUrl.length-1);
    }
    if (this.steamUrl.substr(-17).includes('/')) {
      this.toastr.error('Niepoprawny adres profilu Steam, wklej adres z SteamID64');
    }
    else {
      this.member.steamId = this.steamUrl.substr(-17);
      this.memberService.updateMember(this.member).subscribe(() => {
        this.toastr.success('Profil został zaktualizowany!');
        this.editForm.reset(this.member);
        return;
      });
      this.userGameService.deleteAllUserGames(this.member.id).subscribe(r => {
        return;
      });
      this.userGameService.addUserGameList(this.userGames).subscribe(r => {
        return;
      });
    }
  }
}
