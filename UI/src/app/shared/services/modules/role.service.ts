import { Injectable } from '@angular/core';
import { GenericRestService } from '../generic-rest/generic-rest-service';


@Injectable({ providedIn: "root" })
export class RoleService extends GenericRestService {
  constructor() {
    super({
      resourceName: "Roles", // API controller
    });
    // endpoint: https://example.com/api/tasks
  }
}
