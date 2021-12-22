import {Injectable} from '@angular/core';
import {environment} from "../../environments/environment";
import {HttpClient} from "@angular/common/http";
import {Member, PagintationParams} from "../model/model";
import {of,} from "rxjs";
import {map} from "rxjs/operators";
import {getPaginatedResult, getPaginationHeaders} from "./paginationHelper";

@Injectable({
  providedIn: 'root'
})
export class MembersService {
  baseUrl = environment.apiUrl;
  members: Member[] = [];
  memberCache = new Map();

  constructor(private http: HttpClient) {
  }

  // getMembers() {
  //   if(this.members.length > 0)
  //     return of(this.members);
  //   return this.http.get<Member[]>(this.baseUrl + 'users').pipe(
  //     map(members => {
  //       this.members = members;
  //       return members;
  //     })
  //   )
  // }

  // getMember(username: string) {
  //   const member = this.members.find(x => x.username === username);
  //   if (member !== undefined)
  //     return of(member);
  //   return this.http.get<Member>(this.baseUrl + 'users/' + username);
  // }

  getMembers(userParams: PagintationParams) {
    var response = this.memberCache.get(Object.values(userParams).join('-'));
    if(response){
      return of(response);
    }

    let params = getPaginationHeaders(userParams.pageNumber, userParams.pageSize);

    return getPaginatedResult<Member[]>(this.baseUrl + 'users', params, this.http)
      .pipe(map(response => {
        this.memberCache.set(Object.values(userParams).join('-'), response);
        return response;
      }))
  }

  getCurrentlyLoggedMemberId() {
    return this.http.get(this.baseUrl + 'users/member');
  }

  getMember(username: string) {
    const member = [...this.memberCache.values()]
      .reduce((arr, elem) => arr.concat(elem.result), [])
      .find((member: Member) => member.username === username);

    if(member){
      return of(member);
    }

    return this.http.get<Member>(this.baseUrl + 'users/' + username);
  }

  getMemberById(userId: number){
    const member = [...this.memberCache.values()]
      .reduce((arr, elem) => arr.concat(elem.result), [])
      .find((member: Member) => member.id === userId);

    if(member){
      return of(member);
    }

    return this.http.get<Member>(this.baseUrl + 'users/member/' + userId);
  }

  getMemberIdByUsername(username: string) {
    const member = [...this.memberCache.values()]
      .reduce((arr, elem) => arr.concat(elem.result), [])
      .find((member: Member) => member.username === username);

    return this.http.get<number>(this.baseUrl + 'users/user/' + username);
  }

  updateMember(member: Member) {
    return this.http.put(this.baseUrl + 'users', member).pipe(
      map(() => {
        const index = this.members.indexOf(member);
        this.members[index] = member;
      })
    )
  }

  setMainPhoto(photoId: number) {
    return this.http.put(this.baseUrl + 'users/set-main-photo/' + photoId, {})
  }

  deletePhoto(photoId: number) {
    return this.http.delete(this.baseUrl + 'users/delete-photo/' + photoId);
  }

}
