import { Component, OnInit } from '@angular/core';
import {ForumService} from "../../_services/forum.service";
import {ForumThread, Member, User} from "../../model/model";
import {MembersService} from "../../_services/members.service";
import {take} from "rxjs/operators";
import {AccountService} from "../../_services/account.service";

@Component({
  selector: 'app-forum-thread-list',
  templateUrl: './forum-thread-list.component.html',
  styleUrls: ['./forum-thread-list.component.css']
})
export class ForumThreadListComponent implements OnInit {

  public forumThread: ForumThread[] = []
  public user: User;

  private members: Member[] = [];

  constructor(private forumService: ForumService,
              private accountService: AccountService,
              private membersService: MembersService) {
    this.accountService.currentUser$.pipe(take(1)).subscribe(user => this.user = user);
  }

  ngOnInit(): void {
    this.forumService.getForumThreads().subscribe(f => {
      // @ts-ignore
      this.forumThread = f;
      this.membersService.getMembers({pageNumber: 1, pageSize: 99999}).subscribe(m => {
        this.members = m.result;
        this.forumThread.forEach(thread => {
          thread.user.photoUrl = <string>this.members?.find(m => m?.username === thread?.user?.username)?.photoUrl;
        });
        console.log('members: ', m);
        return;
      });
      console.log('threads: ', f);
      return;
    });
  }

}
