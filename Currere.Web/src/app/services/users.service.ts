import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { User } from "../model/User";

@Injectable({
  providedIn: 'root'
})
export class UsersService {

  private endpoint = 'http://localhost:5002/Users';

  constructor(private http: HttpClient) { }

  create(user: User): Observable<User> {
    return this.http.post<User>(this.endpoint + '/create/', user);
  }
}
