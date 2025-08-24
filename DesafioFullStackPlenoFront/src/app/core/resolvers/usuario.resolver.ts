import { ResolveFn } from '@angular/router';
import { UsuarioService } from '../../shared/services/usuario.service';
import { inject } from '@angular/core';
import { Usuario } from '../models/Usuario';
import { Observable } from 'rxjs';

export const usuarioResolver: ResolveFn<Observable<Usuario[]>> = (route, state) => {
  const service = inject(UsuarioService);
  return service.getUsuarios();
};
