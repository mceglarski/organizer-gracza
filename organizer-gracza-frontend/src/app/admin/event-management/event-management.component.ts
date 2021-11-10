import {Component, OnInit} from '@angular/core';
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
import {MatDialog, MatDialogRef, MatDialogModule} from "@angular/material/dialog";
import {EventsSoloUpdateComponent} from "../../events/events-solo-update/events-solo-update.component";



@Component({
  selector: 'app-event-management',
  templateUrl: './event-management.component.html',
  styleUrls: ['./event-management.component.css']
})
export class EventManagementComponent implements OnInit {
  // @ts-ignore
  teamEvents: EventTeam[];
  // @ts-ignore
  userEvents: EventUser[];
  // @ts-ignore
  event: EventUser;
  // @ts-ignore
  eventUser: EventUser;
  // @ts-ignore
  eventTeam: EventTeam;
  // @ts-ignore
  newUserEventForm: FormGroup;
  // @ts-ignore
  newTeamEventForm: FormGroup;
  validationErrors: string[] = [];
  // @ts-ignore
  games: Game[];
  baseUrl = environment.apiUrl;
  // @ts-ignore
  uploader: FileUploader;
  hasBaseDropzoneOver = false;
  // @ts-ignore
  user: User;

  constructor(public eventService: EventsService, private modalService: NgbModal, private toastr: ToastrService,
              public gameService: GameService, private route: Router, private accountService: AccountService,
              private dialog: MatDialog) {
    this.accountService.currentUser$.pipe(take(1)).subscribe(user => this.user = user);
  }

  ngOnInit(): void {
    this.loadUserEvents();
    this.loadTeamEvents();
    this.loadGames();
    this.initializeAddEventForm();
    this.initializeTeamEventForm();
  }

  fileOverBase(e: any){
    this.hasBaseDropzoneOver = e;
  }

  loadTeamEvents() {
    this.eventService.getTeamEvents().subscribe(teamEvents => {
      // @ts-ignore
      this.teamEvents = teamEvents;
    })

  }

  loadUserEvents() {
    this.eventService.getUserEvents().subscribe(userEvents => {
      // @ts-ignore
      this.userEvents = userEvents;
    })
  }

  loadGames() {
    this.gameService.getGames().subscribe(games => {
      // @ts-ignore
      this.games = games;
    })
  }

  loadEvent(){
    this.eventService.getUserEventByName(this.newUserEventForm.value.name).subscribe(specifiedEvent => {
      // @ts-ignore
      this.event = specifiedEvent;
    })
  }

  loadTeamEvent(){
    this.eventService.getTeamEventByName(this.newTeamEventForm.value.name).subscribe(specifiedEvent => {
      // @ts-ignore
      this.eventTeam = specifiedEvent;
    })
  }

  initializeUserUploader(){
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
      if(response){
        this.loadEvent();
        const photo: Photo = JSON.parse(response);
        console.log(photo);
        this.event.photoUrl = photo.url;
      }
    }
  }

  initializeTeamUploader(){
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
        console.log(photo);
        this.eventTeam.photoUrl = photo.url;
      }
    }
  }

  initializeAddEventForm(){
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

  initializeTeamEventForm(){
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

  open(content: any) {
    this.modalService.open(content, {ariaLabelledBy: 'modal-basic-title'});
  }

  openEditEventUserModal(eventUserId: number): void{
    const dialogRef = this.dialog.open(EventsSoloUpdateComponent, {
      width: '500px',
      data:{
        eventUserId: eventUserId
      }
    });
    dialogRef.afterClosed().subscribe();
  }

  newUserEvent() {
    this.eventService.addUserEvent(this.newUserEventForm.value).subscribe(response => {
      this.toastr.info("Wydarzenie zostało dodane");
    }, error => {
      this.toastr.error("Nie udało się dodać nowego wydarzenia");
      console.log(error);
      this.validationErrors = error;
    })
    this.initializeUserUploader();
  }

  newTeamEvent() {
    this.eventService.addTeamEvent(this.newTeamEventForm.value).subscribe(response => {
      this.toastr.info("Wydarzenie zostało dodane");
    }, error => {
      this.toastr.error("Nie udało się dodać nowego wydarzenia");
      console.log(error);
      this.validationErrors = error;
    })
    this.initializeTeamUploader();
  }

  deleteUserEvent(eventUserId: number){
    this.eventService.deleteUserEvent(eventUserId).subscribe(() => {
      this.userEvents.splice(this.userEvents.findIndex(x => x.eventUserId === eventUserId), 1);
    })
  }

  deleteTeamEvent(eventTeamId: number){
    this.eventService.deleteTeamEvent(eventTeamId).subscribe(() => {
      this.teamEvents.splice(this.teamEvents.findIndex(x => x.eventTeamId === eventTeamId), 1);
    })
  }

}
