import {Component, OnChanges, OnInit} from '@angular/core';
import {LoginComponent} from "../../login/login.component";
import {AccountService} from "../../_services/account.service";
import {MemberContentComponent} from "../../member-page/member-content/member-content.component";

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  public isLogged = false;

  constructor(public login: LoginComponent,
              public accountService: AccountService) {}

  ngOnInit(): void {
    this.isLogged = !!this.accountService.currentUser$;
  }
}
