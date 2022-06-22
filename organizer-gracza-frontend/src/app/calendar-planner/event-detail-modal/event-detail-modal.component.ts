import {Component, Inject, OnInit} from '@angular/core';
import {MAT_DIALOG_DATA, MatDialogRef} from "@angular/material/dialog";
import {EventTeam, EventUser} from "../../model/model";
import {ReminderService} from "../../_services/reminder.service";
import {EventsService} from "../../_services/events.service";
import {Router} from "@angular/router";
import {FormControl, FormGroup} from "@angular/forms";

@Component({
  selector: 'app-event-detail-modal',
  templateUrl: './event-detail-modal.component.html',
  styleUrls: ['./event-detail-modal.component.css']
})
export class EventDetailModalComponent implements OnInit {

  public editMode: boolean = false;
  public reminderTitle: string = '';
  public reminderDate: Date = new Date();
  public isEventUser: number;
  public isEventTeam: number;
  public eventUrl: string;
  public editReminderForm: FormGroup= new FormGroup({
    date: new FormControl()
  });

  private eventsUser: EventUser[] = [];
  private eventsTeam: EventTeam[] = [];
  private editedReminderId: number;

  constructor(public dialogRef: MatDialogRef<EventDetailModalComponent>,
              public router: Router,
              private eventsService: EventsService,
              private reminderService: ReminderService,
              @Inject(MAT_DIALOG_DATA) public data: {
                event: any,
                memberId: number
              }){ }

  ngOnInit(): void {
    this.reminderTitle = this.data.event.event.title;
    this.reminderDate = this.data.event.event.start;
    this.editedReminderId = this.data.event.event.id;
    this.eventsService.getUserEvents().subscribe(e => {
      // @ts-ignore
      this.eventsUser = e;
      // @ts-ignore
      this.isEventUser = this.eventsUser.find(e => e.name == this.reminderTitle)?.eventUserId;
      if (this.isEventUser) {
        this.eventUrl = 'events/eventsuser/'+this.isEventUser;
      }
    });
    this.eventsService.getTeamEvents().subscribe(e => {
      // @ts-ignore
      this.eventsTeam = e;
      // @ts-ignore
      this.isEventTeam = this.eventsTeam.find(e => e.name == this.reminderTitle)?.eventTeamId;
      if (this.isEventTeam) {
        this.eventUrl = 'events/eventsteam/'+this.isEventTeam;
      }
    });
  }

  public editReminder(): void {
    this.editMode = true;
  }

  public saveReminder(): void {
    this.reminderService.updateReminder({
      title: this.reminderTitle,
      startDate: this.reminderDate
    }, this.editedReminderId).subscribe();
    this.editMode = false;
    window.location.reload();
    this.closeModal();
  }

  public deleteReminder(): void {
    this.reminderService.deleteReminder(this.editedReminderId).subscribe();
    window.location.reload();
    this.closeModal();
  }

  public closeModal(): void {
    this.dialogRef.close();
  }

}
