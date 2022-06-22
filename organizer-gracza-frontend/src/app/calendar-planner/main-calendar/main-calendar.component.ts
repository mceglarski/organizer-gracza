import {ChangeDetectorRef, Component, OnInit} from '@angular/core';
import {CalendarOptions} from "@fullcalendar/angular";
import {ReminderService} from "../../_services/reminder.service";
import {MatDialog} from "@angular/material/dialog";
import {AddNewEventModalComponent} from "../add-new-event-modal/add-new-event-modal.component";
import {Reminder, User} from "../../model/model";
import {EventDetailModalComponent} from "../event-detail-modal/event-detail-modal.component";
import {take} from "rxjs/operators";
import {AccountService} from "../../_services/account.service";

@Component({
  selector: 'app-main-calendar',
  templateUrl: './main-calendar.component.html',
  styleUrls: ['./main-calendar.component.css']
})
export class MainCalendarComponent implements OnInit {

  private reminderArray: Reminder[] = [];
  private eventSource: any[] = []
  public user: User;

  public calendarOptions: CalendarOptions = {};

  constructor(private dialog: MatDialog,
              private reminderService: ReminderService,
              private cd: ChangeDetectorRef,
              private accountService: AccountService) {
    this.accountService.currentUser$.pipe(take(1)).subscribe(user => {
      this.user = user;
    });
  }

  ngOnInit(): void {
    this.init();
  }

  public init(): void {
    this.reminderService.getRemindsForUserById(this.user.id).subscribe(reminder => {
      // @ts-ignore
      this.reminderArray = reminder;
      this.reminderArray.forEach( r => {
        this.eventSource.push({
          title: r.title,
          date: r.startDate,
          allDay: false,
          id: r.reminderId
        });

      })
      this.cd.detectChanges();
      this.calendarOptions = {
        initialView: 'dayGridMonth',
        themeSystem: 'Darkly',
        locale: 'pl',
        firstDay: 1,
        buttonText: {
          today: 'Dzisiaj',
          month: 'Widok miesiąca',
          listMonth: 'Widok listy'
        },
        navLinks: true,
        headerToolbar: {
          end: 'today dayGridMonth listMonth prev,next',
        },
        selectable: true,
        dayMaxEventRows: true,
        eventDisplay: 'block',
        events: this.eventSource,
        eventClick: (info) => { this.openEventDetailModal(info); }
      }
      this.cd.detectChanges();
    });
    this.cd.detectChanges();
  }

  public addNewEvent(): void {
    const dialogRef = this.dialog.open(AddNewEventModalComponent, {
      width: '600px',
      disableClose: true
    });
    dialogRef.afterClosed().subscribe(() => {
      this.init();
      this.cd.detectChanges();

    });
  }

  private openEventDetailModal(event: any): void {
    const dialogRef = this.dialog.open(EventDetailModalComponent, {
      width: '600px',
      data: {
        event: event,
        memberId: this.user.id
      }
    });
    dialogRef.afterClosed().subscribe(() => {
      this.init();
      this.cd.detectChanges();

    });
  }

}
