import { Injectable } from '@angular/core';
import { GenericRestService } from '../generic-rest/generic-rest-service';


@Injectable({ providedIn: "root" })
export class RealEstateCatalogItemTypesService extends GenericRestService {
    constructor() {
        super({
          resourceName: "RealestateCatalogItemType", // API controller
        });
        // endpoint: https://example.com/api/tasks
      }
}


