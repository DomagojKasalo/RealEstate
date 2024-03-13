import { Injectable } from '@angular/core';
import { GenericRestService } from '../generic-rest/generic-rest-service';


@Injectable({ providedIn: "root" })
export class UserService extends GenericRestService {

  constructor() {
    super({
      resourceName: "Accounts/User", // API controller
    });
    // endpoint: https://example.com/api/tasks
  }
}
