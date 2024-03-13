import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { CatalogItemsDetailsPageRoutingModule } from './catalog-items-details-routing.module';

import { CatalogItemsDetailsPage } from './catalog-items-details.page';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    CatalogItemsDetailsPageRoutingModule
  ],
  declarations: [CatalogItemsDetailsPage]
})
export class CatalogItemsDetailsPageModule {}
