import { NgModule } from '@angular/core';
import { PreloadAllModules, RouterModule, Routes } from '@angular/router';
import { LoginPage } from './pages/login/login.page';

const routes: Routes = [
  {
    path: '',
    loadChildren: () => import('./pages/home/home.module').then( m => m.HomePageModule)
  },
  {
    path: 'login',
    component: LoginPage,
  },
  {
    path: 'register',
    loadChildren: () => import('./pages/register/register.module').then( m => m.RegisterPageModule)
  },
  {
    path: 'catalogs',
    loadChildren: () => import('./pages/catalogs/catalog.module').then( m => m.CatalogPageModule)
  },
  {
    path: 'catalog-items/:id',
    loadChildren: () => import('./pages/catalog-items/catalog-items.module').then( m => m.CatalogItemsPageModule)
  },
  {
    path: 'catalog-items/:id/details',
    loadChildren: () => import('./pages/catalog-items-details/catalog-items-details.module').then( m => m.CatalogItemsDetailsPageModule)
  },
  {
    path: 'index',
    loadChildren: () => import('./pages/index/index.module').then( m => m.IndexPageModule)
  },
  {
    path: 'all-catalogs',
    loadChildren: () => import('./pages/all-catalogs/all-catalogs.module').then( m => m.AllCatalogsPageModule)
  },
];
@NgModule({
  imports: [
    RouterModule.forRoot(routes, { preloadingStrategy: PreloadAllModules })
  ],
  exports: [RouterModule]
})
export class AppRoutingModule {}
