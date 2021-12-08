import { Injectable } from '@angular/core';
import {environment} from "../../environments/environment";
import {News} from "../model/model";

@Injectable({
  providedIn: 'root'
})
export class NewsService {

  baseUrl = environment.apiUrl;
  news: News[] = [];

  constructor() { }
}
