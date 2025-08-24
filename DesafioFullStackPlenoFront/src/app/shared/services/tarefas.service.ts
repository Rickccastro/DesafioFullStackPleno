import { inject, Injectable } from '@angular/core';
import { Tarefas } from '../../core/models/Tarefas';
import { Observable } from 'rxjs/internal/Observable';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class TarefasService {
  httpClient = inject(HttpClient);

  getTarefas(): Observable<Tarefas[]> {
    return this.httpClient.get<Tarefas[]>('/api/Tarefas');
  }

  adicionar(task: Omit<Tarefas, 'id'>) 
  {
    return this.httpClient.post<Tarefas>('/api/Tarefas',task);
  }

  atualizar(task: Tarefas)
   {
        return this.httpClient.put<Tarefas>('/api/Tarefas',task);
   }

  deletar(id: string)
   {
        return this.httpClient.delete<Tarefas>(`/api/Tarefas/${id}`);
   }
}
