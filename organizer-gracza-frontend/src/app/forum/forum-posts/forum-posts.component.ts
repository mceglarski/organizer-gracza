import { Component, OnInit } from '@angular/core';
import {ActivatedRoute} from "@angular/router";
import {ForumService} from "../../_services/forum.service";
import {ForumPost, ForumThread} from "../../model/model";

@Component({
  selector: 'app-forum-posts',
  templateUrl: './forum-posts.component.html',
  styleUrls: ['./forum-posts.component.css']
})
export class ForumPostsComponent implements OnInit {

  public threadId: string | null;
  public thread: ForumThread;
  public posts: ForumPost[] = [];

  constructor(private activatedRoute: ActivatedRoute,
              private forumService: ForumService) { }

  ngOnInit(): void {
    this.threadId = this.activatedRoute.snapshot.paramMap.get('threadId');
    // @ts-ignore
    this.forumService.getForumPost(+this.threadId).subscribe(p => {
      // @ts-ignore
      this.posts = p;
      return;
    });
    // @ts-ignore
    this.forumService.getForumThread(this.threadId).subscribe(t => {
      // @ts-ignore
      this.thread = t;
      return;
    })
  }

}
