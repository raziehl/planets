export class CrewMember {
  id: number;
  name: string;
  rank: number;
  species: number;
  role: number;

  constructor(member: Partial<CrewMember> = {}) {
    this.id = member.id || 0;
    this.name = member.name || '';
    this.rank = member.rank || 0;
    this.species = member.species || 0;
    this.role = member.role || 0;
  }

}