import {Component, Injectable, OnInit, EventEmitter, Output} from '@angular/core';
import {NgbModal} from '@ng-bootstrap/ng-bootstrap';
import {AccountService} from "../_services/account.service";


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
@Injectable()
export class LoginComponent implements OnInit {
  model: any = {};

  constructor(private modalService: NgbModal, public accountService: AccountService) {}

  ngOnInit(): void {
  }

  open(content: any) {
    this.modalService.open(content, {ariaLabelledBy: 'modal-basic-title'});
  }

  login(){
    this.accountService.login(this.model).subscribe(response => {
    }, error => {
      console.log(error);
    })
  }

  logout(){
    this.accountService.logout();
  }
}