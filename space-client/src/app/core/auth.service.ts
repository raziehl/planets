import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  token?: string;

  constructor() {
    this.token = localStorage.getItem('JWT_TOKEN') || undefined;
  }

  registerJwtToken(token: string) {
    this.token = token;
    localStorage.setItem('JWT_TOKEN', token);
  }

  isLoggedIn() {
    return this.token ? true : false;
  }
}
