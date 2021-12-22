import { Injectable } from '@angular/core';
import {environment} from "../../environments/environment";
import {HttpClient} from "@angular/common/http";
import {EventTeamResult} from "../model/model";

@Injectable({
  providedIn: 'root'
})
export class eventteamsresultsService {

  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getEventsTeamResults(){
    return this.http.get(this.baseUrl + 'eventsteamresults');
  }
  getEventTeamResult(eventTeamResultId: number){
    return this.http.get(this.baseUrl + 'eventsteamresults/' + eventTeamResultId);
  }
  addEventTeamResult(model: any){
    return this.http.post(this.baseUrl + 'eventsteamresults', model);
  }
  deleteEventTeamResult(eventTeamResultId: number){
    return this.http.delete(this.baseUrl + 'eventsteamresults/' + eventTeamResultId);
  }
  updateEventTeamResult(eventTeamResult: EventTeamResult, eventResultId: number){
    return this.http.put(this.baseUrl + 'eventsteamresults/' + eventResultId, eventsteamresults)
  }
}
