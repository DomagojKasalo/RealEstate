import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppComponent } from './app.component';
import { SideNavOuterToolbarModule, SideNavInnerToolbarModule, SingleCardModule } from './layouts';
import { ChangePasswordFormModule, CreateAccountFormComponent, FooterModule, LoginComponent, ResetPasswordFormModule, SideNavigationMenuComponent } from './shared/components';
import { ScreenService, AppInfoService, AuthService } from './shared/services';
import { UnauthenticatedContentModule } from './unauthenticated-content';
import { AppRoutingModule } from './app-routing.module';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { DxButtonModule, DxChartModule, DxDataGridModule, DxFileManagerModule, DxFormModule, DxListModule, DxLoadIndicatorModule, DxLoadPanelModule, DxLookupModule, DxSelectBoxModule, DxTemplateModule, DxTextBoxModule, DxToastModule } from 'devextreme-angular';
import { ToastrModule, ToastrService } from 'ngx-toastr';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CompanyListComponent } from './pages/company/list/company-list.component';
import { CompanyEditComponent } from './pages/company/edit/company-edit.component';
import { CompanyAddComponent } from './pages/company/edit/company-add.component';
import { TokenInterceptor } from './shared/services/HttpInterceptor.service';
import { UserListComponent } from './pages/Users/list/user-list.component';
import { UserDetailComponent } from './pages/Users/edit/user-edit.component';
import { ProfileComponent } from './pages/profile/profile.component';
import { RealEstateCatalogItemsListComponent } from './pages/catalogs/realEstateCatalogItems/list/realEstateCatalogItems-list.component';
import { RealEstateCatalogItemEditComponent } from './pages/catalogs/realEstateCatalogItems/edit/realEstateCatalogItem-edit.component';
import { RealEstateCatalogListComponent } from './pages/catalogs/realEstateCatalogs/list/realEstateCatalogs-list.component';
import { RealEstateCatalogAddComponent } from './pages/catalogs/realEstateCatalogs/edit/realEstateCatalog-add.component';
import { RealEstateCatalogEditComponent } from './pages/catalogs/realEstateCatalogs/edit/realEstateCatalog-edit.component';
import { RealEstateCatalogItemAddComponent } from './pages/catalogs/realEstateCatalogItems/edit/realEstateCatalogItem-add.component';
import { InvitationComponent } from './pages/email/invitation.component';
import { RealEstateCatalogItemUploadComponent } from './pages/catalogs/realEstateCatalogItems/uploadImage/realEstateCatalogItem-upload.component';
import { FileUploadComponent } from './pages/file-upload/file-upload.component';
import { BlobServiceClient } from '@azure/storage-blob';




@NgModule({
  declarations: [
    AppComponent,
    CompanyListComponent,
    CompanyAddComponent,
    CompanyEditComponent,
    LoginComponent,
    CreateAccountFormComponent,
    UserListComponent,
    UserDetailComponent,
    ProfileComponent,
    RealEstateCatalogItemsListComponent,
    RealEstateCatalogItemEditComponent,
    RealEstateCatalogListComponent,
    RealEstateCatalogAddComponent,
    RealEstateCatalogEditComponent,
    RealEstateCatalogItemAddComponent,
    InvitationComponent,
    RealEstateCatalogItemUploadComponent,
    FileUploadComponent
  ],
  imports: [
    ToastrModule.forRoot(),
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    SideNavOuterToolbarModule,
    SideNavInnerToolbarModule,
    SingleCardModule,
    FooterModule,
    ResetPasswordFormModule,
    ChangePasswordFormModule,
    UnauthenticatedContentModule,
    AppRoutingModule,
    HttpClientModule,
    DxLoadPanelModule,
    DxToastModule,
    DxDataGridModule,
    DxTemplateModule,
    DxButtonModule,
    DxListModule,
    DxTextBoxModule,
    DxFormModule,
    DxChartModule,
    DxLoadIndicatorModule,
    DxSelectBoxModule,
    DxFileManagerModule,
  ],
  providers: [
    AuthService,
    ScreenService,
    AppInfoService,
    ToastrService,
    { provide: HTTP_INTERCEPTORS, useClass: TokenInterceptor, multi: true },
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
