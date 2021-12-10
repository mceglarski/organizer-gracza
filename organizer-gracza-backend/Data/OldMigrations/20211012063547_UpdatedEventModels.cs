// using Microsoft.EntityFrameworkCore.Migrations;
//
// namespace organizer_gracza_backend.Data.Migrations
// {
//     public partial class UpdatedEventModels : Migration
//     {
//         protected override void Up(MigrationBuilder migrationBuilder)
//         {
//             migrationBuilder.DropForeignKey(
//                 name: "FK_AspNetUsers_EventRegistrations_EventRegistrationId",
//                 table: "AspNetUsers");
//
//             migrationBuilder.DropForeignKey(
//                 name: "FK_Teams_EventRegistrations_EventRegistrationId1",
//                 table: "Teams");
//
//             migrationBuilder.DropIndex(
//                 name: "IX_Teams_EventRegistrationId1",
//                 table: "Teams");
//
//             migrationBuilder.DropIndex(
//                 name: "IX_AspNetUsers_EventRegistrationId",
//                 table: "AspNetUsers");
//
//             migrationBuilder.DropColumn(
//                 name: "EventRegistrationId",
//                 table: "Teams");
//
//             migrationBuilder.DropColumn(
//                 name: "EventRegistrationId1",
//                 table: "Teams");
//
//             migrationBuilder.DropColumn(
//                 name: "EventRegistrationId",
//                 table: "AspNetUsers");
//
//             migrationBuilder.AddColumn<int>(
//                 name: "TeamId",
//                 table: "EventRegistrations",
//                 type: "INTEGER",
//                 nullable: true);
//
//             migrationBuilder.AddColumn<int>(
//                 name: "UserId",
//                 table: "EventRegistrations",
//                 type: "INTEGER",
//                 nullable: true);
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
//             migrationBuilder.AddForeignKey(
//                 name: "FK_EventRegistrations_AspNetUsers_UserId",
//                 table: "EventRegistrations",
//                 column: "UserId",
//                 principalTable: "AspNetUsers",
//                 principalColumn: "Id",
//                 onDelete: ReferentialAction.Restrict);
//
//             migrationBuilder.AddForeignKey(
//                 name: "FK_EventRegistrations_Teams_TeamId",
//                 table: "EventRegistrations",
//                 column: "TeamId",
//                 principalTable: "Teams",
//                 principalColumn: "TeamId",
//                 onDelete: ReferentialAction.Restrict);
//         }
//
//         protected override void Down(MigrationBuilder migrationBuilder)
//         {
//             migrationBuilder.DropForeignKey(
//                 name: "FK_EventRegistrations_AspNetUsers_UserId",
//                 table: "EventRegistrations");
//
//             migrationBuilder.DropForeignKey(
//                 name: "FK_EventRegistrations_Teams_TeamId",
//                 table: "EventRegistrations");
//
//             migrationBuilder.DropIndex(
//                 name: "IX_EventRegistrations_TeamId",
//                 table: "EventRegistrations");
//
//             migrationBuilder.DropIndex(
//                 name: "IX_EventRegistrations_UserId",
//                 table: "EventRegistrations");
//
//             migrationBuilder.DropColumn(
//                 name: "TeamId",
//                 table: "EventRegistrations");
//
//             migrationBuilder.DropColumn(
//                 name: "UserId",
//                 table: "EventRegistrations");
//
//             migrationBuilder.AddColumn<string>(
//                 name: "EventRegistrationId",
//                 table: "Teams",
//                 type: "TEXT",
//                 nullable: true);
//
//             migrationBuilder.AddColumn<int>(
//                 name: "EventRegistrationId1",
//                 table: "Teams",
//                 type: "INTEGER",
//                 nullable: true);
//
//             migrationBuilder.AddColumn<int>(
//                 name: "EventRegistrationId",
//                 table: "AspNetUsers",
//                 type: "INTEGER",
//                 nullable: false,
//                 defaultValue: 0);
//
//             migrationBuilder.CreateIndex(
//                 name: "IX_Teams_EventRegistrationId1",
//                 table: "Teams",
//                 column: "EventRegistrationId1");
//
//             migrationBuilder.CreateIndex(
//                 name: "IX_AspNetUsers_EventRegistrationId",
//                 table: "AspNetUsers",
//                 column: "EventRegistrationId");
//
//             migrationBuilder.AddForeignKey(
//                 name: "FK_AspNetUsers_EventRegistrations_EventRegistrationId",
//                 table: "AspNetUsers",
//                 column: "EventRegistrationId",
//                 principalTable: "EventRegistrations",
//                 principalColumn: "EventRegistrationId",
//                 onDelete: ReferentialAction.Cascade);
//
//             migrationBuilder.AddForeignKey(
//                 name: "FK_Teams_EventRegistrations_EventRegistrationId1",
//                 table: "Teams",
//                 column: "EventRegistrationId1",
//                 principalTable: "EventRegistrations",
//                 principalColumn: "EventRegistrationId",
//                 onDelete: ReferentialAction.Restrict);
//         }
//     }
// }
