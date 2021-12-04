import {Component, Input, OnDestroy, OnInit, ViewChild} from '@angular/core';
import {Member, Message, User} from "../../model/model";
import {MessageService} from "../../_services/message.service";
import {MembersService} from "../../_services/members.service";
import {AccountService} from "../../_services/account.service";
import {take} from "rxjs/operators";
import {ActivatedRoute, Router} from "@angular/router";
import {NgForm} from "@angular/forms";

@Component({
  selector: 'app-messages-members-chat',
  templateUrl: './messages-members-chat.component.html',
  styleUrls: ['./messages-members-chat.component.css']
})
export class MessagesMembersChatComponent implements OnInit, OnDestroy {
  @ViewChild('messageForm') messageForm: NgForm;
  public messages: Message[];
  public user: User;
  public member: Member;
  public messageContent: string;

  constructor(public messageService: MessageService,
              private memberService: MembersService,
              private accountService: AccountService, private route: ActivatedRoute, private router: Router) {
    this.accountService.currentUser$.pipe(take(1)).subscribe(user => {
      this.user = user;
      this.router.routeReuseStrategy.shouldReuseRoute = () => false;
    })
  }

  ngOnInit(): void {
    this.route.data.subscribe(data => {
      this.member = data.member;
    })
      this.messageService.createHubConnection(this.user, this.member.username);
  }

  ngOnDestroy(): void {
    this.messageService.stopHubConnection();
  }

  private loadMessages() {
      this.messageService.getMessageThread(this.member.username).subscribe(messages => {
        this.messages = messages;
      })
  }

  public sendMessage(){
    this.messageService.sendMessage(this.member.username, this.messageContent).then(() => {
      this.messageForm.reset();
    })
  }

}
