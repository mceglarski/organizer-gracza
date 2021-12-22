import { Component, OnInit } from '@angular/core';
import {ActivatedRoute, Router} from "@angular/router";
import {ForumService} from "../../_services/forum.service";
import {ForumPost, ForumThread, Member} from "../../model/model";
import {MembersService} from "../../_services/members.service";
import {FormControl, FormGroup, Validators} from "@angular/forms";
import {ToastrService} from "ngx-toastr";

@Component({
  selector: 'app-forum-posts',
  templateUrl: './forum-posts.component.html',
  styleUrls: ['./forum-posts.component.css']
})
export class ForumPostsComponent implements OnInit {

  public threadId: string | null;
  public forumThread: ForumThread;
  public posts: ForumPost[] = [];

  public noWhitespaceValidator(control: FormControl) {
    const isWhitespace = (control.value || '').trim().length === 0;
    const isValid = !isWhitespace;
    return isValid ? null : { 'whitespace': true };
  }

  public addPostForm = new FormGroup({
    content: new FormControl('', [Validators.required, this.noWhitespaceValidator])
  });

  private members: Member[] = [];
  private currentlyLoggedMember: number;

  constructor(private activatedRoute: ActivatedRoute,
              private forumService: ForumService,
              private membersService: MembersService,
              private toastr: ToastrService,
              private router: Router) { }

  ngOnInit(): void {
    this.threadId = this.activatedRoute.snapshot.paramMap.get('threadId');
    this.membersService.getCurrentlyLoggedMemberId().subscribe(m => {
      // @ts-ignore
      this.currentlyLoggedMember = m;
      return;
    })
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

  public onSubmit(): void {
    console.log(this.addPostForm);

    if (this.addPostForm.valid) {
      this.forumService.addForumPost({
        content: this.addPostForm.value.content.trim(),
        postDate: new Date(),
        forumThreadId: this.threadId
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

}
