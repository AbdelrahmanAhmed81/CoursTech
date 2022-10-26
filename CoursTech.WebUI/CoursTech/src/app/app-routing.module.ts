import { NgModule } from '@angular/core';
import { PreloadAllModules, RouterModule, Routes } from '@angular/router';

import { HomeComponent } from './components/home/home.component';
import { AccessDeniedComponent } from './components/access-denied/access-denied.component';

const routes: Routes = [
  { path: '', redirectTo: 'Home', pathMatch: "full" },
  { path: 'Home', component: HomeComponent },
  {
    path: 'Adminstration',
    loadChildren: () => import('./Modules/AdminstrationModule/adminstration.module')
      .then(m => m.AdminstrationModule)
  },
  { path: 'AccessDenied', component: AccessDeniedComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes, { scrollPositionRestoration: 'enabled', preloadingStrategy: PreloadAllModules })],
  exports: [RouterModule]
})
export class AppRoutingModule { }
