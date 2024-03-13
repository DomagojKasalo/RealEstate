import { Injectable } from '@angular/core';
import { NgxGenericRestService } from 'ngx-grs';

@Injectable({ providedIn: "root" })
export class UserService extends NgxGenericRestService {

  constructor() {
    super({
      baseUrl: "https://localhost:7059/api/Accounts", // environment.apiUrl
      resourceName: "User", // API controller
    });
    // endpoint: https://example.com/api/tasks
  }
}
