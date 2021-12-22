import { Injectable } from '@angular/core';
import {environment} from "../../environments/environment";
import {HttpClient} from "@angular/common/http";
import {EventTeamResult, EventUserResult} from "../model/model";

@Injectable({
  providedIn: 'root'
})
export class EventuserresultsService {

  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getEventsUserResults(){
    return this.http.get(this.baseUrl + 'eventuserresult');
  }
  getEventUserResult(eventUserResultId: number){
    return this.http.get(this.baseUrl + 'eventuserresult/' + eventUserResultId);
  }
  addEventUserResult(model: any){
    return this.http.post(this.baseUrl + 'eventuserresult', model);
  }
  deleteEventUserResult(eventUserResultId: number){
    return this.http.delete(this.baseUrl + 'eventuserresult/' + eventUserResultId);
  }
  updateEventUserResult(eventUserResult: EventUserResult, eventUserResultId: number){
    return this.http.put(this.baseUrl + 'eventuserresult/' + eventUserResultId, eventUserResult)
  }
}
