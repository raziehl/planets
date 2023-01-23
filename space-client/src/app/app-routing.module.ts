import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { CrewsComponent } from './crews/crews.component';
import { LoginComponent } from './login/login.component';
import { PlanetsComponent } from './planets/planets.component';

const routes: Routes = [
  { path: '', redirectTo: 'planets', pathMatch: 'full' },
  { path: 'login', component: LoginComponent },
  { path: 'crews', component: CrewsComponent },
  { path: 'planets', component: PlanetsComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
