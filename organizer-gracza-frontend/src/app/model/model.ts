export interface User{
  username: string;
  nickname: string;
  token: string;
}

export interface News {
  IdArticles: number;
  Title: string;
  Content: string;
  PublicationDate: Date;
  User?: User;
}

export interface Photo {
  photoId: number;
  url: string;
  isMain: boolean;
}

export interface Member {
  userId: number;
  username: string;
  nickname: string;
  email: string;
  created: Date;
  lastActive: Date;
  photoUrl: string;
  photos: Photo[];
}

export interface event {

}
