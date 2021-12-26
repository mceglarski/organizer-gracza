export interface User {
  id: number;
  username: string;
  nickname: string;
  token: string;
  photoUrl: string;
  roles: string[];
  description: string;
  steamId: string;
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
  description: string;
  steamId: string;
  emailConfirmed?: number;
  userGames?: UserGame[];
}

export interface SteamInformation {
  communityvisibilitystate?: number;
  profilestate?: number;
  personaname?: string;
  profileurl?: string;
  gameid?: number;
  gameextrainfo?: string;
  realname?: string;
  avatarfull?: string;
}

export interface SteamLastPlayedGame {
  appid?: number;
  name?: string;
}

export interface SteamAchievements {
  achieved: number;
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
  pageSize = 200;
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
  eventResultId: number;
}

export interface EventTeamRegistration {
  eventTeamRegistrationId: number;
  teamId: number;
  eventTeamId: number;
  team: Team;
  eventResultId: number;
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
  photoUrl: string;
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

export interface Achievements {
  achievementsId: number;
  name: string;
  details: string;
  photoUrl: string
  userId: number;
}

export interface Reminder {
  reminderId?: number;
  title: string;
  startDate: Date;
  user?: User;
  userId: number;
}

export interface ForumThread {
  forumThreadId: number;
  title: string;
  content: string;
  threadDate: Date;
  forumPosts: ForumPost[];
  userId: number;
  user: User;
  gameId: number;
  game: Game;
}

export interface ForumPost {
  forumPostId: number;
  content: string;
  postDate: Date;
  userId: number;
  forumThreadId: number;
  photoUrl: string;
  nickname: string;
  username: string;
}

export interface EventTeamResult {
  eventTeamResultId: number;
  eventTeamId: number;
  teamId: number;
}

export interface EventUserResult {
  eventUserResultId: number;
  eventUserId: number;
  userId: number;
}

export interface TwitchBroadcast {
  id: string;
  user_id: string;
  user_login: string;
  user_name: string;
  game_id: string;
  game_name: string;
  type: string;
  title: string;
  viewer_count: number;
  started_at: string;
  language: string;
  thumbnail_url: string;
  tag_ids: string;
  is_mature: boolean;
  pagination: any;
}

export interface UserAchievementCounter{
  userAchievementCounterId: number;
  numberOfTeamsCreated: number;
  numberOfTeamsJoined: number;
  numberOfThreadsCreated: number;
  numberOfPostsCreated: number;
  numberOfEventUserJoined: number;
  userId: number;
}

export interface UserGame{
  userGameId?: number;
  userId: number;
  gameId: number;
}

export interface UserAchievement {
  achievements: Achievements;
  userAchievementsId: number;
  achievementsId: number;
  userId: number;
  user: User;
}
