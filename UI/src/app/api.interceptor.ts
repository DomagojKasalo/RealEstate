import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable } from 'rxjs';
import { AuthService } from './shared/services';

@Injectable()
export class CombinedInterceptor implements HttpInterceptor {

  constructor(public auth: AuthService) {}

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    const token = this.auth.getAccessToken();

    if (token) {
      request = request.clone({
        setHeaders: {
          Authorization: `Bearer ${token}`
        }
      });
    }

    const apiUrl = request.url.split('?')[0];
    const browserUrl = window.location.pathname;

    if (apiUrl === browserUrl) {
      const queryParams = request.params.keys().reduce((acc, key) => {
        const value = request.params.get(key);
        return value ? { ...acc, [key]: value } : acc;
      }, {});
      history.pushState({}, '', apiUrl + this.buildQueryString(queryParams));
    }

    return next.handle(request);
  }

  private buildQueryString(params: { [key: string]: string }): string {
    const queryString = Object.keys(params)
      .map((key) => `${encodeURIComponent(key)}=${encodeURIComponent(params[key])}`)
      .join('&');

    return queryString ? `?${queryString}` : '';
  }
}
