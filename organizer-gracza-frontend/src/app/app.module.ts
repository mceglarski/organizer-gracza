import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import {HttpClientModule} from "@angular/common/http";
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
    EventsExtendedComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    BrowserAnimationsModule,
    IvyCarouselModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
