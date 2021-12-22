import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {environment} from "../../environments/environment";
import {Reminder} from "../model/model";

@Injectable({
  providedIn: 'root'
})
export class ReminderService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getRemind(reminderId: number){
    return this.http.get(this.baseUrl + 'reminder/' + reminderId);
  }
  getReminds(){
    return this.http.get(this.baseUrl + 'reminder');
  }
  getRemindsForUserById(userId: number){
    return this.http.get(this.baseUrl + 'reminder/userId/' + userId);
  }
  getRemindByUserIdAndRemindId(reminderId: number, userId: number){
    return this.http.get(this.baseUrl + 'remind/' + reminderId + '/' + userId);
  }
  addReminder(model: any){
    return this.http.post(this.baseUrl + 'reminder', model);
  }
  deleteTeam(reminderId: number){
    return this.http.delete(this.baseUrl + 'reminder/' + reminderId);
  }
  updateReminder(model: any, reminderId: number){
    return this.http.put(this.baseUrl + 'reminder/' + reminderId, model);
  }
}
