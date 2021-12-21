import { Injectable } from '@angular/core';
import {environment} from "../../environments/environment";
import {HttpClient} from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class TwitchService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getData(){
    return this.http.get(this.baseUrl + 'twitch');
  }

  getDataForGameAndLanguage(gameId: string, languageId: string){
    return this.http.get(this.baseUrl + 'twitch/game/' + gameId + '/language/' + languageId);
  }

  getDataForLanguage(id: string){
    return this.http.get(this.baseUrl + 'twitch/language/' + id);
  }
}
