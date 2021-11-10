import {Component, Inject, OnInit} from '@angular/core';
import {FormControl, FormGroup, Validators} from "@angular/forms";
import {EventsService} from "../../_services/events.service";
import {ToastrService} from "ngx-toastr";
import {Game} from "../../model/model";
import {GameService} from "../../_services/game.service";
import {MAT_DIALOG_DATA} from "@angular/material/dialog";

@Component({
  selector: 'app-events-solo-update',
  templateUrl: './events-solo-update.component.html',
  styleUrls: ['./events-solo-update.component.css']
})
export class EventsSoloUpdateComponent implements OnInit {
  // @ts-ignore
  updateUserEventForm: FormGroup;
  // @ts-ignore
  games: Game[];

  constructor(private eventService: EventsService, private toastr: ToastrService, private gameService: GameService,
              @Inject(MAT_DIALOG_DATA) public data: {
                eventUserId: number
              }) {
  }

  ngOnInit(): void {
    console.log(this.data.eventUserId);
    this.loadGames();
    this.initializeUpdateEventForm();
  }

  loadGames() {
    this.gameService.getGames().subscribe(games => {
      // @ts-ignore
      this.games = games;
    })
  }

  initializeUpdateEventForm() {
    this.updateUserEventForm = new FormGroup({
      name: new FormControl('', Validators.required),
      description: new FormControl('', Validators.required),
      startDate: new FormControl('', Validators.required),
      endDate: new FormControl('', Validators.required),
      eventType: new FormControl('', Validators.required),
      winnerPrize: new FormControl('', Validators.required),
      eventOrganiser: new FormControl('', Validators.required),
      gameId: new FormControl('', Validators.required),
    })
  }

  updateEventUser(eventUserId: number) {
    this.eventService.updateUserEvent(this.updateUserEventForm.value, eventUserId).subscribe(() => {
      this.toastr.success('Wydarzenie zostało zaktualizowane!');
    })
  }

}
