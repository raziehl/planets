import { Component, OnInit } from '@angular/core';
import { NbToastrService } from '@nebular/theme';
import { Planet } from 'src/models/planet.model';
import { HttpService } from '../core/http.service';

@Component({
  selector: 'app-planets',
  templateUrl: './planets.component.html',
  styleUrls: ['./planets.component.scss']
})
export class PlanetsComponent implements OnInit{

  planets: Planet[] = [];

  constructor(
    private http: HttpService,
    private toastr: NbToastrService
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

  }

  editPlanet(planet: Planet) {
    console.log('EDIT');
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
