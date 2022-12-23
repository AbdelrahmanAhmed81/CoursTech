import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";

import { ProfileRoutingModule } from "./profile-routing.module";
import { ProfileComponent } from './components/profile/profile.component';
import { UserDataComponent } from './components/user-data/user-data.component';
import { EnrollmentsComponent } from './components/enrollments/enrollments.component';

@NgModule({
  declarations: [
    ProfileComponent,
    UserDataComponent,
    EnrollmentsComponent
  ],
  imports: [
    CommonModule,
    ProfileRoutingModule
  ],
  exports: []
})
export class ProfileModule { }