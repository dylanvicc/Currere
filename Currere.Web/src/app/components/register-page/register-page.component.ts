import { Component } from '@angular/core';
import { UsersService } from '../../services/users.service';
import { User } from '../../model/User';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register-page',
  standalone: false,
  templateUrl: './register-page.component.html',
  styleUrl: './register-page.component.css'
})
export class RegisterPageComponent {

  public email: string = "";
  public firstName: string = "";
  public lastName: string = "";
  public password: string = "";
  public passwordConfirmation: string = "";

  constructor(
    private userService: UsersService,
    private router: Router) { }

  public register(): void {
    this.userService.create({
      emailAddress: this.email,
      firstName: this.firstName,
      lastName: this.lastName,
      password: this.password
    } as User).subscribe({
      next: () => {
        this.router.navigate(['/login']);
      }
    });
  }

  public registerDisabled(): boolean {
    return !this.email.length || !this.firstName.length || !this.lastName.length || !this.password.length || !this.passwordConfirmation.length;
  }

  public passwordsMatch(): boolean {
    return this.password === this.passwordConfirmation;
  }
}
