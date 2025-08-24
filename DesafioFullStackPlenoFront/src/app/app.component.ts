import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { UsuariosManagerComponent } from './features/usuarios/usuarios-manager/usuarios-manager.component';
import { LoginUsuariosComponent } from './features/login/login-usuarios/login-usuarios.component';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent {
  title = 'DesafioFullStackPlenoFront';
}
