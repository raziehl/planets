import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { AuthGuard } from './core/auth.guard';
import { CrewsComponent } from './crews/crews.component';
import { LoginComponent } from './login/login.component';
import { PlanetsComponent } from './planets/planets.component';
import { ProfileComponent } from './profile/profile.component';

const routes: Routes = [
  { path: '', redirectTo: 'planets', pathMatch: 'full' },
  { path: 'login', component: LoginComponent },
  { path: 'crews', component: CrewsComponent, canActivate: [AuthGuard] },
  { path: 'planets', component: PlanetsComponent, canActivate: [AuthGuard] },
  { path: 'profile', component: ProfileComponent, canActivate: [AuthGuard] },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
