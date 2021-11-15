import { Injectable } from '@angular/core';
import {environment} from "../../environments/environment";
import {HttpClient} from "@angular/common/http";
import {EventUser, GameStatistics, GeneralStatistics} from "../model/model";

@Injectable({
  providedIn: 'root'
})
export class StatisticsService {
  private baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getGameStatistics(){
    return this.http.get(this.baseUrl + 'gamestatistics');
  }

  getGameStatisticsById(gameStatisticId: number){
    return this.http.get(this.baseUrl + 'gamestatistics/' + gameStatisticId);
  }

  getGameStatisticsByUserId(userId: number){
    return this.http.get(this.baseUrl + 'gamestatistics/' + userId);
  }

  getGameStatisticsForUser(userId: number, gameId: number){
    return this.http.get(this.baseUrl + 'gamestatistics/specifiedgame/' + userId + '/' + gameId);
  }

  addGameStatistics(model: any){
    return this.http.post(this.baseUrl + 'gamestatistics', model)
  }

  deleteGameStatistics(gameStatisticsId: number){
    return this.http.delete(this.baseUrl + 'gamestatistics' + gameStatisticsId)
  }

  updateGameStatistics(gameStatistics: GameStatistics, gameStatisticsId: number){
    return this.http.put(this.baseUrl + 'gamestatistics/' + gameStatisticsId, gameStatistics)
  }

  getGeneralStatistics(){
    return this.http.get(this.baseUrl + 'generalstatistics');
  }

  getGeneralStatisticsById(generalStatisticId: number){
    return this.http.get(this.baseUrl + 'generalstatistics/' + generalStatisticId);
  }

  getGeneralStatisticsByUserId(userId: number){
    return this.http.get(this.baseUrl + 'generalstatistics/' + userId);
  }

  addGeneralStatistics(model: any){
    return this.http.post(this.baseUrl + 'generalstatistics', model)
  }

  deleteGeneralStatistics(generalStatisticId: number){
    return this.http.delete(this.baseUrl + 'generalstatistics' + generalStatisticId)
  }

  updateGeneralStatistics(generalStatistic: GeneralStatistics, generalStatisticId: number){
    return this.http.put(this.baseUrl + 'generalstatistics/' + generalStatisticId, generalStatistic)
  }

}
