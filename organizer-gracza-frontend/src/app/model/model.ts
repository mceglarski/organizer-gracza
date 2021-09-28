export interface User{
  username: string;
  nickname: string;
  token: string;
  photoUrl: string;
  roles: string[];
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
  Id: number;
  username: string;
  nickname: string;
  email: string;
  created: Date;
  lastActive: Date;
  photoUrl: string;
  photos: Photo[];
}

export interface Pagination{
  currentPage: number;
  itemsPerPage: number;
  totalItems: number;
  totalPages: number;
}

export class PaginatedResult<T>{
  // @ts-ignore
  result: T;
  // @ts-ignore
  pagination: Pagination;
}

export class PagintationParams {
  pageNumber = 1;
  pageSize = 5;
}

export interface Message {
  messageId: number;
  senderId: number;
  senderUsername: string;
  senderPhotoUrl: string;
  recipientId: number;
  recipientUsername: string;
  recipientPhotoUrl: string;
  content: string;
  dateRead?: Date;
  messageSent: Date;
}

export interface Group{
  name:string;
  connections: Connection[];
}

export interface Connection{
  connectionId: string;
  username: string;
}

export interface event {

}
