import {Component, Input, OnInit, ViewChild} from '@angular/core';
import {Member, Message, User} from "../../model/model";
import {MessageService} from "../../_services/message.service";
import {MembersService} from "../../_services/members.service";
import {AccountService} from "../../_services/account.service";
import {take} from "rxjs/operators";
import {ActivatedRoute} from "@angular/router";
import {NgForm} from "@angular/forms";

@Component({
  selector: 'app-messages-members-chat',
  templateUrl: './messages-members-chat.component.html',
  styleUrls: ['./messages-members-chat.component.css']
})
export class MessagesMembersChatComponent implements OnInit {
  // @ts-ignore
  @ViewChild('messageForm') messageForm: NgForm;
  // @ts-ignore
  messages: Message[];
  // @ts-ignore
  user: User;
  // @ts-ignore
  member: Member;
  // @ts-ignore
  messageContent: string;

  constructor(private messageService: MessageService, private memberService: MembersService,
              private accountService: AccountService, private route: ActivatedRoute) {
    this.accountService.currentUser$.pipe(take(1)).subscribe(user => {
      this.user = user;
    })
  }

  ngOnInit(): void {
    this.route.data.subscribe(data => {
      this.member = data.member;
    })
    this.loadMessages();
  }

  loadMessages() {
      this.messageService.getMessageThread(this.member.username).subscribe(messages => {
        this.messages = messages;
      })
  }

  sendMessage(){
    this.messageService.sendMessage(this.member.username, this.messageContent).subscribe(message => {
      this.messages.push(message);
      this.messageForm.reset();
    })
  }
}
