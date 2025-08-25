import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { UsuariosManagerComponent } from './features/usuarios/usuarios-manager/usuarios-manager.component';
import { LoginUsuariosComponent } from './features/login/login-usuarios/login-usuarios.component';
import { LayoutComponent } from "./core/layouts/layout/layout.component";

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, LayoutComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent {
  title = 'DesafioFullStackPlenoFront';
}
