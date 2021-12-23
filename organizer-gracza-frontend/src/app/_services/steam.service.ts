import { Injectable } from '@angular/core';
import {environment} from "../../environments/environment";
import {HttpClient} from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class SteamService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getUser(id: string){
    return this.http.get(this.baseUrl + 'steam/user/' + id);
  }

  getUserFriends(id: string){
    return this.http.get(this.baseUrl + 'steam/user/friends/' + id);
  }

  getUserGames(id: string){
    return this.http.get(this.baseUrl + 'steam/user/games/' + id);
  }

  getNewsForGame(gameId: number){
    return this.http.get(this.baseUrl + 'steam/news/' + gameId);
  }

  getAchievements(gameId: number){
    return this.http.get(this.baseUrl + 'steam/achievements/' + gameId);
  }

  getAchievementsDetails(gameId: number){
    return this.http.get(this.baseUrl + 'steam/achievements/details' + gameId);
  }

  getUserRecentlyPlayedGames(userId: string){
    return this.http.get(this.baseUrl + 'steam/user/played/' + userId);
  }

  getUserAchievements(userId: string, gameId: number){
    return this.http.get(this.baseUrl + 'steam/user/achievements/' + userId + '/game/' + gameId);
  }
}
