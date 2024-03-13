import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { CatalogItemsPage } from './catalog-items.page';

const routes: Routes = [
  {
    path: '',
    component: CatalogItemsPage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class CatalogItemsPageRoutingModule {}
