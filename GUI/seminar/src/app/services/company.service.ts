import { Injectable } from '@angular/core';
import { NgxGenericRestService } from 'ngx-grs';

@Injectable({ providedIn: "root" })
export class CompanyService extends NgxGenericRestService {
  constructor() {
    super({
      baseUrl: "https://localhost:7059/api/crm/v1", // environment.apiUrl
      resourceName: "Companies", // API controller
    });
  }
}
