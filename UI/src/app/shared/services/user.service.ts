import { Injectable } from "@angular/core";
import { User } from "../model/user";

@Injectable({
    providedIn: 'root'
  })
  export class UserService {
    private _user: User | null = null;
  
    get user(): User | null {
        return this._user;
      }
  
    setUser(user: User) {
      this._user = user;
    }
  
    resetUser() {
      this._user = null;
    }
  }