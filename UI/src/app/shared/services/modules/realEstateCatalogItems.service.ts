import { Injectable } from '@angular/core';
import { GenericRestService } from '../generic-rest/generic-rest-service';


@Injectable({ providedIn: "root" })
export class RealEstateCatalogItemsService extends GenericRestService {
    constructor() {
        super({
          resourceName: "RealestateCatalogItems", // API controller
        });
        // endpoint: https://example.com/api/tasks
    }

}
