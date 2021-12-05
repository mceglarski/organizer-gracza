import { NgModule } from '@angular/core';
import {Routes, RouterModule} from "@angular/router";
import {MainPageContentComponent} from "./main-page/main-page-content/main-page-content.component";
import {AuthGuard} from "./_guards/auth.guard";
import {TestErrorsComponent} from "./errors/test-errors/test-errors.component";
import {NotFoundComponent} from "./errors/not-found/not-found.component";
import {MemberContentComponent} from "./member-page/member-content/member-content.component";
import {MemberEditComponent} from "./member-page/member-edit/member-edit.component";
import {PreventUnsavedChangesGuard} from "./_guards/prevent-unsaved-changes.guard";
import {MessagesChatComponent} from "./messages/messages-chat/messages-chat.component";
import {MessagesMembersChatComponent} from "./messages/messages-members-chat/messages-members-chat.component";
import {MemberDetailedResolver} from "./_resolvers/member-detailed-resolver";
import {AdminPanelComponent} from "./admin/admin-panel/admin-panel.component";
import {AdminGuard} from "./_guards/admin.guard";
import {CommunityListComponent} from "./community/community-list/community-list.component";
import {TeamsDetailsComponent} from "./teams/teams-details/teams-details.component";
import {EventsListComponent} from "./events/events-list/events-list.component";
import {EventsSoloEditComponent} from "./events/events-solo-edit/events-solo-edit.component";
import {EventsTeamEditComponent} from "./events/events-team-edit/events-team-edit.component";
import {EventsSoloDetailsComponent} from "./events/events-solo-details/events-solo-details.component";
import {EventsTeamDetailsComponent} from "./events/events-team-details/events-team-details.component";

const routes: Routes = [
  {path: '', component: MainPageContentComponent},
  {
    path: '',
    runGuardsAndResolvers: 'always',
    canActivate: [AuthGuard],
    children: [
      {path: 'community', component: CommunityListComponent},
      {path: 'members/:username', component: MemberContentComponent, resolve: {member: MemberDetailedResolver}},
      {path: 'teams/details/:name', component: TeamsDetailsComponent},
      {path: 'member/edit', component: MemberEditComponent, canDeactivate: [PreventUnsavedChangesGuard]},
      {path: 'messages', component: MessagesChatComponent},
      {path: 'messages/thread/:username', component: MessagesMembersChatComponent, resolve: {member: MemberDetailedResolver}},
      {path: 'admin', component: AdminPanelComponent, canActivate: [AdminGuard]},
      {path: 'admin/events/eventsuser/:eventUserId', component: EventsSoloEditComponent},
      {path: 'admin/events/eventsteam/:eventTeamId', component: EventsTeamEditComponent},
      {path: 'events/eventsuser/:eventUserId', component: EventsSoloDetailsComponent},
      {path: 'events/eventsteam/:eventTeamId', component: EventsTeamDetailsComponent},
      {path: 'events', component: EventsListComponent}
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
