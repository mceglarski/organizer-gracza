import {Component, Injectable} from '@angular/core';
import {NgbModal} from '@ng-bootstrap/ng-bootstrap';
import {AccountService} from "../_services/account.service";
import {ToastrService} from "ngx-toastr";
import {Router} from "@angular/router";
import {FormControl, FormGroup, Validators} from "@angular/forms";
import {MembersService} from "../_services/members.service";


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
@Injectable()
export class LoginComponent {

  public resetPasswordForm: FormGroup = new FormGroup({
    email: new FormControl('', [Validators.required, this.noWhitespaceValidator, Validators.email]),
  })
  model: any = {};

  constructor(public accountService: AccountService,
              private memberService: MembersService,
              private modalService: NgbModal,
              private toastr: ToastrService,
              private router: Router) {
  }

  public open(content: any): void {
    this.modalService.open(content, {ariaLabelledBy: 'modal-basic-title'});
  }

  public login(): void {
    this.accountService.login(this.model).subscribe(() => {
      window.location.reload();
    });
  }

  public logout(): void {
    this.accountService.logout();
    this.router.navigateByUrl('/');
  }

  public sendResetPassword(): void {
    this.memberService.sendLink(this.resetPasswordForm.value.email).subscribe(() => {
      this.toastr.success('Jeśli podany mail jest prawidłowy, link do przywrócenia hasła został wysłany');
    }, () => {
      this.toastr.error('Coś poszło nie tak');
    })
  }

  private noWhitespaceValidator(control: FormControl) {
    const isWhitespace = (control.value || '').trim().length === 0;
    const isValid = !isWhitespace;
    return isValid ? null : {'whitespace': true};
  }
}
