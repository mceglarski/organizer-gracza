import { Injectable } from '@angular/core';
import {environment} from "../../environments/environment";
import {HttpClient} from "@angular/common/http";
import {Achievements} from "../model/model";

@Injectable({
  providedIn: 'root'
})
export class AchievementsService {
  private baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getAchievements(){
    return this.http.get(this.baseUrl + 'achievements');
  }

  getAchievementsByUserId(userId: number){
    return this.http.get(this.baseUrl + 'achievements/userId/' + userId);
  }

  getAchievementById(achievementId: number){
    return this.http.get(this.baseUrl + 'achievements/' + achievementId);
  }

  addAchievementById(model: any){
    return this.http.post(this.baseUrl + 'achievements', model);
  }

  deleteAchievementById(achievementId: number){
    return this.http.delete(this.baseUrl + 'achievements/' + achievementId);
  }

  updateAchievementById(achievements: Achievements, achievementsId: number){
    return this.http.put(this.baseUrl + 'achievements/' + achievementsId , achievements);
  }
}
