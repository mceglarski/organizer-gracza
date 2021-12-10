// using Microsoft.EntityFrameworkCore.Migrations;
//
// namespace organizer_gracza_backend.Data.Migrations
// {
//     public partial class ModifiedGameStatistics : Migration
//     {
//         protected override void Up(MigrationBuilder migrationBuilder)
//         {
//             migrationBuilder.DropIndex(
//                 name: "IX_GameStatistics_GameId",
//                 table: "GameStatistics");
//
//             migrationBuilder.CreateIndex(
//                 name: "IX_GameStatistics_GameId",
//                 table: "GameStatistics",
//                 column: "GameId");
//         }
//
//         protected override void Down(MigrationBuilder migrationBuilder)
//         {
//             migrationBuilder.DropIndex(
//                 name: "IX_GameStatistics_GameId",
//                 table: "GameStatistics");
//
//             migrationBuilder.CreateIndex(
//                 name: "IX_GameStatistics_GameId",
//                 table: "GameStatistics",
//                 column: "GameId",
//                 unique: true);
//         }
//     }
// }
