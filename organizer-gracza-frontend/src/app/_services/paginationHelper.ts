// @ts-ignore
import {PaginatedResult} from "../model/model";
import {map} from "rxjs/operators";
import {HttpClient, HttpParams} from "@angular/common/http";

// @ts-ignore
export function getPaginatedResult<T>(url, params, http: HttpClient) {
  const paginatedResult: PaginatedResult<T> = new PaginatedResult<T>();
  // @ts-ignore
  return http.get<T>(url, {observe: 'response', params}).pipe(
    map(response => {
      // @ts-ignore
      paginatedResult.result = response.body;
      // @ts-ignore
      if (response.headers.get('Pagination') !== null) {
        // @ts-ignore
        paginatedResult.pagination = JSON.parse(response.headers.get('Pagination'));
      }
      return paginatedResult;
    })
  )
}

export function getPaginationHeaders(pageNumber: number, pageSize: number) {
  let params = new HttpParams();

  // @ts-ignore
  params = params.append('pageNumber', pageNumber.toString());
  // @ts-ignore
  params = params.append('pageSize', pageSize.toString());

  return params;
}
