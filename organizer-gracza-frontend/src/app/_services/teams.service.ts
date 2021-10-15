import { Injectable } from '@angular/core';
import {environment} from "../../environments/environment";
import {HttpClient} from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class TeamsService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getTeams(){
    return this.http.get(this.baseUrl + 'teams');
  }
  getTeam(teamId: number){
    return this.http.get(this.baseUrl + 'teams/' + teamId);
  }
  getTeamByName(name: string){
    return this.http.get(this.baseUrl + 'teams/details/' + name);
  }
  addTeam(model: any){
    return this.http.post(this.baseUrl + 'teams', model);
  }
  deleteTeam(teamId: number){
    return this.http.delete(this.baseUrl + 'teams/' + teamId);
  }

  getTeamsUsers(){
    return this.http.get(this.baseUrl + 'teamusers');
  }
  getTeamUser(teamUserId: number){
    return this.http.get(this.baseUrl + 'teamusers/' + teamUserId);
  }
  addTeamUser(model: any){
    return this.http.post(this.baseUrl + 'teamusers', model);
  }
  deleteTeamUser(teamUserId: number){
    return this.http.delete(this.baseUrl + 'teamusers/' + teamUserId);
  }

  getTeamsForUser(username: string){
    return this.http.get(this.baseUrl + 'teamusers/teams/' + username);
  }
}
