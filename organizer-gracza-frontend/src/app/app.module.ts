import {LOCALE_ID, NgModule} from '@angular/core';
import {BrowserModule} from '@angular/platform-browser';
import {AppComponent} from './app.component';
import {HTTP_INTERCEPTORS, HttpClientModule} from "@angular/common/http";
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {HeaderComponent} from './main-components/header/header.component';
import {FooterComponent} from './main-components/footer/footer.component';
import {MainPageBannerComponent} from './main-page/main-page-banner/main-page-banner.component';
import {MainPageContentComponent} from './main-page/main-page-content/main-page-content.component';
import {NewsShortComponent} from './news/news-short/news-short.component';
import {NewsExtendedComponent} from './news/news-extended/news-extended.component';
import {EventsShortComponent} from './events/events-short/events-short.component';
import {EventsExtendedComponent} from './events/events-extended/events-extended.component';
import {AppRoutingModule} from './app-routing.module';
import {LoginComponent} from './login/login.component';
import {RegistrationComponent} from './registration/registration.component';
import {RouterModule} from "@angular/router";
import {FormsModule, ReactiveFormsModule} from "@angular/forms";
import {NgbModule} from "@ng-bootstrap/ng-bootstrap";
import {BsDropdownModule} from "ngx-bootstrap/dropdown";
import {ToastrModule} from "ngx-toastr";
import {TestErrorsComponent} from './errors/test-errors/test-errors.component';
import {ErrorInterceptor} from "./_interceptors/error.interceptor";
import {NotFoundComponent} from './errors/not-found/not-found.component';
import {MemberImageComponent} from './member-page/member-image/member-image.component';
import {MemberContentComponent} from './member-page/member-content/member-content.component';
import {MemberAchievementsComponent} from './member-page/member-achievements/member-achievements.component';
import {MemberStatisticsComponent} from './member-page/member-statistics/member-statistics.component';
import {JwtInterceptor} from "./_interceptors/jwt.interceptor";
import {MemberEditComponent} from './member-page/member-edit/member-edit.component';
import {NgxSpinnerModule} from "ngx-spinner";
import {LoadingInterceptor} from "./_interceptors/loading.interceptor";
import {MemberPhotoEditorComponent} from './member-page/member-photo-editor/member-photo-editor.component';
import {FileUploadModule} from "ng2-file-upload";
import {MemberListComponent} from './member-page/member-list/member-list.component';
import {MemberCardComponent} from './member-page/member-card/member-card.component';
import {PaginationModule} from "ngx-bootstrap/pagination";
import {TimeagoModule} from "ngx-timeago";
import {MessagesChatComponent} from './messages/messages-chat/messages-chat.component';
import {ButtonsModule} from "ngx-bootstrap/buttons";
import {MessagesMembersChatComponent} from './messages/messages-members-chat/messages-members-chat.component';
import {AdminPanelComponent} from './admin/admin-panel/admin-panel.component';
import {HasRoleDirective} from './_directives/has-role.directive';
import {UserManagementComponent} from './admin/user-management/user-management.component';
import {TabsModule} from "ngx-bootstrap/tabs";
import {RolesModalComponent} from './modals/roles-modal/roles-modal.component';
import {ModalModule} from "ngx-bootstrap/modal";
import {EventManagementComponent} from './admin/event-management/event-management.component';
import {TeamsListComponent} from './teams/teams-list/teams-list.component';
import {CommunityListComponent} from './community/community-list/community-list.component';
import {TeamsCardComponent} from './teams/teams-card/teams-card.component';
import {TeamsDetailsComponent} from './teams/teams-details/teams-details.component';
import {EventsListComponent} from './events/events-list/events-list.component';
import {EventsSoloListComponent} from './events/events-solo-list/events-solo-list.component';
import {EventsTeamListComponent} from './events/events-team-list/events-team-list.component';
import {EventsSoloDetailsComponent} from './events/events-solo-details/events-solo-details.component';
import {EventsTeamDetailsComponent} from './events/events-team-details/events-team-details.component';
import {EventsSoloEditComponent} from './events/events-solo-edit/events-solo-edit.component';
import {EventsTeamEditComponent} from './events/events-team-edit/events-team-edit.component';
import {BsDatepickerModule} from "ngx-bootstrap/datepicker";
import {EventsSoloUpdateComponent} from './events/events-solo-update/events-solo-update.component';
import {MatDialogModule} from '@angular/material/dialog';
import {MatButtonModule} from "@angular/material/button";
import {MatInputModule} from "@angular/material/input";
import {MatSelectModule} from "@angular/material/select";
import {AchievementsComponent} from './achievements/achievements.component';
import {CarouselModule} from "primeng/carousel";
import {ButtonModule} from 'primeng/button';
import {ToastModule} from "primeng/toast";
import {registerLocaleData} from '@angular/common';
import localePl from '@angular/common/locales/pl';
import {EventsTeamUpdateComponent} from './events/events-team-update/events-team-update.component';
import {UploadImageModalComponent} from './modals/upload-image-modal/upload-image-modal.component';
import {NewsFullArticleComponent} from './news/news-full-article/news-full-article.component';
import {MainCalendarComponent} from './calendar-planner/main-calendar/main-calendar.component';
import {FullCalendarModule} from "@fullcalendar/angular";
import dayGridPlugin from '@fullcalendar/daygrid';
import interactionPlugin from '@fullcalendar/interaction';
import list from '@fullcalendar/list';
import {AddNewEventModalComponent} from './calendar-planner/add-new-event-modal/add-new-event-modal.component';
import {MatNativeDateModule} from "@angular/material/core";
import {MatDatepickerModule} from "@angular/material/datepicker";
import {
  NgxMatDatetimePickerModule,
  NgxMatNativeDateModule,
  NgxMatTimepickerModule
} from "@angular-material-components/datetime-picker";
import { NewsListComponent } from './news/news-list/news-list.component';
import { BroadcastsComponent } from './broadcasts/broadcasts.component';
import { ForumThreadListComponent } from './forum/forum-thread-list/forum-thread-list.component';
import { BroadcastEmbeddedComponent } from './broadcasts/broadcast-embedded/broadcast-embedded.component';
import { ForumPostsComponent } from './forum/forum-posts/forum-posts.component';
import { ForumAddNewThreadComponent } from './forum/forum-add-new-thread/forum-add-new-thread.component';
import { NewsEditorPanelComponent } from './news-editor/news-editor-panel/news-editor-panel.component';
import { SteamInformationComponent } from './member-page/steam-information/steam-information.component';
import { ActivateMailComponent } from './member-page/activate-mail/activate-mail.component';
import { MatTooltipModule } from '@angular/material/tooltip';
import { ResetPasswordComponent } from './login/reset-password/reset-password.component';
import { EventsTeamResultComponent } from './events/events-team-result/events-team-result.component';
import { EventsSoloResultComponent } from './events/events-solo-result/events-solo-result.component';
import {MatAutocompleteModule} from '@angular/material/autocomplete';
import {MatFormFieldModule} from '@angular/material/form-field';
import { NewsEditorUpdateComponent } from './news-editor/news-editor-update/news-editor-update.component';
import { EventDetailModalComponent } from './calendar-planner/event-detail-modal/event-detail-modal.component';

