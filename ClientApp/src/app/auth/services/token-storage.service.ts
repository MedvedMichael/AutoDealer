import { Injectable } from '@angular/core';

const TOKEN_KEY = 'TOKEN';

@Injectable({
  providedIn: 'root',
})
export class TokenStorageService {
  private token: string | null = null;

  constructor() {
    this.getTokenFromStorage();
  }

  public getAccessToken() {
    return this.token;
  }

  public setAccessToken(token: string) {
    localStorage.setItem(TOKEN_KEY, token);
    this.token = token;
  }

  private getTokenFromStorage() {
    this.token = localStorage.getItem(TOKEN_KEY) ?? null;
  }

  removeToken() {
    localStorage.removeItem(TOKEN_KEY);
    this.token = null;
  }
}
