import {ChangeDetectorRef, Component, OnInit} from '@angular/core';
import {EventsService} from "../../_services/events.service";
import {EventTeam, EventUser, Game, Photo, User} from "../../model/model";
import {FormControl, FormGroup, Validators} from "@angular/forms";
import {Router} from "@angular/router";
import {ToastrService} from "ngx-toastr";
import {NgbModal} from "@ng-bootstrap/ng-bootstrap";
import {GameService} from "../../_services/game.service";
import {FileUploader} from "ng2-file-upload";
import {AccountService} from "../../_services/account.service";
import {take} from "rxjs/operators";
import {environment} from "../../../environments/environment";
import {MatDialog} from "@angular/material/dialog";
import {EventsSoloUpdateComponent} from "../../events/events-solo-update/events-solo-update.component";
import {EventsTeamUpdateComponent} from "../../events/events-team-update/events-team-update.component";
import {EventUserResultsService} from "../../_services/event-user-results.service";
import {EventTeamsResultsService} from "../../_services/event-teams-results.service";
import {EventsSoloResultComponent} from "../../events/events-solo-result/events-solo-result.component";
import {EventsTeamResultComponent} from "../../events/events-team-result/events-team-result.component";



@Component({
  selector: 'app-event-management',
  templateUrl: './event-management.component.html',
  styleUrls: ['./event-management.component.css']
})
export class EventManagementComponent implements OnInit {

  public teamEvents: EventTeam[] = [];
  public userEvents: EventUser[] = [];
  public event: EventUser;
  public eventUser: EventUser;
  public eventTeam: EventTeam;
  public newUserEventForm: FormGroup;
  public newTeamEventForm: FormGroup;
  public validationErrors: string[] = [];
  public games: Game[] = [];
  public uploader: FileUploader;
  public hasBaseDropzoneOver = false;
  public user: User;

  private baseUrl = environment.apiUrl;


  constructor(public eventService: EventsService,
              public gameService: GameService,
              private eventUserResultService: EventUserResultsService,
              private eventTeamResultService: EventTeamsResultsService,
              private modalService: NgbModal,
              private toastr: ToastrService,
              private route: Router,
              private accountService: AccountService,
              private dialog: MatDialog,
              private cd: ChangeDetectorRef) {
    this.accountService.currentUser$.pipe(take(1)).subscribe(user => this.user = user);
  }

  ngOnInit(): void {
    this.init();
  }

  init(): void {
    this.loadUserEvents();
    this.loadTeamEvents();
    this.loadGames();
    this.initializeAddEventForm();
    this.initializeTeamEventForm();
  }

  public fileOverBase(e: any): void {
    this.hasBaseDropzoneOver = e;
  }

  public loadTeamEvents(): void {
    this.eventService.getTeamEvents().subscribe(teamEvents => {
      // @ts-ignore
      this.teamEvents = teamEvents;
    })

  }

  public loadUserEvents(): void {
    this.eventService.getUserEvents().subscribe(userEvents => {
      // @ts-ignore
      this.userEvents = userEvents;
      this.cd.detectChanges();
    })
  }

  public loadGames(): void {
    this.gameService.getGames().subscribe(games => {
      // @ts-ignore
      this.games = games;
    })
  }

  public loadEvent(): void {
    this.eventService.getUserEventByName(this.newUserEventForm.value.name).subscribe(specifiedEvent => {
      // @ts-ignore
      this.event = specifiedEvent;
    })
  }

  public loadTeamEvent(): void {
    this.eventService.getTeamEventByName(this.newTeamEventForm.value.name).subscribe(specifiedEvent => {
      // @ts-ignore
      this.eventTeam = specifiedEvent;
    })
  }

  public initializeUserUploader(): void {
    this.uploader = new FileUploader({
      url: this.baseUrl + 'eventsuser/add-photo/' + this.newUserEventForm.value.name,
      authToken: 'Bearer ' + this.user.token,
      isHTML5: true,
      allowedFileType: ['image'],
      removeAfterUpload: true,
      autoUpload: false,
      maxFileSize: 10 * 1024 * 1024
    });

    this.uploader.onSuccessItem = (item, response, status, headers) => {
      if(response) {
        this.loadEvent();
        const photo: Photo = JSON.parse(response);
        this.event.photoUrl = photo.url;
      }
    }
  }

