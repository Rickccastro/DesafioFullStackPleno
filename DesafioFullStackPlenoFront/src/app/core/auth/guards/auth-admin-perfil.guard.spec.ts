import { TestBed } from '@angular/core/testing';
import { CanActivateFn } from '@angular/router';

import { AuthAdminPerfilGuard } from '../guards/auth-admin-perfil.guard';

describe('authAdminPerfilGuard', () => {
  const executeGuard: CanActivateFn = (...guardParameters) => 
      TestBed.runInInjectionContext(() => AuthAdminPerfilGuard(...guardParameters));

  beforeEach(() => {
    TestBed.configureTestingModule({});
  });

  it('should be created', () => {
    expect(executeGuard).toBeTruthy();
  });
});