registerLocaleData(localePl, 'pl');

FullCalendarModule.registerPlugins([
  dayGridPlugin,
  interactionPlugin,
  list
])

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    FooterComponent,
    MainPageBannerComponent,
    MainPageContentComponent,
    NewsShortComponent,
    NewsExtendedComponent,
    EventsShortComponent,
    EventsExtendedComponent,
    LoginComponent,
    RegistrationComponent,
    TestErrorsComponent,
    NotFoundComponent,
    MemberImageComponent,
    MemberContentComponent,
    MemberAchievementsComponent,
    MemberStatisticsComponent,
    MemberEditComponent,
    MemberPhotoEditorComponent,
    MemberListComponent,
    MemberCardComponent,
    MessagesChatComponent,
    MessagesMembersChatComponent,
    AdminPanelComponent,
    HasRoleDirective,
    UserManagementComponent,
    RolesModalComponent,
    EventManagementComponent,
    TeamsListComponent,
    CommunityListComponent,
    TeamsCardComponent,
    TeamsDetailsComponent,
    EventsListComponent,
    EventsSoloListComponent,
    EventsTeamListComponent,
    EventsSoloDetailsComponent,
    EventsTeamDetailsComponent,
    EventsSoloEditComponent,
    EventsTeamEditComponent,
    EventsSoloUpdateComponent,
    AchievementsComponent,
    EventsTeamUpdateComponent,
    UploadImageModalComponent,
    NewsFullArticleComponent,
    MainCalendarComponent,
    AddNewEventModalComponent,
    NewsListComponent,
    BroadcastsComponent,
    BroadcastEmbeddedComponent,
    BroadcastsComponent,
    ForumThreadListComponent,
    ForumPostsComponent,
    ForumAddNewThreadComponent,
    NewsEditorPanelComponent,
    SteamInformationComponent,
    ActivateMailComponent,
    ResetPasswordComponent,
    EventsTeamResultComponent,
    EventsSoloResultComponent,
    NewsEditorUpdateComponent,
    EventDetailModalComponent,
  ],
  imports: [
    BrowserModule,
    FullCalendarModule,
    HttpClientModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    RouterModule,
    FormsModule,
    NgbModule,
    BsDropdownModule.forRoot(),
    ToastrModule.forRoot({
      positionClass: 'toast-bottom-right'
    }),
    ReactiveFormsModule,
    NgxSpinnerModule,
    FileUploadModule,
    PaginationModule.forRoot(),
    TimeagoModule.forRoot(),
    ButtonsModule,
    TabsModule,
    ModalModule.forRoot(),
    BsDatepickerModule.forRoot(),
    MatDialogModule,
    MatButtonModule,
    MatInputModule,
    MatSelectModule,
    CarouselModule,
    ButtonModule,
    ToastModule,
    MatNativeDateModule,
    MatDatepickerModule,
    NgxMatDatetimePickerModule,
    NgxMatTimepickerModule,
    NgxMatNativeDateModule,
    MatTooltipModule,
    MatAutocompleteModule,
    MatFormFieldModule
  ],
  providers: [
    {provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true},
    {provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true},
    {provide: HTTP_INTERCEPTORS, useClass: LoadingInterceptor, multi: true},
    {provide: LOCALE_ID, useValue: "pl"},
    LoginComponent, MemberContentComponent],
  bootstrap: [AppComponent]
})
export class AppModule {
}
