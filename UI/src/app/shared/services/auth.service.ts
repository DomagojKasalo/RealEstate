import { Injectable } from '@angular/core';
import { CanActivate, Router, ActivatedRouteSnapshot } from '@angular/router';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, map } from 'rxjs';
import { User } from '../model/user';
import jwt_decode from 'jwt-decode';
import { UserService } from './user.service';

const defaultPath = '/';
const defaultUser = new User();
defaultUser.email = '';
defaultUser.userName = '';
defaultUser.password = '';
defaultUser.confirmPassword = '';
defaultUser.firstName = '';
defaultUser.lastName = '';
defaultUser.phoneNumber = '';
defaultUser.address = '';
defaultUser.roles = [];

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private accessToken: string | null = null;

  private serverUrl = 'https://localhost:7059/api/Accounts';
  private user: User | null = defaultUser;

  get loggedIn(): boolean {
    return !!this.user;
  }

  private _lastAuthenticatedPath: string = defaultPath;
  set lastAuthenticatedPath(value: string) {
    this._lastAuthenticatedPath = value;
  }

  constructor(private router: Router, private http: HttpClient, private userService: UserService) {
    const token = this.getAccessToken();
    if (token) {
      const decodedToken: any = jwt_decode(token);
      this.user = new User();
      this.user.email = decodedToken.email;
      this.user.userName = decodedToken.userName;
      this.user.id = decodedToken['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier'];
      this.user.roles = [decodedToken['http://schemas.microsoft.com/ws/2008/06/identity/claims/role']];
    }
  }


  async logIn(email: string, password: string) {
    return this.http.post<{ token: string }>(`${this.serverUrl}/Login`, { email, password })
      .pipe(
        map((result: { token: string }) => {
          localStorage.setItem('access_token', result.token);
          const decodedToken: any = jwt_decode(result.token);
          this.user = new User();
          this.user.email = email;
          this.user.userName = decodedToken.userName;
          this.user.id = decodedToken['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier'];
          this.user.roles = [decodedToken['http://schemas.microsoft.com/ws/2008/06/identity/claims/role']];

          this.userService.setUser(this.user);
          
          this.router.navigate(['/home']).then(() => {
            location.reload();
          });
          
          return {
            isOk: true,
            data: this.user
          };
        })
      ).toPromise()
      .catch(err => {
        console.error(err);
        return {
          isOk: false,
          message: "Authentication failed"
        };
      });
  }

  getAuthorizationHeader(): HttpHeaders {
    const token = localStorage.getItem('access_token');
    return new HttpHeaders({ Authorization: `Bearer ${token}` });
  }

  getAccessToken(): string | null {
    return localStorage.getItem('access_token');
  }

  getUserId(): string | null {
    const token = this.getAccessToken();
    if (!token) {
      return null;
    }
    const decodedToken: any = jwt_decode(token);
    return decodedToken['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier'];
  }

  register(user: User): Observable<boolean> {
    return this.http.post<{ token: string }>(`${this.serverUrl}/Register`, user)
      .pipe(
        map(result => {
          localStorage.setItem('access_token', result.token);
          return true;
        })
      );
  }

  async createUser(user: User) {
    try {
      const headers = this.getAuthorizationHeader();

      await this.http.post(`${this.serverUrl}/CreateUser`, user, { headers }).toPromise();
      return {
        isOk: true
      };
    } catch (error) {
      return {
        isOk: false,
        message: "Failed to create user"
      };
    }
  }


  async getUsers() {
    try {
      const headers = this.getAuthorizationHeader();
      const result = await this.http.get<User>(`${this.serverUrl}/Users`, { headers }).toPromise();
      this.user = result ? result : null;

      return {
        isOk: true,
        data: this.user
      };
    } catch (error) {
      return {
        isOk: false,
        data: null
      };
    }
  }

  async getUser() {
    try {
      // Send request

      return {
        isOk: true,
        data: this.user
      };
    }
    catch {
      return {
        isOk: false,
        data: null
      };
    }
  }

  async changePassword(email: string, recoveryCode: string) {
    try {
      // Send request

      return {
        isOk: true
      };
    }
    catch {
      return {
        isOk: false,
        message: "Failed to change password"
      }
    }
  }

  async resetPassword(email: string) {
    try {
      // Send request

      return {
        isOk: true
      };
    }
    catch {
      return {
        isOk: false,
        message: "Failed to reset password"
      };
    }
  }

  async logOut() {
    localStorage.removeItem('access_token');
    this.user = null;
    this.userService.resetUser()
    this.router.navigate(['/login-form']);
  }

  getUserRole(): string | null {
    const token = this.getAccessToken();
    if (!token) {
      return null;
    }
    const decodedToken: any = jwt_decode(token);
    return decodedToken['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'];
}


  isTokenExpired(): boolean {
    const token = this.getAccessToken();
    if (!token) {
      return true; 
    }
  
    const decodedToken: any = jwt_decode(token);
    const currentTime = Math.floor(Date.now() / 1000);
  
    return decodedToken.exp < currentTime;
  }  
}

@Injectable()
export class AuthGuardService implements CanActivate {
  constructor(private router: Router, private authService: AuthService) {}

  canActivate(route: ActivatedRouteSnapshot): boolean {
    const isLoggedIn = this.authService.loggedIn;
    const isAuthForm = [
      'login-form',
      'create-account',
    ].includes(route.routeConfig?.path || defaultPath);

    if (!isLoggedIn && !isAuthForm) {
      this.router.navigate(['/login-form']);
      return false; 
    }

    if (isLoggedIn) {
      const tokenExpired = this.authService.isTokenExpired();
      const userRole = this.authService.getUserRole();

      if (tokenExpired) {
        this.authService.logOut();
        return false;
      }

      this.authService.lastAuthenticatedPath = route.routeConfig?.path || defaultPath;

      if (route.data?.['roles']) {
        const requiredRoles: string[] = route.data['roles'];

        if (!userRole || !requiredRoles.some(role => userRole.includes(role))) {
          this.router.navigate(['/home']);
          return false;
        }
      }
    }

    return true;
  }
}