import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-feed-card',
  standalone: false,
  templateUrl: './feed-card.component.html',
  styleUrl: './feed-card.component.css'
})
export class FeedCardComponent {

  @Input({ required: true }) public text: string = "";
  @Input({ required: true }) public title: string = "";
}
