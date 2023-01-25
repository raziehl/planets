import { Component, OnInit } from '@angular/core';
import { NbDialogRef } from '@nebular/theme';
import { Crew, Expedition, Planet, PlanetStatus } from 'src/models';
import { HttpService } from '../core/http.service';

@Component({
  selector: 'app-edit-expedition',
  templateUrl: './edit-expedition.component.html',
  styleUrls: ['./edit-expedition.component.scss']
})
export class EditExpeditionComponent implements OnInit {
  planet: Planet = new Planet({} as Planet);
  status: PlanetStatus = PlanetStatus.TODO;

  constructor(
    private http: HttpService,
    private dialogRef: NbDialogRef<EditExpeditionComponent>
  ) {}

  ngOnInit() {
    console.log(this.planet); 
  }

  get planetStatusOptions() {
    let arr: { value: string, label: string }[] = [];
    // Object.keys(PlanetStatus).forEach(e => arr.push({ value: e, label: e }));
    Object.values(PlanetStatus).forEach(e => arr.push({ value: e, label: e }));
    return arr;
  }

  async uploadExpedition() {
    // In production this would be the real crew of the active user
    let crew: Crew = new Crew((await this.http.crews())[0]);
    
    console.log(this.status)

    await this.http.createExpedition(new Expedition({
      crew: crew,
      crewId: crew.id,
      planet: this.planet,
      planetId: this.planet.id,
      status: this.status,
      expeditionDate: new Date
    }));
  }


}
