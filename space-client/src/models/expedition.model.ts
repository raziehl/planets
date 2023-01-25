import { CrewMember } from "./crew-member.model";
import { Crew } from "./crew.model";
import { Planet, PlanetStatus } from "./planet.model";

export class Expedition {
  id: number;
  crewId: number;
  crew: Crew;
  planetId: number;
  planet: Planet;
  status: PlanetStatus;

  constructor(expedition: Expedition) {
    this.id = expedition.id;
    this.crewId = expedition.crewId;
    this.crew = expedition.crew;
    this.planetId = expedition.planetId;
    this.planet = expedition.planet;
    this.status = expedition.status;
  }
}