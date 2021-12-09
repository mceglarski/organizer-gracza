export interface User {
  Id: number;
  username: string;
  nickname: string;
  token: string;
  photoUrl: string;
  roles: string[];
}

export interface News {
  articlesId: number;
  title: string;
  content: string;
  publicationDate: Date;
  photoUrl: string;
  user?: User;
  userId: number
}

export interface Photo {
  photoId: number;
  url: string;
  isMain: boolean;
}

export interface Member {
  id: number;
  username: string;
  nickname: string;
  email: string;
  created: Date;
  lastActive: Date;
  photoUrl: string;
  photos: Photo[];
}

export interface Pagination {
  currentPage: number;
  itemsPerPage: number;
  totalItems: number;
  totalPages: number;
}

export class PaginatedResult<T> {
  // @ts-ignore
  result: T;
  // @ts-ignore
  pagination: Pagination;
}

export class PagintationParams {
  pageNumber = 1;
  pageSize = 6;
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

export interface Group {
  name: string;
  connections: Connection[];
}

export interface Connection {
  connectionId: string;
  username: string;
}

export interface EventUser {
  eventUserId: number;
  name: string;
  description: string;
  startDate: Date;
  endDate: Date;
  eventType: string;
  winnerPrize: number;
  eventOrganiser: string;
  game: Game;
  gameId: number;
  photoUrl: string;
  eventUserRegistration: EventUserRegistration[];
}

export interface EventTeam {
  eventTeamId: number;
  name: string;
  description: string;
  startDate: Date;
  endDate: Date;
  eventType: string;
  winnerPrize: number;
  eventOrganiser: string;
  game: Game;
  gameId: number;
  photoUrl: string;
  eventTeamRegistration: EventTeamRegistration[];
}

export interface EventUserRegistration {
  eventUserRegistrationId: number;
  userId: number;
  eventUserId: number;
}

export interface EventTeamRegistration {
  eventTeamRegistrationId: number;
  teamId: number;
  eventTeamId: number;
  team: Team;
}

export interface Participiant {
  Id: number;
  nickname: string;
}

export interface Team {
  teamId: number;
  name: string;
  photoUrl: string;
  teamUser: TeamUser[]
}

export interface TeamUser {
  teamUserId: number;
  userId: number;
  user: User;
  teamId: number;
  team: Team;
}

export interface Game {
  gameId: number;
  title: string;
}

export interface GameStatistics {
  gameStatisticsId: number;
  wonGames: number;
  lostGames: number;
  gameId: number;
  userId: number;
}

export interface GeneralStatistics {
  generalStatisticsId: number;
  eventsParticipated: number;
  eventsWon: number;
  postWritten: number;
  userId: number;
  user: User;
}

export interface Achievements{
  achievementsId: number;
  name: string;
  details: string;
  photoUrl: string
  userId: number;
}

export interface Reminder{
  ReminderId: number;
  title: string;
  startDate: Date;
  user: User;
  userId: number;
}
