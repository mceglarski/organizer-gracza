import { Injectable } from '@angular/core';
import {environment} from "../../environments/environment";
import {HttpClient} from "@angular/common/http";
import {UserAchievementCounter} from "../model/model";

@Injectable({
  providedIn: 'root'
})
export class AchievementcountersService {
  private baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getAchievementsCounters(){
    return this.http.get(this.baseUrl + 'userachievementcounter');
  }

  getAchievementsCountersByUserId(userId: number){
    return this.http.get(this.baseUrl + 'userachievementcounter/userId/' + userId);
  }

  getAchievementCounterById(achievementCounterId: number){
    return this.http.get(this.baseUrl + 'userachievementcounter/' + achievementCounterId);
  }

  addAchievementCounterById(model: any){
    return this.http.post(this.baseUrl + 'userachievementcounter', model);
  }

  deleteAchievementCounterById(achievementId: number){
    return this.http.delete(this.baseUrl + 'userachievementcounter/' + achievementId);
  }

  updateAchievementCounterById(userAchievementCounter: UserAchievementCounter, achievementCounterId: number){
    return this.http.put(this.baseUrl + 'userachievementcounter/' + achievementCounterId , userAchievementCounter);
  }
}
