import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { lastValueFrom } from 'rxjs';
import { Planet, CrewMember, Crew } from '../../models';
import { environment as env } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class HttpService {
  private defaultHeaders = {
    'Access-Control-Allow-Origin': '*'
  }
  private defaultOptions = {
    headers: {
      ...this.defaultHeaders
    }
  };

  constructor(
    private http: HttpClient
  ) {}

  async login(loginCreds: { email: string, password: string }) {
    try {
      return await lastValueFrom(this.http.post<{ user: CrewMember, token: string }>(`${env.gatewayApiUrl}/crews_gateway/login`, loginCreds, this.defaultOptions));
    } catch(err) {
      console.error(err);
      throw err;
    }
  }

  async crews() {
    try {
      return await lastValueFrom(this.http.get<Crew[]>(`${env.gatewayApiUrl}/crews_gateway/crews`));
    } catch(err) {
      throw err;
    }
  }

  async createCrew(crew: Crew) {
    try {
      return await lastValueFrom(this.http.post(`${env.gatewayApiUrl}/crews_gateway/crews`, crew));
    } catch(err) {
      throw err;
    }
  }

  async updateCrew(crew: Crew) {
    try {
      return await lastValueFrom(this.http.put(`${env.gatewayApiUrl}/crews_gateway/crews/${crew.id}`, crew));
    } catch(err) {
      throw err;
    }
  }

  async crewMembers() {
    try {
      return await lastValueFrom(this.http.get<CrewMember[]>(`${env.gatewayApiUrl}/crews_gateway/crew_members`));
    } catch(err) {
      throw err;
    }
  }

  async planets() {
    try {
      return await lastValueFrom(this.http.get<Planet[]>(`${env.gatewayApiUrl}/planets_gateway/planets`));
    } catch(err) {
      console.error(err);
      throw err;
    }
  }

  async createPlanet(planet: Planet) {
    try {
      return await lastValueFrom(this.http.post<{ message: string }>(`${env.gatewayApiUrl}/planets_gateway/planets`, planet));
    } catch(err) {
      console.error(err);
      throw err;
    }
  }


  async updatePlanet(planet: Planet) {
    try {
      return await lastValueFrom(this.http.put<{ message: string }>(`${env.gatewayApiUrl}/planets_gateway/planets/${planet.id}`, planet));
    } catch(err) {
      console.error(err);
      throw err;
    }
  }

  async deletePlanet(planet: Planet) {
    try {
      return await lastValueFrom(this.http.delete<{ message: string }>(`${env.gatewayApiUrl}/planets_gateway/planets/${planet.id}`));
    } catch(err) {
      console.error(err);
      throw err;
    }
  }
}
