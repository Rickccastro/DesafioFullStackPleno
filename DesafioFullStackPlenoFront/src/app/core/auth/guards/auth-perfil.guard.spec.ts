import { TestBed } from '@angular/core/testing';
import { CanActivateFn } from '@angular/router';

import { AuthPerfilGuard } from './auth-perfil.guard';

describe('authPerfilGuard', () => {
  const executeGuard: CanActivateFn = (...guardParameters) => 
      TestBed.runInInjectionContext(() => AuthPerfilGuard(...guardParameters));

  beforeEach(() => {
    TestBed.configureTestingModule({});
  });

  it('should be created', () => {
    expect(executeGuard).toBeTruthy();
  });
});
