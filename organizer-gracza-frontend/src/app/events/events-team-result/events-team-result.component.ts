import {Component, Inject, OnInit} from '@angular/core';
import {FormControl, Validators} from "@angular/forms";
import {EventTeam, EventTeamResult, Team} from "../../model/model";
import {Observable} from "rxjs";
import {MAT_DIALOG_DATA, MatDialogRef} from "@angular/material/dialog";
import {ToastrService} from "ngx-toastr";
import {map, startWith} from "rxjs/operators";
import {TeamsService} from "../../_services/teams.service";
import {EventTeamsResultsService} from "../../_services/event-teams-results.service";
import {EventsService} from "../../_services/events.service";

@Component({
  selector: 'app-events-team-result',
  templateUrl: './events-team-result.component.html',
  styleUrls: ['./events-team-result.component.css']
})
export class EventsTeamResultComponent implements OnInit {

  public myControl = new FormControl('', Validators.required);
  public teams: Team[] = [];
  public teamsParticipated: Team[] = [];
  public teamsName: string[] = [];
  public filteredTeams: Observable<Team[]>;

  private winnerTeam: Team;
  private teamEvent: EventTeam;
  private existingEventResult: EventTeamResult;
  private allEventsResults: EventTeamResult[];

  constructor(private dialogRef: MatDialogRef<EventsTeamResultComponent>,
              private teamsService: TeamsService,
              private eventsService: EventsService,
              private eventTeamsResultService: EventTeamsResultsService,
              private toastr: ToastrService,
              @Inject(MAT_DIALOG_DATA) public data: {
                event: EventTeam
              }) { }

  ngOnInit() {
    this.teamsService.getTeams().subscribe(t => {
      this.eventsService.getTeamEvent(this.data.event.eventTeamId).subscribe(e => {
        // @ts-ignore
        this.teamEvent = e;
        // @ts-ignore
        this.teams = t;
        this.eventTeamsResultService.getEventsTeamResults().subscribe(r => {
          // @ts-ignore
          this.allEventsResults = r;
          // @ts-ignore
          this.existingEventResult = this.allEventsResults.find(f => f.eventTeamId == this.data.event.eventTeamId);
          if (this.existingEventResult) {
            this.myControl.setValue(this.teams?.find(f => f.teamId === this.existingEventResult?.teamId)?.name);
          }

        });
        // @ts-ignore
        this.teamEvent.eventTeamRegistration.forEach(team => this.teamsParticipated.push(this.teams.find(f => f.teamId == team.teamId)));
        this.teamsParticipated.forEach(team => this.teamsName.push(team.name));

        this.filteredTeams = this.myControl.valueChanges.pipe(
          startWith(''),
          map(value => {
            return this.teamsParticipated.filter(option => option?.name?.toLowerCase()?.includes(value?.toLowerCase()))
          })
        );
      });
    });
  }

  public sendResult(): void {
    this.winnerTeam = <Team>this.teams?.find(m => m.name === this.myControl.value);

    if (this.existingEventResult && this.winnerTeam) {
      this.eventTeamsResultService
        .updateEventTeamResult({teamId: this.winnerTeam.teamId, eventTeamId: this.data.event.eventTeamId}, <number>this.existingEventResult.eventTeamResultId)
        .subscribe(() => {
          this.dialogRef.close();
          this.toastr.success('Pomyślnie zaktualizowano wynik wydarzenia');
        });
    } else if (this.winnerTeam) {
      this.eventTeamsResultService
        .addEventTeamResult({teamId: this.winnerTeam.teamId, eventTeamId: this.data.event.eventTeamId})
        .subscribe(() => {
          this.dialogRef.close();
          this.toastr.success('Pomyślnie dodano wynik wydarzenia');
        });
    } else {
      this.toastr.error('Wpisz poprawną nazwę drużyny');
    }
  }

  public closeModal(): void {
    this.dialogRef.close();
  }

}
