import { Injectable } from '@angular/core';
import {environment} from "../../environments/environment";
import {HttpClient} from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class ForumService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getForumThreads(){
    return this.http.get(this.baseUrl + 'forumthread');
  }

  getForumThread(forumThreadId: number){
    return this.http.get(this.baseUrl + 'forumthread/' + forumThreadId);
  }

  getForumThreadsByUserid(userId: number){
    return this.http.get(this.baseUrl + 'forumthread/userId/' + userId);
  }

  addForumThread(model: any){
    return this.http.post(this.baseUrl + 'forumthread', model)
  }

  deleteForumThread(forumThreadId: number){
    return this.http.delete(this.baseUrl + 'forumthread/' + forumThreadId)
  }

  updateForumThread(forumThread: any, forumThreadId: number){
    return this.http.put(this.baseUrl + 'forumthread/' + forumThreadId, forumThread)
  }

  getForumPosts(){
    return this.http.get(this.baseUrl + 'forumpost');
  }

  getForumPost(forumPostId: number){
    return this.http.get(this.baseUrl + 'forumpost/' + forumPostId);
  }

  getForumPostsByUserId(userId: number){
    return this.http.get(this.baseUrl + 'forumpost/userId/' + userId);
  }

  addForumPost(model: any){
    return this.http.post(this.baseUrl + 'forumpost', model)
  }

  deleteForumPost(forumPostId: number){
    return this.http.delete(this.baseUrl + 'forumpost/' + forumPostId)
  }

  updateForumPost(forumPost: any, forumPostId: number){
    return this.http.put(this.baseUrl + 'forumpost/' + forumPostId, forumPost)
  }
}
