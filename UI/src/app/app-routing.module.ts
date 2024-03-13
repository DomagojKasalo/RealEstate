import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent, ResetPasswordFormComponent, CreateAccountFormComponent, ChangePasswordFormComponent } from './shared/components';
import { AuthGuardService, AuthService } from './shared/services';
import { HomeComponent } from './pages/home/home.component';
import { ProfileComponent } from './pages/profile/profile.component';
import { DxDataGridModule, DxFormModule } from 'devextreme-angular';
import { CompanyListComponent } from './pages/company/list/company-list.component';
import { CompanyAddComponent } from './pages/company/edit/company-add.component';
import { CompanyEditComponent } from './pages/company/edit/company-edit.component';
import { UserListComponent } from './pages/Users/list/user-list.component';
import { UserDetailComponent } from './pages/Users/edit/user-edit.component';
import { RealEstateCatalogItemsListComponent } from './pages/catalogs/realEstateCatalogItems/list/realEstateCatalogItems-list.component';
import { RealEstateCatalogItemEditComponent } from './pages/catalogs/realEstateCatalogItems/edit/realEstateCatalogItem-edit.component';
import { RealEstateCatalogListComponent } from './pages/catalogs/realEstateCatalogs/list/realEstateCatalogs-list.component';
import { RealEstateCatalogAddComponent } from './pages/catalogs/realEstateCatalogs/edit/realEstateCatalog-add.component';
import { RealEstateCatalogEditComponent } from './pages/catalogs/realEstateCatalogs/edit/realEstateCatalog-edit.component';
import { RealEstateCatalogItemAddComponent } from './pages/catalogs/realEstateCatalogItems/edit/realEstateCatalogItem-add.component';
import { InvitationComponent } from './pages/email/invitation.component';
import { RealEstateCatalogItemUploadComponent } from './pages/catalogs/realEstateCatalogItems/uploadImage/realEstateCatalogItem-upload.component';
import { FileUploadComponent } from './pages/file-upload/file-upload.component';


const routes: Routes = [
  {
    path: 'invitation',
    component: InvitationComponent,
    canActivate: [AuthGuardService],
  },
  {
    path: 'catalogs',
    component: RealEstateCatalogListComponent,
    canActivate: [ AuthGuardService ]
  },
  {
    path: 'catalogs/add',
    component: RealEstateCatalogAddComponent,
    canActivate: [ AuthGuardService ]
  },
  {
    path: 'catalogs/edit/:id',
    component: RealEstateCatalogEditComponent,
    canActivate: [ AuthGuardService ]
  },
  {
    path: 'catalogItems',
    component: RealEstateCatalogItemsListComponent,
    canActivate: [ AuthGuardService ]
  },
  {
    path: 'catalogItems/edit/:id',
    component: RealEstateCatalogItemEditComponent,
    canActivate: [ AuthGuardService ]
  },
  {
    path: 'catalogItems/upload/:id',
    component: RealEstateCatalogItemUploadComponent,
    canActivate: [ AuthGuardService ]
  },
  {
    path: 'catalogItems/add',
    component: RealEstateCatalogItemAddComponent,
    canActivate: [ AuthGuardService ]
  },
  {
    path: 'companies',
    component: CompanyListComponent,
    canActivate: [ AuthGuardService ],
    data: { roles: ['Admin'] }
  },
  {
    path: 'companies/add',
    component: CompanyAddComponent,
    canActivate: [ AuthGuardService ],
    data: { roles: ['Admin'] }
  },
  {
    path: 'companies/edit/:id',
    component: CompanyEditComponent,
    canActivate: [ AuthGuardService ],
    data: { roles: ['Admin'] }
  },
  {
    path: 'user',
    component: UserListComponent,
    canActivate: [ AuthGuardService ],
    data: { roles: ['Admin'] }
  },
  {
    path: 'user/edit/:id',
    component: UserDetailComponent,
    canActivate: [ AuthGuardService ],
  },
  {
    path: 'createAcc',
    component: CreateAccountFormComponent,
    canActivate: [ AuthGuardService ],
    data: { roles: ['Admin'] }
  },
  {
    path: 'profile',
    component: ProfileComponent,
    canActivate: [ AuthGuardService ],
  },
  {
    path: 'home',
    component: HomeComponent,
    canActivate: [ AuthGuardService ]
  },
  {
    path: 'file-upload',
    component: FileUploadComponent,
    canActivate: [ AuthGuardService ]
  },
  {
    path: 'login-form',
    component: LoginComponent,
    canActivate: [ AuthGuardService ]
  },
  // {
  //   path: 'reset-password',
  //   component: ResetPasswordFormComponent,
  //   canActivate: [ AuthGuardService ]
  // },
  // {
  //   path: 'change-password/:recoveryCode',
  //   component: ChangePasswordFormComponent,
  //   canActivate: [ AuthGuardService ]
  // },
  {
    path: '**',
    redirectTo: 'home'
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes, { useHash: true }), DxDataGridModule, DxFormModule],
  providers: [AuthGuardService],
  exports: [RouterModule],
  declarations: [
    HomeComponent,
  ]
})
export class AppRoutingModule { }
