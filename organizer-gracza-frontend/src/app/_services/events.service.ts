import { Injectable } from '@angular/core';
import {environment} from "../../environments/environment";
import {HttpClient} from "@angular/common/http";
import {mod} from "ngx-bootstrap/chronos/utils";

@Injectable({
  providedIn: 'root'
})
export class EventsService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getUserEvents(){
    return this.http.get(this.baseUrl + 'eventsuser');
  }

  getTeamEvents(){
    return this.http.get(this.baseUrl + 'eventsteam');
  }

  getUserEvent(userEventId: number){
    return this.http.get(this.baseUrl + 'eventsuser/' + userEventId);
  }

  getTeamEvent(teamEventId: number){
    return this.http.get(this.baseUrl + 'eventsteam/' + teamEventId);
  }

  deleteUserEvent(userEventId: number){
    return this.http.delete(this.baseUrl + 'eventsuser/' + userEventId);
  }

  deleteTeamEvent(teamEventId: number){
    return this.http.delete(this.baseUrl + 'eventsteam/' + teamEventId);
  }

  addUserEvent(model: any){
    return this.http.post(this.baseUrl + 'eventsuser', model)
  }

  addTeamEvent(model: any){
    return this.http.post(this.baseUrl + 'eventsteam', model)
  }

  addUserEventRegistration(model: any){
    return this.http.post(this.baseUrl + 'eventsuserregistrations', model);
  }

  addTeamEventRegistration(model: any){
    return this.http.post(this.baseUrl + 'eventsteamregistrations', model);
  }
}
