import { Routes } from '@angular/router';
import { UsuariosManagerComponent } from './features/usuarios/usuarios-manager/usuarios-manager.component';
import { LoginUsuariosComponent } from './features/login/login-usuarios/login-usuarios.component';
import { TarefasManagerComponent } from './features/tarefas/tarefas-manager/tarefas-manager.component';
import { usuarioResolver } from './core/resolvers/usuario.resolver';
import { tarefasResolver } from './core/resolvers/tarefas.resolver';
import { AuthPerfilGuard } from './core/auth/guards/auth-perfil.guard';
import { AuthAdminPerfilGuard } from './core/auth/guards/auth-admin-perfil.guard';
import { HomeComponent } from './features/home/home.component';

export const routes: Routes = [
 {
  path:'',
  canActivate: [AuthPerfilGuard],
  component: LoginUsuariosComponent,
}, 
 {
  path:'home',
  component: HomeComponent,
}, 
 {
  path:'usuarios',
  component: UsuariosManagerComponent,
  canActivate:[AuthAdminPerfilGuard],
  resolve:{
    usuarios: usuarioResolver
  }
},
{
  path:'tarefas',
  component: TarefasManagerComponent,
    canActivate:[AuthPerfilGuard],
      resolve: {
      usuarios: usuarioResolver,
      tarefas: tarefasResolver
  }
},
{
  path:'**',
  redirectTo: '',
} 
];