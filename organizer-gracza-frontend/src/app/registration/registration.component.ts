import { Component, OnInit } from '@angular/core';
import {NgbModal} from "@ng-bootstrap/ng-bootstrap";
import {AccountService} from "../_services/account.service";
import {ToastrService} from "ngx-toastr";
import {AbstractControl, FormBuilder, FormControl, FormGroup, ValidatorFn, Validators} from "@angular/forms";
import {Router} from "@angular/router";

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent implements OnInit {
  // @ts-ignore
  registerForm: FormGroup;
  validationErrors: string[] = [];

  constructor(public router: Router,
              private modalService: NgbModal,
              private accountService: AccountService,
              private toastr: ToastrService) {
  }

  ngOnInit(): void {
    this.initializeForm();
  }

  private initializeForm(){
    this.registerForm = new FormGroup({
      username: new FormControl('', Validators.required),
      nickname: new FormControl('', Validators.required),
      email: new FormControl('', Validators.required),
      password: new FormControl('', [Validators.required, Validators.minLength(8),
        Validators.maxLength(24)]),
      confirmPassword: new FormControl('', [Validators.required,
        this.matchValues('password')])
    })
    this.registerForm.controls.password.valueChanges.subscribe(() => {
      this.registerForm.controls.confirmPassword.updateValueAndValidity();
    })
  }

  public open(content: any): void {
    this.modalService.open(content, {ariaLabelledBy: 'modal-basic-title'});
  }

  public register(): void {
    this.accountService.register(this.registerForm.value).subscribe(response => {
      this.router.navigateByUrl('/');
    }, error => {
      this.validationErrors = error;
      console.log(error);
      this.toastr.error('Zarejestrowanie się nie powiodło');
    });
  }

  private matchValues(matchTo: string): ValidatorFn {
    return (control: AbstractControl) => {
      // @ts-ignore
      return control?.value === control?.parent?.controls[matchTo].value
        ? null : {isMatching: true}
    }
  }
}
