import { Injectable } from '@angular/core';
import {environment} from "../../environments/environment";
import {HttpClient} from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class GameService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getGames(){
    return this.http.get(this.baseUrl + 'games');
  }

  getGame(gameId: number){
    return this.http.get(this.baseUrl + 'games/' + gameId);
  }
}
