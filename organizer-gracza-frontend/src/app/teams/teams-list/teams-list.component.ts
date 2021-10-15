import { Component, OnInit } from '@angular/core';
import {Member, Pagination, PagintationParams, Team, User} from "../../model/model";
import {MembersService} from "../../_services/members.service";
import {AccountService} from "../../_services/account.service";
import {take} from "rxjs/operators";
import {TeamsService} from "../../_services/teams.service";
import {NgbModal} from "@ng-bootstrap/ng-bootstrap";
import {ToastrService} from "ngx-toastr";
import {FormControl, FormGroup, Validators} from "@angular/forms";
import {Router} from "@angular/router";

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

  constructor(private teamService: TeamsService, private modalService: NgbModal, private toastr: ToastrService,
              private router: Router) {}

  ngOnInit(): void {
    this.loadTeams();
    this.initializeForm();
  }

  initializeForm(){
    this.newTeamForm = new FormGroup({
      name: new FormControl('', Validators.required)
    })}

  loadTeams(){
    // @ts-ignore
    this.teamService.getTeams().subscribe(teams => {
      // @ts-ignore
      this.teams = teams;
    })
  }

  open(content: any) {
    this.modalService.open(content, {ariaLabelledBy: 'modal-basic-title'});
  }

  createNewTeam(){
    this.teamService.addTeam(this.newTeamForm.value).subscribe(response => {
      this.router.navigateByUrl('teams');
      this.toastr.success("Utworzono nową drużyne")
    }, error => {
      console.log(error);
      this.toastr.error('Zarejestrowanie się nie powiodło');
    })
  }
}
