import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { Post } from "../model/Post";

@Injectable({
  providedIn: 'root'
})
export class PostsService {

  private endpoint = 'http://localhost:5001/Posts';

  constructor(private http: HttpClient) { }

  posts(): Observable<Post[]> {
    return this.http.get<Post[]>(this.endpoint + '/find');
  }

  post(identity: number): Observable<Post[]> {
    return this.http.get<Post[]>(this.endpoint + 'find/identity/' + encodeURIComponent(identity));
  }

  create(post: Post): Observable<Post> {
    return this.http.post<Post>(this.endpoint + '/create/', post);
  }
}
