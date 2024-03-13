import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { CatalogItemsDetailsPage } from './catalog-items-details.page';

const routes: Routes = [
  {
    path: '',
    component: CatalogItemsDetailsPage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class CatalogItemsDetailsPageRoutingModule {}
