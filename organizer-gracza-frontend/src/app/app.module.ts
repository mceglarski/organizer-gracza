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
import {FormsModule} from "@angular/forms";
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
  ],
  providers: [
    {provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true},
    {provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true},
    LoginComponent, MemberContentComponent],
  bootstrap: [AppComponent]
})
export class AppModule { }
