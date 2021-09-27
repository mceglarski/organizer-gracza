import { Injectable } from '@angular/core';
import {ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree} from '@angular/router';
import { Observable } from 'rxjs';
import {AccountService} from "../_services/account.service";
import {ToastrService} from "ngx-toastr";
import {map} from "rxjs/operators";

@Injectable({
  providedIn: 'root'
})
export class AdminGuard implements CanActivate {

  constructor(private accountService: AccountService, private toastr: ToastrService, private route: Router) {}


  canActivate(): Observable<boolean> {
    // @ts-ignore
    return this.accountService.currentUser$.pipe(
      // @ts-ignore
      map(user => {
        if(user.roles.includes('Admin') || user.roles.includes('Moderator')){
          return true;
        }
        this.toastr.error('You cannot enter this area');
        this.route.navigateByUrl('/');
      })
    )
  }

}
