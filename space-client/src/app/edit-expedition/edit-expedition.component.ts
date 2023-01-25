import { Component, OnInit } from '@angular/core';
import { NbDialogRef, NbToastrService } from '@nebular/theme';
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
    private dialogRef: NbDialogRef<EditExpeditionComponent>,
    private toastr: NbToastrService
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
    try {
      // In production this would be the real crew of the active user
      let crew: Crew = new Crew((await this.http.crews())[0]);
      
      await this.http.createExpedition(new Expedition({
        crew: crew,
        crewId: crew.id,
        planet: this.planet,
        planetId: this.planet.id,
        status: this.status,
        expeditionDate: new Date
      }));

      this.toastr.success("Successful Operation", "Created Expedition");
    } catch(err) {
      this.toastr.danger((err as any).error, "Failed to Create Expedition")
    } finally {
      this.dialogRef.close();
    }
  }


}
