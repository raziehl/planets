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
    try {
      this.planets = await this.http.planets();
      // this.toastr.info("asd");
    } catch(err) {
      this.toastr.danger(err);
    }
  }

}
