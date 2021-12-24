// using Microsoft.EntityFrameworkCore.Migrations;
//
// namespace organizer_gracza_backend.Data.Migrations
// {
//     public partial class ModifiedResultsLogic : Migration
//     {
//         protected override void Up(MigrationBuilder migrationBuilder)
//         {
//             migrationBuilder.AddColumn<int>(
//                 name: "EventUserResultId",
//                 table: "EventUser",
//                 type: "INTEGER",
//                 nullable: true);
//
//             migrationBuilder.CreateTable(
//                 name: "EventUserResult",
//                 columns: table => new
//                 {
//                     EventUserResultId = table.Column<int>(type: "INTEGER", nullable: false)
//                         .Annotation("Sqlite:Autoincrement", true),
//                     UserId = table.Column<int>(type: "INTEGER", nullable: true),
//                     EventUserId = table.Column<int>(type: "INTEGER", nullable: true)
//                 },
//                 constraints: table =>
//                 {
//                     table.PrimaryKey("PK_EventUserResult", x => x.EventUserResultId);
//                     table.ForeignKey(
//                         name: "FK_EventUserResult_AspNetUsers_UserId",
//                         column: x => x.UserId,
//                         principalTable: "AspNetUsers",
//                         principalColumn: "Id",
//                         onDelete: ReferentialAction.Restrict);
//                     table.ForeignKey(
//                         name: "FK_EventUserResult_EventUser_EventUserId",
//                         column: x => x.EventUserId,
//                         principalTable: "EventUser",
//                         principalColumn: "EventUserId",
//                         onDelete: ReferentialAction.Restrict);
//                 });
//
//             migrationBuilder.CreateIndex(
//                 name: "IX_EventUserResult_EventUserId",
//                 table: "EventUserResult",
//                 column: "EventUserId",
//                 unique: true);
//
//             migrationBuilder.CreateIndex(
//                 name: "IX_EventUserResult_UserId",
//                 table: "EventUserResult",
//                 column: "UserId");
//         }
//
//         protected override void Down(MigrationBuilder migrationBuilder)
//         {
//             migrationBuilder.DropTable(
//                 name: "EventUserResult");
//
//             migrationBuilder.DropColumn(
//                 name: "EventUserResultId",
//                 table: "EventUser");
//         }
//     }
// }
