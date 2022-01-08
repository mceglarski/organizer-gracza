import {Component, OnInit} from '@angular/core';
import {Member, Pagination, PagintationParams, Photo, Team, User} from "../../model/model";
import {TeamsService} from "../../_services/teams.service";
import {NgbModal} from "@ng-bootstrap/ng-bootstrap";
import {ToastrService} from "ngx-toastr";
import {FormControl, FormGroup, Validators} from "@angular/forms";
import {Router} from "@angular/router";
import {FileUploader} from "ng2-file-upload";
import {environment} from "../../../environments/environment";
import {take} from "rxjs/operators";
import {AccountService} from "../../_services/account.service";
import {MatDialog} from "@angular/material/dialog";
import {UploadImageModalComponent} from "../../modals/upload-image-modal/upload-image-modal.component";
import {NgxSpinner, NgxSpinnerService} from "ngx-spinner";


@Component({
  selector: 'app-teams-list',
  templateUrl: './teams-list.component.html',
  styleUrls: ['./teams-list.component.css']
})
export class TeamsListComponent implements OnInit {

  public newTeamForm: FormGroup;
  public teams: Team[];
  public uploader: FileUploader;
  public hasBaseDropzoneOver = false;
  public pagination: Pagination;
  public hasCreatedTeam: Boolean = true;

  private userParams: PagintationParams;
  private user: User;
  private baseUrl = environment.apiUrl;
  private team: Team;

  constructor(private teamService: TeamsService,
              private modalService: NgbModal,
              private toastr: ToastrService,
              private router: Router,
              private accountService: AccountService,
              private dialog: MatDialog,
              private spinner: NgxSpinnerService) {
    this.accountService.currentUser$.pipe(take(1)).subscribe(user => this.user = user);
  }

  ngOnInit(): void {
    this.loadTeams();
    this.initializeForm();
  }

  initializeForm() {
    this.newTeamForm = new FormGroup({
      name: new FormControl('', Validators.required)
    })
  }

  loadTeams() {
    this.teamService.getTeams().subscribe(teams => {
      // @ts-ignore
      this.teams = teams;
    })
  }

  loadTeam() {
    this.teamService.getTeamByName(this.newTeamForm.value.name).subscribe(team => {
      // @ts-ignore
      this.team = team;
    })
  }

  open(content: any) {
     this.modalService.open(content, {ariaLabelledBy: 'modal-basic-title'});
  }

  public openUploadImageModal(): void {
    const dialogRef = this.dialog.open(UploadImageModalComponent, {
      width: '530px',
      disableClose: true,
      data: {
        path: 'teams/add-photo/' + this.newTeamForm.value.name,
        user: this.user
      }
    });
    dialogRef.afterClosed().subscribe(() => {
      return;
    });
  }

  createNewTeam(content: any) {
    this.teamService.addTeam(this.newTeamForm.value).subscribe(response => {
      this.hasCreatedTeam = true;
      this.modalService.open(content, {ariaLabelledBy: 'modal-basic-title'});
      this.toastr.success("Utworzono nową drużynę");
    }, error => {
      console.log(error);
      this.toastr.error('Zarejestrowanie drużyny nie powiodło się');
      this.hasCreatedTeam = false;
    });
    this.initializeUploader();
  }

  initializeUploader() {
    this.uploader = new FileUploader({
      url: this.baseUrl + 'teams/add-photo/' + this.newTeamForm.value.name,
      authToken: 'Bearer ' + this.user.token,
      isHTML5: true,
      allowedFileType: ['image'],
      removeAfterUpload: true,
      autoUpload: false,
      maxFileSize: 10 * 1024 * 1024
    });

    this.uploader.onSuccessItem = (item, response, status, headers) => {
      if (response) {
        this.teamService.getTeamByName(this.newTeamForm.value.name).subscribe(team => {
          // @ts-ignore
          this.team = team;
          const photo: Photo = JSON.parse(response);
          if (photo.url) {
            this.team.photoUrl = photo.url;
          }
          this.toastr.success('Drużyna założona!');
          this.spinner.hide();
          window.location.reload();
        });
      }
    }
  }

  fileOverBase(e: any) {
    this.hasBaseDropzoneOver = e;
  }

  public reloadPage(): void {
    this.spinner.show(undefined,{
      type: 'line-scale-party',
      bdColor: 'rgba(0, 0, 0, 0.8)',
      size: 'medium',
      template: 'Ładowanie'
    });
  }
}
