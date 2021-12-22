import { Injectable } from '@angular/core';
import {environment} from "../../environments/environment";
import {HttpClient} from "@angular/common/http";
import {map} from "rxjs/operators";

@Injectable({
  providedIn: 'root'
})
export class TwitchService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getData(){
    return this.http.get(this.baseUrl + 'twitch').pipe(
      map(res => {
        // @ts-ignore
        res.data.forEach(r => {
          r.thumbnail_url = r.thumbnail_url.replace("{width}", "440");
          r.thumbnail_url = r.thumbnail_url.replace("{height}", "248");
          return r;
        });
        // @ts-ignore
        return res;
      })
    );
  }

  getDataForGame(id: string) {
    return this.http.get(this.baseUrl + 'twitch/game/' + id).pipe(
      map(res => {
        // @ts-ignore
        res.data.forEach(r => {
          r.thumbnail_url = r.thumbnail_url.replace("{width}", "440");
          r.thumbnail_url = r.thumbnail_url.replace("{height}", "248");
          return r;
        });
        // @ts-ignore
        return res;
      })
    );
  }

  getDataForGameAndLanguage(gameId: string, languageId: string) {
    return this.http.get(this.baseUrl + 'twitch/game/' + gameId + '/language/' + languageId).pipe(
      map(res => {
        // @ts-ignore
        res.data.forEach(r => {
          r.thumbnail_url = r.thumbnail_url.replace("{width}", "440");
          r.thumbnail_url = r.thumbnail_url.replace("{height}", "248");
          return r;
        });
        // @ts-ignore
        return res;
      })
    );
  }

  getDataForLanguage(id: string){
    return this.http.get(this.baseUrl + 'twitch/language/' + id).pipe(
      map(res => {
        // @ts-ignore
        res.data.forEach(r => {
          r.thumbnail_url = r.thumbnail_url.replace("{width}", "440");
          r.thumbnail_url = r.thumbnail_url.replace("{height}", "248");
          return r;
        });
        // @ts-ignore
        return res;
      })
    );
  }
}
