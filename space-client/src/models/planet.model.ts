export class Planet {
  id: number;
  name: string;
  description: string;
  image: string;
  status: string;

  constructor(planet: Partial<Planet> = {}) {
    this.id = planet.id || -1;
    this.name = planet.name || "";
    this.description = planet.description || "";
    this.image = planet.description || "";
    this.status = planet.status || "";
  }
}