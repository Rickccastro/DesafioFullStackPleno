import { HttpInterceptorFn } from '@angular/common/http';
import { AuthTokenService } from '../services/authtoken.service';
import { inject } from '@angular/core';

export const authInterceptor: HttpInterceptorFn = (req, next) => {
const authTokenService = inject(AuthTokenService); 

 if (req.url.endsWith('/Login')) {
    return next(req);
  }
  
  const token = authTokenService.getToken();

  if (token) {
    const cloned = req.clone({
      setHeaders: {
        Authorization: `Bearer ${token}`
      }
    });
    return next(cloned);
  }

  return next(req);
};
