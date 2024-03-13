import { Injectable } from '@angular/core';
import { GenericRestService } from '../generic-rest/generic-rest-service';


@Injectable({ providedIn: "root" })
export class RealEstateCatalogItemDeploymentStatusesService extends GenericRestService {
  constructor() {
    super({
      resourceName: "DeploymentStatus", // API controller
    });
    // endpoint: https://example.com/api/tasks
  }
}

