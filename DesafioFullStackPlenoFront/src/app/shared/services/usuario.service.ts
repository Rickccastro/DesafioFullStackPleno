import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Tarefas } from '../../core/models/Tarefas';
import { Usuario } from '../../core/models/Usuario';

@Injectable({
  providedIn: 'root'
})
export class UsuarioService {
  httpClient = inject(HttpClient);

  getUsuarios(): Observable<Usuario[]> {
    return this.httpClient.get<Usuario[]>('/api/Usuario');
  }

  adicionar(task: Omit<Usuario, 'id'>) 
  {
    return this.httpClient.post<Usuario>('/api/Usuario',task);
  }

  atualizar(task: Usuario)
   {
        return this.httpClient.put<Usuario>('/api/Usuario',task);
   }
}
