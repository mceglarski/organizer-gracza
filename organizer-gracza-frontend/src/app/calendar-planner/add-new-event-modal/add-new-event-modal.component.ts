import {ChangeDetectionStrategy, Component, OnInit} from '@angular/core';
import {MatDialogRef} from "@angular/material/dialog";
import {FormControl, FormGroup, Validators} from "@angular/forms";
import {ReminderService} from "../../_services/reminder.service";
import {ToastrService} from "ngx-toastr";

@Component({
  selector: 'app-add-new-event-modal',
  templateUrl: './add-new-event-modal.component.html',
  styleUrls: ['./add-new-event-modal.component.css']
})
export class AddNewEventModalComponent implements OnInit {

  public addNewEventForm: FormGroup = new FormGroup({
    eventName: new FormControl('', Validators.required),
    eventDatePick: new FormControl('', Validators.required)
  });

  private currentUser: any;

  constructor(public dialogRef: MatDialogRef<AddNewEventModalComponent>,
              private reminderService: ReminderService,
              private toastr: ToastrService) { }

  ngOnInit(): void {
    // @ts-ignore
    this.currentUser = JSON.parse(localStorage.getItem('user'));
  }

  public addNewEvent(): void {
    if (this.addNewEventForm.valid) {
      this.reminderService.addReminder({
        title: this.addNewEventForm.controls.eventName.value,
        startDate: this.addNewEventForm.controls.eventDatePick.value,
        userId: this.currentUser.id
      }).subscribe(response => {
        window.location.reload();
        this.toastr.info("Wydarzenie zostało dodane");
        this.dialogRef.close();
      }, error => {
        this.toastr.error("Nie udało się dodać nowego wydarzenia");
        console.log(error);
      });
    }
  }

  public closeModal(): void {
    this.dialogRef.close();
  }

}
