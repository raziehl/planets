import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { CrewMember } from 'src/models';
import { HttpService } from '../core/http.service';

@Component({
  selector: 'app-crew-members',
  templateUrl: './crew-members.component.html',
  styleUrls: ['./crew-members.component.scss']
})
export class CrewMembersComponent implements OnInit {
  crewMembers: CrewMember[] = [];
  @Output() newCrewMemberEvent = new EventEmitter<CrewMember>();
  
  constructor(
    private http: HttpService
  ) {}

  async ngOnInit() {
    (await this.http.crewMembers()).forEach(e => {
      this.crewMembers.push(new CrewMember(e));
    });
  }

  addNewCrewMemberToCrew(value: CrewMember) {
    this.newCrewMemberEvent.emit(value);
  }

}
