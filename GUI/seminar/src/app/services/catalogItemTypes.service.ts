import { Injectable } from '@angular/core';
import { NgxGenericRestService } from 'ngx-grs';

@Injectable({ providedIn: "root" })
export class CatalogItemTypesService extends NgxGenericRestService {
    constructor() {
        super({
          baseUrl: "https://localhost:7059/api/cpm/v1", // environment.apiUrl
          resourceName: "RealestateCatalogItemType", // API controller
        });
        // endpoint: https://example.com/api/tasks
      }
}


