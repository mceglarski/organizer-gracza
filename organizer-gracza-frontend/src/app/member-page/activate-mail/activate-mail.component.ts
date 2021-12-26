import { Component, OnInit } from '@angular/core';
import {MembersService} from "../../_services/members.service";
import {Member, User} from "../../model/model";
import {AccountService} from "../../_services/account.service";
import {take} from "rxjs/operators";

@Component({
  selector: 'app-activate-mail',
  templateUrl: './activate-mail.component.html',
  styleUrls: ['./activate-mail.component.css']
})
export class ActivateMailComponent implements OnInit {

  public member: Member;
  private user: User;

  constructor(private memberService: MembersService,
              private accountService: AccountService) {
    this.accountService.currentUser$.pipe(take(1)).subscribe(user => this.user = user);
  }

  ngOnInit(): void {

  }

}
