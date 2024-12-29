import { Component } from '@angular/core';
import { AuthenticationService } from '../../services/auth/authentication.service.ts.js';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login-page',
  standalone: false,
  templateUrl: './login-page.component.html',
  styleUrl: './login-page.component.css'
})
export class LoginPageComponent {

  public email: string = "";
  public password: string = "";
  public error: boolean = false;

  constructor(
    private authService: AuthenticationService,
    private router: Router
  ) { }

  public login(): void {
    this.authService.login(this.email, this.password).subscribe({
      next: () => {
        this.router.navigate(['/home']);
      },
      error: () => {
        this.error = true;
      }
    });
  }
}
