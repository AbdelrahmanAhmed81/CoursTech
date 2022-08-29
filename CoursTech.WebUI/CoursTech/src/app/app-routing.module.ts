import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './components/views/home/home.component';
import { CourseDetailsComponent } from './components/views/course-details/course-details.component';

const routes: Routes = [
  { path: '', redirectTo: 'Home', pathMatch: "full" },
  { path: 'Home', component: HomeComponent },
  { path: 'Course/:id', component: CourseDetailsComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes, { scrollPositionRestoration: 'enabled' })],
  exports: [RouterModule]
})
export class AppRoutingModule { }
