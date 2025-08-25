import { Component, inject, signal } from '@angular/core';
import { Router } from '@angular/router';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { AuthTokenService } from '../../auth/services/authtoken.service';

interface MenuItem {
  label: string;
  link?: string;
  submenu?: MenuItem[];
}

@Component({
  selector: 'app-navbar',
  standalone: true,
  imports: [RouterModule, CommonModule],
  templateUrl: './navbar.component.html',
})
export class NavbarComponent {
  private auth = inject(AuthTokenService);
  private router = inject(Router);

  mobileMenuOpen = signal(false);
  openSubmenu = signal<string | null>(null);

  menuItems = signal<MenuItem[]>([
    { label: 'Home', link: '/home' },
    { label: 'Usuarios', link: '/usuarios' },
    { label: 'Tarefas', link: '/tarefas' },
    {
      label: 'Account',
      submenu: [
        { label: 'Login', link: '/' },
        { label: 'Logout' }
      ],
    },
  ]);

  toggleMobileMenu() {
    this.mobileMenuOpen.set(!this.mobileMenuOpen());
  }

  toggleSubmenu(label: string) {
    this.openSubmenu.set(this.openSubmenu() === label ? null : label);
  }

  navigateAndClose(link?: string) {
    this.openSubmenu.set(null);
    if (link) this.router.navigate([link]);
  }

  logoutAndClose() {
    this.openSubmenu.set(null);
    this.logout();
  }

  logout() {
    this.auth.removeToken();
    this.router.navigate(['/']);
  }
}
