import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({ providedIn: "root" })
export class CompanyAddEditService {
  baseUrl: string = "https://localhost:7059/api/crm/v1";
  resourceName: string = "Companies";

  constructor(private http: HttpClient) { }

  add<T>(data: FormData): Observable<T> {
    return this.http.post<T>(`${this.baseUrl}/${this.resourceName}`, data);
  }

  update<T>(id: number, data: FormData): Observable<T> {
    return this.http.put<T>(`${this.baseUrl}/${this.resourceName}/${id}`, data);
  }
}
