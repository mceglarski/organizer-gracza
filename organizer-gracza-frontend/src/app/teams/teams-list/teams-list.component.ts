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


@Component({
  selector: 'app-teams-list',
  templateUrl: './teams-list.component.html',
  styleUrls: ['./teams-list.component.css']
})
export class TeamsListComponent implements OnInit {
  // @ts-ignore
  newTeamForm: FormGroup;
  // @ts-ignore
  teams: Team[];
  // @ts-ignore
  pagination: Pagination;
  // @ts-ignore
  userParams: PagintationParams;
  // @ts-ignore
  user: User;
  // @ts-ignore
  uploader: FileUploader;
  hasBaseDropzoneOver = false;
  baseUrl = environment.apiUrl;
  // @ts-ignore
  team: Team;


  constructor(private teamService: TeamsService, private modalService: NgbModal, private toastr: ToastrService,
              private router: Router, private accountService: AccountService) {
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
    // @ts-ignore
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

  createNewTeam() {
    this.teamService.addTeam(this.newTeamForm.value).subscribe(response => {
      this.toastr.success("Utworzono nową drużyne")
    }, error => {
      console.log(error);
      this.toastr.error('Zarejestrowanie się nie powiodło');
    })
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
        this.loadTeam();
        console.log(this.team)
        const photo: Photo = JSON.parse(response);
        console.log(photo)
        this.team.photoUrl = photo.url;
      }
    }
  }

  fileOverBase(e: any) {
    this.hasBaseDropzoneOver = e;
  }
}
