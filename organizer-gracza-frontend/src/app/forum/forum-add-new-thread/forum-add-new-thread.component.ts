import { Component, OnInit } from '@angular/core';
import {ForumService} from "../../_services/forum.service";
import {FormControl, FormGroup, Validators} from "@angular/forms";
import {GameService} from "../../_services/game.service";
import {Game} from "../../model/model";
import {MembersService} from "../../_services/members.service";

@Component({
  selector: 'app-forum-add-new-thread',
  templateUrl: './forum-add-new-thread.component.html',
  styleUrls: ['./forum-add-new-thread.component.css']
})
export class ForumAddNewThreadComponent implements OnInit {

  public addThreadForm = new FormGroup({
    title: new FormControl('', Validators.required),
    content: new FormControl('', Validators.required),
    game: new FormControl('', Validators.required)
  });
  public games: Game[] = [];

  private currentlyLoggedMember: number;

  constructor(private forumService: ForumService,
              private gameService: GameService,
              private membersService: MembersService) { }

  ngOnInit(): void {
    this.gameService.getGames().subscribe(g => {
      // @ts-ignore
      this.games = g;
      return;
    });
    this.membersService.getCurrentlyLoggedMemberId().subscribe(m => {
      // @ts-ignore
      this.currentlyLoggedMember = m;
      console.log(m);
      return;
    });
  }

  public onSubmit(): void {
    console.log(this.addThreadForm);
    this.forumService.addForumThread({
      title: this.addThreadForm.value.title,
      content: this.addThreadForm.value.content,
      threadDate: new Date(),
      gameId: this.addThreadForm.value.game,
      userId: this.currentlyLoggedMember
    }).subscribe(result => {
      return;
    });
  }

}
