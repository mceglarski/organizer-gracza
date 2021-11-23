import {Component, OnInit} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {User} from "./model/model";
import {AccountService} from "./_services/account.service";
import {PresenceService} from "./_services/presence.service";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  title = 'organizer-gracza-frontend';

  constructor(private http: HttpClient,
              private accountService: AccountService,
              private presence: PresenceService) {
  }

  ngOnInit() {
    this.setCurrentUser();
  }

  private setCurrentUser(): void {
    // @ts-ignore
    const user: User = JSON.parse(localStorage.getItem('user'));
    if(user){
      this.accountService.setCurrentUser(user);
      this.presence.createHubConnection(user);
    }
  }

}
