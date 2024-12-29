import { Component } from '@angular/core';
import { AuthenticationService } from '../../services/auth/authentication.service.ts.js';

@Component({
  selector: 'app-navigation-bar',
  standalone: false,
  templateUrl: './navigation-bar.component.html',
  styleUrl: './navigation-bar.component.css'
})
export class NavigationBarComponent {

  constructor(
    public authService: AuthenticationService) { }
}
