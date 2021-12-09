import {Injectable} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {environment} from "../../environments/environment";

@Injectable({
  providedIn: 'root'
})
export class ArticlesService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {
  }

  getArticle(articleId: number) {
    return this.http.get(this.baseUrl + 'articles/' + articleId);
  }

  getArticles() {
    return this.http.get(this.baseUrl + 'articles');
  }

  getArticlesByUserId(userId: number) {
    return this.http.get(this.baseUrl + 'articles/userId/' + userId);
  }

  getArticleByArticleAndUserId(articleId: number, userId: number) {
    return this.http.get(this.baseUrl + 'articles/' + articleId + '/' + userId);
  }

  addArticle(model: any) {
    return this.http.post(this.baseUrl + 'articles', model);
  }

  deleteArticle(articleId: number) {
    return this.http.delete(this.baseUrl + 'articles/' + articleId);
  }

  updateArticle(model: any, articleId: number) {
    return this.http.put(this.baseUrl + 'articles/' + articleId, model);
  }
}
