import {Component, Inject, OnInit} from '@angular/core';
import {FormControl, Validators} from "@angular/forms";
import {EventTeam, EventTeamResult, EventUser, EventUserResult, Member, Team} from "../../model/model";
import {Observable} from "rxjs";
import {MAT_DIALOG_DATA, MatDialogRef} from "@angular/material/dialog";
import {MembersService} from "../../_services/members.service";
import {EventUserResultsService} from "../../_services/event-user-results.service";
import {ToastrService} from "ngx-toastr";
import {map, startWith} from "rxjs/operators";
import {TeamsService} from "../../_services/teams.service";
import {EventTeamsResultsService} from "../../_services/event-teams-results.service";

@Component({
  selector: 'app-events-team-result',
  templateUrl: './events-team-result.component.html',
  styleUrls: ['./events-team-result.component.css']
})
export class EventsTeamResultComponent implements OnInit {

  public myControl = new FormControl('', Validators.required);
  public teams: Team[] = [];
  public teamsName: string[] = [];
  public filteredTeams: Observable<Team[]>;

  private winnerTeam: Team;
  private existingEventResult: EventTeamResult;
  private allEventsResults: EventTeamResult[];

  constructor(private dialogRef: MatDialogRef<EventsTeamResultComponent>,
              private teamsService: TeamsService,
              private eventTeamsResultService: EventTeamsResultsService,
              private toastr: ToastrService,
              @Inject(MAT_DIALOG_DATA) public data: {
                event: EventTeam
              }) { }

  ngOnInit() {
    this.teamsService.getTeams().subscribe(t => {
      // @ts-ignore
      this.teams = t;
      console.log(this.teams);
      this.teams.forEach(team => this.teamsName.push(team.name));

      this.filteredTeams = this.myControl.valueChanges.pipe(
        startWith(''),
        map(value => {
          return this.teams.filter(option => option?.name?.toLowerCase()?.includes(value?.toLowerCase()))
        })
      );

      this.eventTeamsResultService.getEventsTeamResults().subscribe(r => {
        // @ts-ignore
        this.allEventsResults = r;
        console.log(this.allEventsResults);
        // @ts-ignore
        this.existingEventResult = this.allEventsResults.find(f => f.eventTeamId == this.data.event.eventTeamId);
        if (this.existingEventResult) {
          this.myControl.setValue(this.teams?.find(f => f.teamId === this.existingEventResult?.teamId)?.name);
        }
        return;
      });
    });
  }

  public sendResult(): void {
    this.winnerTeam = <Team>this.teams?.find(m => m.name === this.myControl.value);

    if (this.existingEventResult && this.winnerTeam) {
      this.eventTeamsResultService
        .updateEventTeamResult({teamId: this.winnerTeam.teamId, eventTeamId: this.data.event.eventTeamId}, <number>this.existingEventResult.eventTeamResultId)
        .subscribe(r => {
          this.dialogRef.close();
          this.toastr.success('Pomyślnie zaktualizowano wynik wydarzenia');
        });
    } else if (this.winnerTeam) {
      this.eventTeamsResultService
        .addEventTeamResult({teamId: this.winnerTeam.teamId, eventTeamId: this.data.event.eventTeamId})
        .subscribe(r => {
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
