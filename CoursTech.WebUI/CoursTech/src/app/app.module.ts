import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { CoursesModule } from './Modules/CoursesModule/courses.module';
import { SharedModule } from './Modules/SharedModule/shared.module';
import { AuthModule } from './Modules/AuthModule/auth.module';

import { AppComponent } from './app.component';
import { HomeComponent } from './components/home/home.component';
import { NavbarComponent } from './components/navbar/navbar.component';
import { FooterComponent } from './components/footer/footer.component';
import { AccessDeniedComponent } from './components/access-denied/access-denied.component';


@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    AccessDeniedComponent,
    NavbarComponent,
    FooterComponent,
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    CoursesModule,
    AuthModule,
    SharedModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
