import { Injectable } from '@angular/core';
import {environment} from "../../environments/environment";
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {Member} from "../model/model";

// const httpOptions = {
//   headers: new HttpHeaders({
//     Authorization: 'Bearer ' + JSON.parse(<string>localStorage.getItem('user'))?.token
//   })
// };

@Injectable({
  providedIn: 'root'
})
export class MembersService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getMembers() {
    return this.http.get<Member[]>(this.baseUrl + 'users');
  }

  getMember(username: string){
    return this.http.get<Member>(this.baseUrl + 'users/' + username)
  }
}