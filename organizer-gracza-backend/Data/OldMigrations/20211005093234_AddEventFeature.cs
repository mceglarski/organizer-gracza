// using System;
// using Microsoft.EntityFrameworkCore.Migrations;
//
// namespace organizer_gracza_backend.Data.Migrations
// {
//     public partial class AddEventFeature : Migration
//     {
//         protected override void Up(MigrationBuilder migrationBuilder)
//         {
//             migrationBuilder.CreateTable(
//                 name: "AspNetRoles",
//                 columns: table => new
//                 {
//                     Id = table.Column<int>(type: "INTEGER", nullable: false)
//                         .Annotation("Sqlite:Autoincrement", true),
//                     Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
//                     NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
//                     ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
//                 },
//                 constraints: table =>
//                 {
//                     table.PrimaryKey("PK_AspNetRoles", x => x.Id);
//                 });
//
//             migrationBuilder.CreateTable(
//                 name: "Chats",
//                 columns: table => new
//                 {
//                     ChatId = table.Column<int>(type: "INTEGER", nullable: false)
//                         .Annotation("Sqlite:Autoincrement", true),
//                     Name = table.Column<string>(type: "TEXT", nullable: true)
//                 },
//                 constraints: table =>
//                 {
//                     table.PrimaryKey("PK_Chats", x => x.ChatId);
//                 });
//
//             migrationBuilder.CreateTable(
//                 name: "Games",
//                 columns: table => new
//                 {
//                     GameId = table.Column<int>(type: "INTEGER", nullable: false)
//                         .Annotation("Sqlite:Autoincrement", true),
//                     Title = table.Column<string>(type: "TEXT", nullable: true)
//                 },
//                 constraints: table =>
//                 {
//                     table.PrimaryKey("PK_Games", x => x.GameId);
//                 });
//
//             migrationBuilder.CreateTable(
//                 name: "Groups",
//                 columns: table => new
//                 {
//                     Name = table.Column<string>(type: "TEXT", nullable: false)
//                 },
//                 constraints: table =>
//                 {
//                     table.PrimaryKey("PK_Groups", x => x.Name);
//                 });
//
//             migrationBuilder.CreateTable(
//                 name: "Profile",
//                 columns: table => new
//                 {
//                     ProfileId = table.Column<int>(type: "INTEGER", nullable: false)
//                         .Annotation("Sqlite:Autoincrement", true),
//                     Description = table.Column<string>(type: "TEXT", nullable: true),
//                     Url = table.Column<string>(type: "TEXT", nullable: true)
//                 },
//                 constraints: table =>
//                 {
//                     table.PrimaryKey("PK_Profile", x => x.ProfileId);
//                 });
//
//             migrationBuilder.CreateTable(
//                 name: "AspNetRoleClaims",
//                 columns: table => new
//                 {
//                     Id = table.Column<int>(type: "INTEGER", nullable: false)
//                         .Annotation("Sqlite:Autoincrement", true),
//                     RoleId = table.Column<int>(type: "INTEGER", nullable: false),
//                     ClaimType = table.Column<string>(type: "TEXT", nullable: true),
//                     ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
//                 },
//                 constraints: table =>
//                 {
//                     table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
//                     table.ForeignKey(
//                         name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
//                         column: x => x.RoleId,
//                         principalTable: "AspNetRoles",
//                         principalColumn: "Id",
//                         onDelete: ReferentialAction.Cascade);
//                 });
//
//             migrationBuilder.CreateTable(
//                 name: "ChatUsers",
//                 columns: table => new
//                 {
//                     ChatUsersId = table.Column<int>(type: "INTEGER", nullable: false)
//                         .Annotation("Sqlite:Autoincrement", true),
//                     ChatId = table.Column<int>(type: "INTEGER", nullable: true)
//                 },
//                 constraints: table =>
//                 {
//                     table.PrimaryKey("PK_ChatUsers", x => x.ChatUsersId);
//                     table.ForeignKey(
//                         name: "FK_ChatUsers_Chats_ChatId",
//                         column: x => x.ChatId,
//                         principalTable: "Chats",
//                         principalColumn: "ChatId",
//                         onDelete: ReferentialAction.Restrict);
//                 });
//
//             migrationBuilder.CreateTable(
//                 name: "Events",
//                 columns: table => new
//                 {
//                     EventId = table.Column<int>(type: "INTEGER", nullable: false)
//                         .Annotation("Sqlite:Autoincrement", true),
//                     Name = table.Column<string>(type: "TEXT", nullable: true),
//                     Description = table.Column<string>(type: "TEXT", nullable: true),
//                     StartDate = table.Column<DateTime>(type: "TEXT", nullable: true),
//                     EndDate = table.Column<DateTime>(type: "TEXT", nullable: true),
//                     EventType = table.Column<string>(type: "TEXT", nullable: true),
//                     WinnerPrize = table.Column<double>(type: "REAL", nullable: true),
//                     EventOrganiser = table.Column<string>(type: "TEXT", nullable: true),
//                     PhotoUrl = table.Column<string>(type: "TEXT", nullable: true),
//                     GameId = table.Column<int>(type: "INTEGER", nullable: true)
//                 },
//                 constraints: table =>
//                 {
//                     table.PrimaryKey("PK_Events", x => x.EventId);
//                     table.ForeignKey(
//                         name: "FK_Events_Games_GameId",
//                         column: x => x.GameId,
//                         principalTable: "Games",
//                         principalColumn: "GameId",
//                         onDelete: ReferentialAction.Restrict);
//                 });
//
//             migrationBuilder.CreateTable(
//                 name: "Streams",
//                 columns: table => new
//                 {
//                     StreamId = table.Column<int>(type: "INTEGER", nullable: false)
//                         .Annotation("Sqlite:Autoincrement", true),
//                     Url = table.Column<string>(type: "TEXT", nullable: true),
//                     Name = table.Column<string>(type: "TEXT", nullable: true),
//                     GameId = table.Column<int>(type: "INTEGER", nullable: true)
//                 },
//                 constraints: table =>
//                 {
//                     table.PrimaryKey("PK_Streams", x => x.StreamId);
//                     table.ForeignKey(
//                         name: "FK_Streams_Games_GameId",
//                         column: x => x.GameId,
//                         principalTable: "Games",
//                         principalColumn: "GameId",
//                         onDelete: ReferentialAction.Restrict);
//                 });
//
//             migrationBuilder.CreateTable(
//                 name: "Connections",
//                 columns: table => new
//                 {
//                     ConnectionId = table.Column<string>(type: "TEXT", nullable: false),
//                     Username = table.Column<string>(type: "TEXT", nullable: true),
//                     GroupName = table.Column<string>(type: "TEXT", nullable: true)
//                 },
//                 constraints: table =>
//                 {
//                     table.PrimaryKey("PK_Connections", x => x.ConnectionId);
//                     table.ForeignKey(
//                         name: "FK_Connections_Groups_GroupName",
//                         column: x => x.GroupName,
//                         principalTable: "Groups",
//                         principalColumn: "Name",
//                         onDelete: ReferentialAction.Restrict);
//                 });
//
//             migrationBuilder.CreateTable(
//                 name: "Achievements",
//                 columns: table => new
//                 {
//                     AchievementsId = table.Column<int>(type: "INTEGER", nullable: false)
//                         .Annotation("Sqlite:Autoincrement", true),
//                     Name = table.Column<string>(type: "TEXT", nullable: true),
//                     Details = table.Column<string>(type: "TEXT", nullable: true),
//                     ProfileId = table.Column<int>(type: "INTEGER", nullable: true)
//                 },
//                 constraints: table =>
//                 {
//                     table.PrimaryKey("PK_Achievements", x => x.AchievementsId);
//                     table.ForeignKey(
//                         name: "FK_Achievements_Profile_ProfileId",
//                         column: x => x.ProfileId,
//                         principalTable: "Profile",
//                         principalColumn: "ProfileId",
//                         onDelete: ReferentialAction.Restrict);
//                 });
//
//             migrationBuilder.CreateTable(
//                 name: "GameStatistics",
//                 columns: table => new
//                 {
//                     GameStatisticsId = table.Column<int>(type: "INTEGER", nullable: false)
//                         .Annotation("Sqlite:Autoincrement", true),
//                     WonGames = table.Column<int>(type: "INTEGER", nullable: false),
//                     LostGames = table.Column<int>(type: "INTEGER", nullable: false),
//                     GameId = table.Column<int>(type: "INTEGER", nullable: true),
//                     ProfileId = table.Column<int>(type: "INTEGER", nullable: true)
//                 },
//                 constraints: table =>
//                 {
//                     table.PrimaryKey("PK_GameStatistics", x => x.GameStatisticsId);
//                     table.ForeignKey(
//                         name: "FK_GameStatistics_Games_GameId",
//                         column: x => x.GameId,
//                         principalTable: "Games",
//                         principalColumn: "GameId",
//                         onDelete: ReferentialAction.Restrict);
//                     table.ForeignKey(
//                         name: "FK_GameStatistics_Profile_ProfileId",
//                         column: x => x.ProfileId,
//                         principalTable: "Profile",
//                         principalColumn: "ProfileId",
//                         onDelete: ReferentialAction.Restrict);
//                 });
//
//             migrationBuilder.CreateTable(
//                 name: "GeneralStatistics",
//                 columns: table => new
//                 {
//                     GeneralStatisticsId = table.Column<int>(type: "INTEGER", nullable: false)
//                         .Annotation("Sqlite:Autoincrement", true),
//                     EventsParticipated = table.Column<int>(type: "INTEGER", nullable: false),
//                     EventsWon = table.Column<int>(type: "INTEGER", nullable: false),
//                     PostWritten = table.Column<int>(type: "INTEGER", nullable: false),
//                     ProfileId = table.Column<int>(type: "INTEGER", nullable: true)
//                 },
//                 constraints: table =>
//                 {
//                     table.PrimaryKey("PK_GeneralStatistics", x => x.GeneralStatisticsId);
//                     table.ForeignKey(
//                         name: "FK_GeneralStatistics_Profile_ProfileId",
//                         column: x => x.ProfileId,
//                         principalTable: "Profile",
//                         principalColumn: "ProfileId",
//                         onDelete: ReferentialAction.Restrict);
//                 });
//
//             migrationBuilder.CreateTable(
//                 name: "EventRegistrations",
//                 columns: table => new
//                 {
//                     EventRegistrationId = table.Column<int>(type: "INTEGER", nullable: false)
//                         .Annotation("Sqlite:Autoincrement", true),
//                     EventId = table.Column<int>(type: "INTEGER", nullable: false)
//                 },
//                 constraints: table =>
//                 {
//                     table.PrimaryKey("PK_EventRegistrations", x => x.EventRegistrationId);
//                     table.ForeignKey(
//                         name: "FK_EventRegistrations_Events_EventId",
//                         column: x => x.EventId,
//                         principalTable: "Events",
//                         principalColumn: "EventId",
//                         onDelete: ReferentialAction.Cascade);
//                 });
//
//             migrationBuilder.CreateTable(
//                 name: "EventResults",
//                 columns: table => new
//                 {
//                     EventResultId = table.Column<int>(type: "INTEGER", nullable: false)
//                         .Annotation("Sqlite:Autoincrement", true),
//                     WinnerName = table.Column<string>(type: "TEXT", nullable: true),
//                     EventId = table.Column<int>(type: "INTEGER", nullable: true)
//                 },
//                 constraints: table =>
//                 {
//                     table.PrimaryKey("PK_EventResults", x => x.EventResultId);
//                     table.ForeignKey(
//                         name: "FK_EventResults_Events_EventId",
//                         column: x => x.EventId,
//                         principalTable: "Events",
//                         principalColumn: "EventId",
//                         onDelete: ReferentialAction.Restrict);
//                 });
//
//             migrationBuilder.CreateTable(
//                 name: "AspNetUsers",
//                 columns: table => new
//                 {
//                     Id = table.Column<int>(type: "INTEGER", nullable: false)
//                         .Annotation("Sqlite:Autoincrement", true),
//                     Nickname = table.Column<string>(type: "TEXT", nullable: true),
//                     Created = table.Column<DateTime>(type: "TEXT", nullable: false),
//                     LastActive = table.Column<DateTime>(type: "TEXT", nullable: false),
//                     EventRegistrationId = table.Column<int>(type: "INTEGER", nullable: true),
//                     ChatUsersId = table.Column<int>(type: "INTEGER", nullable: true),
//                     UserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
//                     NormalizedUserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
//                     Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
//                     NormalizedEmail = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
//                     EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
//                     PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
//                     SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
//                     ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
//                     PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
//                     PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
//                     TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
//                     LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
//                     LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
//                     AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
//                 },
//                 constraints: table =>
//                 {
//                     table.PrimaryKey("PK_AspNetUsers", x => x.Id);
//                     table.ForeignKey(
//                         name: "FK_AspNetUsers_ChatUsers_ChatUsersId",
//                         column: x => x.ChatUsersId,
//                         principalTable: "ChatUsers",
//                         principalColumn: "ChatUsersId",
//                         onDelete: ReferentialAction.Restrict);
//                     table.ForeignKey(
//                         name: "FK_AspNetUsers_EventRegistrations_EventRegistrationId",
//                         column: x => x.EventRegistrationId,
//                         principalTable: "EventRegistrations",
//                         principalColumn: "EventRegistrationId",
//                         onDelete: ReferentialAction.Cascade);
//                 });
//
//             migrationBuilder.CreateTable(
//                 name: "Teams",
//                 columns: table => new
//                 {
//                     TeamId = table.Column<int>(type: "INTEGER", nullable: false)
//                         .Annotation("Sqlite:Autoincrement", true),
//                     Name = table.Column<string>(type: "TEXT", nullable: true),
//                     EventRegistrationId = table.Column<string>(type: "TEXT", nullable: true),
//                     EventRegistrationId1 = table.Column<int>(type: "INTEGER", nullable: true)
//                 },
//                 constraints: table =>
//                 {
//                     table.PrimaryKey("PK_Teams", x => x.TeamId);
//                     table.ForeignKey(
//                         name: "FK_Teams_EventRegistrations_EventRegistrationId1",
//                         column: x => x.EventRegistrationId1,
//                         principalTable: "EventRegistrations",
//                         principalColumn: "EventRegistrationId",
//                         onDelete: ReferentialAction.Restrict);
//                 });
//
//             migrationBuilder.CreateTable(
//                 name: "Articles",
//                 columns: table => new
//                 {
//                     ArticlesId = table.Column<int>(type: "INTEGER", nullable: false)
//                         .Annotation("Sqlite:Autoincrement", true),
//                     Title = table.Column<string>(type: "TEXT", nullable: true),
//                     Content = table.Column<string>(type: "TEXT", nullable: true),
//                     PublicationDate = table.Column<DateTime>(type: "TEXT", nullable: false),
//                     UserId = table.Column<int>(type: "INTEGER", nullable: true)
//                 },
//                 constraints: table =>
//                 {
//                     table.PrimaryKey("PK_Articles", x => x.ArticlesId);
//                     table.ForeignKey(
//                         name: "FK_Articles_AspNetUsers_UserId",
//                         column: x => x.UserId,
//                         principalTable: "AspNetUsers",
//                         principalColumn: "Id",
//                         onDelete: ReferentialAction.Restrict);
//                 });
//
//             migrationBuilder.CreateTable(
//                 name: "AspNetUserClaims",
//                 columns: table => new
//                 {
//                     Id = table.Column<int>(type: "INTEGER", nullable: false)
//                         .Annotation("Sqlite:Autoincrement", true),
//                     UserId = table.Column<int>(type: "INTEGER", nullable: false),
//                     ClaimType = table.Column<string>(type: "TEXT", nullable: true),
//                     ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
//                 },
//                 constraints: table =>
//                 {
//                     table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
//                     table.ForeignKey(
//                         name: "FK_AspNetUserClaims_AspNetUsers_UserId",
//                         column: x => x.UserId,
//                         principalTable: "AspNetUsers",
//                         principalColumn: "Id",
//                         onDelete: ReferentialAction.Cascade);
//                 });
//
//             migrationBuilder.CreateTable(
//                 name: "AspNetUserLogins",
//                 columns: table => new
//                 {
//                     LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
//                     ProviderKey = table.Column<string>(type: "TEXT", nullable: false),
//                     ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
//                     UserId = table.Column<int>(type: "INTEGER", nullable: false)
//                 },
//                 constraints: table =>
//                 {
//                     table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
//                     table.ForeignKey(
//                         name: "FK_AspNetUserLogins_AspNetUsers_UserId",
//                         column: x => x.UserId,
//                         principalTable: "AspNetUsers",
//                         principalColumn: "Id",
//                         onDelete: ReferentialAction.Cascade);
//                 });
//
//             migrationBuilder.CreateTable(
//                 name: "AspNetUserRoles",
//                 columns: table => new
//                 {
//                     UserId = table.Column<int>(type: "INTEGER", nullable: false),
//                     RoleId = table.Column<int>(type: "INTEGER", nullable: false)
//                 },
//                 constraints: table =>
//                 {
//                     table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
//                     table.ForeignKey(
//                         name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
//                         column: x => x.RoleId,
//                         principalTable: "AspNetRoles",
//                         principalColumn: "Id",
//                         onDelete: ReferentialAction.Cascade);
//                     table.ForeignKey(
//                         name: "FK_AspNetUserRoles_AspNetUsers_UserId",
//                         column: x => x.UserId,
//                         principalTable: "AspNetUsers",
//                         principalColumn: "Id",
//                         onDelete: ReferentialAction.Cascade);
//                 });
//
//             migrationBuilder.CreateTable(
//                 name: "AspNetUserTokens",
//                 columns: table => new
//                 {
//                     UserId = table.Column<int>(type: "INTEGER", nullable: false),
//                     LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
//                     Name = table.Column<string>(type: "TEXT", nullable: false),
//                     Value = table.Column<string>(type: "TEXT", nullable: true)
//                 },
//                 constraints: table =>
//                 {
//                     table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
//                     table.ForeignKey(
//                         name: "FK_AspNetUserTokens_AspNetUsers_UserId",
//                         column: x => x.UserId,
//                         principalTable: "AspNetUsers",
//                         principalColumn: "Id",
//                         onDelete: ReferentialAction.Cascade);
//                 });
//
//             migrationBuilder.CreateTable(
//                 name: "ForumThread",
//                 columns: table => new
//                 {
//                     ForumThreadId = table.Column<int>(type: "INTEGER", nullable: false)
//                         .Annotation("Sqlite:Autoincrement", true),
//                     Title = table.Column<string>(type: "TEXT", nullable: true),
//                     Content = table.Column<string>(type: "TEXT", nullable: true),
//                     ThreadDate = table.Column<DateTime>(type: "TEXT", nullable: false),
//                     UserId = table.Column<int>(type: "INTEGER", nullable: true)
//                 },
//                 constraints: table =>
//                 {
//                     table.PrimaryKey("PK_ForumThread", x => x.ForumThreadId);
//                     table.ForeignKey(
//                         name: "FK_ForumThread_AspNetUsers_UserId",
//                         column: x => x.UserId,
//                         principalTable: "AspNetUsers",
//                         principalColumn: "Id",
//                         onDelete: ReferentialAction.Restrict);
//                 });
//
//             migrationBuilder.CreateTable(
//                 name: "Messages",
//                 columns: table => new
//                 {
//                     MessageId = table.Column<int>(type: "INTEGER", nullable: false)
//                         .Annotation("Sqlite:Autoincrement", true),
//                     SenderId = table.Column<int>(type: "INTEGER", nullable: false),
//                     SenderUsername = table.Column<string>(type: "TEXT", nullable: true),
//                     RecipientId = table.Column<int>(type: "INTEGER", nullable: false),
//                     RecipientUsername = table.Column<string>(type: "TEXT", nullable: true),
//                     Content = table.Column<string>(type: "TEXT", nullable: true),
//                     DateRead = table.Column<DateTime>(type: "TEXT", nullable: true),
//                     MessageSent = table.Column<DateTime>(type: "TEXT", nullable: false),
//                     SenderDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
//                     RecipientDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
//                 },
//                 constraints: table =>
//                 {
//                     table.PrimaryKey("PK_Messages", x => x.MessageId);
//                     table.ForeignKey(
//                         name: "FK_Messages_AspNetUsers_RecipientId",
//                         column: x => x.RecipientId,
//                         principalTable: "AspNetUsers",
//                         principalColumn: "Id",
//                         onDelete: ReferentialAction.Restrict);
//                     table.ForeignKey(
//                         name: "FK_Messages_AspNetUsers_SenderId",
//                         column: x => x.SenderId,
//                         principalTable: "AspNetUsers",
//                         principalColumn: "Id",
//                         onDelete: ReferentialAction.Restrict);
//                 });
//
//             migrationBuilder.CreateTable(
//                 name: "Photos",
//                 columns: table => new
//                 {
//                     PhotoId = table.Column<int>(type: "INTEGER", nullable: false)
//                         .Annotation("Sqlite:Autoincrement", true),
//                     Url = table.Column<string>(type: "TEXT", nullable: true),
//                     IsMain = table.Column<bool>(type: "INTEGER", nullable: false),
//                     PublicId = table.Column<string>(type: "TEXT", nullable: true),
//                     UserId = table.Column<int>(type: "INTEGER", nullable: false)
//                 },
//                 constraints: table =>
//                 {
//                     table.PrimaryKey("PK_Photos", x => x.PhotoId);
//                     table.ForeignKey(
//                         name: "FK_Photos_AspNetUsers_UserId",
//                         column: x => x.UserId,
//                         principalTable: "AspNetUsers",
//                         principalColumn: "Id",
//                         onDelete: ReferentialAction.Cascade);
//                 });
//
//             migrationBuilder.CreateTable(
//                 name: "Reminder",
//                 columns: table => new
//                 {
//                     ReminderId = table.Column<int>(type: "INTEGER", nullable: false)
//                         .Annotation("Sqlite:Autoincrement", true),
//                     Title = table.Column<string>(type: "TEXT", nullable: true),
//                     Content = table.Column<string>(type: "TEXT", nullable: true),
//                     ReminderDate = table.Column<DateTime>(type: "TEXT", nullable: false),
//                     UserId = table.Column<int>(type: "INTEGER", nullable: true)
//                 },
//                 constraints: table =>
//                 {
//                     table.PrimaryKey("PK_Reminder", x => x.ReminderId);
//                     table.ForeignKey(
//                         name: "FK_Reminder_AspNetUsers_UserId",
//                         column: x => x.UserId,
//                         principalTable: "AspNetUsers",
//                         principalColumn: "Id",
//                         onDelete: ReferentialAction.Restrict);
//                 });
//
//             migrationBuilder.CreateTable(
//                 name: "TeamUsers",
//                 columns: table => new
//                 {
//                     TeamUserId = table.Column<int>(type: "INTEGER", nullable: false)
//                         .Annotation("Sqlite:Autoincrement", true),
//                     UserId = table.Column<int>(type: "INTEGER", nullable: false),
//                     TeamId = table.Column<int>(type: "INTEGER", nullable: false)
//                 },
//                 constraints: table =>
//                 {
//                     table.PrimaryKey("PK_TeamUsers", x => x.TeamUserId);
//                     table.ForeignKey(
//                         name: "FK_TeamUsers_AspNetUsers_UserId",
//                         column: x => x.UserId,
//                         principalTable: "AspNetUsers",
//                         principalColumn: "Id",
//                         onDelete: ReferentialAction.Cascade);
//                     table.ForeignKey(
//                         name: "FK_TeamUsers_Teams_TeamId",
//                         column: x => x.TeamId,
//                         principalTable: "Teams",
//                         principalColumn: "TeamId",
//                         onDelete: ReferentialAction.Cascade);
//                 });
//
//             migrationBuilder.CreateTable(
//                 name: "ForumPost",
//                 columns: table => new
//                 {
//                     ForumPostId = table.Column<int>(type: "INTEGER", nullable: false)
//                         .Annotation("Sqlite:Autoincrement", true),
//                     Content = table.Column<string>(type: "TEXT", nullable: true),
//                     PostDate = table.Column<DateTime>(type: "TEXT", nullable: false),
//                     UserId = table.Column<int>(type: "INTEGER", nullable: true),
//                     ForumThreadId = table.Column<int>(type: "INTEGER", nullable: true)
//                 },
//                 constraints: table =>
//                 {
//                     table.PrimaryKey("PK_ForumPost", x => x.ForumPostId);
//                     table.ForeignKey(
//                         name: "FK_ForumPost_AspNetUsers_UserId",
//                         column: x => x.UserId,
//                         principalTable: "AspNetUsers",
//                         principalColumn: "Id",
//                         onDelete: ReferentialAction.Restrict);
//                     table.ForeignKey(
//                         name: "FK_ForumPost_ForumThread_ForumThreadId",
//                         column: x => x.ForumThreadId,
//                         principalTable: "ForumThread",
//                         principalColumn: "ForumThreadId",
//                         onDelete: ReferentialAction.Restrict);
//                 });
//
//             migrationBuilder.CreateIndex(
//                 name: "IX_Achievements_ProfileId",
//                 table: "Achievements",
//                 column: "ProfileId");
//
//             migrationBuilder.CreateIndex(
//                 name: "IX_Articles_UserId",
//                 table: "Articles",
//                 column: "UserId");
//
//             migrationBuilder.CreateIndex(
//                 name: "IX_AspNetRoleClaims_RoleId",
//                 table: "AspNetRoleClaims",
//                 column: "RoleId");
//
//             migrationBuilder.CreateIndex(
//                 name: "RoleNameIndex",
//                 table: "AspNetRoles",
//                 column: "NormalizedName",
//                 unique: true);
//
//             migrationBuilder.CreateIndex(
//                 name: "IX_AspNetUserClaims_UserId",
//                 table: "AspNetUserClaims",
//                 column: "UserId");
//
//             migrationBuilder.CreateIndex(
//                 name: "IX_AspNetUserLogins_UserId",
//                 table: "AspNetUserLogins",
//                 column: "UserId");
//
//             migrationBuilder.CreateIndex(
//                 name: "IX_AspNetUserRoles_RoleId",
//                 table: "AspNetUserRoles",
//                 column: "RoleId");
//
//             migrationBuilder.CreateIndex(
//                 name: "EmailIndex",
//                 table: "AspNetUsers",
//                 column: "NormalizedEmail");
//
//             migrationBuilder.CreateIndex(
//                 name: "IX_AspNetUsers_ChatUsersId",
//                 table: "AspNetUsers",
//                 column: "ChatUsersId");
//
//             migrationBuilder.CreateIndex(
//                 name: "IX_AspNetUsers_EventRegistrationId",
//                 table: "AspNetUsers",
//                 column: "EventRegistrationId");
//
//             migrationBuilder.CreateIndex(
//                 name: "UserNameIndex",
//                 table: "AspNetUsers",
//                 column: "NormalizedUserName",
//                 unique: true);
//
//             migrationBuilder.CreateIndex(
//                 name: "IX_ChatUsers_ChatId",
//                 table: "ChatUsers",
//                 column: "ChatId");
//
//             migrationBuilder.CreateIndex(
//                 name: "IX_Connections_GroupName",
//                 table: "Connections",
//                 column: "GroupName");
//
//             migrationBuilder.CreateIndex(
//                 name: "IX_EventRegistrations_EventId",
//                 table: "EventRegistrations",
//                 column: "EventId");
//
//             migrationBuilder.CreateIndex(
//                 name: "IX_EventResults_EventId",
//                 table: "EventResults",
//                 column: "EventId");
//
//             migrationBuilder.CreateIndex(
//                 name: "IX_Events_GameId",
//                 table: "Events",
//                 column: "GameId");
//
//             migrationBuilder.CreateIndex(
//                 name: "IX_ForumPost_ForumThreadId",
//                 table: "ForumPost",
//                 column: "ForumThreadId");
//
//             migrationBuilder.CreateIndex(
//                 name: "IX_ForumPost_UserId",
//                 table: "ForumPost",
//                 column: "UserId");
//
//             migrationBuilder.CreateIndex(
//                 name: "IX_ForumThread_UserId",
//                 table: "ForumThread",
//                 column: "UserId");
//
//             migrationBuilder.CreateIndex(
//                 name: "IX_GameStatistics_GameId",
//                 table: "GameStatistics",
//                 column: "GameId");
//
//             migrationBuilder.CreateIndex(
//                 name: "IX_GameStatistics_ProfileId",
//                 table: "GameStatistics",
//                 column: "ProfileId");
//
//             migrationBuilder.CreateIndex(
//                 name: "IX_GeneralStatistics_ProfileId",
//                 table: "GeneralStatistics",
//                 column: "ProfileId");
//
//             migrationBuilder.CreateIndex(
//                 name: "IX_Messages_RecipientId",
//                 table: "Messages",
//                 column: "RecipientId");
//
//             migrationBuilder.CreateIndex(
//                 name: "IX_Messages_SenderId",
//                 table: "Messages",
//                 column: "SenderId");
//
//             migrationBuilder.CreateIndex(
//                 name: "IX_Photos_UserId",
//                 table: "Photos",
//                 column: "UserId");
//
//             migrationBuilder.CreateIndex(
//                 name: "IX_Reminder_UserId",
//                 table: "Reminder",
//                 column: "UserId");
//
//             migrationBuilder.CreateIndex(
//                 name: "IX_Streams_GameId",
//                 table: "Streams",
//                 column: "GameId");
//
//             migrationBuilder.CreateIndex(
//                 name: "IX_Teams_EventRegistrationId1",
//                 table: "Teams",
//                 column: "EventRegistrationId1");
//
//             migrationBuilder.CreateIndex(
//                 name: "IX_TeamUsers_TeamId",
//                 table: "TeamUsers",
//                 column: "TeamId");
//
//             migrationBuilder.CreateIndex(
//                 name: "IX_TeamUsers_UserId",
//                 table: "TeamUsers",
//                 column: "UserId");
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
//                 name: "AspNetRoleClaims");
//
//             migrationBuilder.DropTable(
//                 name: "AspNetUserClaims");
//
//             migrationBuilder.DropTable(
//                 name: "AspNetUserLogins");
//
//             migrationBuilder.DropTable(
//                 name: "AspNetUserRoles");
//
//             migrationBuilder.DropTable(
//                 name: "AspNetUserTokens");
//
//             migrationBuilder.DropTable(
//                 name: "Connections");
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
//                 name: "Photos");
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
//                 name: "AspNetRoles");
//
//             migrationBuilder.DropTable(
//                 name: "Groups");
//
//             migrationBuilder.DropTable(
//                 name: "ForumThread");
//
//             migrationBuilder.DropTable(
//                 name: "Profile");
//
//             migrationBuilder.DropTable(
//                 name: "Teams");
//
//             migrationBuilder.DropTable(
//                 name: "AspNetUsers");
//
//             migrationBuilder.DropTable(
//                 name: "ChatUsers");
//
//             migrationBuilder.DropTable(
//                 name: "EventRegistrations");
//
//             migrationBuilder.DropTable(
//                 name: "Chats");
//
//             migrationBuilder.DropTable(
//                 name: "Events");
//
//             migrationBuilder.DropTable(
//                 name: "Games");
//         }
//     }
// }
