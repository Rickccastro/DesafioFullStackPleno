import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { jwtDecode } from 'jwt-decode';
import { Observable } from 'rxjs';
import { LoginResponse } from '../../models/Responses/LoginResponse';

@Injectable({
  providedIn: 'root',
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
  getUserRole(): string {
    const token = this.getToken();
    if (!token) {
      return '';
    }

    const decoded: any = jwtDecode(token);
    return decoded.role || null;
  }
}
