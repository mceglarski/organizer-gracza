import {Component, Inject, OnInit} from '@angular/core';
import {MAT_DIALOG_DATA, MatDialogRef} from "@angular/material/dialog";
import {EventUser} from "../../model/model";
import {ReminderService} from "../../_services/reminder.service";

@Component({
  selector: 'app-event-detail-modal',
  templateUrl: './event-detail-modal.component.html',
  styleUrls: ['./event-detail-modal.component.css']
})
export class EventDetailModalComponent implements OnInit {

  constructor(public dialogRef: MatDialogRef<EventDetailModalComponent>,
              private reminderService: ReminderService,
              @Inject(MAT_DIALOG_DATA) public data: {
                event: any
              }){ }

  ngOnInit(): void {
    console.log(this.data.event);
  }

  public editReminder(): void {

  }

  public deleteReminder(): void {

  }

  public closeModal(): void {
    this.dialogRef.close();
  }

}
