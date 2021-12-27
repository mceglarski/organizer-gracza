import { Component, OnInit } from '@angular/core';
import {ActivatedRoute} from "@angular/router";
import {ForumService} from "../../_services/forum.service";
import {ForumPost, ForumThread, Member, User} from "../../model/model";
import {MembersService} from "../../_services/members.service";
import {FormControl, FormGroup, Validators} from "@angular/forms";
import {ToastrService} from "ngx-toastr";
import {take} from "rxjs/operators";
import {AccountService} from "../../_services/account.service";

@Component({
  selector: 'app-forum-posts',
  templateUrl: './forum-posts.component.html',
  styleUrls: ['./forum-posts.component.css']
})
export class ForumPostsComponent implements OnInit {

  public threadId: string | null;
  public forumThread: ForumThread;
  public posts: ForumPost[] = [];
  public currentlyLoggedMember: number;
  public user: User;
  public isUserBlocked: boolean = false;

  public addPostForm = new FormGroup({
    content: new FormControl('', [Validators.required, this.noWhitespaceValidator])
  });

  private members: Member[] = [];

  constructor(private activatedRoute: ActivatedRoute,
              private accountService: AccountService,
              private forumService: ForumService,
              private membersService: MembersService,
              private toastr: ToastrService) {
    this.accountService.currentUser$.pipe(take(1)).subscribe(user => this.user = user);
  }

  ngOnInit(): void {
    this.threadId = this.activatedRoute.snapshot.paramMap.get('threadId');
    if (this.user) {
      this.isUserBlocked = this.user.roles.includes('Zablokowany');
      this.membersService.getCurrentlyLoggedMemberId().subscribe(m => {
        // @ts-ignore
        this.currentlyLoggedMember = m;
        return;
      });
    }
    // @ts-ignore
    this.forumService.getForumThread(this.threadId).subscribe(f => {
      // @ts-ignore
      this.forumThread = f;
      this.posts = this.forumThread.forumPosts;
      // match thread and posts photoUrl and nicknames to users
      this.membersService.getMembers({pageNumber: 1, pageSize: 99999}).subscribe(m => {
        this.members = m.result;
        this.forumThread.user.photoUrl = <string>this.members?.find(m => m?.username === this.forumThread?.user?.username)?.photoUrl;
        this.posts.forEach(post => {
          post.photoUrl = <string>this.members?.find(m => m?.id === post.userId)?.photoUrl;
          post.nickname = <string>this.members?.find(m => m?.id === post.userId)?.nickname;
          post.username = <string>this.members?.find(m => m?.id === post.userId)?.username;
        });
        return;
      });
      return;
    });
  }

  public noWhitespaceValidator(control: FormControl) {
    const isWhitespace = (control.value || '').trim().length === 0;
    const isValid = !isWhitespace;
    return isValid ? null : { 'whitespace': true };
  }

  public onSubmit(): void {
    if (this.addPostForm.valid) {
      this.forumService.addForumPost({
        content: this.addPostForm.value.content.trim(),
        postDate: new Date(),
        forumThreadId: this.threadId,
        userId: this.currentlyLoggedMember
      }).subscribe(result => {
        window.location.reload();
      }, error => {
        this.toastr.error("Nie udało się dodać nowego postu");
        console.log(error);
      });
    } else {
      this.toastr.error("Treść nie może być pusta");
    }
  }

  public deletePost(postId: number): void {
    this.forumService.deleteForumPost(postId).subscribe(r => {
      window.location.reload();
      this.toastr.success('Usunięto post');
    });
  }

}
