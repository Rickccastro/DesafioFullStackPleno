import { ResolveFn } from '@angular/router';
import { TarefasService } from '../../shared/services/tarefas.service';
import { inject } from '@angular/core';
import { Observable } from 'rxjs';
import { Usuario } from '../models/Usuario';
import { Tarefas } from '../models/Tarefas';

export const tarefasResolver: ResolveFn<Observable<Tarefas[]>> = (route, state) => {
  const service = inject(TarefasService);
  return service.getTarefas();
};