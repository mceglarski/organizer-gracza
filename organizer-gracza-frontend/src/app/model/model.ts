export interface User{
  username: string;
  token: string;
}

export interface News {
  IdArticles: number;
  Title: string;
  Content: string;
  PublicationDate: Date;
  User?: User;
}

export interface event {

}
