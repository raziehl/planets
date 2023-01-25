import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { NbDialogRef, NbToastrService } from '@nebular/theme';
import { Crew, CrewMember } from 'src/models';
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

  candidateMembers: CrewMember[] = [];

  constructor(
    private http: HttpService,
    private dialogRef: NbDialogRef<EditCrewComponent>,
    private toastr: NbToastrService,
    private auth: AuthService
  ) {
    this.crewForm = new FormGroup({
      crewName: new FormControl('', [
        Validators.required
      ]),
      shuttleName: new FormControl('', [
        
      ])
    });
  }

  async ngOnInit() {
    if(!this.crew) {
      this.creationMode = true;
      this.crew = new Crew({} as Crew);
    } else {
      this.crewName?.setValue(this.crew.crewName);
      this.shuttleName?.setValue(this.crew.shuttleName);
    }

    (await this.http.crewMembers()).forEach(e => {
      this.candidateMembers.push(new CrewMember(e));
    });
  }

  get crewName() {
    return this.crewForm.get('crewName');
  }

  get shuttleName() {
    return this.crewForm.get('shuttleName');
  }

  async onSubmit() {
    if(this.crewForm.valid) {
      try {
        (this.crew as Crew).crewName = this.crewName?.value;
        (this.crew as Crew).shuttleName = this.shuttleName?.value;

        if(this.creationMode) {
          this.http.createCrew(this.crew as Crew);
        } else {
          this.http.updateCrew(this.crew as Crew);
        }

        this.toastr.success("Operation Successful", this.creationMode ? 'Crew Creation' : 'Crew Update');
        this.dialogRef.close();
      } catch(err: any) {
        this.toastr.danger(err.error, this.creationMode ? 'Crew Creation Failed' : 'Crew Update Failed');
      } finally {
        this.dialogRef.close();
      }
    }
  }

  addCrewMember(member: CrewMember) {
    this.candidateMembers = this.candidateMembers.filter(e => e != member);
    this.crew?.crewMembers.push(member);
  }

  removeCrewMember(member: CrewMember) {
    this.candidateMembers.push(member);
    (this.crew as Crew).crewMembers = this.crew?.crewMembers.filter(e => e != member) as CrewMember[];
  }
}
