import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './components/views/home/home.component';
import { NavbarComponent } from './components/partial-views/navbar/navbar.component';
import { FooterComponent } from './components/partial-views/footer/footer.component';
import { CoursesComponent } from './components/views/courses/courses.component';
import { PagesNavigatorComponent } from './components/partial-views/pages-navigator/pages-navigator.component';
import { CourseDetailsComponent } from './components/views/course-details/course-details.component';
import { AdminstrationComponent } from './components/views/adminstration/adminstration.component';
import { AdmCoursesComponent } from './components/views/adminstration-components/adm-courses/adm-courses.component';
import { AdmIndustriesComponent } from './components/views/adminstration-components/adm-industries/adm-industries.component';
import { AdmInstructorsComponent } from './components/views/adminstration-components/adm-instructors/adm-instructors.component';
import { AlertComponent } from './components/partial-views/alert/alert.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    NavbarComponent,
    FooterComponent,
    CoursesComponent,
    PagesNavigatorComponent,
    CourseDetailsComponent,
    AdminstrationComponent,
    AdmCoursesComponent,
    AdmIndustriesComponent,
    AdmInstructorsComponent,
    AlertComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
