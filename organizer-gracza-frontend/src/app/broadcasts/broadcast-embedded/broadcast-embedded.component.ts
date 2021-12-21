import { Component, OnInit } from '@angular/core';
import {ActivatedRoute} from "@angular/router";

declare let Twitch: any;

@Component({
  selector: 'app-broadcast-embedded',
  templateUrl: './broadcast-embedded.component.html',
  styleUrls: ['./broadcast-embedded.component.css']
})
export class BroadcastEmbeddedComponent implements OnInit {

  public userName: string | null = "";

  constructor(private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.userName = this.route.snapshot.paramMap.get('userName');

    var options = {
      width: "100%",
      height: 1080,
      channel: this.userName,
      videoWithChat: true
    };
    var player = new Twitch.Embed("twitch-embed", options);
    player.setVolume(0.5);
  }

}
