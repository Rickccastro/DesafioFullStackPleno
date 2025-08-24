import { Component, inject, OnInit, Input } from '@angular/core';
import { LoginService } from '../../../shared/services/login.service';
import { Router } from '@angular/router';
import { AuthTokenService } from '../../../core/auth/services/authtoken.service';
import { CommonModule } from '@angular/common';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { Login } from '../../../core/models/Requests/Login';
import { Usuario } from '../../../core/models/Usuario';

@Component({
  selector: 'app-login-usuarios',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './login-usuarios.component.html',
  styleUrls: ['./login-usuarios.component.scss']
})
export class LoginUsuariosComponent implements OnInit {
  loginUser = inject(LoginService);
  authTokenService = inject(AuthTokenService);
  router = inject(Router);

  @Input() usuario: Usuario | null = null;

  form!: FormGroup;

  ngOnInit(): void {
    this.form = new FormGroup({
      email: new FormControl<string>(this.usuario?.email ?? '', {
        nonNullable: true,
        validators: [Validators.required, Validators.email],
      }),
      senha: new FormControl<string>(this.usuario?.senha ?? '', {
        nonNullable: true,
        validators: [Validators.required],
      }),
    });
  }

  onSubmit() {
    if (this.form.invalid) return;

    const credentials: Login = this.form.value; // Pega { email, senha } do form

    this.loginUser.loginUser(credentials).subscribe({
      next: (response) => {
        this.authTokenService.setToken(response.token);
        this.router.navigate(['/usuarios']); // rota pós-login
      },
      error: (err) => {
        alert('Erro ao fazer login. Verifique seus dados.');
        console.error(err);
      },
    });
  }
}
