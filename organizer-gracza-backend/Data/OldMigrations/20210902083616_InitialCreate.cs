// using System;
// using Microsoft.EntityFrameworkCore.Migrations;
//
// namespace organizer_gracza_backend.Data.Migrations
// {
//     public partial class InitialCreate : Migration
//     {
//         protected override void Up(MigrationBuilder migrationBuilder)
//         {
//             migrationBuilder.CreateTable(
//                 name: "Chats",
//                 columns: table => new
//                 {
//                     IdChat = table.Column<int>(type: "INTEGER", nullable: false)
//                         .Annotation("Sqlite:Autoincrement", true),
//                     Name = table.Column<string>(type: "TEXT", nullable: true)
//                 },
//                 constraints: table =>
//                 {
//                     table.PrimaryKey("PK_Chats", x => x.IdChat);
//                 });
//
//             migrationBuilder.CreateTable(
//                 name: "Events",
//                 columns: table => new
//                 {
//                     IdEvent = table.Column<int>(type: "INTEGER", nullable: false)
//                         .Annotation("Sqlite:Autoincrement", true),
//                     Name = table.Column<string>(type: "TEXT", nullable: true),
//                     Description = table.Column<string>(type: "TEXT", nullable: true),
//                     StartDate = table.Column<DateTime>(type: "TEXT", nullable: false),
//                     EndDate = table.Column<DateTime>(type: "TEXT", nullable: false),
//                     EventType = table.Column<string>(type: "TEXT", nullable: true)
//                 },
//                 constraints: table =>
//                 {
//                     table.PrimaryKey("PK_Events", x => x.IdEvent);
//                 });
//
//             migrationBuilder.CreateTable(
//                 name: "Games",
//                 columns: table => new
//                 {
//                     IdGame = table.Column<int>(type: "INTEGER", nullable: false)
//                         .Annotation("Sqlite:Autoincrement", true),
//                     Title = table.Column<string>(type: "TEXT", nullable: true)
//                 },
//                 constraints: table =>
//                 {
//                     table.PrimaryKey("PK_Games", x => x.IdGame);
//                 });
//
//             migrationBuilder.CreateTable(
//                 name: "Profile",
//                 columns: table => new
//                 {
//                     IdProfile = table.Column<int>(type: "INTEGER", nullable: false)
//                         .Annotation("Sqlite:Autoincrement", true),
//                     Description = table.Column<string>(type: "TEXT", nullable: true),
//                     Url = table.Column<string>(type: "TEXT", nullable: true)
//                 },
//                 constraints: table =>
//                 {
//                     table.PrimaryKey("PK_Profile", x => x.IdProfile);
//                 });
//
//             migrationBuilder.CreateTable(
//                 name: "Teams",
//                 columns: table => new
//                 {
//                     IdTeam = table.Column<int>(type: "INTEGER", nullable: false)
//                         .Annotation("Sqlite:Autoincrement", true),
//                     Name = table.Column<string>(type: "TEXT", nullable: true)
//                 },
//                 constraints: table =>
//                 {
//                     table.PrimaryKey("PK_Teams", x => x.IdTeam);
//                 });
//
//             migrationBuilder.CreateTable(
//                 name: "ChatUsers",
//                 columns: table => new
//                 {
//                     IdChatUsers = table.Column<int>(type: "INTEGER", nullable: false)
//                         .Annotation("Sqlite:Autoincrement", true),
//                     ChatIdChat = table.Column<int>(type: "INTEGER", nullable: true)
//                 },
//                 constraints: table =>
//                 {
//                     table.PrimaryKey("PK_ChatUsers", x => x.IdChatUsers);
//                     table.ForeignKey(
//                         name: "FK_ChatUsers_Chats_ChatIdChat",
//                         column: x => x.ChatIdChat,
//                         principalTable: "Chats",
//                         principalColumn: "IdChat",
//                         onDelete: ReferentialAction.Restrict);
//                 });
//
//             migrationBuilder.CreateTable(
//                 name: "EventResults",
//                 columns: table => new
//                 {
//                     IdEventResult = table.Column<int>(type: "INTEGER", nullable: false)
//                         .Annotation("Sqlite:Autoincrement", true),
//                     WinnerName = table.Column<string>(type: "TEXT", nullable: true),
//                     EventIdEvent = table.Column<int>(type: "INTEGER", nullable: true)
//                 },
//                 constraints: table =>
//                 {
//                     table.PrimaryKey("PK_EventResults", x => x.IdEventResult);
//                     table.ForeignKey(
//                         name: "FK_EventResults_Events_EventIdEvent",
//                         column: x => x.EventIdEvent,
//                         principalTable: "Events",
//                         principalColumn: "IdEvent",
//                         onDelete: ReferentialAction.Restrict);
//                 });
//
//             migrationBuilder.CreateTable(
//                 name: "Streams",
//                 columns: table => new
//                 {
//                     IdStream = table.Column<int>(type: "INTEGER", nullable: false)
//                         .Annotation("Sqlite:Autoincrement", true),
//                     Url = table.Column<string>(type: "TEXT", nullable: true),
//                     Name = table.Column<string>(type: "TEXT", nullable: true),
//                     GameIdGame = table.Column<int>(type: "INTEGER", nullable: true)
//                 },
//                 constraints: table =>
//                 {
//                     table.PrimaryKey("PK_Streams", x => x.IdStream);
//                     table.ForeignKey(
//                         name: "FK_Streams_Games_GameIdGame",
//                         column: x => x.GameIdGame,
//                         principalTable: "Games",
//                         principalColumn: "IdGame",
//                         onDelete: ReferentialAction.Restrict);
//                 });
//
//             migrationBuilder.CreateTable(
//                 name: "Achievements",
//                 columns: table => new
//                 {
//                     IdAchievements = table.Column<int>(type: "INTEGER", nullable: false)
//                         .Annotation("Sqlite:Autoincrement", true),
//                     Name = table.Column<string>(type: "TEXT", nullable: true),
//                     Details = table.Column<string>(type: "TEXT", nullable: true),
//                     ProfileIdProfile = table.Column<int>(type: "INTEGER", nullable: true)
//                 },
//                 constraints: table =>
//                 {
//                     table.PrimaryKey("PK_Achievements", x => x.IdAchievements);
//                     table.ForeignKey(
//                         name: "FK_Achievements_Profile_ProfileIdProfile",
//                         column: x => x.ProfileIdProfile,
//                         principalTable: "Profile",
//                         principalColumn: "IdProfile",
//                         onDelete: ReferentialAction.Restrict);
//                 });
//
//             migrationBuilder.CreateTable(
//                 name: "GameStatistics",
//                 columns: table => new
//                 {
//                     IdGameStatistics = table.Column<int>(type: "INTEGER", nullable: false)
//                         .Annotation("Sqlite:Autoincrement", true),
//                     WonGames = table.Column<int>(type: "INTEGER", nullable: false),
//                     LostGames = table.Column<int>(type: "INTEGER", nullable: false),
//                     GameIdGame = table.Column<int>(type: "INTEGER", nullable: true),
//                     ProfileIdProfile = table.Column<int>(type: "INTEGER", nullable: true)
//                 },
//                 constraints: table =>
//                 {
//                     table.PrimaryKey("PK_GameStatistics", x => x.IdGameStatistics);
//                     table.ForeignKey(
//                         name: "FK_GameStatistics_Games_GameIdGame",
//                         column: x => x.GameIdGame,
//                         principalTable: "Games",
//                         principalColumn: "IdGame",
//                         onDelete: ReferentialAction.Restrict);
//                     table.ForeignKey(
//                         name: "FK_GameStatistics_Profile_ProfileIdProfile",
//                         column: x => x.ProfileIdProfile,
//                         principalTable: "Profile",
//                         principalColumn: "IdProfile",
//                         onDelete: ReferentialAction.Restrict);
//                 });
//
//             migrationBuilder.CreateTable(
//                 name: "GeneralStatistics",
//                 columns: table => new
//                 {
//                     IdGeneralStatistics = table.Column<int>(type: "INTEGER", nullable: false)
//                         .Annotation("Sqlite:Autoincrement", true),
//                     EventsParticipated = table.Column<int>(type: "INTEGER", nullable: false),
//                     EventsWon = table.Column<int>(type: "INTEGER", nullable: false),
//                     PostWritten = table.Column<int>(type: "INTEGER", nullable: false),
//                     ProfileIdProfile = table.Column<int>(type: "INTEGER", nullable: true)
//                 },
//                 constraints: table =>
//                 {
//                     table.PrimaryKey("PK_GeneralStatistics", x => x.IdGeneralStatistics);
//                     table.ForeignKey(
//                         name: "FK_GeneralStatistics_Profile_ProfileIdProfile",
//                         column: x => x.ProfileIdProfile,
//                         principalTable: "Profile",
//                         principalColumn: "IdProfile",
//                         onDelete: ReferentialAction.Restrict);
//                 });
//
//             migrationBuilder.CreateTable(
//                 name: "Users",
//                 columns: table => new
//                 {
//                     IdUser = table.Column<int>(type: "INTEGER", nullable: false)
//                         .Annotation("Sqlite:Autoincrement", true),
//                     Nickname = table.Column<string>(type: "TEXT", nullable: true),
//                     Email = table.Column<string>(type: "TEXT", nullable: true),
//                     PasswordHash = table.Column<byte[]>(type: "BLOB", nullable: true),
//                     PasswordSalt = table.Column<byte[]>(type: "BLOB", nullable: true),
//                     ChatUsersIdChatUsers = table.Column<int>(type: "INTEGER", nullable: true)
//                 },
//                 constraints: table =>
//                 {
//                     table.PrimaryKey("PK_Users", x => x.IdUser);
//                     table.ForeignKey(
//                         name: "FK_Users_ChatUsers_ChatUsersIdChatUsers",
//                         column: x => x.ChatUsersIdChatUsers,
//                         principalTable: "ChatUsers",
//                         principalColumn: "IdChatUsers",
//                         onDelete: ReferentialAction.Restrict);
//                 });
//
//             migrationBuilder.CreateTable(
//                 name: "Articles",
//                 columns: table => new
//                 {
//                     IdArticles = table.Column<int>(type: "INTEGER", nullable: false)
//                         .Annotation("Sqlite:Autoincrement", true),
//                     Title = table.Column<string>(type: "TEXT", nullable: true),
//                     Content = table.Column<string>(type: "TEXT", nullable: true),
//                     PublicationDate = table.Column<DateTime>(type: "TEXT", nullable: false),
//                     UserIdUser = table.Column<int>(type: "INTEGER", nullable: true)
//                 },
//                 constraints: table =>
//                 {
//                     table.PrimaryKey("PK_Articles", x => x.IdArticles);
//                     table.ForeignKey(
//                         name: "FK_Articles_Users_UserIdUser",
//                         column: x => x.UserIdUser,
//                         principalTable: "Users",
//                         principalColumn: "IdUser",
//                         onDelete: ReferentialAction.Restrict);
//                 });
//
//             migrationBuilder.CreateTable(
//                 name: "EventRegistrations",
//                 columns: table => new
//                 {
//                     IdEventRegistration = table.Column<int>(type: "INTEGER", nullable: false)
//                         .Annotation("Sqlite:Autoincrement", true),
//                     UserIdUser = table.Column<int>(type: "INTEGER", nullable: true),
//                     TeamIdTeam = table.Column<int>(type: "INTEGER", nullable: true),
//                     EventIdEvent = table.Column<int>(type: "INTEGER", nullable: true)
//                 },
//                 constraints: table =>
//                 {
//                     table.PrimaryKey("PK_EventRegistrations", x => x.IdEventRegistration);
//                     table.ForeignKey(
//                         name: "FK_EventRegistrations_Events_EventIdEvent",
//                         column: x => x.EventIdEvent,
//                         principalTable: "Events",
//                         principalColumn: "IdEvent",
//                         onDelete: ReferentialAction.Restrict);
//                     table.ForeignKey(
//                         name: "FK_EventRegistrations_Teams_TeamIdTeam",
//                         column: x => x.TeamIdTeam,
//                         principalTable: "Teams",
//                         principalColumn: "IdTeam",
//                         onDelete: ReferentialAction.Restrict);
//                     table.ForeignKey(
//                         name: "FK_EventRegistrations_Users_UserIdUser",
//                         column: x => x.UserIdUser,
//                         principalTable: "Users",
//                         principalColumn: "IdUser",
//                         onDelete: ReferentialAction.Restrict);
//                 });
//
//             migrationBuilder.CreateTable(
//                 name: "ForumThread",
//                 columns: table => new
//                 {
//                     IdForumThread = table.Column<int>(type: "INTEGER", nullable: false)
//                         .Annotation("Sqlite:Autoincrement", true),
//                     Title = table.Column<string>(type: "TEXT", nullable: true),
//                     Content = table.Column<string>(type: "TEXT", nullable: true),
//                     ThreadDate = table.Column<DateTime>(type: "TEXT", nullable: false),
//                     UserIdUser = table.Column<int>(type: "INTEGER", nullable: true)
//                 },
//                 constraints: table =>
//                 {
//                     table.PrimaryKey("PK_ForumThread", x => x.IdForumThread);
//                     table.ForeignKey(
//                         name: "FK_ForumThread_Users_UserIdUser",
//                         column: x => x.UserIdUser,
//                         principalTable: "Users",
//                         principalColumn: "IdUser",
//                         onDelete: ReferentialAction.Restrict);
//                 });
//
//             migrationBuilder.CreateTable(
//                 name: "Messages",
//                 columns: table => new
//                 {
//                     IdMessage = table.Column<int>(type: "INTEGER", nullable: false)
//                         .Annotation("Sqlite:Autoincrement", true),
//                     Content = table.Column<string>(type: "TEXT", nullable: true),
//                     MessageDate = table.Column<DateTime>(type: "TEXT", nullable: false),
//                     UserIdUser = table.Column<int>(type: "INTEGER", nullable: true),
//                     ChatIdChat = table.Column<int>(type: "INTEGER", nullable: true)
//                 },
//                 constraints: table =>
//                 {
//                     table.PrimaryKey("PK_Messages", x => x.IdMessage);
//                     table.ForeignKey(
//                         name: "FK_Messages_Chats_ChatIdChat",
//                         column: x => x.ChatIdChat,
//                         principalTable: "Chats",
//                         principalColumn: "IdChat",
//                         onDelete: ReferentialAction.Restrict);
//                     table.ForeignKey(
//                         name: "FK_Messages_Users_UserIdUser",
//                         column: x => x.UserIdUser,
//                         principalTable: "Users",
//                         principalColumn: "IdUser",
//                         onDelete: ReferentialAction.Restrict);
//                 });
//
//             migrationBuilder.CreateTable(
//                 name: "Reminder",
//                 columns: table => new
//                 {
//                     IdReminder = table.Column<int>(type: "INTEGER", nullable: false)
//                         .Annotation("Sqlite:Autoincrement", true),
//                     Title = table.Column<string>(type: "TEXT", nullable: true),
//                     Content = table.Column<string>(type: "TEXT", nullable: true),
//                     ReminderDate = table.Column<DateTime>(type: "TEXT", nullable: false),
//                     UserIdUser = table.Column<int>(type: "INTEGER", nullable: true)
//                 },
//                 constraints: table =>
//                 {
//                     table.PrimaryKey("PK_Reminder", x => x.IdReminder);
//                     table.ForeignKey(
//                         name: "FK_Reminder_Users_UserIdUser",
//                         column: x => x.UserIdUser,
//                         principalTable: "Users",
//                         principalColumn: "IdUser",
//                         onDelete: ReferentialAction.Restrict);
//                 });
//
//             migrationBuilder.CreateTable(
//                 name: "TeamUsers",
//                 columns: table => new
//                 {
//                     IdTeamUser = table.Column<int>(type: "INTEGER", nullable: false)
//                         .Annotation("Sqlite:Autoincrement", true),
//                     IdUser = table.Column<int>(type: "INTEGER", nullable: false),
//                     IdTeam = table.Column<int>(type: "INTEGER", nullable: false)
//                 },
//                 constraints: table =>
//                 {
//                     table.PrimaryKey("PK_TeamUsers", x => x.IdTeamUser);
//                     table.ForeignKey(
//                         name: "FK_TeamUsers_Teams_IdTeam",
//                         column: x => x.IdTeam,
//                         principalTable: "Teams",
//                         principalColumn: "IdTeam",
//                         onDelete: ReferentialAction.Cascade);
//                     table.ForeignKey(
//                         name: "FK_TeamUsers_Users_IdUser",
//                         column: x => x.IdUser,
//                         principalTable: "Users",
//                         principalColumn: "IdUser",
//                         onDelete: ReferentialAction.Cascade);
//                 });
//
//             migrationBuilder.CreateTable(
//                 name: "ForumPost",
//                 columns: table => new
//                 {
//                     IdForumPost = table.Column<int>(type: "INTEGER", nullable: false)
//                         .Annotation("Sqlite:Autoincrement", true),
//                     Content = table.Column<string>(type: "TEXT", nullable: true),
//                     PostDate = table.Column<DateTime>(type: "TEXT", nullable: false),
//                     UserIdUser = table.Column<int>(type: "INTEGER", nullable: true),
//                     ForumThreadIdForumThread = table.Column<int>(type: "INTEGER", nullable: true)
//                 },
//                 constraints: table =>
//                 {
//                     table.PrimaryKey("PK_ForumPost", x => x.IdForumPost);
//                     table.ForeignKey(
//                         name: "FK_ForumPost_ForumThread_ForumThreadIdForumThread",
//                         column: x => x.ForumThreadIdForumThread,
//                         principalTable: "ForumThread",
//                         principalColumn: "IdForumThread",
//                         onDelete: ReferentialAction.Restrict);
//                     table.ForeignKey(
//                         name: "FK_ForumPost_Users_UserIdUser",
//                         column: x => x.UserIdUser,
//                         principalTable: "Users",
//                         principalColumn: "IdUser",
//                         onDelete: ReferentialAction.Restrict);
//                 });
//
//             migrationBuilder.CreateIndex(
//                 name: "IX_Achievements_ProfileIdProfile",
//                 table: "Achievements",
//                 column: "ProfileIdProfile");
//
//             migrationBuilder.CreateIndex(
//                 name: "IX_Articles_UserIdUser",
//                 table: "Articles",
//                 column: "UserIdUser");
//
//             migrationBuilder.CreateIndex(
//                 name: "IX_ChatUsers_ChatIdChat",
//                 table: "ChatUsers",
//                 column: "ChatIdChat");
//
//             migrationBuilder.CreateIndex(
//                 name: "IX_EventRegistrations_EventIdEvent",
//                 table: "EventRegistrations",
//                 column: "EventIdEvent");
//
//             migrationBuilder.CreateIndex(
//                 name: "IX_EventRegistrations_TeamIdTeam",
//                 table: "EventRegistrations",
//                 column: "TeamIdTeam");
//
//             migrationBuilder.CreateIndex(
//                 name: "IX_EventRegistrations_UserIdUser",
//                 table: "EventRegistrations",
//                 column: "UserIdUser");
//
//             migrationBuilder.CreateIndex(
//                 name: "IX_EventResults_EventIdEvent",
//                 table: "EventResults",
//                 column: "EventIdEvent");
//
//             migrationBuilder.CreateIndex(
//                 name: "IX_ForumPost_ForumThreadIdForumThread",
//                 table: "ForumPost",
//                 column: "ForumThreadIdForumThread");
//
//             migrationBuilder.CreateIndex(
//                 name: "IX_ForumPost_UserIdUser",
//                 table: "ForumPost",
//                 column: "UserIdUser");
//
//             migrationBuilder.CreateIndex(
//                 name: "IX_ForumThread_UserIdUser",
//                 table: "ForumThread",
//                 column: "UserIdUser");
//
//             migrationBuilder.CreateIndex(
//                 name: "IX_GameStatistics_GameIdGame",
//                 table: "GameStatistics",
//                 column: "GameIdGame");
//
//             migrationBuilder.CreateIndex(
//                 name: "IX_GameStatistics_ProfileIdProfile",
//                 table: "GameStatistics",
//                 column: "ProfileIdProfile");
//
//             migrationBuilder.CreateIndex(
//                 name: "IX_GeneralStatistics_ProfileIdProfile",
//                 table: "GeneralStatistics",
//                 column: "ProfileIdProfile");
//
//             migrationBuilder.CreateIndex(
//                 name: "IX_Messages_ChatIdChat",
//                 table: "Messages",
//                 column: "ChatIdChat");
//
//             migrationBuilder.CreateIndex(
//                 name: "IX_Messages_UserIdUser",
//                 table: "Messages",
//                 column: "UserIdUser");
//
//             migrationBuilder.CreateIndex(
//                 name: "IX_Reminder_UserIdUser",
//                 table: "Reminder",
//                 column: "UserIdUser");
//
//             migrationBuilder.CreateIndex(
//                 name: "IX_Streams_GameIdGame",
//                 table: "Streams",
//                 column: "GameIdGame");
//
//             migrationBuilder.CreateIndex(
//                 name: "IX_TeamUsers_IdTeam",
//                 table: "TeamUsers",
//                 column: "IdTeam");
//
//             migrationBuilder.CreateIndex(
//                 name: "IX_TeamUsers_IdUser",
//                 table: "TeamUsers",
//                 column: "IdUser");
//
//             migrationBuilder.CreateIndex(
//                 name: "IX_Users_ChatUsersIdChatUsers",
//                 table: "Users",
//                 column: "ChatUsersIdChatUsers");
//         }
//
//         protected override void Down(MigrationBuilder migrationBuilder)
//         {
//             migrationBuilder.DropTable(
//                 name: "Achievements");
//
//             migrationBuilder.DropTable(
//                 name: "Articles");
//
//             migrationBuilder.DropTable(
//                 name: "EventRegistrations");
//
//             migrationBuilder.DropTable(
//                 name: "EventResults");
//
//             migrationBuilder.DropTable(
//                 name: "ForumPost");
//
//             migrationBuilder.DropTable(
//                 name: "GameStatistics");
//
//             migrationBuilder.DropTable(
//                 name: "GeneralStatistics");
//
//             migrationBuilder.DropTable(
//                 name: "Messages");
//
//             migrationBuilder.DropTable(
//                 name: "Reminder");
//
//             migrationBuilder.DropTable(
//                 name: "Streams");
//
//             migrationBuilder.DropTable(
//                 name: "TeamUsers");
//
//             migrationBuilder.DropTable(
//                 name: "Events");
//
//             migrationBuilder.DropTable(
//                 name: "ForumThread");
//
//             migrationBuilder.DropTable(
//                 name: "Profile");
//
//             migrationBuilder.DropTable(
//                 name: "Games");
//
//             migrationBuilder.DropTable(
//                 name: "Teams");
//
//             migrationBuilder.DropTable(
//                 name: "Users");
//
//             migrationBuilder.DropTable(
//                 name: "ChatUsers");
//
//             migrationBuilder.DropTable(
//                 name: "Chats");
//         }
//     }
// }
