import {AfterViewInit, ChangeDetectorRef, Component, Inject, OnInit} from '@angular/core';
import {FormControl, FormGroup, Validators} from "@angular/forms";
import {EventTeam, Game, User} from "../../model/model";
import {FileUploader} from "ng2-file-upload";
import {MAT_DIALOG_DATA, MatDialogRef} from "@angular/material/dialog";
import {NgbModal} from "@ng-bootstrap/ng-bootstrap";
import {EventsService} from "../../_services/events.service";
import {ToastrService} from "ngx-toastr";
import {GameService} from "../../_services/game.service";
import {environment} from "../../../environments/environment";

@Component({
  selector: 'app-events-team-update',
  templateUrl: './events-team-update.component.html',
  styleUrls: ['./events-team-update.component.css']
})
export class EventsTeamUpdateComponent implements OnInit, AfterViewInit {

  public updateEventTeamForm: FormGroup;
  public games: Game[];
  public uploader: FileUploader;
  public hasBaseDropzoneOver = false;

  private baseUrl = environment.apiUrl;

  constructor(public dialogRef: MatDialogRef<EventsTeamUpdateComponent>,
              private modalService: NgbModal,
              private eventService: EventsService,
              private toastr: ToastrService,
              private gameService: GameService,
              private cdr: ChangeDetectorRef,
              @Inject(MAT_DIALOG_DATA) public data: {
                event: EventTeam,
                user: User
              }) { }

  ngOnInit(): void {
    this.loadGames();
    this.initializeUpdateEventForm();
  }

  ngAfterViewInit() {
    this.cdr.detectChanges();
  }

  public closeEventTeamUpdateModal(): void {
    this.dialogRef.close();
  }

  public open(content: any) {
    this.modalService.open(content, {ariaLabelledBy: 'modal-basic-title'});
  }

  public fileOverBase(e: any){
    this.hasBaseDropzoneOver = e;
  }

  public updateEventTeam(eventTeamId: number): void {
    if (this.updateEventTeamForm.valid) {
      this.eventService.updateTeamEvent(this.updateEventTeamForm.value, eventTeamId).subscribe(() => {
        this.toastr.success('Wydarzenie zostało zaktualizowane!');
      });
      this.dialogRef.close();
    }
    this.initializeUserUploader();
  }

  public initializeUserUploader() {
    this.uploader = new FileUploader({
      url: this.baseUrl + 'eventsteam/add-photo/' + this.updateEventTeamForm.value.name,
      authToken: 'Bearer ' + this.data.user.token,
      isHTML5: true,
      allowedFileType: ['image'],
      removeAfterUpload: true,
      autoUpload: false,
      maxFileSize: 10 * 1024 * 1024
    });
  }

  private loadGames(): void {
    this.gameService.getGames().subscribe(games => {
      // @ts-ignore
      this.games = games;
    })
  }

  private initializeUpdateEventForm(): void {
    this.updateEventTeamForm = new FormGroup({
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

}
