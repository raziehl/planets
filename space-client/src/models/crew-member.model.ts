
export enum Rank {
  Captain,
  Lieutenant,
  Ensign,
  Cadet
}

export enum Species {
  Human,
  Robot
}

export enum Role {
  Comand,
  Engineering,
  Medical,
  Analysis
}

export class CrewMember {
  id: number;
  email: string;
  name: string;
  rank: Rank;
  species: Species;
  role: Role;

  constructor(member: CrewMember) {
    this.id = member.id;
    this.email = member.email;
    this.name = member.name;
    this.rank = member.rank;
    this.species = member.species;
    this.role = member.role;
  }

  get Rank() {
    return Object.keys(Rank).filter((v) => isNaN(Number(v)))[this.rank];
  }

  get Species() {
    return Object.keys(Species).filter((v) => isNaN(Number(v)))[this.species];
  }

  get Role() {
    return Object.keys(Role).filter((v) => isNaN(Number(v)))[this.role];
  }

}
