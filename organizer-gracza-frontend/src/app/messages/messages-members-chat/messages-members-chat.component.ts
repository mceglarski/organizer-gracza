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
  public loading = false;

  constructor(public messageService: MessageService,
              private memberService: MembersService,
              private accountService: AccountService,
              private route: ActivatedRoute,
              private router: Router) {
    this.accountService.currentUser$.pipe(take(1)).subscribe(user => {
      this.user = user;
      this.router.routeReuseStrategy.shouldReuseRoute = () => false;
    })
  }

  ngOnInit(): void {
    this.route.data.subscribe(data => {
      this.member = data.member;
    });
    this.messageService.createHubConnection(this.user, this.member.username);
  }

  ngOnDestroy(): void {
    this.messageService.stopHubConnection();
  }

  public sendMessage() {
    this.loading = true;
    this.messageService.sendMessage(this.member.username, this.messageContent).then(() => {
      this.messageForm.reset();
    }).finally(() => this.loading = false);
  }

  public triggerFunction(event: any) {
    console.log(event);
    if (event.ctrlKey && event.key === 'Enter') {
      /*
        cannot make textarea produce a next line.
      */
      let text = document.getElementById("messagesMemberChatInput");
      // @ts-ignore
      text.value += '\n';
      console.log(text);
      //  text = text.

      console.log("next line!");
    } else if (event.key === 'Enter') {
      event.preventDefault();
      console.log("submit!");
    }
  }

  private loadMessages() {
    this.messageService.getMessageThread(this.member.username).subscribe(messages => {
      this.messages = messages;
    })
  }

}
