import { Injectable } from '@angular/core';
import {environment} from "../../environments/environment";
import {HttpClient} from "@angular/common/http";
import {EventResult} from "../model/model";

@Injectable({
  providedIn: 'root'
})
export class EventsresultsService {

  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getEventsResults(){
    return this.http.get(this.baseUrl + 'eventsresults');
  }
  getEventResult(eventResultId: number){
    return this.http.get(this.baseUrl + 'eventsresults/' + eventResultId);
  }
  addEventResult(model: any){
    return this.http.post(this.baseUrl + 'eventsresults', model);
  }
  deleteEventResult(eventResultId: number){
    return this.http.delete(this.baseUrl + 'eventsresults/' + eventResultId);
  }
  updateEventResult(eventResult: EventResult, eventResultId: number){
    return this.http.put(this.baseUrl + 'eventsresults/' + eventResultId, eventResult)
  }
}
