import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { lastValueFrom } from 'rxjs';
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
  ) {
    this.http
    // this.planets().then(console.log);
  }

  async login(loginCreds: { email: string, password: string }) {
    try {
      return await lastValueFrom(this.http.post<{ token: string }>(`${env.gatewayApiUrl}/crews_gateway/login`, loginCreds, this.defaultOptions));
    } catch(err) {
      console.error(err);
      return;
    }
  }

  async planets() {
    try {
      return await lastValueFrom(this.http.get(`${env.gatewayApiUrl}/planets_gateway/planets`));
    } catch(err) {
      console.error(err);
      return;
    }
  }
}
