import { Component, OnInit } from '@angular/core';
import {Message, Pagination, User} from "../../model/model";
import {MessageService} from "../../_services/message.service";

@Component({
  selector: 'app-messages-chat',
  templateUrl: './messages-chat.component.html',
  styleUrls: ['./messages-chat.component.css']
})
export class MessagesChatComponent implements OnInit {
  public messages: Message[] = [];
  public chatInfo: {pictureUrl: string, titleName: string, term: string}[] = [];
  public pagination: Pagination;
  public container = 'Unread';
  public pageNumber = 1;
  public pageSize = 5;
  public loading = false;

  private currentUser: User = JSON.parse(<string>localStorage.getItem('user'));

  constructor(private messageService: MessageService) { }

  ngOnInit(): void {
    this.getAllUserThread();
    this.getPicturesFromMessages();
  }

  public deleteMessage(id: number): void {
    this.messageService.deleteMessage(id).subscribe(() => {
      this.messages.splice(this.messages.findIndex(m => m.messageId === id), 1);
    })
  }

  public pageChanged(event: any): void {
    this.pageNumber = event.page;
    this.loadMessages();
  }

  public loadMessages(): void {
    this.loading = true;
    this.messageService.getMessages(this.pageNumber, this.pageSize, this.container).subscribe(response => {
      this.messages = response.result;
      this.pagination = response.pagination;
      this.loading = false;
    })
  }

  private getAllUserThread(): void {
    this.messageService.getAllUserMessageThread().subscribe(response => {
      this.messages = response;
      this.getPicturesFromMessages();
    });
  }

  private getPicturesFromMessages(): void {
    this.messages.forEach(m => {
      if (m.senderUsername === this.currentUser.username) {
        if (m.recipientPhotoUrl === null) {
          m.recipientPhotoUrl = 'https://randomuser.me/api/portraits/lego/8.jpg';
        }
        this.chatInfo.push({pictureUrl: m.recipientPhotoUrl, titleName: m.recipientUsername, term: 'Ty'})
      }
      else {
        if (m.senderPhotoUrl === null) {
          m.senderPhotoUrl = 'https://randomuser.me/api/portraits/lego/8.jpg';
        }
        this.chatInfo.push({pictureUrl: m.senderPhotoUrl, titleName: m.senderUsername, term: 'Nadawca'});
      }
    })
  }

}
