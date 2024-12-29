import { Component, OnInit } from '@angular/core';
import { PostsService } from '../../services/posts.service';
import { Post } from '../../model/Post';

@Component({
  selector: 'app-home-page',
  standalone: false,
  templateUrl: './home-page.component.html',
  styleUrl: './home-page.component.css'
})
export class HomePageComponent implements OnInit {

  public title: string = "";
  public body: string = "";

  public posts: Post[] = [];

  public search: string = "";

  constructor(
    private postsService: PostsService) { }

  public create() {
    this.postsService.create({
      title: this.title,
      textContent: this.body,
    } as Post).subscribe({
      next: (post: Post) => {
        this.title = "";
        this.body = "";
        this.posts.push(post);
      }
    });
  }

  ngOnInit(): void {
    this.postsService.posts().subscribe({
      next: (posts: Post[]) => {
        this.posts = posts;
      }
    });
  }
}
