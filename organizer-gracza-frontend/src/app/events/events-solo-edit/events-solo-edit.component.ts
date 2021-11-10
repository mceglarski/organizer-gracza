import {Component, OnInit, ViewChild} from '@angular/core';
import {EventsService} from "../../_services/events.service";
import {EventUser, Game, Photo, User} from "../../model/model";
import {ActivatedRoute, Router} from "@angular/router";
import {ToastrService} from "ngx-toastr";
import {NgForm} from "@angular/forms";
import {GameService} from "../../_services/game.service";
import {FileUploader} from "ng2-file-upload";
import {take} from "rxjs/operators";
import {AccountService} from "../../_services/account.service";
import {environment} from "../../../environments/environment";

@Component({
  selector: 'app-events-solo-edit',
  templateUrl: './events-solo-edit.component.html',
  styleUrls: ['./events-solo-edit.component.css']
})
export class EventsSoloEditComponent implements OnInit {
  // @ts-ignore
  eventUser: EventUser;
  // @ts-ignore
  @ViewChild('editUserForm') editForm: NgForm;
  // @ts-ignore
  games: Game[];
  // @ts-ignore
  uploader: FileUploader;
  hasBaseDropzoneOver = false;
  // @ts-ignore
  user: User;
  baseUrl: string = environment.apiUrl;

  constructor(private eventService: EventsService, private route: ActivatedRoute, private toastr: ToastrService,
              public gameService: GameService, public accountService: AccountService) {
    this.accountService.currentUser$.pipe(take(1)).subscribe(user => this.user = user);

  }

  ngOnInit(): void {
    this.loadEventUser();
    this.loadGames();
  }

  fileOverBase(event: any) {
    this.hasBaseDropzoneOver = event;
  }

  initializeUploader() {
    this.uploader = new FileUploader({
      url: this.baseUrl + 'eventsuser/add-photo/' + this.eventUser.name,
      authToken: 'Bearer ' + this.user.token,
      isHTML5: true,
      allowedFileType: ['image'],
      removeAfterUpload: true,
      autoUpload: false,
      maxFileSize: 10 * 1024 * 1024
    });

    this.uploader.onAfterAddingFile = (file) => {
      file.withCredentials = false;
    }

    this.uploader.onSuccessItem = (item, response, status, headers) => {
      if (response) {
        const photo: Photo = JSON.parse(response);
        console.log(photo);
        this.eventUser.photoUrl = photo.url;
        this.accountService.setCurrentUser(this.user);
      }
    }
  }

  loadEventUser() {
    // @ts-ignore
    this.eventService.getUserEvent(this.route.snapshot.paramMap.get('eventUserId')).subscribe(eventUser => {
      // @ts-ignore
      this.eventUser = eventUser;
      this.initializeUploader();
    })
  }

  updateEventUser() {
    this.eventService.updateUserEvent(this.eventUser, this.eventUser.eventUserId).subscribe(() => {
      this.toastr.success('Wydarzenie został zaktualizowany!');
    })
  }

  loadGames() {
    this.gameService.getGames().subscribe(games => {
      // @ts-ignore
      this.games = games;
    })
  }

  deleteUserEvent(eventUserId: number){
    this.eventService.deleteUserEvent(eventUserId)
  }
}
