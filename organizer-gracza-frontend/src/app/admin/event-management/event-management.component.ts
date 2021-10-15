import {Component, OnInit} from '@angular/core';
import {EventsService} from "../../_services/events.service";
import {EventTeam, EventUser, Game, User} from "../../model/model";
import {FormControl, FormGroup, Validators} from "@angular/forms";
import { Router} from "@angular/router";
import {ToastrService} from "ngx-toastr";
import {NgbModal} from "@ng-bootstrap/ng-bootstrap";
import {GameService} from "../../_services/game.service";
import {environment} from "../../../environments/environment";
import {FileUploader} from "ng2-file-upload";
import {AccountService} from "../../_services/account.service";
import {take} from "rxjs/operators";


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
  event: Event;
  // @ts-ignore
  newUserEventForm: FormGroup;
  validationErrors: string[] = [];
  // @ts-ignore
  games: Game[];
  // @ts-ignore
  baseUrl: environment.apiUrl;
  // @ts-ignore
  uploader: FileUploader;
  hasBaseDropzoneOver = false;
  // @ts-ignore
  user: User;

  constructor(public eventService: EventsService, private modalService: NgbModal, private toastr: ToastrService,
              public gameService: GameService, private route: Router, private accountService: AccountService) {
    this.accountService.currentUser$.pipe(take(1)).subscribe(user => this.user = user);
  }

  ngOnInit(): void {
    this.loadUserEvents();
    this.loadTeamEvents();
    this.loadGames();
    this.initializeAddEventForm();
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

  loadUserEvent(){
    this.eventService.getUserEvent(this.userEvents.findIndex(x => x.eventUserId))
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

  initializeUserUploader(){
    this.uploader = new FileUploader({
      url: this.baseUrl + 'eventsuser/add-photo/' + this.newUserEventForm.controls['eventUserId'].value,
      authToken: 'Bearer ' + this.user.token,
      isHTML5: true,
      allowedFileType: ['image'],
      removeAfterUpload: true,
      autoUpload: false,
      maxFileSize: 10 * 1024 * 1024
    });

    this.uploader.onSuccessItem = (item, response, status, headers) => {
      if(response){
        const photo = JSON.parse(response);
        this.newUserEventForm.value.photoUrl = photo.photoUrl;
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
      // photoUrl: new FormControl('', Validators.required)
    })
    console.log(this.newUserEventForm);
  }

  open(content: any) {
    this.modalService.open(content, {ariaLabelledBy: 'modal-basic-title'});
  }

  newUserEvent() {
    this.eventService.addUserEvent(this.newUserEventForm.value).subscribe(response => {
      this.toastr.info("Wydarzenie zostało dodane");
    }, error => {
      this.toastr.error("Nie udało się dodać nowego wydarzenia");
      console.log(error);
      this.validationErrors = error;
    })
    console.log(this.newUserEventForm)
    this.initializeUserUploader();
  }


  // newTeamEvent() {
  //   this.eventService.addTeamEvent(this.newUserEventForm.value).subscribe(response => {
  //     this.toastr.info("Wydarzenie zostało dodane");
  //   }, error => {
  //     this.toastr.error("Nie udało się dodać nowego wydarzenia");
  //     console.log(error);
  //     this.validationErrors = error;
  //   })
  // }
}
