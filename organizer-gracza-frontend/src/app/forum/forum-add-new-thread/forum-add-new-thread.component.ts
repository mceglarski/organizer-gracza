import { Component, OnInit } from '@angular/core';
import {ForumService} from "../../_services/forum.service";
import {FormControl, FormGroup, Validators} from "@angular/forms";
import {GameService} from "../../_services/game.service";
import {Game} from "../../model/model";
import {MembersService} from "../../_services/members.service";
import {ToastrService} from "ngx-toastr";
import {Router} from "@angular/router";

@Component({
  selector: 'app-forum-add-new-thread',
  templateUrl: './forum-add-new-thread.component.html',
  styleUrls: ['./forum-add-new-thread.component.css']
})
export class ForumAddNewThreadComponent implements OnInit {

  public noWhitespaceValidator(control: FormControl) {
    const isWhitespace = (control.value || '').trim().length === 0;
    const isValid = !isWhitespace;
    return isValid ? null : { 'whitespace': true };
  }

  public addThreadForm = new FormGroup({
    title: new FormControl('', [Validators.required, this.noWhitespaceValidator]),
    content: new FormControl('', [Validators.required, this.noWhitespaceValidator]),
    game: new FormControl('', Validators.required)
  });
  public games: Game[] = [];

  private currentlyLoggedMember: number;

  constructor(private forumService: ForumService,
              private gameService: GameService,
              private membersService: MembersService,
              private toastr: ToastrService,
              private router: Router) { }

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
    if (this.addThreadForm.valid) {
      this.forumService.addForumThread({
        title: this.addThreadForm.value.title.trim(),
        content: this.addThreadForm.value.content.trim(),
        threadDate: new Date(),
        gameId: this.addThreadForm.value.game,
        userId: this.currentlyLoggedMember
      }).subscribe(result => {
        this.toastr.info("Wątek został dodany!");
        this.router.navigate(["/forum"]);
      }, error => {
          this.toastr.error("Nie udało się dodać nowego wątku");
          console.log(error);
        });
    } else {
      this.toastr.error("Uzupełnij wszystkie pola formularza");
    }

  }

}
