import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './components/views/home/home.component';
import { CourseDetailsComponent } from './components/views/course-details/course-details.component';
import { AdminstrationComponent } from './components/views/adminstration/adminstration.component';
import { AdmCoursesComponent } from './components/views/adminstration-components/adm-courses/adm-courses.component';
import { AdmIndustriesComponent } from './components/views/adminstration-components/adm-industries/adm-industries.component';
import { AdmInstructorsComponent } from './components/views/adminstration-components/adm-instructors/adm-instructors.component';
import { RegisterComponent } from './components/views/auth/register/register.component';
import { LoginComponent } from './components/views/auth/login/login.component';

const routes: Routes = [
  { path: '', redirectTo: 'Home', pathMatch: "full" },
  { path: 'Home', component: HomeComponent },
  { path: 'Course/:id', component: CourseDetailsComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'login', component: LoginComponent },
  {
    path: 'Adminstration', component: AdminstrationComponent, children: [
      { path: '', redirectTo: 'Courses', pathMatch: 'full' },
      { path: 'Courses', component: AdmCoursesComponent },
      { path: 'Industries', component: AdmIndustriesComponent },
      { path: 'Instructors', component: AdmInstructorsComponent }
    ]
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes, { scrollPositionRestoration: 'enabled' })],
  exports: [RouterModule]
})
export class AppRoutingModule { }
