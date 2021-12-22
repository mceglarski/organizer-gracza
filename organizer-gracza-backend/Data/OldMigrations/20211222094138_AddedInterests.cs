// using System;
// using Microsoft.EntityFrameworkCore.Migrations;
//
// namespace organizer_gracza_backend.Data.Migrations
// {
//     public partial class AddedInterests : Migration
//     {
//         protected override void Up(MigrationBuilder migrationBuilder)
//         {
//             migrationBuilder.DropForeignKey(
//                 name: "FK_ForumPost_AspNetUsers_UserId",
//                 table: "ForumPost");
//
//             migrationBuilder.DropForeignKey(
//                 name: "FK_ForumPost_ForumThread_ForumThreadId",
//                 table: "ForumPost");
//
//             migrationBuilder.DropForeignKey(
//                 name: "FK_ForumThread_AspNetUsers_UserId",
//                 table: "ForumThread");
//
//             migrationBuilder.DropForeignKey(
//                 name: "FK_ForumThread_Games_GameId",
//                 table: "ForumThread");
//
//             migrationBuilder.AlterColumn<int>(
//                 name: "UserId",
//                 table: "ForumThread",
//                 type: "INTEGER",
//                 nullable: false,
//                 defaultValue: 0,
//                 oldClrType: typeof(int),
//                 oldType: "INTEGER",
//                 oldNullable: true);
//
//             migrationBuilder.AlterColumn<DateTime>(
//                 name: "ThreadDate",
//                 table: "ForumThread",
//                 type: "TEXT",
//                 nullable: false,
//                 defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
//                 oldClrType: typeof(DateTime),
//                 oldType: "TEXT",
//                 oldNullable: true);
//
//             migrationBuilder.AlterColumn<int>(
//                 name: "GameId",
//                 table: "ForumThread",
//                 type: "INTEGER",
//                 nullable: false,
//                 defaultValue: 0,
//                 oldClrType: typeof(int),
//                 oldType: "INTEGER",
//                 oldNullable: true);
//
//             migrationBuilder.AlterColumn<int>(
//                 name: "UserId",
//                 table: "ForumPost",
//                 type: "INTEGER",
//                 nullable: false,
//                 defaultValue: 0,
//                 oldClrType: typeof(int),
//                 oldType: "INTEGER",
//                 oldNullable: true);
//
//             migrationBuilder.AlterColumn<DateTime>(
//                 name: "PostDate",
//                 table: "ForumPost",
//                 type: "TEXT",
//                 nullable: false,
//                 defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
//                 oldClrType: typeof(DateTime),
//                 oldType: "TEXT",
//                 oldNullable: true);
//
//             migrationBuilder.AlterColumn<int>(
//                 name: "ForumThreadId",
//                 table: "ForumPost",
//                 type: "INTEGER",
//                 nullable: false,
//                 defaultValue: 0,
//                 oldClrType: typeof(int),
//                 oldType: "INTEGER",
//                 oldNullable: true);
//
//             migrationBuilder.AddColumn<string>(
//                 name: "Description",
//                 table: "AspNetUsers",
//                 type: "TEXT",
//                 nullable: true);
//
//             migrationBuilder.CreateTable(
//                 name: "UserGame",
//                 columns: table => new
//                 {
//                     UserGameId = table.Column<int>(type: "INTEGER", nullable: false)
//                         .Annotation("Sqlite:Autoincrement", true),
//                     UserId = table.Column<int>(type: "INTEGER", nullable: false),
//                     GameId = table.Column<int>(type: "INTEGER", nullable: false)
//                 },
//                 constraints: table =>
//                 {
//                     table.PrimaryKey("PK_UserGame", x => x.UserGameId);
//                     table.ForeignKey(
//                         name: "FK_UserGame_AspNetUsers_UserId",
//                         column: x => x.UserId,
//                         principalTable: "AspNetUsers",
//                         principalColumn: "Id",
//                         onDelete: ReferentialAction.Cascade);
//                     table.ForeignKey(
//                         name: "FK_UserGame_Games_GameId",
//                         column: x => x.GameId,
//                         principalTable: "Games",
//                         principalColumn: "GameId",
//                         onDelete: ReferentialAction.Cascade);
//                 });
//
//             migrationBuilder.CreateIndex(
//                 name: "IX_UserGame_GameId",
//                 table: "UserGame",
//                 column: "GameId");
//
//             migrationBuilder.CreateIndex(
//                 name: "IX_UserGame_UserId",
//                 table: "UserGame",
//                 column: "UserId");
//
//             migrationBuilder.AddForeignKey(
//                 name: "FK_ForumPost_AspNetUsers_UserId",
//                 table: "ForumPost",
//                 column: "UserId",
//                 principalTable: "AspNetUsers",
//                 principalColumn: "Id",
//                 onDelete: ReferentialAction.Cascade);
//
//             migrationBuilder.AddForeignKey(
//                 name: "FK_ForumPost_ForumThread_ForumThreadId",
//                 table: "ForumPost",
//                 column: "ForumThreadId",
//                 principalTable: "ForumThread",
//                 principalColumn: "ForumThreadId",
//                 onDelete: ReferentialAction.Cascade);
//
//             migrationBuilder.AddForeignKey(
//                 name: "FK_ForumThread_AspNetUsers_UserId",
//                 table: "ForumThread",
//                 column: "UserId",
//                 principalTable: "AspNetUsers",
//                 principalColumn: "Id",
//                 onDelete: ReferentialAction.Cascade);
//
//             migrationBuilder.AddForeignKey(
//                 name: "FK_ForumThread_Games_GameId",
//                 table: "ForumThread",
//                 column: "GameId",
//                 principalTable: "Games",
//                 principalColumn: "GameId",
//                 onDelete: ReferentialAction.Cascade);
//         }
//
//         protected override void Down(MigrationBuilder migrationBuilder)
//         {
//             migrationBuilder.DropForeignKey(
//                 name: "FK_ForumPost_AspNetUsers_UserId",
//                 table: "ForumPost");
//
//             migrationBuilder.DropForeignKey(
//                 name: "FK_ForumPost_ForumThread_ForumThreadId",
//                 table: "ForumPost");
//
//             migrationBuilder.DropForeignKey(
//                 name: "FK_ForumThread_AspNetUsers_UserId",
//                 table: "ForumThread");
//
//             migrationBuilder.DropForeignKey(
//                 name: "FK_ForumThread_Games_GameId",
//                 table: "ForumThread");
//
//             migrationBuilder.DropTable(
//                 name: "UserGame");
//
//             migrationBuilder.DropColumn(
//                 name: "Description",
//                 table: "AspNetUsers");
//
//             migrationBuilder.AlterColumn<int>(
//                 name: "UserId",
//                 table: "ForumThread",
//                 type: "INTEGER",
//                 nullable: true,
//                 oldClrType: typeof(int),
//                 oldType: "INTEGER");
//
//             migrationBuilder.AlterColumn<DateTime>(
//                 name: "ThreadDate",
//                 table: "ForumThread",
//                 type: "TEXT",
//                 nullable: true,
//                 oldClrType: typeof(DateTime),
//                 oldType: "TEXT");
//
//             migrationBuilder.AlterColumn<int>(
//                 name: "GameId",
//                 table: "ForumThread",
//                 type: "INTEGER",
//                 nullable: true,
//                 oldClrType: typeof(int),
//                 oldType: "INTEGER");
//
//             migrationBuilder.AlterColumn<int>(
//                 name: "UserId",
//                 table: "ForumPost",
//                 type: "INTEGER",
//                 nullable: true,
//                 oldClrType: typeof(int),
//                 oldType: "INTEGER");
//
//             migrationBuilder.AlterColumn<DateTime>(
//                 name: "PostDate",
//                 table: "ForumPost",
//                 type: "TEXT",
//                 nullable: true,
//                 oldClrType: typeof(DateTime),
//                 oldType: "TEXT");
//
//             migrationBuilder.AlterColumn<int>(
//                 name: "ForumThreadId",
//                 table: "ForumPost",
//                 type: "INTEGER",
//                 nullable: true,
//                 oldClrType: typeof(int),
//                 oldType: "INTEGER");
//
//             migrationBuilder.AddForeignKey(
//                 name: "FK_ForumPost_AspNetUsers_UserId",
//                 table: "ForumPost",
//                 column: "UserId",
//                 principalTable: "AspNetUsers",
//                 principalColumn: "Id",
//                 onDelete: ReferentialAction.Restrict);
//
//             migrationBuilder.AddForeignKey(
//                 name: "FK_ForumPost_ForumThread_ForumThreadId",
//                 table: "ForumPost",
//                 column: "ForumThreadId",
//                 principalTable: "ForumThread",
//                 principalColumn: "ForumThreadId",
//                 onDelete: ReferentialAction.Restrict);
//
//             migrationBuilder.AddForeignKey(
//                 name: "FK_ForumThread_AspNetUsers_UserId",
//                 table: "ForumThread",
//                 column: "UserId",
//                 principalTable: "AspNetUsers",
//                 principalColumn: "Id",
//                 onDelete: ReferentialAction.Restrict);
//
//             migrationBuilder.AddForeignKey(
//                 name: "FK_ForumThread_Games_GameId",
//                 table: "ForumThread",
//                 column: "GameId",
//                 principalTable: "Games",
//                 principalColumn: "GameId",
//                 onDelete: ReferentialAction.Restrict);
//         }
//     }
// }
