import {Component, OnDestroy, OnInit, ViewChild} from '@angular/core';
import {Member, Message, User} from "../../model/model";
import {MessageService} from "../../_services/message.service";
import {MembersService} from "../../_services/members.service";
import {AccountService} from "../../_services/account.service";
import {take} from "rxjs/operators";
import {ActivatedRoute, Router} from "@angular/router";
import {NgForm} from "@angular/forms";
import {ToastrService} from "ngx-toastr";

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
              private router: Router,
              private toastr: ToastrService) {
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

  public hasWhiteSpace(text: string): boolean {
    return text?.trim().length === 0;
  }

  public sendMessage(): void {
    this.loading = true;
    if (this.messageForm.valid && !this.hasWhiteSpace(this.messageContent)) {
      this.messageService.sendMessage(this.member.username, this.messageContent).then(() => {
        this.messageForm.reset();
      }).finally(() => this.loading = false);
    } else {
      this.loading = false;
    }
  }

  public deleteMessage(id: number): void {
    this.messageService.deleteMessage(id).subscribe(() => {
      window.location.reload();

    }, () => {
      this.toastr.error("Nie udało się usunąć wiadomości");

    });
  }

  private loadMessages(): void {
    this.messageService.getMessageThread(this.member.username).subscribe(messages => {
      this.messages = messages;
    })
  }

}
