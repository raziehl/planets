import { Component, OnInit } from '@angular/core';
import { NbDialogService, NbToastrService } from '@nebular/theme';
import { Planet, PlanetStatus } from 'src/models/planet.model';
import { BreakpointService } from '../core/breakpoint.service';
import { HttpService } from '../core/http.service';
import { EditExpeditionComponent } from '../edit-expedition/edit-expedition.component';
import { EditPlanetComponent } from '../edit-planet/edit-planet.component';

@Component({
  selector: 'app-planets',
  templateUrl: './planets.component.html',
  styleUrls: ['./planets.component.scss']
})
export class PlanetsComponent implements OnInit{

  planets: Planet[] = [];

  constructor(
    public http: HttpService,
    private toastr: NbToastrService,
    private dialog: NbDialogService,
    public breakpoint: BreakpointService
  ) {}

  async ngOnInit() {
    await this.getPlanets();
  }

  async getPlanets() {
    try {
      this.planets = await this.http.planets();

      this.planets.map(async e => {
        try {
          e.status = (await this.http.planetStatus(e)).status;
        } catch(err) {
          e.status = PlanetStatus.TODO;
        }
      })
    } catch(err) {
      this.toastr.danger(err);
    }
  }

  addExpeditionToPlanet(planet: Planet) {
    this.dialog.open(EditExpeditionComponent, {
      autoFocus: false,
      context: {
        planet: planet
      }
    });
  }

  createPlanet() {
    this.dialog.open(EditPlanetComponent, {
      autoFocus: false
    });
  }

  editPlanet(planet: Planet) {
    this.dialog.open(EditPlanetComponent, {
      context: {
        planet: planet
      }
    });
  }

  async deletePlanet(planet: Planet) {
    try {
      this.toastr.info((await this.http.deletePlanet(planet)).message, "Delete Successful");
      await this.getPlanets();
    } catch(err) {
      this.toastr.danger("Not Working");
    }
  }

}
