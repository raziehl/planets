import { Component, OnInit } from '@angular/core';
import { NbDialogService, NbToastrService } from '@nebular/theme';
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
    private dialog: NbDialogService,
    private toastr: NbToastrService
  ) {}

  async ngOnInit() {
    this.loadCrews();
  }

  async loadCrews() {
    this.crews = await this.http.crews();
  }

  createCrew() {
    this.dialog.open(EditCrewComponent, {
      autoFocus: false
    }).onClose.subscribe(() => this.loadCrews()).unsubscribe();
  }

  async editCrew(crew: Crew) {
    this.dialog.open(EditCrewComponent, {
      autoFocus: false,
      context: {
        crew: crew
      }
    }).onClose.subscribe(() => this.loadCrews()).unsubscribe();
  }

  async deleteCrew(crew: Crew) {
    try {
      await this.http.deleteCrew(crew);
      await this.loadCrews();
      this.toastr.success("Operation Successful", "Crew Deletion");
    } catch(err) {
      this.toastr.danger((err as any).error, "Failed to Delete Crew");
    }
  }
}
