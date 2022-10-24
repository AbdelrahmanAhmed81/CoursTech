import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { JwtModule } from "@auth0/angular-jwt";

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
import { CourseFormComponent } from './components/views/course-form/course-form.component';
import { RegisterComponent } from './components/views/auth/register/register.component';
import { LoginComponent } from './components/views/auth/login/login.component';
import { AccessDeniedComponent } from './components/partial-views/access-denied/access-denied.component';
import { ReadmoreDirective } from './directives/readmore.directive';
// import { InterceptorService } from './services/interceptor.service';

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
    CourseFormComponent,
    RegisterComponent,
    LoginComponent,
    AccessDeniedComponent,
    ReadmoreDirective,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    JwtModule.forRoot({
      config: {
        tokenGetter: () => localStorage.getItem("jwt"),
        allowedDomains: ["localhost:7017"],
        disallowedRoutes: []
      }
    })
  ],
  providers: [/*{ provide: HTTP_INTERCEPTORS, useClass: InterceptorService, multi: true }*/],
  bootstrap: [AppComponent]
})
export class AppModule { }
