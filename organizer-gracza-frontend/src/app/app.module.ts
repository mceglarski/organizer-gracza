import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import {HTTP_INTERCEPTORS, HttpClientModule} from "@angular/common/http";
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HeaderComponent } from './main-components/header/header.component';
import { FooterComponent } from './main-components/footer/footer.component';
import { MainPageBannerComponent } from './main-page/main-page-banner/main-page-banner.component';
import { MainPageContentComponent } from './main-page/main-page-content/main-page-content.component';
import { NewsShortComponent } from './news/news-short/news-short.component';
import { NewsExtendedComponent } from './news/news-extended/news-extended.component';
import { EventsShortComponent } from './events/events-short/events-short.component';
import { EventsExtendedComponent } from './events/events-extended/events-extended.component';
import {IvyCarouselModule} from "angular-responsive-carousel";
import { AppRoutingModule } from './app-routing.module';
import { LoginComponent } from './login/login.component';
import { RegistrationComponent } from './registration/registration.component';
import {RouterModule} from "@angular/router";
import {FormsModule, ReactiveFormsModule} from "@angular/forms";
import {NgbModule} from "@ng-bootstrap/ng-bootstrap";
import {NewsTeaserComponent} from "./news/news-teaser/news-teaser.component";
import {BsDropdownModule} from "ngx-bootstrap/dropdown";
import {ToastrModule} from "ngx-toastr";
import { TestErrorsComponent } from './errors/test-errors/test-errors.component';
import {ErrorInterceptor} from "./_interceptors/error.interceptor";
import { NotFoundComponent } from './errors/not-found/not-found.component';
import { MemberImageComponent } from './member-page/member-image/member-image.component';
import { MemberContentComponent } from './member-page/member-content/member-content.component';
import { MemberAchievementsComponent } from './member-page/member-achievements/member-achievements.component';
import { MemberStatisticsComponent } from './member-page/member-statistics/member-statistics.component';
import {JwtInterceptor} from "./_interceptors/jwt.interceptor";
import { MemberEditComponent } from './member-page/member-edit/member-edit.component';
import {NgxSpinnerModule} from "ngx-spinner";
import {LoadingInterceptor} from "./_interceptors/loading.interceptor";
import { MemberPhotoEditorComponent } from './member-page/member-photo-editor/member-photo-editor.component';
import {FileUploadModule} from "ng2-file-upload";
import { MemberListComponent } from './member-page/member-list/member-list.component';
import { MemberCardComponent } from './member-page/member-card/member-card.component';
import {PaginationModule} from "ngx-bootstrap/pagination";
import {TimeagoModule} from "ngx-timeago";
import { MessagesChatComponent } from './messages/messages-chat/messages-chat.component';
import {ButtonsModule} from "ngx-bootstrap/buttons";
import { MessagesMembersChatComponent } from './messages/messages-members-chat/messages-members-chat.component';

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
    NewsTeaserComponent,
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
  ],
    imports: [
        BrowserModule,
        HttpClientModule,
        BrowserAnimationsModule,
        IvyCarouselModule,
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
        ButtonsModule
    ],
  providers: [
    {provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true},
    {provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true},
    {provide: HTTP_INTERCEPTORS, useClass: LoadingInterceptor, multi: true},
    LoginComponent, MemberContentComponent],
  bootstrap: [AppComponent]
})
export class AppModule { }
