import { Component, OnInit } from '@angular/core';
import { NbDialogService, NbToastrService } from '@nebular/theme';
import { Planet } from 'src/models/planet.model';
import { BreakpointService } from '../core/breakpoint.service';
import { HttpService } from '../core/http.service';
import { EditPlanetComponent } from '../edit-planet/edit-planet.component';

@Component({
  selector: 'app-planets',
  templateUrl: './planets.component.html',
  styleUrls: ['./planets.component.scss']
})
export class PlanetsComponent implements OnInit{

  planets: Planet[] = [];

  constructor(
    private http: HttpService,
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
    } catch(err) {
      this.toastr.danger(err);
    }
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
