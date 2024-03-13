import { Injectable } from '@angular/core';
import { GenericRestService } from '../generic-rest/generic-rest-service';

@Injectable({ providedIn: "root" })
export class RealEstateCatalogsService extends GenericRestService {
  
  constructor() {
    super({
      resourceName: "RealestateCatalogs", // API controller
    });
    // endpoint: https://example.com/api/tasks
  }

}
