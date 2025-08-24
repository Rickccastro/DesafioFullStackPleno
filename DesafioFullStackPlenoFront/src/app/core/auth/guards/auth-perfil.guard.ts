import { inject } from '@angular/core';
import { CanActivateFn } from '@angular/router';
import { AuthTokenService } from '../services/authtoken.service';
import { Router } from '@angular/router';

export const AuthPerfilGuard: CanActivateFn = (route, state) => {
  const authTokenService = inject(AuthTokenService);
  const token = authTokenService.getToken();
  const role = authTokenService.getUserRole();
  const router = inject(Router);

  if(token != '' || role === 'Administrador' || role === 'Usuario'){
    return true 
  }else{
    router.navigate(['/'])
    return false 
  }
};
