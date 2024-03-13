import { Injectable } from '@angular/core';
import { NgxGenericRestService } from 'ngx-grs';

@Injectable({ providedIn: "root" })
export class CatalogTypesService extends NgxGenericRestService {
    constructor() {
        super({
          baseUrl: "https://localhost:7059/api/cpm/v1", // environment.apiUrl
          resourceName: "RealestateCatalogTypes", // API controller
        });
        // endpoint: https://example.com/api/tasks
      }
}
