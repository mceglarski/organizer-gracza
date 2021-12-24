import {Component, Input, OnInit} from '@angular/core';
import {SteamService} from "../../_services/steam.service";
import {SteamInformation} from "../../model/model";

@Component({
  selector: 'app-steam-information',
  templateUrl: './steam-information.component.html',
  styleUrls: ['./steam-information.component.css']
})
export class SteamInformationComponent implements OnInit {

  @Input() steamId: string;
  public steamInfo: SteamInformation;
  public currentlyPlayedGame: string;

  constructor(private steamService: SteamService) { }

  ngOnInit(): void {
    this.steamService.getUser(this.steamId).subscribe(response => {
      this.steamInfo = {
        // @ts-ignore
        communityvisibilitystate: response.response.players[0].communityvisibilitystate,
        // @ts-ignore
        profileurl: response.response.players[0].profileurl,
        // @ts-ignore
        gameid: response.response.players[0].gameid,
        // @ts-ignore
        realname: response.response.players[0].realname
      }
      if (this.steamInfo.gameid) {
        this.steamService.getUserRecentlyPlayedGames(this.steamId).subscribe( game => {
          // console.log(game);
          return;
        });
      }
      else {
        this.steamService.getUserRecentlyPlayedGames(this.steamId).subscribe( game => {
          // console.log(game);
          return;
        });
      }
      // console.log(this.steamInfo);
      return;
    });
  }

}
