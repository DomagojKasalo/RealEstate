import { Injectable } from '@angular/core';
import { GenericRestService } from '../generic-rest/generic-rest-service';

@Injectable({ providedIn: "root" })
export class CompanyService extends GenericRestService {
  constructor() {
    super({
      resourceName: "Companies", // API controller
    });
  }
}
