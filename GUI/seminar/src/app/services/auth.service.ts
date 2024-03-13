import { Injectable } from '@angular/core';
import jwt_decode from 'jwt-decode';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private TOKEN_KEY = 'token';  

  constructor() { }

  getAccessToken(): string | null {
    return localStorage.getItem(this.TOKEN_KEY);  
  }

  getUserId(): string | null {
    const token = this.getAccessToken();
    if (!token) {
      return null;
    }
    const decodedToken: any = jwt_decode(token);
    return decodedToken['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier'];
  }

  saveToken(token: string) {
    localStorage.setItem(this.TOKEN_KEY, token);
  }

  getToken() {
    return localStorage.getItem(this.TOKEN_KEY);
  }
  clearToken() {
    localStorage.removeItem(this.TOKEN_KEY);
  }
  isAuthenticated() {
    return this.getToken() !== null;
  }
}
