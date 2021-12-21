import { Component, OnInit } from '@angular/core';
import {ForumService} from "../../_services/forum.service";
import {ForumThread} from "../../model/model";

@Component({
  selector: 'app-forum-thread-list',
  templateUrl: './forum-thread-list.component.html',
  styleUrls: ['./forum-thread-list.component.css']
})
export class ForumThreadListComponent implements OnInit {

  public forumThread: ForumThread[] = [];

  constructor(private forumService: ForumService) { }

  ngOnInit(): void {
    this.forumService.getForumThreads().subscribe(f => {
      // @ts-ignore
      this.forumThread = f;
      console.log(f);
      return;
    })
  }

}
