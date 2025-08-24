import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';
import { AuthTokenService } from '../services/authtoken.service';

export const AuthAdminPerfilGuard: CanActivateFn = (route, state) => {
  const authTokenService = inject(AuthTokenService);
  const role = authTokenService.getUserRole();
  const router = inject(Router);

  if(role === 'Administrador'){
    return true 
  }else{
    router.navigate(['/'])
    return false 
  }
};
