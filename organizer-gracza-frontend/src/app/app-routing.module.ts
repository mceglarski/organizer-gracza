import { NgModule } from '@angular/core';
import {Routes, RouterModule} from "@angular/router";
import {MainPageContentComponent} from "./main-page/main-page-content/main-page-content.component";
import {AuthGuard} from "./_guards/auth.guard";
import {TestErrorsComponent} from "./errors/test-errors/test-errors.component";
import {NotFoundComponent} from "./errors/not-found/not-found.component";
import {MemberContentComponent} from "./member-page/member-content/member-content.component";
import {MemberEditComponent} from "./member-page/member-edit/member-edit.component";
import {PreventUnsavedChangesGuard} from "./_guards/prevent-unsaved-changes.guard";
import {MemberListComponent} from "./member-page/member-list/member-list.component";

const routes: Routes = [
  {path: '', component: MainPageContentComponent},
  {
    path: '',
    runGuardsAndResolvers: 'always',
    canActivate: [AuthGuard],
    children: [
      {path: 'members', component: MemberListComponent},
      {path: 'members/:nickname', component: MemberContentComponent},
      {path: 'member/edit', component: MemberEditComponent, canDeactivate: [PreventUnsavedChangesGuard]}
    ]
  },
  {path: 'errors', component: TestErrorsComponent},
  {path: 'not-found', component: NotFoundComponent},
  {path: '**', component: MainPageContentComponent, pathMatch: 'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
