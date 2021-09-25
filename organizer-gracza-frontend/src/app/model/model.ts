export interface User{
  username: string;
  nickname: string;
  token: string;
  photoUrl: string;
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

export class UserParams{
  pageNumber = 1;
  pageSize = 5;
}

export interface event {

}
