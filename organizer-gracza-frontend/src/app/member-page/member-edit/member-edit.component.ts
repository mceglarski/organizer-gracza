import {Component, HostListener, OnInit, ViewChild} from '@angular/core';
import {Member, User} from "../../model/model";
import {AccountService} from "../../_services/account.service";
import {MembersService} from "../../_services/members.service";
import {take} from "rxjs/operators";
import {ToastrService} from "ngx-toastr";
import {NgForm} from "@angular/forms";

@Component({
  selector: 'app-member-edit',
  templateUrl: './member-edit.component.html',
  styleUrls: ['./member-edit.component.css']
})
export class MemberEditComponent implements OnInit {
  // @ts-ignore
  @ViewChild('editform') editForm: NgForm;
  // @ts-ignore
  member: Member;
  // @ts-ignore
  user: User;
  @HostListener('window:beforeunload', ['$event']) unloadNotification($event: any){
    if(this.editForm.dirty){
      $event.returnValue = true;
    }
  }

  constructor(private accountService: AccountService, private memberService: MembersService,
              private toastr: ToastrService) {
    this.accountService.currentUser$.pipe(take(1)).subscribe(user => this.user = user);
  }

  ngOnInit(): void {
    this.loadMember()
  }

  loadMember(){
    this.memberService.getMember(this.user.username).subscribe(member => {
      this.member = member;
    })
  }

  updateMember(){
    console.log(this.member);
    this.toastr.success('Profil został zaktualizowany!');
    this.editForm.reset(this.member);
  }

}