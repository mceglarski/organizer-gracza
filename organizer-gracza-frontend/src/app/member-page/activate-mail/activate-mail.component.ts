import { Component, OnInit } from '@angular/core';
import {MembersService} from "../../_services/members.service";
import {Member, User} from "../../model/model";
import {AccountService} from "../../_services/account.service";
import {take} from "rxjs/operators";
import {Router} from "@angular/router";
import {ToastrService} from "ngx-toastr";

@Component({
  selector: 'app-activate-mail',
  templateUrl: './activate-mail.component.html',
  styleUrls: ['./activate-mail.component.css']
})
export class ActivateMailComponent implements OnInit {

  public member: Member;
  public user: User;

  constructor(private memberService: MembersService,
              private accountService: AccountService,
              private router: Router,
              private toastr: ToastrService) {
    this.accountService.currentUser$.pipe(take(1)).subscribe(user => this.user = user);
  }

  ngOnInit(): void {
    if (this.user) {
      this.memberService.getMember(this.user.username).subscribe(member => {
        this.member = member;
        return;
      });
    }
  }

  public activateEmail(): void {
    this.member.emailConfirmed = 1;
    this.memberService.emailConfirmed(this.member).subscribe(r => {
      this.router.navigate(['/']);
    }, error => {
      this.toastr.error('Coś poszło nie tak');
    });
  }

}
