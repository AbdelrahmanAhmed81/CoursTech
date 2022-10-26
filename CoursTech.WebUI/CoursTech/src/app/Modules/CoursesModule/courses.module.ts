import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';
import { CoursesRoutingModule } from './courses-routing.module';

import { CoursesComponent } from './components/courses/courses.component';
import { CourseDetailsComponent } from './components/course-details/course-details.component';
import { ReadmoreDirective } from './directives/readmore.directive';


@NgModule({
  declarations: [
    CoursesComponent,
    CourseDetailsComponent,
    ReadmoreDirective
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    CoursesRoutingModule,
  ],
  exports: [
    CoursesComponent,
  ]
})
export class CoursesModule { }
