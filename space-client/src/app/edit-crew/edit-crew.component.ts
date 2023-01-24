import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { NbDialogRef, NbToastrService } from '@nebular/theme';
import { Crew } from 'src/models';
import { AuthService } from '../core/auth.service';
import { HttpService } from '../core/http.service';

@Component({
  selector: 'app-edit-crew',
  templateUrl: './edit-crew.component.html',
  styleUrls: ['./edit-crew.component.scss']
})
export class EditCrewComponent {
  crew?: Crew;
  crewForm: FormGroup;
  creationMode: boolean = false;

  constructor(
    private http: HttpService,
    private dialogRef: NbDialogRef<EditCrewComponent>,
    private toastr: NbToastrService,
    private auth: AuthService
  ) {
    this.crewForm = new FormGroup({
      crewName: new FormControl('', [
        Validators.required
      ])
    });
  }

  ngOnInit() {
    if(!this.crew) {
      this.creationMode = true;
      this.crew = new Crew({} as Crew);
    } else {
      this.crewName?.setValue(this.crew.crewName);
    }
  }

  get crewName() {
    return this.crewForm.get('crewName');
  }

  async onSubmit() {
    if(this.crewForm.valid) {
      try {
        (this.crew as Crew).crewName = this.crewName?.value;

        if(this.creationMode) {
          this.http.createCrew(this.crew as Crew);
        } else {
          this.http.updateCrew(this.crew as Crew);
        }

        this.toastr.success("Operation Successful", this.creationMode ? 'Crew Creation' : 'Crew Update');
      } catch(err: any) {
        this.toastr.danger(err.error, this.creationMode ? 'Crew Creation Failed' : 'Crew Update Failed');
      } finally {
        this.dialogRef.close();
      }
    }
  }

}
