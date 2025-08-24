import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable, tap } from 'rxjs';
import { Login } from '../../core/models/Requests/Login';
import { LoginResponse } from '../../core/models/Responses/LoginResponse';

@Injectable({
  providedIn: 'root'
})
export class LoginService {
  httpClient = inject(HttpClient);

  loginUser(credentials: Login): Observable<LoginResponse> {
    return this.httpClient.post<LoginResponse>('/api/Login', credentials);
  }
}
