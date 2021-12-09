import {Injectable} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {environment} from "../../environments/environment";
import {Observable} from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class ArticlesService {
  private baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {
  }

  public getArticle(articleId: number) {
    return this.http.get(this.baseUrl + 'articles/' + articleId);
  }

  public getArticles(): Observable<Object> {
    return this.http.get(this.baseUrl + 'articles');
  }

  public getArticlesByUserId(userId: number) {
    return this.http.get(this.baseUrl + 'articles/userId/' + userId);
  }

  public getArticleByArticleAndUserId(articleId: number, userId: number) {
    return this.http.get(this.baseUrl + 'articles/' + articleId + '/' + userId);
  }

  public addArticle(model: any) {
    return this.http.post(this.baseUrl + 'articles', model);
  }

  public deleteArticle(articleId: number) {
    return this.http.delete(this.baseUrl + 'articles/' + articleId);
  }

  public updateArticle(model: any, articleId: number) {
    return this.http.put(this.baseUrl + 'articles/' + articleId, model);
  }
}
