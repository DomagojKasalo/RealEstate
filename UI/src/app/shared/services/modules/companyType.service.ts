import { Injectable } from '@angular/core';
import { GenericRestService } from '../generic-rest/generic-rest-service';


@Injectable({ providedIn: "root" })
export class CompanyTypeService extends GenericRestService {
  constructor() {
    super({
      resourceName: "CompanyTypes", // API controller
    });
    // endpoint: https://example.com/api/tasks
  }
}
