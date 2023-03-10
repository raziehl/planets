import { Injectable } from '@angular/core';
import { CrewMember } from 'src/models';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  user?: CrewMember;
  token?: string;

  constructor() {
    this.token = localStorage.getItem('JWT_TOKEN') || undefined;
    try {
      this.user = new CrewMember(JSON.parse(localStorage.getItem('USER_DATA') as string));
    } catch(err) {
      this.logout();
    }
  }

  login(creds: { user: CrewMember, token: string }) {
    this.token = creds.token;
    localStorage.setItem('JWT_TOKEN', creds.token);
    localStorage.setItem('USER_DATA', JSON.stringify(creds.user));
    this.user = creds.user;
  }

  logout() {
    this.user = undefined;
    this.token = undefined;
    localStorage.removeItem("JWT_TOKEN");
    localStorage.removeItem('USER_DATA');
  }

  isLoggedIn() {
    return this.token ? true : false;
  }
}
