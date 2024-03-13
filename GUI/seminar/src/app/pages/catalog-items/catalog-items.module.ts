import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { CatalogItemsPageRoutingModule } from './catalog-items-routing.module';

import { CatalogItemsPage } from './catalog-items.page';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    CatalogItemsPageRoutingModule
  ],
  declarations: [CatalogItemsPage]
})
export class CatalogItemsPageModule {}
