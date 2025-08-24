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
  ngOnInit(): void {
    throw new Error('Method not implemented.');
  }
  
}