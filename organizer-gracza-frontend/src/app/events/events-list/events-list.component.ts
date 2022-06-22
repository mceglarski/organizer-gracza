import { Component, OnInit } from '@angular/core';
// @ts-ignore
import anime from 'animejs/lib/anime.es';

@Component({
  selector: 'app-events-list',
  templateUrl: './events-list.component.html',
  styleUrls: ['./events-list.component.css']
})
export class EventsListComponent implements OnInit {

  ngOnInit(): void {
    var ml4 = {};
    // @ts-ignore
    ml4.opacityIn = [0,1];// @ts-ignore
    ml4.scaleIn = [0.2, 1];// @ts-ignore
    ml4.scaleOut = 3;// @ts-ignore
    ml4.durationIn = 800;// @ts-ignore
    ml4.durationOut = 600;// @ts-ignore
    ml4.delay = 500;// @ts-ignore

    anime.timeline({loop: true})
      .add({
        targets: '.ml4 .letters-1',// @ts-ignore
        opacity: ml4.opacityIn,// @ts-ignore
        scale: ml4.scaleIn,// @ts-ignore
        duration: ml4.durationIn// @ts-ignore
      }).add({
      targets: '.ml4 .letters-1',
      opacity: 0,// @ts-ignore
      scale: ml4.scaleOut,// @ts-ignore
      duration: ml4.durationOut,// @ts-ignore
      easing: "easeInExpo",// @ts-ignore
      delay: ml4.delay// @ts-ignore
    }).add({
      targets: '.ml4 .letters-2',// @ts-ignore
      opacity: ml4.opacityIn,// @ts-ignore
      scale: ml4.scaleIn,// @ts-ignore
      duration: ml4.durationIn
    }).add({
      targets: '.ml4 .letters-2',
      opacity: 0,// @ts-ignore
      scale: ml4.scaleOut,// @ts-ignore
      duration: ml4.durationOut,// @ts-ignore
      easing: "easeInExpo",// @ts-ignore
      delay: ml4.delay
    }).add({
      targets: '.ml4 .letters-3',// @ts-ignore
      opacity: ml4.opacityIn,// @ts-ignore
      scale: ml4.scaleIn,// @ts-ignore
      duration: ml4.durationIn// @ts-ignore
    }).add({
      targets: '.ml4 .letters-3',// @ts-ignore
      opacity: 0,// @ts-ignore
      scale: ml4.scaleOut,// @ts-ignore// @ts-ignore
      duration: ml4.durationOut,// @ts-ignore
      easing: "easeInExpo",// @ts-ignore
      delay: ml4.delay
    }).add({
      targets: '.ml4',
      opacity: 0,
      duration: 500,
      delay: 500
    });
  }

}
