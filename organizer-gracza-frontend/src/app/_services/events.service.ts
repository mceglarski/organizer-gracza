import {Injectable} from '@angular/core';
import {environment} from "../../environments/environment";
import {HttpClient} from "@angular/common/http";
import {EventTeam, EventUser} from "../model/model";

@Injectable({
  providedIn: 'root'
})
export class EventsService {
  baseUrl = environment.apiUrl;
  eventUsers: EventUser[] = [];
  eventTeams: EventTeam[] = [];
  eventUserCache = new Map();
  eventTeamCache = new Map();


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

  getUserEventByName(name: string){
    return this.http.get(this.baseUrl + 'eventsuser/specified/' + name);
  }

  getTeamEventByName(name: string){
    return this.http.get(this.baseUrl + 'eventsteam/specified/' + name);
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

  getTeamEventRegistration(eventId: number){
    return this.http.get(this.baseUrl + 'eventsteamregistrations/event/' + eventId)
  }

  getUserEventRegistration(eventId: number){
    return this.http.get(this.baseUrl + 'eventsuserregistrations/event/' + eventId)
  }

  updateUserEvent(userEvent: EventUser, eventId: number) {
    return this.http.put(this.baseUrl + 'eventsuser/' + eventId, userEvent);
  }

  updateTeamEvent(teamEvent: EventTeam, eventId: number) {
    return this.http.put(this.baseUrl + 'eventsteam/' + eventId, teamEvent);
  }

  deleteUserEventRegistration(userEventId: number, userId: number){
    return this.http.delete(this.baseUrl + 'eventsuserregistrations/delete/' + userEventId + '/' + userId);
  }

  deleteTeamEventRegistration(eventTeamId: number, teamId: number){
    return this.http.delete(this.baseUrl + 'eventsteamregistrations/delete/' + eventTeamId + '/' + teamId);
  }
}
