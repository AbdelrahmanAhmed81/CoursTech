import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { AdminAuthGuard } from '../AuthModule/guards/admin-auth.guard';
import { AuthGuard } from '../AuthModule/guards/auth.guard';
import { AdmCoursesComponent } from './components/adm-courses/adm-courses.component';
import { AdmIndustriesComponent } from './components/adm-industries/adm-industries.component';
import { AdmInstructorsComponent } from './components/adm-instructors/adm-instructors.component';
import { AdminstrationComponent } from './components/adminstration/adminstration.component';

const routes: Routes = [
  {
    path: '', component: AdminstrationComponent, canActivate: [AuthGuard/*, AdminAuthGuard*/], children: [
      { path: '', redirectTo: 'Courses', pathMatch: 'full' },
      { path: 'Courses', component: AdmCoursesComponent },
      { path: 'Industries', component: AdmIndustriesComponent },
      { path: 'Instructors', component: AdmInstructorsComponent }
    ]
  },
]

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forChild(routes)
  ],
  exports: [
    RouterModule
  ]
})
export class AdminstrationRoutingModule { }
