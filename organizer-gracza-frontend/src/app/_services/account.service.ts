import {Injectable} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {BehaviorSubject, ReplaySubject} from "rxjs";
import {map} from "rxjs/operators";
import {User} from "../model/model";

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  baseUrl = 'https://localhost:44347/api/';
  private currentUserSource = new ReplaySubject<User>(1);
  currentUser$ = this.currentUserSource.asObservable();

  constructor(private http: HttpClient) {}

  login(model: any){
    return this.http.post(this.baseUrl + 'account/login', model).pipe(
      // @ts-ignore
      map((response: User) => {
       const user = response;
       if(user){
         localStorage.setItem('user', JSON.stringify(user));
         this.setCurrentUser(user);
       }
     })
    )
  }

  setCurrentUser(user: User){
    this.currentUserSource.next(user);
  }

  logout(){
    localStorage.removeItem('user');
    // @ts-ignore
    this.currentUserSource.next(null);
  }
}
