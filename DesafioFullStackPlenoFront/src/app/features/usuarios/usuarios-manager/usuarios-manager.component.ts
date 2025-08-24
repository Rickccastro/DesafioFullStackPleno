import { Component, inject, OnInit, signal } from '@angular/core';
import { FormGroup, FormControl, Validators, ReactiveFormsModule } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { Tarefas } from '../../../core/models/Tarefas';
import { Usuario } from '../../../core/models/Usuario';
import { TarefasService } from '../../../shared/services/tarefas.service';
import { UsuarioService } from '../../../shared/services/usuario.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-usuarios-manager',
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './usuarios-manager.component.html',
  styleUrl: './usuarios-manager.component.scss'
})
export class UsuariosManagerComponent implements OnInit {
  usuarioService = inject(UsuarioService);
  form!: FormGroup;
  editingUsuario: Usuario | null = null;
  perfilOptions: string[] = [];
  listUsuarios = signal<Usuario[]>([]);
  private route = inject(ActivatedRoute);

  ngOnInit() {
    this.form = new FormGroup({
      nome: new FormControl('', [Validators.required]),
      email: new FormControl(''),
      perfil: new FormControl('', [Validators.required]),
      senha: new FormControl('', [Validators.required]),
    });

    this.route.data.subscribe((data) => {
      this.listUsuarios.set(data['usuarios']);
    });

    this.perfilOptions = ['Usuario', 'Administrador'];
  }

submit() {
  if (this.form.invalid) return;

  if (this.editingUsuario) {
    const usuarioAtualizado = {
      ...this.editingUsuario,
      ...this.form.value,
    };

    this.usuarioService.atualizar(usuarioAtualizado).subscribe(() => {
      this.listUsuarios.update((usuarios) =>
        usuarios.map((u) =>
          u.id === usuarioAtualizado.id ? usuarioAtualizado : u
        )
      );
      this.editingUsuario = null;
    });

  } else {
    this.usuarioService.adicionar(this.form.value).subscribe((novoUsuario) => {
      this.listUsuarios.update((usuarios) => [...usuarios, novoUsuario]);
    });
  }
    this.form.reset();
}
  edit(usuario: Usuario) {
    this.editingUsuario = usuario;

    this.form.patchValue({
      nome: usuario.nome,
      email: usuario.email,
      perfil: usuario.perfil,
      senha: usuario.senha,
    });
  }

  cancelEdit() {
    this.editingUsuario = null;
    this.form.reset();
  }  
}