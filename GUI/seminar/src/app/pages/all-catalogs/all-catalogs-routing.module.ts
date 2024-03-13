import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AllCatalogsPage } from './all-catalogs.page';

const routes: Routes = [
  {
    path: '',
    component: AllCatalogsPage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class AllCatalogsPageRoutingModule {}
