import { NgModule } from '@angular/core';
import {Routes, RouterModule} from "@angular/router";
import {MainPageContentComponent} from "./main-page/main-page-content/main-page-content.component";
import {LoginComponent} from "./login/login.component";
import {RegistrationComponent} from "./registration/registration.component";

const routes: Routes = [
  {path: '', component: MainPageContentComponent},
  {path: 'login', component: LoginComponent},
  {path: 'registration', component: RegistrationComponent},
  {path: '**', component: MainPageContentComponent, pathMatch: 'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
