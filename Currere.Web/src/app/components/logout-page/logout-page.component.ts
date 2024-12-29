import { Component } from '@angular/core';
import { AuthenticationService } from '../../services/auth/authentication.service.ts';
import { Router } from '@angular/router';

@Component({
  selector: 'app-logout-page',
  standalone: false,  
  templateUrl: './logout-page.component.html',
  styleUrl: './logout-page.component.css'
})
export class LogoutPageComponent {
  constructor(
    public authService: AuthenticationService,
    private router: Router) { }

  public logout(): void {
    this.authService.logout();
    this.router.navigate(['/login']);
  }
}
