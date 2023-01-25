import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NbThemeModule, NbLayoutModule, NbInputModule, NbCardModule, NbButtonModule, NbIconModule, NbFormFieldModule, NbActionsModule, NbTabsetModule, NbMenuModule, NbRouteTabsetModule, NbButtonGroupModule, NbUserModule, NbToastrModule, NbGlobalPhysicalPosition, NbAccordionModule, NbDialogModule, NbRadioModule, NbSelectModule, NbContextMenuModule } from '@nebular/theme';
import { NbEvaIconsModule } from '@nebular/eva-icons';
import { LoginComponent } from './login/login.component';
import { CrewsComponent } from './crews/crews.component';
import { PlanetsComponent } from './planets/planets.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { EditPlanetComponent } from './edit-planet/edit-planet.component';
import { EditCrewComponent } from './edit-crew/edit-crew.component';
import { CrewMembersComponent } from './crew-members/crew-members.component';
import { ProfileComponent } from './profile/profile.component';
import { EditExpeditionComponent } from './edit-expedition/edit-expedition.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    CrewsComponent,
    PlanetsComponent,
    EditPlanetComponent,
    EditCrewComponent,
    CrewMembersComponent,
    ProfileComponent,
    EditExpeditionComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    HttpClientModule,
    NbThemeModule.forRoot({ name: 'default' }),
    NbLayoutModule,
    NbEvaIconsModule,
    NbInputModule,
    NbCardModule,
    NbButtonModule,
    NbIconModule,
    NbFormFieldModule,
    NbActionsModule,
    NbButtonGroupModule,
    NbUserModule,
    NbAccordionModule,
    NbSelectModule,
    NbContextMenuModule,
    NbMenuModule.forRoot(),
    NbToastrModule.forRoot({
      position: NbGlobalPhysicalPosition.BOTTOM_RIGHT
    }),
    NbDialogModule.forRoot()
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
