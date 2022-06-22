import {Component, Input, OnChanges} from '@angular/core';
import {SteamService} from "../../_services/steam.service";
import {SteamAchievements, SteamInformation, SteamLastPlayedGame} from "../../model/model";

@Component({
  selector: 'app-steam-information',
  templateUrl: './steam-information.component.html',
  styleUrls: ['./steam-information.component.css']
})
export class SteamInformationComponent implements OnChanges {

  @Input() steamId: string;
  public steamInfo: SteamInformation;
  public lastPlayedGame: SteamLastPlayedGame[];
  public firstGameAchievements: SteamAchievements[];
  public firstGameUnlockedAchievements: number = 0;
  public secondGameAchievements: SteamAchievements[];
  public secondGameUnlockedAchievements: number = 0;
  public isRecentGameAvailable: boolean;

  constructor(private steamService: SteamService) { }

  ngOnChanges() {
    this.init();
  }

  private init(): void {
    this.steamService.getUser(this.steamId).subscribe(response => {
      this.steamInfo = {
        // @ts-ignore
        communityvisibilitystate: response.response.players[0].communityvisibilitystate,
        // @ts-ignore
        profileurl: response.response.players[0].profileurl,
        // @ts-ignore
        gameid: response.response.players[0].gameid,
        // @ts-ignore
        realname: response.response.players[0].realname,
        // @ts-ignore
        profilestate: response.response.players[0].profilestate,
        // @ts-ignore
        personaname: response.response.players[0].personaname,
        // @ts-ignore
        gameextrainfo: response.response.players[0].gameextrainfo,
        // @ts-ignore
        avatarfull: response.response.players[0].avatarfull
      }
      if (this.steamInfo.gameid) {
        this.getRecentFirstPlayedGameAchievements(this.steamId, this.steamInfo.gameid);
      }
      this.steamService.getUserRecentlyPlayedGames(this.steamId).subscribe( game => {
        // @ts-ignore
        this.lastPlayedGame = game.response.games;
        this.lastPlayedGame = this.lastPlayedGame?.filter( l => l.appid != this.steamInfo.gameid);
        if (this.lastPlayedGame && this.steamInfo.gameid) {
          this.isRecentGameAvailable = true;
          // @ts-ignore
          this.steamService.getUserAchievements(this.steamId, this.lastPlayedGame[0].appid).subscribe( game => {
            // @ts-ignore
            this.secondGameAchievements = game.playerstats.achievements;
            this.secondGameAchievements.forEach(a => this.secondGameUnlockedAchievements += a.achieved);

          });
        }
        else if (this.lastPlayedGame?.length === 1 && !this.steamInfo.gameid) {
          // @ts-ignore
          this.getRecentFirstPlayedGameAchievements(this.steamId, this.lastPlayedGame[0].appid);
        }
        else if (this.lastPlayedGame?.length > 1 && !this.steamInfo.gameid) {
          // @ts-ignore
          this.getRecentFirstPlayedGameAchievements(this.steamId, this.lastPlayedGame[0].appid);
          // @ts-ignore
          this.steamService.getUserAchievements(this.steamId, this.lastPlayedGame[1].appid).subscribe( game => {
            // @ts-ignore
            this.secondGameAchievements = game.playerstats.achievements;
            this.secondGameAchievements.forEach(a => this.secondGameUnlockedAchievements += a.achieved);

          });
        }

      });

    });
  }

  private getRecentFirstPlayedGameAchievements(steamId: string, gameid: number): void {
    this.steamService.getUserAchievements(steamId, gameid).subscribe( game => {
      // @ts-ignore
      this.firstGameAchievements = game.playerstats.achievements;
      if (this.firstGameAchievements) {
        this.firstGameAchievements.forEach(a => this.firstGameUnlockedAchievements += a.achieved);
      }

    }, error => {
      console.log(error);
    });
  }

}
