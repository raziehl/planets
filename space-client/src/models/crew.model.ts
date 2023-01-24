import { CrewMember } from "./crew-member.model";

export class Crew {
  id: number;
  crewName: string;
  crewMembers: CrewMember[];

  constructor(crew: Crew) {
    this.id = crew.id;
    this.crewName = crew.crewName;
    this.crewMembers = crew.crewMembers;
  }
}