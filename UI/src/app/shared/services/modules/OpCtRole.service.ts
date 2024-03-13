import { Injectable } from '@angular/core';
import { GenericRestService } from '../generic-rest/generic-rest-service';


@Injectable({ providedIn: "root" })
export class OpCtRoleService extends GenericRestService {
  constructor() {
    super({
      resourceName: "OpportunityContactRole", // API controller
    });
    // endpoint: https://example.com/api/tasks
  }
}
