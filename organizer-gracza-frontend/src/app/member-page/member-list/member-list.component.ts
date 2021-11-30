import { Component, OnInit } from '@angular/core';
import {Member, Pagination, User, PagintationParams} from "../../model/model";
import {MembersService} from "../../_services/members.service";
import {AccountService} from "../../_services/account.service";
import {take} from "rxjs/operators";

@Component({
  selector: 'app-member-list',
  templateUrl: './member-list.component.html',
  styleUrls: ['./member-list.component.css']
})
export class MemberListComponent implements OnInit {

  public members: Member[];
  public pagination: Pagination;

  private userParams: PagintationParams;
  private user: User;

  constructor(private memberService: MembersService,
              private accountService: AccountService) {
    this.accountService.currentUser$.pipe(take(1)).subscribe(user => {
      this.user = user;
      this.userParams = new PagintationParams();
    })
  }

  ngOnInit(): void {
    this.loadMembers();
  }

  public pageChanged(event: any){
    this.userParams.pageNumber = event.page;
    this.loadMembers();
  }

  private loadMembers(){
    this.memberService.getMembers(this.userParams).subscribe(response => {
      this.members = response.result;
      this.pagination = response.pagination;
    })
  }
}
