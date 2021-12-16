import {ChangeDetectorRef, Component, OnInit} from '@angular/core';
import {CalendarOptions} from "@fullcalendar/angular";
import {ReminderService} from "../../_services/reminder.service";
import {MatDialog} from "@angular/material/dialog";
import {AddNewEventModalComponent} from "../add-new-event-modal/add-new-event-modal.component";
import {Reminder} from "../../model/model";

@Component({
  selector: 'app-main-calendar',
  templateUrl: './main-calendar.component.html',
  styleUrls: ['./main-calendar.component.css']
})
export class MainCalendarComponent implements OnInit {

  private reminderArray: Reminder[] = [];
  private eventSource: any[] = []
  private currentUser: any;

  public calendarOptions: CalendarOptions = {};

  constructor(private dialog: MatDialog,
              private reminderService: ReminderService,
              private cd: ChangeDetectorRef) {  }

  ngOnInit(): void {
    // @ts-ignore
    this.currentUser = JSON.parse(localStorage.getItem('user'));
    this.init();
  }

  public init(): void {
    this.reminderService.getRemindsForUserById(this.currentUser.id).subscribe(reminder => {
      // @ts-ignore
      this.reminderArray = reminder;
      this.reminderArray.forEach( r => {
        this.eventSource.push({
          title: r.title,
          date: r.startDate,
          allDay: false
        });
        return;
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
        events: this.eventSource
      }
      this.cd.detectChanges();
    });
    this.cd.detectChanges();
  }

  public addNewEvent() {
    const dialogRef = this.dialog.open(AddNewEventModalComponent, {
      width: '600px',
      disableClose: true
    });
    dialogRef.afterClosed().subscribe(() => {
      this.init();
      this.cd.detectChanges();
      return;
    });
  }

}
