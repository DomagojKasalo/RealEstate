import { Injectable } from '@angular/core';
import { GenericRestService } from '../generic-rest/generic-rest-service';


@Injectable({ providedIn: "root" })
export class RealEstateCatalogItemStatusesService extends GenericRestService {
    constructor() {
        super({
          resourceName: "RealestateCatalogItemStatus", // API controller
        });
        // endpoint: https://example.com/api/tasks
      }
}

