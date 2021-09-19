import { Component, OnInit } from '@angular/core';
import {NgbModal} from "@ng-bootstrap/ng-bootstrap";
import {AccountService} from "../_services/account.service";
import {ToastrService} from "ngx-toastr";

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent implements OnInit {
  model: any = {};

  constructor(private modalService: NgbModal, private accountService: AccountService,
              private toastr: ToastrService) {
  }

  ngOnInit(): void {

  }

  open(content: any) {
    this.modalService.open(content, {ariaLabelledBy: 'modal-basic-title'});
  }

  register(){
    this.accountService.register(this.model).subscribe(response => {
    }, error => {
      console.log(error);
      this.toastr.error(error.error)
    })
  }
}
