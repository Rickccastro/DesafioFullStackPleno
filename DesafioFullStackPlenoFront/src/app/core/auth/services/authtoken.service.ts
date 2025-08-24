import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AuthTokenService {
private readonly TOKEN_KEY = 'auth_token'; 

  setToken(token: string): void {
    localStorage.setItem(this.TOKEN_KEY, token);
  }

  getToken(): string | null {
    return localStorage.getItem(this.TOKEN_KEY);
  }

  removeToken(): void {
    localStorage.removeItem(this.TOKEN_KEY);
  }

  isLoggedIn(): boolean {
    return !!this.getToken();
  }
}
