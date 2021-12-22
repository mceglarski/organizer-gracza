import { Injectable } from '@angular/core';
import {environment} from "../../environments/environment";
import {HttpClient} from "@angular/common/http";
import {UserGame} from "../model/model";

@Injectable({
  providedIn: 'root'
})
export class UsergameService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getUsersGames(){
    return this.http.get(this.baseUrl + 'usergame');
  }
  getUserGame(userGameId: number){
    return this.http.get(this.baseUrl + 'usergame/' + userGameId);
  }
  getUserGameForUser(userId: number){
    return this.http.get(this.baseUrl + 'usergame/user/' + userId);
  }
  getUserGameForGame(gameId: number){
    return this.http.get(this.baseUrl + 'usergame/game/' + gameId)
  }
  addUserGame(model: any){
    return this.http.post(this.baseUrl + 'usergame', model);
  }
  deleteUserGame(userGameId: number){
    return this.http.delete(this.baseUrl + 'usergame/' + userGameId);
  }
  updateUserGame(userGame: UserGame, userGameId: number){
    return this.http.put(this.baseUrl + 'usergame/' + userGameId, userGame);
  }
}
