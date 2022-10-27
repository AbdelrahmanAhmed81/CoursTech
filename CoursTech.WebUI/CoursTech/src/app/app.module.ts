import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { JwtModule } from "@auth0/angular-jwt";

import { AppRoutingModule } from './app-routing.module';
import { CoursesModule } from './Modules/CoursesModule/courses.module';
import { SharedModule } from './Modules/SharedModule/shared.module';
import { AuthModule } from './Modules/AuthModule/auth.module';

import { AppComponent } from './app.component';
import { HomeComponent } from './components/home/home.component';
import { NavbarComponent } from './components/navbar/navbar.component';
import { FooterComponent } from './components/footer/footer.component';
import { AccessDeniedComponent } from './components/access-denied/access-denied.component';
import { AuthService } from './Modules/AuthModule/services/auth.service';


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
    JwtModule.forRoot({
      config: {
        // tokenGetter: () => localStorage.getItem("jwt"),
        tokenGetter: () => AuthService.getAccessToken(),
        allowedDomains: ["localhost:7017"],
        disallowedRoutes: []
      }
    }),
    AppRoutingModule,
    CoursesModule,
    AuthModule,
    SharedModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
