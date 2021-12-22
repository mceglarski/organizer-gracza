import { Component, OnInit } from '@angular/core';
import {ActivatedRoute} from "@angular/router";
import {ForumService} from "../../_services/forum.service";
import {ForumPost, ForumThread, Member} from "../../model/model";
import {MembersService} from "../../_services/members.service";

@Component({
  selector: 'app-forum-posts',
  templateUrl: './forum-posts.component.html',
  styleUrls: ['./forum-posts.component.css']
})
export class ForumPostsComponent implements OnInit {

  public threadId: string | null;
  public forumThread: ForumThread;
  public posts: ForumPost[] = [];

  private members: Member[] = [];

  constructor(private activatedRoute: ActivatedRoute,
              private forumService: ForumService,
              private membersService: MembersService) { }

  ngOnInit(): void {
    this.threadId = this.activatedRoute.snapshot.paramMap.get('threadId');
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

}
