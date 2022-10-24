import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { HomeComponent } from './components/home/home.component';
import { AccessDeniedComponent } from './components/access-denied/access-denied.component';

const routes: Routes = [
  { path: '', redirectTo: 'Home', pathMatch: "full" },
  { path: 'Home', component: HomeComponent },
  { path: 'AccessDenied', component: AccessDeniedComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes, { scrollPositionRestoration: 'enabled' })],
  exports: [RouterModule]
})
export class AppRoutingModule { }
