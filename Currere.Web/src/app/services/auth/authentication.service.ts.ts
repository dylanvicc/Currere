import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  private endpoint = 'http://localhost:5000/Authentication';

  constructor(private http: HttpClient) { }

  login(email: string, password: string): Observable<void> {

    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });

    const credentials = {
      "EmailAddress": email,
      "Password": password
    };

    return this.http.post<{ token: string }>(`${this.endpoint}/authenticate`, credentials, { headers })
      .pipe(
        map(response => {
          localStorage.setItem('token', response.token);
        })
      );
  }

  logout(): void {
    localStorage.removeItem('token');
  }

  isLoggedIn(): boolean {
    return !!localStorage.getItem('token');
  }

  getToken(): string | null {
    return localStorage.getItem('token');
  }
}
