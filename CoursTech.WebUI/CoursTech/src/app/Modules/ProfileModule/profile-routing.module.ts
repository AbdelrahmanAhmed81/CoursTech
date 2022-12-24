import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { AuthGuard } from "../AuthModule/guards/auth.guard";

import { EnrollmentsComponent } from "./components/enrollments/enrollments.component";
import { ProfileComponent } from "./components/profile/profile.component";
import { UserDataComponent } from "./components/user-data/user-data.component";

const routes: Routes = [
    {
        path: '', component: ProfileComponent, canActivate: [AuthGuard], children: [
            { path: '', redirectTo: 'UserData', pathMatch: 'full' },
            { path: 'UserData', component: UserDataComponent },
            { path: 'Enrollments', component: EnrollmentsComponent },
        ]
    },

]
@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class ProfileRoutingModule { }