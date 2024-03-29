import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class UserRoleService {
  private apiUrl = 'https://localhost:7059/api/Accounts'; 

  constructor(private http: HttpClient) {}

  getUserRole(userId: string): Observable<any> {
    const url = `${this.apiUrl}/User/${userId}/role`;
    return this.http.get<any>(url);
}

}