  public initializeTeamUploader(): void {
    this.uploader = new FileUploader({
      url: this.baseUrl + 'eventsteam/add-photo/' + this.newTeamEventForm.value.name,
      authToken: 'Bearer ' + this.user.token,
      isHTML5: true,
      allowedFileType: ['image'],
      removeAfterUpload: true,
      autoUpload: false,
      maxFileSize: 10 * 1024 * 1024
    });

    this.uploader.onSuccessItem = (item, response, status, headers) => {
      if(response){
        this.loadTeamEvent();
        const photo: Photo = JSON.parse(response);
        this.eventTeam.photoUrl = photo.url;
      }
    }
  }

  public initializeAddEventForm(): void {
    this.newUserEventForm = new FormGroup({
      name: new FormControl('', Validators.required),
      description: new FormControl('', Validators.required),
      startDate: new FormControl('', Validators.required),
      endDate: new FormControl('', Validators.required),
      eventType: new FormControl('', Validators.required),
      winnerPrize: new FormControl('', Validators.required),
      eventOrganiser: new FormControl('', Validators.required),
      gameId: new FormControl('', Validators.required),
    })
  }

  public initializeTeamEventForm(): void {
    this.newTeamEventForm = new FormGroup({
      name: new FormControl('', Validators.required),
      description: new FormControl('', Validators.required),
      startDate: new FormControl('', Validators.required),
      endDate: new FormControl('', Validators.required),
      eventType: new FormControl('', Validators.required),
      winnerPrize: new FormControl('', Validators.required),
      eventOrganiser: new FormControl('', Validators.required),
      gameId: new FormControl('', Validators.required),
    })
  }

  public open(content: any): void {
    this.modalService.open(content, {ariaLabelledBy: 'modal-basic-title'});
  }

  public openEditEventUserModal(event: EventUser): void{
    const dialogRef = this.dialog.open(EventsSoloUpdateComponent, {
      width: '530px',
      disableClose: true,
      data: {
        event: event,
        user: this.user
      }
    });
    dialogRef.afterClosed().subscribe(() => {
      this.init();

    });
  }

  public openEditEventTeamModal(event: EventTeam): void{
    const dialogRef = this.dialog.open(EventsTeamUpdateComponent, {
      width: '530px',
      disableClose: true,
      data: {
        event: event,
        user: this.user
      }
    });
    dialogRef.afterClosed().subscribe(() => {
      this.init();

    });
  }

  public newUserEvent(): void {
    this.eventService.addUserEvent(this.newUserEventForm.value).subscribe(response => {
      this.toastr.info("Wydarzenie zostało dodane");
    }, error => {
      this.toastr.error("Nie udało się dodać nowego wydarzenia");
      console.log(error);
      this.validationErrors = error;
    })
    this.initializeUserUploader();
  }

  public newTeamEvent(): void {
    this.eventService.addTeamEvent(this.newTeamEventForm.value).subscribe(response => {
      this.toastr.info("Wydarzenie zostało dodane");
    }, error => {
      this.toastr.error("Nie udało się dodać nowego wydarzenia");
      console.log(error);
      this.validationErrors = error;
    })
    this.initializeTeamUploader();
  }

  public setUserEventResult(userEvent: EventUser): void {
    const dialogRef = this.dialog.open(EventsSoloResultComponent, {
      width: '530px',
      data: {
        event: userEvent,
        user: this.user
      }
    });
    dialogRef.afterClosed().subscribe(() => {
      this.init();

    });
  }

  public setTeamEventResult(teamEvent: EventTeam): void {
    const dialogRef = this.dialog.open(EventsTeamResultComponent, {
      width: '530px',
      data: {
        event: teamEvent,
        user: this.user
      }
    });
    dialogRef.afterClosed().subscribe(() => {
      this.init();

    });
  }

  public deleteUserEvent(eventUserId: number): void {
    this.eventService.deleteUserEvent(eventUserId).subscribe(() => {
      this.userEvents.splice(this.userEvents.findIndex(x => x.eventUserId === eventUserId), 1);
    })
  }

  public deleteTeamEvent(eventTeamId: number): void {
    this.eventService.deleteTeamEvent(eventTeamId).subscribe(() => {
      this.teamEvents.splice(this.teamEvents.findIndex(x => x.eventTeamId === eventTeamId), 1);
    })
  }

}
