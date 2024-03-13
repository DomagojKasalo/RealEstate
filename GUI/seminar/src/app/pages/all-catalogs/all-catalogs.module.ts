import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { AllCatalogsPageRoutingModule } from './all-catalogs-routing.module';

import { AllCatalogsPage } from './all-catalogs.page';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    AllCatalogsPageRoutingModule
  ],
  declarations: [AllCatalogsPage]
})
export class AllCatalogsPageModule {}
