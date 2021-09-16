import {Component, OnInit} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {User} from "./model/model";
import {AccountService} from "./_services/account.service";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  title = 'organizer-gracza-frontend';
  users: any;

  constructor(private http: HttpClient, private accountService: AccountService) {
  }

  ngOnInit() {
    this.getUsers();
    this.setCurrentUser();
  }

  setCurrentUser(){
    // @ts-ignore
    const user: User = JSON.parse(localStorage.getItem('user'));
    this.accountService.setCurrentUser(user);
  }

  getUsers(){
    this.http.get("https://localhost:44347/api/events").subscribe(response => {
      this.users = response;
    }, error => {
      console.log(error);
    })
  }
}
