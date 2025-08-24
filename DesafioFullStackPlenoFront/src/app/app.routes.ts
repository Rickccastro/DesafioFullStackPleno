import { Routes } from '@angular/router';
import { UsuariosManagerComponent } from './features/usuarios/usuarios-manager/usuarios-manager.component';
import { LoginUsuariosComponent } from './features/login/login-usuarios/login-usuarios.component';
import { TarefasManagerComponent } from './features/tarefas/tarefas-manager/tarefas-manager.component';
import { usuarioResolver } from './core/resolvers/usuario.resolver';
import { tarefasResolver } from './core/resolvers/tarefas.resolver';

export const routes: Routes = [
 {
  path:'login',
  component: LoginUsuariosComponent,
}, 
 {
  path:'usuarios',
  component: UsuariosManagerComponent,
  resolve:{
    usuarios: usuarioResolver
  }
},
{
  path:'tarefas',
  component: TarefasManagerComponent,
      resolve: {
      usuarios: usuarioResolver,
      tarefas: tarefasResolver
  }
} 
];