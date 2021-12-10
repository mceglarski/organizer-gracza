// using System;
// using Microsoft.EntityFrameworkCore.Migrations;
//
// namespace organizer_gracza_backend.Data.Migrations
// {
//     public partial class ModifiedEventModels : Migration
//     {
//         protected override void Up(MigrationBuilder migrationBuilder)
//         {
//             migrationBuilder.DropForeignKey(
//                 name: "FK_EventResults_Events_EventId",
//                 table: "EventResults");
//
//             migrationBuilder.DropTable(
//                 name: "EventRegistrations");
//
//             migrationBuilder.DropTable(
//                 name: "Events");
//
//             migrationBuilder.DropIndex(
//                 name: "IX_EventResults_EventId",
//                 table: "EventResults");
//
//             migrationBuilder.DropColumn(
//                 name: "EventId",
//                 table: "EventResults");
//
//             migrationBuilder.AddColumn<string>(
//                 name: "PhotoUrl",
//                 table: "Teams",
//                 type: "TEXT",
//                 nullable: true);
//
//             migrationBuilder.CreateTable(
//                 name: "EventTeam",
//                 columns: table => new
//                 {
//                     EventTeamId = table.Column<int>(type: "INTEGER", nullable: false)
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
//                     table.PrimaryKey("PK_EventTeam", x => x.EventTeamId);
//                     table.ForeignKey(
//                         name: "FK_EventTeam_Games_GameId",
//                         column: x => x.GameId,
//                         principalTable: "Games",
//                         principalColumn: "GameId",
//                         onDelete: ReferentialAction.Restrict);
//                 });
//
//             migrationBuilder.CreateTable(
//                 name: "EventUser",
//                 columns: table => new
//                 {
//                     EventUserId = table.Column<int>(type: "INTEGER", nullable: false)
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
//                     table.PrimaryKey("PK_EventUser", x => x.EventUserId);
//                     table.ForeignKey(
//                         name: "FK_EventUser_Games_GameId",
//                         column: x => x.GameId,
//                         principalTable: "Games",
//                         principalColumn: "GameId",
//                         onDelete: ReferentialAction.Restrict);
//                 });
//
//             migrationBuilder.CreateTable(
//                 name: "EventTeamRegistration",
//                 columns: table => new
//                 {
//                     EventTeamRegistrationId = table.Column<int>(type: "INTEGER", nullable: false)
//                         .Annotation("Sqlite:Autoincrement", true),
//                     TeamId = table.Column<int>(type: "INTEGER", nullable: false),
//                     EventTeamId = table.Column<int>(type: "INTEGER", nullable: false)
//                 },
//                 constraints: table =>
//                 {
//                     table.PrimaryKey("PK_EventTeamRegistration", x => x.EventTeamRegistrationId);
//                     table.ForeignKey(
//                         name: "FK_EventTeamRegistration_EventTeam_EventTeamId",
//                         column: x => x.EventTeamId,
//                         principalTable: "EventTeam",
//                         principalColumn: "EventTeamId",
//                         onDelete: ReferentialAction.Cascade);
//                     table.ForeignKey(
//                         name: "FK_EventTeamRegistration_Teams_TeamId",
//                         column: x => x.TeamId,
//                         principalTable: "Teams",
//                         principalColumn: "TeamId",
//                         onDelete: ReferentialAction.Cascade);
//                 });
//
//             migrationBuilder.CreateTable(
//                 name: "EventUserRegistration",
//                 columns: table => new
//                 {
//                     EventUserRegistrationId = table.Column<int>(type: "INTEGER", nullable: false)
//                         .Annotation("Sqlite:Autoincrement", true),
//                     UserId = table.Column<int>(type: "INTEGER", nullable: false),
//                     EventUserId = table.Column<int>(type: "INTEGER", nullable: false)
//                 },
//                 constraints: table =>
//                 {
//                     table.PrimaryKey("PK_EventUserRegistration", x => x.EventUserRegistrationId);
//                     table.ForeignKey(
//                         name: "FK_EventUserRegistration_AspNetUsers_UserId",
//                         column: x => x.UserId,
//                         principalTable: "AspNetUsers",
//                         principalColumn: "Id",
//                         onDelete: ReferentialAction.Cascade);
//                     table.ForeignKey(
//                         name: "FK_EventUserRegistration_EventUser_EventUserId",
//                         column: x => x.EventUserId,
//                         principalTable: "EventUser",
//                         principalColumn: "EventUserId",
//                         onDelete: ReferentialAction.Cascade);
//                 });
//
//             migrationBuilder.CreateIndex(
//                 name: "IX_EventTeam_GameId",
//                 table: "EventTeam",
//                 column: "GameId");
//
//             migrationBuilder.CreateIndex(
//                 name: "IX_EventTeamRegistration_EventTeamId",
//                 table: "EventTeamRegistration",
//                 column: "EventTeamId");
//
//             migrationBuilder.CreateIndex(
//                 name: "IX_EventTeamRegistration_TeamId",
//                 table: "EventTeamRegistration",
//                 column: "TeamId");
//
//             migrationBuilder.CreateIndex(
//                 name: "IX_EventUser_GameId",
//                 table: "EventUser",
//                 column: "GameId");
//
//             migrationBuilder.CreateIndex(
//                 name: "IX_EventUserRegistration_EventUserId",
//                 table: "EventUserRegistration",
//                 column: "EventUserId");
//
//             migrationBuilder.CreateIndex(
//                 name: "IX_EventUserRegistration_UserId",
//                 table: "EventUserRegistration",
//                 column: "UserId");
//         }
//
//         protected override void Down(MigrationBuilder migrationBuilder)
//         {
//             migrationBuilder.DropTable(
//                 name: "EventTeamRegistration");
//
//             migrationBuilder.DropTable(
//                 name: "EventUserRegistration");
//
//             migrationBuilder.DropTable(
//                 name: "EventTeam");
//
//             migrationBuilder.DropTable(
//                 name: "EventUser");
//
//             migrationBuilder.DropColumn(
//                 name: "PhotoUrl",
//                 table: "Teams");
//
//             migrationBuilder.AddColumn<int>(
//                 name: "EventId",
//                 table: "EventResults",
//                 type: "INTEGER",
//                 nullable: true);
//
//             migrationBuilder.CreateTable(
//                 name: "Events",
//                 columns: table => new
//                 {
//                     EventId = table.Column<int>(type: "INTEGER", nullable: false)
//                         .Annotation("Sqlite:Autoincrement", true),
//                     Description = table.Column<string>(type: "TEXT", nullable: true),
//                     EndDate = table.Column<DateTime>(type: "TEXT", nullable: true),
//                     EventOrganiser = table.Column<string>(type: "TEXT", nullable: true),
//                     EventType = table.Column<string>(type: "TEXT", nullable: true),
//                     GameId = table.Column<int>(type: "INTEGER", nullable: true),
//                     Name = table.Column<string>(type: "TEXT", nullable: true),
//                     PhotoUrl = table.Column<string>(type: "TEXT", nullable: true),
//                     StartDate = table.Column<DateTime>(type: "TEXT", nullable: true),
//                     WinnerPrize = table.Column<double>(type: "REAL", nullable: true)
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
//                 name: "EventRegistrations",
//                 columns: table => new
//                 {
//                     EventRegistrationId = table.Column<int>(type: "INTEGER", nullable: false)
//                         .Annotation("Sqlite:Autoincrement", true),
//                     EventId = table.Column<int>(type: "INTEGER", nullable: false),
//                     TeamId = table.Column<int>(type: "INTEGER", nullable: true),
//                     UserId = table.Column<int>(type: "INTEGER", nullable: true)
//                 },
//                 constraints: table =>
//                 {
//                     table.PrimaryKey("PK_EventRegistrations", x => x.EventRegistrationId);
//                     table.ForeignKey(
//                         name: "FK_EventRegistrations_AspNetUsers_UserId",
//                         column: x => x.UserId,
//                         principalTable: "AspNetUsers",
//                         principalColumn: "Id",
//                         onDelete: ReferentialAction.Restrict);
//                     table.ForeignKey(
//                         name: "FK_EventRegistrations_Events_EventId",
//                         column: x => x.EventId,
//                         principalTable: "Events",
//                         principalColumn: "EventId",
//                         onDelete: ReferentialAction.Cascade);
//                     table.ForeignKey(
//                         name: "FK_EventRegistrations_Teams_TeamId",
//                         column: x => x.TeamId,
//                         principalTable: "Teams",
//                         principalColumn: "TeamId",
//                         onDelete: ReferentialAction.Restrict);
//                 });
//
//             migrationBuilder.CreateIndex(
//                 name: "IX_EventResults_EventId",
//                 table: "EventResults",
//                 column: "EventId");
//
//             migrationBuilder.CreateIndex(
//                 name: "IX_EventRegistrations_EventId",
//                 table: "EventRegistrations",
//                 column: "EventId");
//
//             migrationBuilder.CreateIndex(
//                 name: "IX_EventRegistrations_TeamId",
//                 table: "EventRegistrations",
//                 column: "TeamId");
//
//             migrationBuilder.CreateIndex(
//                 name: "IX_EventRegistrations_UserId",
//                 table: "EventRegistrations",
//                 column: "UserId");
//
//             migrationBuilder.CreateIndex(
//                 name: "IX_Events_GameId",
//                 table: "Events",
//                 column: "GameId");
//
//             migrationBuilder.AddForeignKey(
//                 name: "FK_EventResults_Events_EventId",
//                 table: "EventResults",
//                 column: "EventId",
//                 principalTable: "Events",
//                 principalColumn: "EventId",
//                 onDelete: ReferentialAction.Restrict);
//         }
//     }
// }
