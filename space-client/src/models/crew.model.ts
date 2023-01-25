import { CrewMember } from "./crew-member.model";

export class Crew {
  id: number;
  crewName: string;
  shuttleName: string;
  crewMembers: CrewMember[];

  constructor(crew: Crew) {
    this.id = crew.id;
    this.crewName = crew.crewName;
    this.shuttleName = crew.shuttleName;
    this.crewMembers = crew.crewMembers || [];
  }
}