
export enum PlanetStatus {
  OK = "OK",
  BangOK = "!OK",
  TODO = "TODO",
  EnRoute = "En Route",
}

export class Planet {
  id: number;
  name: string;
  description: string;
  image: string;
  status: PlanetStatus;

  constructor(planet: Planet) {
    this.id = planet.id;
    this.name = planet.name;
    this.description = planet.description;
    this.image = planet.description;
    this.status = planet.status;
  }

  get Status() {
    return this.status;
  }
}