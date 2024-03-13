import { Injectable } from '@angular/core';
import { GenericRestService } from '../generic-rest/generic-rest-service';


@Injectable({ providedIn: "root" })
export class RealEstateCatalogTypesService extends GenericRestService {
    constructor() {
        super({
          resourceName: "RealestateCatalogTypes", // API controller
        });
        // endpoint: https://example.com/api/tasks
      }
}
