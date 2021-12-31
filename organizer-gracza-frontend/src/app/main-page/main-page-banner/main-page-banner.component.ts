import { Component, OnInit } from '@angular/core';
import {User} from "../../model/model";

@Component({
  selector: 'app-main-page-banner',
  templateUrl: './main-page-banner.component.html',
  styleUrls: ['./main-page-banner.component.css']
})
export class MainPageBannerComponent implements OnInit {

  public user: User;

  constructor() { }

  ngOnInit(): void {
    // @ts-ignore
    this.user = JSON.parse(localStorage.getItem('user'));

    window.addEventListener('mousemove', handleMouseMove);
    window.addEventListener('resize', handleWindowResize);
    const spansSlow = document.querySelectorAll('.spanSlow');
    const spansFast = document.querySelectorAll('.spanFast');

    let width = window.innerWidth;

    function handleMouseMove(e: any) {
      let normalizedPosition = e.pageX / (width/2) - 1;
      let speedSlow = 100 * normalizedPosition;
      let speedFast = 200 * normalizedPosition;
      spansSlow.forEach((span) => {
        // @ts-ignore
        span.style.transform = `translate(${speedSlow}px)`;
      });
      spansFast.forEach((span) => {
        // @ts-ignore
        span.style.transform = `translate(${speedFast}px)`
      })
    }
//we need to recalculate width when the window is resized
    function handleWindowResize() {
      width = window.innerWidth;
    }
  }




}
