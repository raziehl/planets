import { Component, OnInit } from '@angular/core';
import { NbDialogService } from '@nebular/theme';
import { Crew, CrewMember } from 'src/models';
import { HttpService } from '../core/http.service';
import { EditCrewComponent } from '../edit-crew/edit-crew.component';

@Component({
  selector: 'app-crews',
  templateUrl: './crews.component.html',
  styleUrls: ['./crews.component.scss']
})
export class CrewsComponent implements OnInit {
  crews: Crew[] = [];

  constructor(
    private http: HttpService,
    private dialog: NbDialogService
  ) {}

  async ngOnInit() {
    this.crews = await this.http.crews();
  }

  createCrew() {
    this.dialog.open(EditCrewComponent, {
      autoFocus: false
    });
  }

}
