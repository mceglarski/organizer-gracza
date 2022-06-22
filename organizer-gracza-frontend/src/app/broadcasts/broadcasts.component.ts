import { Component, OnInit } from '@angular/core';
import {TwitchService} from "../_services/twitch.service";
import {TwitchBroadcast} from "../model/model";

@Component({
  selector: 'app-broadcasts',
  templateUrl: './broadcasts.component.html',
  styleUrls: ['./broadcasts.component.css']
})
export class BroadcastsComponent implements OnInit {

  public twitchBroadcasts: TwitchBroadcast[] = [];
  public game: string = "";
  public language: string = "";

  constructor(private twitchService: TwitchService) { }

  ngOnInit(): void {
    this.twitchService.getData().subscribe( b => {
      // @ts-ignore
      this.twitchBroadcasts = b.data;

    });
  }

  public onGameChange(event: any): void {
    this.game = event;
    this.fillBroadcastArray();
  }

  public onLanguageChange(event: any): void {
    this.language = event;
    this.fillBroadcastArray();
  }

  private fillBroadcastArray(): void {
    if (this.game === "" && this.language === "") {
      this.twitchService.getData().subscribe( b => {
        // @ts-ignore
        this.twitchBroadcasts = b.data;

      });
    }
    else if (this.language !== "" && this.game !== "") {
      this.twitchService.getDataForGameAndLanguage(this.game, this.language).subscribe(b => {
        // @ts-ignore
        this.twitchBroadcasts = b.data;

      });
    }
    else if (this.language === "" && this.game !== "") {
      this.twitchService.getDataForGame(this.game).subscribe(b => {
        // @ts-ignore
        this.twitchBroadcasts = b.data;

      });
    }
    else if (this.language !== "" && this.game === "") {
      this.twitchService.getDataForLanguage(this.language).subscribe(b => {
        // @ts-ignore
        this.twitchBroadcasts = b.data;

      });
    }
  }

}
