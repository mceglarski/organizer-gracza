// using Microsoft.EntityFrameworkCore.Migrations;
//
// namespace organizer_gracza_backend.Data.Migrations
// {
//     public partial class UpdatedArticlesModel : Migration
//     {
//         protected override void Up(MigrationBuilder migrationBuilder)
//         {
//             migrationBuilder.DropForeignKey(
//                 name: "FK_Articles_AspNetUsers_UserId",
//                 table: "Articles");
//
//             migrationBuilder.AlterColumn<int>(
//                 name: "UserId",
//                 table: "Articles",
//                 type: "INTEGER",
//                 nullable: false,
//                 defaultValue: 0,
//                 oldClrType: typeof(int),
//                 oldType: "INTEGER",
//                 oldNullable: true);
//
//             migrationBuilder.AddColumn<string>(
//                 name: "PhotoUrl",
//                 table: "Articles",
//                 type: "TEXT",
//                 nullable: true);
//
//             migrationBuilder.AddForeignKey(
//                 name: "FK_Articles_AspNetUsers_UserId",
//                 table: "Articles",
//                 column: "UserId",
//                 principalTable: "AspNetUsers",
//                 principalColumn: "Id",
//                 onDelete: ReferentialAction.Cascade);
//         }
//
//         protected override void Down(MigrationBuilder migrationBuilder)
//         {
//             migrationBuilder.DropForeignKey(
//                 name: "FK_Articles_AspNetUsers_UserId",
//                 table: "Articles");
//
//             migrationBuilder.DropColumn(
//                 name: "PhotoUrl",
//                 table: "Articles");
//
//             migrationBuilder.AlterColumn<int>(
//                 name: "UserId",
//                 table: "Articles",
//                 type: "INTEGER",
//                 nullable: true,
//                 oldClrType: typeof(int),
//                 oldType: "INTEGER");
//
//             migrationBuilder.AddForeignKey(
//                 name: "FK_Articles_AspNetUsers_UserId",
//                 table: "Articles",
//                 column: "UserId",
//                 principalTable: "AspNetUsers",
//                 principalColumn: "Id",
//                 onDelete: ReferentialAction.Restrict);
//         }
//     }
// }
