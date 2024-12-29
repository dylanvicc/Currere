export interface Post {
  postID: number;
  userID: number;
  title: string;
  textContent: string;
  creationDateUTC: Date;
  timesFlagged: number;
  displayPriority: number;
}
