import { Component, OnInit } from '@angular/core';
import {AbstractControl, FormControl, FormGroup, ValidatorFn, Validators} from "@angular/forms";
import {MembersService} from "../../_services/members.service";
import {ToastrService} from "ngx-toastr";
import {ActivatedRoute, Router} from "@angular/router";
import {ResetPassword} from "../../model/model";

@Component({
  selector: 'app-reset-password',
  templateUrl: './reset-password.component.html',
  styleUrls: ['./reset-password.component.css']
})
export class ResetPasswordComponent implements OnInit {

  public resetPasswordForm: FormGroup = new FormGroup({
    password: new FormControl('', Validators.compose([
      Validators.minLength(8),
      Validators.maxLength(24),
      Validators.required,
      Validators.pattern('^(?=.*[A-Za-z])(?=.*\\d)(?=.*[$@$!%*#?&])[A-Za-z\\d$@$!%*#?&]{8,}$') //this is for the letters (both uppercase and lowercase) and numbers validation
    ])),
    confirmPassword: new FormControl('', Validators.compose([
      Validators.minLength(8),
      Validators.maxLength(24),
      Validators.required,
      this.matchValues('password'),
      Validators.pattern('^(?=.*[A-Za-z])(?=.*\\d)(?=.*[$@$!%*#?&])[A-Za-z\\d$@$!%*#?&]{8,}$') //this is for the letters (both uppercase and lowercase) and numbers validation
    ]))
  });

  private resetPassword: ResetPassword;
  private securityStamp: string;


  constructor(private memberService: MembersService,
              private route: ActivatedRoute,
              private router: Router,
              private toastr: ToastrService) { }

  ngOnInit(): void {
    // @ts-ignore
    this.securityStamp = this.route.snapshot.paramMap.get('security');
  }

  public submitAndResetPassword(): void {
    if (this.resetPasswordForm.valid) {
      this.resetPassword = {
        password: this.resetPasswordForm.value.password,
        securityStamp: this.securityStamp
      }
      this.memberService.resetPassword(this.resetPassword).subscribe(() => {
        // @ts-ignore
        this.router.navigateByUrl(['/']);
        this.toastr.success('Hasło zostało zresetowane');
      }, () => {
        this.toastr.error('Wystąpił błąd');
      })
    } else {
      this.toastr.error('Uzupełnij formularz');
    }
  }

  private matchValues(matchTo: string): ValidatorFn {
    return (control: AbstractControl) => {
      // @ts-ignore
      return control?.value === control?.parent?.controls[matchTo].value
        ? null : {isMatching: true}
    }
  }
}
