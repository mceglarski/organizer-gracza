// using Microsoft.EntityFrameworkCore.Migrations;
//
// namespace organizer_gracza_backend.Data.Migrations
// {
//     public partial class ModifiedEventResult : Migration
//     {
//         protected override void Up(MigrationBuilder migrationBuilder)
//         {
//             migrationBuilder.DropIndex(
//                 name: "IX_EventResults_EventTeamRegistrationId",
//                 table: "EventResults");
//
//             migrationBuilder.DropIndex(
//                 name: "IX_EventResults_EventUserRegistrationId",
//                 table: "EventResults");
//
//             migrationBuilder.DropColumn(
//                 name: "EventResultId",
//                 table: "EventUserRegistration");
//
//             migrationBuilder.DropColumn(
//                 name: "EventResultId",
//                 table: "EventTeamRegistration");
//
//             migrationBuilder.AddColumn<int>(
//                 name: "EventResultId",
//                 table: "EventUser",
//                 type: "INTEGER",
//                 nullable: true);
//
//             migrationBuilder.AddColumn<int>(
//                 name: "EventResultId",
//                 table: "EventTeam",
//                 type: "INTEGER",
//                 nullable: true);
//
//             migrationBuilder.CreateIndex(
//                 name: "IX_EventUser_EventResultId",
//                 table: "EventUser",
//                 column: "EventResultId");
//
//             migrationBuilder.CreateIndex(
//                 name: "IX_EventTeam_EventResultId",
//                 table: "EventTeam",
//                 column: "EventResultId");
//
//             migrationBuilder.CreateIndex(
//                 name: "IX_EventResults_EventTeamRegistrationId",
//                 table: "EventResults",
//                 column: "EventTeamRegistrationId");
//
//             migrationBuilder.CreateIndex(
//                 name: "IX_EventResults_EventUserRegistrationId",
//                 table: "EventResults",
//                 column: "EventUserRegistrationId");
//
//             migrationBuilder.AddForeignKey(
//                 name: "FK_EventTeam_EventResults_EventResultId",
//                 table: "EventTeam",
//                 column: "EventResultId",
//                 principalTable: "EventResults",
//                 principalColumn: "EventResultId",
//                 onDelete: ReferentialAction.Restrict);
//
//             migrationBuilder.AddForeignKey(
//                 name: "FK_EventUser_EventResults_EventResultId",
//                 table: "EventUser",
//                 column: "EventResultId",
//                 principalTable: "EventResults",
//                 principalColumn: "EventResultId",
//                 onDelete: ReferentialAction.Restrict);
//         }
//
//         protected override void Down(MigrationBuilder migrationBuilder)
//         {
//             migrationBuilder.DropForeignKey(
//                 name: "FK_EventTeam_EventResults_EventResultId",
//                 table: "EventTeam");
//
//             migrationBuilder.DropForeignKey(
//                 name: "FK_EventUser_EventResults_EventResultId",
//                 table: "EventUser");
//
//             migrationBuilder.DropIndex(
//                 name: "IX_EventUser_EventResultId",
//                 table: "EventUser");
//
//             migrationBuilder.DropIndex(
//                 name: "IX_EventTeam_EventResultId",
//                 table: "EventTeam");
//
//             migrationBuilder.DropIndex(
//                 name: "IX_EventResults_EventTeamRegistrationId",
//                 table: "EventResults");
//
//             migrationBuilder.DropIndex(
//                 name: "IX_EventResults_EventUserRegistrationId",
//                 table: "EventResults");
//
//             migrationBuilder.DropColumn(
//                 name: "EventResultId",
//                 table: "EventUser");
//
//             migrationBuilder.DropColumn(
//                 name: "EventResultId",
//                 table: "EventTeam");
//
//             migrationBuilder.AddColumn<int>(
//                 name: "EventResultId",
//                 table: "EventUserRegistration",
//                 type: "INTEGER",
//                 nullable: true);
//
//             migrationBuilder.AddColumn<int>(
//                 name: "EventResultId",
//                 table: "EventTeamRegistration",
//                 type: "INTEGER",
//                 nullable: true);
//
//             migrationBuilder.CreateIndex(
//                 name: "IX_EventResults_EventTeamRegistrationId",
//                 table: "EventResults",
//                 column: "EventTeamRegistrationId",
//                 unique: true);
//
//             migrationBuilder.CreateIndex(
//                 name: "IX_EventResults_EventUserRegistrationId",
//                 table: "EventResults",
//                 column: "EventUserRegistrationId",
//                 unique: true);
//         }
//     }
// }
