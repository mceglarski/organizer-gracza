import {Component, Inject, OnInit} from '@angular/core';
import {FormControl, Validators} from "@angular/forms";
import {MembersService} from "../../_services/members.service";
import {EventUser, EventUserResult, Member} from "../../model/model";
import {Observable} from "rxjs";
import {map, startWith} from "rxjs/operators";
import {MAT_DIALOG_DATA, MatDialogRef} from "@angular/material/dialog";
import {EventUserResultsService} from "../../_services/event-user-results.service";
import {ToastrService} from "ngx-toastr";
import {EventsService} from "../../_services/events.service";

@Component({
  selector: 'app-events-solo-result',
  templateUrl: './events-solo-result.component.html',
  styleUrls: ['./events-solo-result.component.css']
})
export class EventsSoloResultComponent implements OnInit {

  public myControl = new FormControl('', Validators.required);
  public members: Member[] = [];
  public membersParticipated: Member[] = [];
  public membersNickname: string[] = [];
  public filteredMembers: Observable<Member[]>;

  private winnerMember: Member;
  private userEvent: EventUser;
  private existingEventResult: EventUserResult;
  private allEventsResults: EventUserResult[];

  constructor(private dialogRef: MatDialogRef<EventsSoloResultComponent>,
              private membersService: MembersService,
              private eventsService: EventsService,
              private eventUserResultService: EventUserResultsService,
              private toastr: ToastrService,
              @Inject(MAT_DIALOG_DATA) public data: {
                event: EventUser
              }) { }

  ngOnInit() {
    this.membersService.getMembers({pageNumber: 1, pageSize: 99999}).subscribe(member => {
      this.eventsService.getUserEvent(this.data.event.eventUserId).subscribe(e => {
        // @ts-ignore
        this.userEvent = e;
        this.members = member.result;
        this.eventUserResultService.getEventsUserResults().subscribe(eventUserResult => {
          // @ts-ignore
          this.allEventsResults = eventUserResult;
          // @ts-ignore
          this.existingEventResult = this.allEventsResults.find(f => f.eventUserId == this.data.event.eventUserId);
          if (this.existingEventResult) {
            this.myControl.setValue(this.members?.find(f => f.id === this.existingEventResult?.userId)?.nickname);
          }
        });
        // @ts-ignore
        this.userEvent.eventUserRegistration.forEach(user => this.membersParticipated.push(this.members.find(f => f.id == user.userId)));
        this.membersParticipated.forEach(member => this.membersNickname.push(member.nickname));

        this.filteredMembers = this.myControl.valueChanges.pipe(
          startWith(''),
          map(value => {
            return this.membersParticipated.filter(option => option?.nickname?.toLowerCase()?.includes(value?.toLowerCase()))
          })
        );
      });
    });
  }

  public sendResult(): void {
    this.winnerMember = <Member>this.members?.find(m => m.nickname === this.myControl.value);

    if (this.existingEventResult && this.winnerMember) {
      this.eventUserResultService
        .updateEventUserResult({userId: this.winnerMember.id, eventUserId: this.data.event.eventUserId}, <number>this.existingEventResult.eventUserResultId)
        .subscribe(() => {
          this.dialogRef.close();
          this.toastr.success('Pomyślnie zaktualizowano wynik wydarzenia');
        });
    } else if (this.winnerMember) {
      this.eventUserResultService
        .addEventUserResult({userId: this.winnerMember.id, eventUserId: this.data.event.eventUserId})
        .subscribe(() => {
          this.dialogRef.close();
          this.toastr.success('Pomyślnie dodano wynik wydarzenia');
        });
    } else {
      this.toastr.error('Wpisz poprawny nickname użytkownika');
    }
  }

  public closeModal(): void {
    this.dialogRef.close();
  }

}
