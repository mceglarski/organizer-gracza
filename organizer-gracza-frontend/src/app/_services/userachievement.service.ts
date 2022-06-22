import {Injectable} from '@angular/core';
import {environment} from "../../environments/environment";
import {HttpClient} from "@angular/common/http";
import {UserAchievement} from "../model/model";

@Injectable({
  providedIn: 'root'
})
export class UserachievementService {

  private baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {
  }

  getUserAchievements() {
    return this.http.get(this.baseUrl + 'userachievement');
  }

  getUserAchievementsById(userAchievementId: number) {
    return this.http.get(this.baseUrl + 'userachievement/' + userAchievementId);
  }

  getUserAchievementsByUserId(userId: number) {
    return this.http.get(this.baseUrl + 'userachievement/userId/' + userId);
  }

  getUserAchievementByAchievementId(achievementId: number) {
    return this.http.get(this.baseUrl + 'userachievement/achievementId/' + achievementId);
  }

  getUserAchievementByUserIdAndAchievementId(userId: number, achievementId: number) {
    return this.http.get(this.baseUrl + 'userachievement/' + userId + '/achievementId/' + achievementId);
  }

  addUserAchievementById(model: any) {
    return this.http.post(this.baseUrl + 'userachievement', model);
  }

  deleteUserAchievementById(userAchievementId: number) {
    return this.http.delete(this.baseUrl + 'userachievement/' + userAchievementId);
  }

  updateUserAchievementById(userAchievement: UserAchievement, userAchievementsId: number) {
    return this.http.put(this.baseUrl + 'userachievement/' + userAchievementsId, userAchievement);
  }
}
