import { Component, inject, OnInit, signal } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Tarefas } from '../../../core/models/Tarefas';
import { TarefasService } from '../../../shared/services/tarefas.service';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { UsuarioService } from '../../../shared/services/usuario.service';
import { Observable } from 'rxjs/internal/Observable';
import { toSignal } from '@angular/core/rxjs-interop';
import { Usuario } from '../../../core/models/Usuario';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-tarefas-manager',
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './tarefas-manager.component.html',
  styleUrl: './tarefas-manager.component.scss',
})
export class TarefasManagerComponent implements OnInit {
  tarefasService = inject(TarefasService);
  usuarioService = inject(UsuarioService);
  form!: FormGroup;
  editingTask: Tarefas | null = null;
  statusOptions: string[] = [];
  responsavelOptions = signal<Usuario[]>([]);
  listaTarefas = signal<Tarefas[]>([]);
  private route = inject(ActivatedRoute);

  ngOnInit() {
    this.form = new FormGroup({
      titulo: new FormControl('', [Validators.required]),
      descricao: new FormControl(''),
      status: new FormControl('', [Validators.required]),
      usuarioId: new FormControl('', [Validators.required]),
    });

    this.route.data.subscribe((data) => {
      this.responsavelOptions.set(data['usuarios']);
    });

    this.route.data.subscribe((data) => {
      this.listaTarefas.set(data['tarefas']);
    });

    this.statusOptions = ['Pendente', 'EmAndamento', 'Concluida'];
  }

submit() {
  if (this.form.invalid) return;

  if (this.editingTask) {
    const tarefaAtualizada = {
      ...this.editingTask,
      ...this.form.value,
    };

    this.tarefasService.atualizar(tarefaAtualizada).subscribe(() => {
      this.listaTarefas.update((tarefas) =>
        tarefas.map((t) =>
          t.id === tarefaAtualizada.id ? tarefaAtualizada : t
        )
      );
      this.editingTask = null;
    });

  } else {
    this.tarefasService.adicionar(this.form.value).subscribe((novaTarefa) => {
      this.listaTarefas.update((tarefas) => [...tarefas, novaTarefa]);
    });
  }
    this.form.reset();
}
  edit(task: Tarefas) {
    this.editingTask = task;

    this.form.patchValue({
      titulo: task.titulo,
      descricao: task.descricao,
      status: task.status,
      usuarioId: task.usuarioId,
    });
  }

 deleteTarefa(id: string) {
  this.tarefasService.deletar(id).subscribe(() => {
    this.listaTarefas.update(tarefas =>
      tarefas.filter(t => t.id !== id)
    );
  });
}

  cancelEdit() {
    this.editingTask = null;
    this.form.reset();
  }
}
