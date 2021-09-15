import { Component, OnInit } from '@angular/core';
import {LoginComponent} from "../../login/login.component";

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  constructor(public login: LoginComponent) { }

  ngOnInit(): void {
    console.log('login', this.login)
  }

  consoling(any: any): void{
    console.log(any)
  }
}
