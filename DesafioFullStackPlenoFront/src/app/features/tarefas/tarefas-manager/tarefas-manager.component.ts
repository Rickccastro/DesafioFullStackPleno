import { Component, inject, OnInit, signal, computed } from '@angular/core';
import { FormGroup, FormControl, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { TarefasService } from '../../../shared/services/tarefas.service';
import { UsuarioService } from '../../../shared/services/usuario.service';
import { ActivatedRoute } from '@angular/router';
import { Tarefas } from '../../../core/models/Tarefas';
import { Usuario } from '../../../core/models/Usuario';

@Component({
  selector: 'app-tarefas-manager',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './tarefas-manager.component.html',
  styleUrls: ['./tarefas-manager.component.scss'],
})
export class TarefasManagerComponent implements OnInit {
  tarefaService = inject(TarefasService);
  usuarioService = inject(UsuarioService);
  private route = inject(ActivatedRoute);

  form!: FormGroup;
  editingTask: Tarefas | null = null;

  statusOptions: string[] = ['Pendente', 'EmAndamento', 'Concluida'];
  responsavelOptions = signal<Usuario[]>([]);
  listaTarefas = signal<Tarefas[]>([]);

  currentPage = signal(1);
  pageSize = 6;

  // Trigger para atualizar o computed quando o form muda
  filterTrigger = signal(0);

  filteredTarefas = computed(() => {
    // Força reavaliação do computed
    this.filterTrigger();

    if (!this.form) return this.listaTarefas();

    const { usuarioNome, ultimasCinco } =
      this.form.value;
    let tarefas = [...this.listaTarefas()];

    if (usuarioNome) {
      tarefas = tarefas.filter((t) =>
        this.responsavelOptions().some(
          (u) => u.id === t.usuarioId && u.nome === usuarioNome
        )
      );
    }
    // Últimas 5 tarefas
    if (ultimasCinco) {
      tarefas = tarefas
        .sort(
          (a, b) =>
            new Date(b.dataCriacao).getTime() -
            new Date(a.dataCriacao).getTime()
        )
        .slice(0, 5);
    }

    return tarefas;
  });

  // Paginação
  paginatedTarefas = computed(() => {
    const tarefas = this.filteredTarefas();
    const start = (this.currentPage() - 1) * this.pageSize;
    return tarefas.slice(start, start + this.pageSize);
  });

  totalPages = computed(() =>
    Math.ceil(this.filteredTarefas().length / this.pageSize)
  );

  ngOnInit() {

    this.form = new FormGroup({
      titulo: new FormControl(''),
      descricao: new FormControl(''),
      status: new FormControl(''),
      usuarioId: new FormControl(''),
      usuarioNome: new FormControl(''),
      ultimasCinco: new FormControl(false),
    });

    this.route.data.subscribe((data) => {
      this.responsavelOptions.set(data['usuarios'] || []);
      this.listaTarefas.set(data['tarefas'] || []);
    });

    // Atualiza trigger sempre que o formulário muda
    this.form.valueChanges.subscribe(() => {
      this.currentPage.set(1);
      this.filterTrigger.update((n) => n + 1);
    });
  }

  submit() {
    if (this.editingTask) {
      const tarefaAtualizada = { ...this.editingTask, ...this.form.value };
      this.tarefaService.atualizar(tarefaAtualizada).subscribe(() => {
        this.listaTarefas.update((tarefas) =>
          tarefas.map((t) =>
            t.id === tarefaAtualizada.id ? tarefaAtualizada : t
          )
        );
        this.editingTask = null;
        this.form.reset();
      });
    } else {
      this.tarefaService.adicionar(this.form.value).subscribe((novaTarefa) => {
        this.listaTarefas.update((tarefas) => [...tarefas, novaTarefa]);
        this.form.reset();
      });
    }
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
    this.tarefaService.deletar(id).subscribe(() => {
      this.listaTarefas.update((tarefas) => tarefas.filter((t) => t.id !== id));
    });
  }

  cancelEdit() {
    this.editingTask = null;
    this.form.reset();
  }

  prevPage() {
    if (this.currentPage() > 1) this.currentPage.update((p) => p - 1);
  }

  nextPage() {
    if (this.currentPage() < this.totalPages())
      this.currentPage.update((p) => p + 1);
  }
}
