import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';

import { AdminstrationComponent } from './components/adminstration/adminstration.component';
import { AdmCoursesComponent } from './components/adm-courses/adm-courses.component';
import { AdmIndustriesComponent } from './components/adm-industries/adm-industries.component';
import { AdmInstructorsComponent } from './components/adm-instructors/adm-instructors.component';
import { CourseFormComponent } from './components/course-form/course-form.component';
import { AdminstrationRoutingModule } from './adminstration-routing.module';
import { AlertComponent } from './components/alert/alert.component';
import { SharedModule } from '../SharedModule/shared.module';



@NgModule({
  declarations: [
    AdminstrationComponent,
    AdmCoursesComponent,
    AdmIndustriesComponent,
    AdmInstructorsComponent,
    CourseFormComponent,
    AlertComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    AdminstrationRoutingModule,
    SharedModule,
  ]
})
export class AdminstrationModule { }
