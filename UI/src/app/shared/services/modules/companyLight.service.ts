import { Injectable } from '@angular/core';
import { GenericRestService } from '../generic-rest/generic-rest-service';

@Injectable({ providedIn: "root" })
export class CompanyLightService extends GenericRestService {
  constructor() {
    super({
      resourceName: "Companies/light", // API controller
    });
    // endpoint: https://example.com/api/tasks
  }
}
