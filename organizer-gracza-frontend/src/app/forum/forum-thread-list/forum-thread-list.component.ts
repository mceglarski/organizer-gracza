import { Component, OnInit } from '@angular/core';
import {ForumService} from "../../_services/forum.service";
import {ForumThread, Member, User} from "../../model/model";
import {MembersService} from "../../_services/members.service";
import {take} from "rxjs/operators";
import {AccountService} from "../../_services/account.service";
import {ToastrService} from "ngx-toastr";

@Component({
  selector: 'app-forum-thread-list',
  templateUrl: './forum-thread-list.component.html',
  styleUrls: ['./forum-thread-list.component.css']
})
export class ForumThreadListComponent implements OnInit {

  public forumThread: ForumThread[] = [];
  public user: User;
  public isUserBlocked: boolean = false;

  private members: Member[] = [];

  constructor(private forumService: ForumService,
              private accountService: AccountService,
              private membersService: MembersService,
              private toastr: ToastrService) {
    this.accountService.currentUser$.pipe(take(1)).subscribe(user => this.user = user);
  }

  ngOnInit(): void {
    if (this.user) {
      this.isUserBlocked = this.user.roles.includes('Zablokowany');
    }
    this.forumService.getForumThreads().subscribe(f => {
      // @ts-ignore
      this.forumThread = f;
      this.membersService.getMembers({pageNumber: 1, pageSize: 99999}).subscribe(m => {
        this.members = m.result;
        this.forumThread.forEach(thread => {
          thread.user.photoUrl = <string>this.members?.find(m => m?.username === thread?.user?.username)?.photoUrl;
        });
        this.forumThread.sort((a, b) => new Date(b.threadDate).getTime() - new Date(a.threadDate).getTime());
        return;
      });
      return;
    });
  }

  public deleteThread(forumThreadId: number): void {
    this.forumService.deleteForumThread(forumThreadId).subscribe(r => {
      window.location.reload();
      this.toastr.success('Usunięto wątek');
      return;
    });
  }

}
