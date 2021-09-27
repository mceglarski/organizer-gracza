﻿// using System;
// using Microsoft.EntityFrameworkCore.Migrations;
//
// namespace organizer_gracza_backend.Data.Migrations
// {
//     public partial class ExtendedUserEntity : Migration
//     {
//         protected override void Up(MigrationBuilder migrationBuilder)
//         {
//             migrationBuilder.AddColumn<DateTime>(
//                 name: "Created",
//                 table: "Users",
//                 type: "TEXT",
//                 nullable: false,
//                 defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
//
//             migrationBuilder.AddColumn<DateTime>(
//                 name: "LastActive",
//                 table: "Users",
//                 type: "TEXT",
//                 nullable: false,
//                 defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
//         }
//
//         protected override void Down(MigrationBuilder migrationBuilder)
//         {
//             migrationBuilder.DropColumn(
//                 name: "Created",
//                 table: "Users");
//
//             migrationBuilder.DropColumn(
//                 name: "LastActive",
//                 table: "Users");
//         }
//     }
// }
