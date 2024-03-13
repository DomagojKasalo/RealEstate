// invitation.service.ts
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { SendMailRequest } from '../../model/invitation.model';

@Injectable({
  providedIn: 'root'
})
export class InvitationService {

  private apiUrl = 'https://localhost:7059/api/Accounts/sendmail';  

  constructor(private http: HttpClient) { }

  sendInvitation(request: SendMailRequest): Observable<any> {
    return this.http.post<any>(this.apiUrl, request);
  }
}
