import { Injectable } from '@angular/core';
import { CrewMember } from 'src/models';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  user?: string;
  token?: string;

  constructor() {
    this.token = localStorage.getItem('JWT_TOKEN') || undefined;
  }

  login(creds: { user: CrewMember, token: string }) {
    this.token = creds.token;
    localStorage.setItem('JWT_TOKEN', creds.token);
    this.user = creds.token;
  }

  isLoggedIn() {
    return this.token ? true : false;
  }
}
