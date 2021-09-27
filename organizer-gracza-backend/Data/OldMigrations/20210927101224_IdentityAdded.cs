// using System;
// using Microsoft.EntityFrameworkCore.Migrations;
//
// namespace organizer_gracza_backend.Data.Migrations
// {
//     public partial class IdentityAdded : Migration
//     {
//         protected override void Up(MigrationBuilder migrationBuilder)
//         {
//             migrationBuilder.DropForeignKey(
//                 name: "FK_Articles_Users_UserId",
//                 table: "Articles");
//
//             migrationBuilder.DropForeignKey(
//                 name: "FK_EventRegistrations_Users_UserId",
//                 table: "EventRegistrations");
//
//             migrationBuilder.DropForeignKey(
//                 name: "FK_ForumPost_Users_UserId",
//                 table: "ForumPost");
//
//             migrationBuilder.DropForeignKey(
//                 name: "FK_ForumThread_Users_UserId",
//                 table: "ForumThread");
//
//             migrationBuilder.DropForeignKey(
//                 name: "FK_Messages_Users_RecipientId",
//                 table: "Messages");
//
//             migrationBuilder.DropForeignKey(
//                 name: "FK_Messages_Users_SenderId",
//                 table: "Messages");
//
//             migrationBuilder.DropForeignKey(
//                 name: "FK_Photos_Users_UserId",
//                 table: "Photos");
//
//             migrationBuilder.DropForeignKey(
//                 name: "FK_Reminder_Users_UserId",
//                 table: "Reminder");
//
//             migrationBuilder.DropForeignKey(
//                 name: "FK_TeamUsers_Users_UserId",
//                 table: "TeamUsers");
//
//             migrationBuilder.DropForeignKey(
//                 name: "FK_Users_ChatUsers_ChatUsersId",
//                 table: "Users");
//
//             migrationBuilder.DropPrimaryKey(
//                 name: "PK_Users",
//                 table: "Users");
//
//             migrationBuilder.DropColumn(
//                 name: "PasswordSalt",
//                 table: "Users");
//
//             migrationBuilder.RenameTable(
//                 name: "Users",
//                 newName: "AspNetUsers");
//
//             migrationBuilder.RenameColumn(
//                 name: "Username",
//                 table: "AspNetUsers",
//                 newName: "UserName");
//
//             migrationBuilder.RenameColumn(
//                 name: "UserId",
//                 table: "AspNetUsers",
//                 newName: "TwoFactorEnabled");
//
//             migrationBuilder.RenameIndex(
//                 name: "IX_Users_ChatUsersId",
//                 table: "AspNetUsers",
//                 newName: "IX_AspNetUsers_ChatUsersId");
//
//             migrationBuilder.AlterColumn<string>(
//                 name: "PasswordHash",
//                 table: "AspNetUsers",
//                 type: "TEXT",
//                 nullable: true,
//                 oldClrType: typeof(byte[]),
//                 oldType: "BLOB",
//                 oldNullable: true);
//
//             migrationBuilder.AlterColumn<bool>(
//                 name: "TwoFactorEnabled",
//                 table: "AspNetUsers",
//                 type: "INTEGER",
//                 nullable: false,
//                 oldClrType: typeof(int),
//                 oldType: "INTEGER")
//                 .OldAnnotation("Sqlite:Autoincrement", true);
//
//             migrationBuilder.AddColumn<int>(
//                 name: "Id",
//                 table: "AspNetUsers",
//                 type: "INTEGER",
//                 nullable: false,
//                 defaultValue: 0)
//                 .Annotation("Sqlite:Autoincrement", true);
//
//             migrationBuilder.AddColumn<int>(
//                 name: "AccessFailedCount",
//                 table: "AspNetUsers",
//                 type: "INTEGER",
//                 nullable: false,
//                 defaultValue: 0);
//
//             migrationBuilder.AddColumn<string>(
//                 name: "ConcurrencyStamp",
//                 table: "AspNetUsers",
//                 type: "TEXT",
//                 nullable: true);
//
//             migrationBuilder.AddColumn<bool>(
//                 name: "EmailConfirmed",
//                 table: "AspNetUsers",
//                 type: "INTEGER",
//                 nullable: false,
//                 defaultValue: false);
//
//             migrationBuilder.AddColumn<bool>(
//                 name: "LockoutEnabled",
//                 table: "AspNetUsers",
//                 type: "INTEGER",
//                 nullable: false,
//                 defaultValue: false);
//
//             migrationBuilder.AddColumn<DateTimeOffset>(
//                 name: "LockoutEnd",
//                 table: "AspNetUsers",
//                 type: "TEXT",
//                 nullable: true);
//
//             migrationBuilder.AddColumn<string>(
//                 name: "NormalizedEmail",
//                 table: "AspNetUsers",
//                 type: "TEXT",
//                 maxLength: 256,
//                 nullable: true);
//
//             migrationBuilder.AddColumn<string>(
//                 name: "NormalizedUserName",
//                 table: "AspNetUsers",
//                 type: "TEXT",
//                 maxLength: 256,
//                 nullable: true);
//
//             migrationBuilder.AddColumn<string>(
//                 name: "PhoneNumber",
//                 table: "AspNetUsers",
//                 type: "TEXT",
//                 nullable: true);
//
//             migrationBuilder.AddColumn<bool>(
//                 name: "PhoneNumberConfirmed",
//                 table: "AspNetUsers",
//                 type: "INTEGER",
//                 nullable: false,
//                 defaultValue: false);
//
//             migrationBuilder.AddColumn<string>(
//                 name: "SecurityStamp",
//                 table: "AspNetUsers",
//                 type: "TEXT",
//                 nullable: true);
//
//             migrationBuilder.AddPrimaryKey(
//                 name: "PK_AspNetUsers",
//                 table: "AspNetUsers",
//                 column: "Id");
//
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
//             migrationBuilder.CreateIndex(
//                 name: "EmailIndex",
//                 table: "AspNetUsers",
//                 column: "NormalizedEmail");
//
//             migrationBuilder.CreateIndex(
//                 name: "UserNameIndex",
//                 table: "AspNetUsers",
//                 column: "NormalizedUserName",
//                 unique: true);
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
//             migrationBuilder.AddForeignKey(
//                 name: "FK_Articles_AspNetUsers_UserId",
//                 table: "Articles",
//                 column: "UserId",
//                 principalTable: "AspNetUsers",
//                 principalColumn: "Id",
//                 onDelete: ReferentialAction.Restrict);
//
//             migrationBuilder.AddForeignKey(
//                 name: "FK_AspNetUsers_ChatUsers_ChatUsersId",
//                 table: "AspNetUsers",
//                 column: "ChatUsersId",
//                 principalTable: "ChatUsers",
//                 principalColumn: "ChatUsersId",
//                 onDelete: ReferentialAction.Restrict);
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
//                 name: "FK_ForumPost_AspNetUsers_UserId",
//                 table: "ForumPost",
//                 column: "UserId",
//                 principalTable: "AspNetUsers",
//                 principalColumn: "Id",
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
//                 name: "FK_Messages_AspNetUsers_RecipientId",
//                 table: "Messages",
//                 column: "RecipientId",
//                 principalTable: "AspNetUsers",
//                 principalColumn: "Id",
//                 onDelete: ReferentialAction.Restrict);
//
//             migrationBuilder.AddForeignKey(
//                 name: "FK_Messages_AspNetUsers_SenderId",
//                 table: "Messages",
//                 column: "SenderId",
//                 principalTable: "AspNetUsers",
//                 principalColumn: "Id",
//                 onDelete: ReferentialAction.Restrict);
//
//             migrationBuilder.AddForeignKey(
//                 name: "FK_Photos_AspNetUsers_UserId",
//                 table: "Photos",
//                 column: "UserId",
//                 principalTable: "AspNetUsers",
//                 principalColumn: "Id",
//                 onDelete: ReferentialAction.Cascade);
//
//             migrationBuilder.AddForeignKey(
//                 name: "FK_Reminder_AspNetUsers_UserId",
//                 table: "Reminder",
//                 column: "UserId",
//                 principalTable: "AspNetUsers",
//                 principalColumn: "Id",
//                 onDelete: ReferentialAction.Restrict);
//
//             migrationBuilder.AddForeignKey(
//                 name: "FK_TeamUsers_AspNetUsers_UserId",
//                 table: "TeamUsers",
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
//             migrationBuilder.DropForeignKey(
//                 name: "FK_AspNetUsers_ChatUsers_ChatUsersId",
//                 table: "AspNetUsers");
//
//             migrationBuilder.DropForeignKey(
//                 name: "FK_EventRegistrations_AspNetUsers_UserId",
//                 table: "EventRegistrations");
//
//             migrationBuilder.DropForeignKey(
//                 name: "FK_ForumPost_AspNetUsers_UserId",
//                 table: "ForumPost");
//
//             migrationBuilder.DropForeignKey(
//                 name: "FK_ForumThread_AspNetUsers_UserId",
//                 table: "ForumThread");
//
//             migrationBuilder.DropForeignKey(
//                 name: "FK_Messages_AspNetUsers_RecipientId",
//                 table: "Messages");
//
//             migrationBuilder.DropForeignKey(
//                 name: "FK_Messages_AspNetUsers_SenderId",
//                 table: "Messages");
//
//             migrationBuilder.DropForeignKey(
//                 name: "FK_Photos_AspNetUsers_UserId",
//                 table: "Photos");
//
//             migrationBuilder.DropForeignKey(
//                 name: "FK_Reminder_AspNetUsers_UserId",
//                 table: "Reminder");
//
//             migrationBuilder.DropForeignKey(
//                 name: "FK_TeamUsers_AspNetUsers_UserId",
//                 table: "TeamUsers");
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
//                 name: "AspNetRoles");
//
//             migrationBuilder.DropPrimaryKey(
//                 name: "PK_AspNetUsers",
//                 table: "AspNetUsers");
//
//             migrationBuilder.DropIndex(
//                 name: "EmailIndex",
//                 table: "AspNetUsers");
//
//             migrationBuilder.DropIndex(
//                 name: "UserNameIndex",
//                 table: "AspNetUsers");
//
//             migrationBuilder.DropColumn(
//                 name: "Id",
//                 table: "AspNetUsers");
//
//             migrationBuilder.DropColumn(
//                 name: "AccessFailedCount",
//                 table: "AspNetUsers");
//
//             migrationBuilder.DropColumn(
//                 name: "ConcurrencyStamp",
//                 table: "AspNetUsers");
//
//             migrationBuilder.DropColumn(
//                 name: "EmailConfirmed",
//                 table: "AspNetUsers");
//
//             migrationBuilder.DropColumn(
//                 name: "LockoutEnabled",
//                 table: "AspNetUsers");
//
//             migrationBuilder.DropColumn(
//                 name: "LockoutEnd",
//                 table: "AspNetUsers");
//
//             migrationBuilder.DropColumn(
//                 name: "NormalizedEmail",
//                 table: "AspNetUsers");
//
//             migrationBuilder.DropColumn(
//                 name: "NormalizedUserName",
//                 table: "AspNetUsers");
//
//             migrationBuilder.DropColumn(
//                 name: "PhoneNumber",
//                 table: "AspNetUsers");
//
//             migrationBuilder.DropColumn(
//                 name: "PhoneNumberConfirmed",
//                 table: "AspNetUsers");
//
//             migrationBuilder.DropColumn(
//                 name: "SecurityStamp",
//                 table: "AspNetUsers");
//
//             migrationBuilder.RenameTable(
//                 name: "AspNetUsers",
//                 newName: "Users");
//
//             migrationBuilder.RenameColumn(
//                 name: "UserName",
//                 table: "Users",
//                 newName: "Username");
//
//             migrationBuilder.RenameColumn(
//                 name: "TwoFactorEnabled",
//                 table: "Users",
//                 newName: "UserId");
//
//             migrationBuilder.RenameIndex(
//                 name: "IX_AspNetUsers_ChatUsersId",
//                 table: "Users",
//                 newName: "IX_Users_ChatUsersId");
//
//             migrationBuilder.AlterColumn<byte[]>(
//                 name: "PasswordHash",
//                 table: "Users",
//                 type: "BLOB",
//                 nullable: true,
//                 oldClrType: typeof(string),
//                 oldType: "TEXT",
//                 oldNullable: true);
//
//             migrationBuilder.AlterColumn<int>(
//                 name: "UserId",
//                 table: "Users",
//                 type: "INTEGER",
//                 nullable: false,
//                 oldClrType: typeof(bool),
//                 oldType: "INTEGER")
//                 .Annotation("Sqlite:Autoincrement", true);
//
//             migrationBuilder.AddColumn<byte[]>(
//                 name: "PasswordSalt",
//                 table: "Users",
//                 type: "BLOB",
//                 nullable: true);
//
//             migrationBuilder.AddPrimaryKey(
//                 name: "PK_Users",
//                 table: "Users",
//                 column: "UserId");
//
//             migrationBuilder.AddForeignKey(
//                 name: "FK_Articles_Users_UserId",
//                 table: "Articles",
//                 column: "UserId",
//                 principalTable: "Users",
//                 principalColumn: "UserId",
//                 onDelete: ReferentialAction.Restrict);
//
//             migrationBuilder.AddForeignKey(
//                 name: "FK_EventRegistrations_Users_UserId",
//                 table: "EventRegistrations",
//                 column: "UserId",
//                 principalTable: "Users",
//                 principalColumn: "UserId",
//                 onDelete: ReferentialAction.Restrict);
//
//             migrationBuilder.AddForeignKey(
//                 name: "FK_ForumPost_Users_UserId",
//                 table: "ForumPost",
//                 column: "UserId",
//                 principalTable: "Users",
//                 principalColumn: "UserId",
//                 onDelete: ReferentialAction.Restrict);
//
//             migrationBuilder.AddForeignKey(
//                 name: "FK_ForumThread_Users_UserId",
//                 table: "ForumThread",
//                 column: "UserId",
//                 principalTable: "Users",
//                 principalColumn: "UserId",
//                 onDelete: ReferentialAction.Restrict);
//
//             migrationBuilder.AddForeignKey(
//                 name: "FK_Messages_Users_RecipientId",
//                 table: "Messages",
//                 column: "RecipientId",
//                 principalTable: "Users",
//                 principalColumn: "UserId",
//                 onDelete: ReferentialAction.Restrict);
//
//             migrationBuilder.AddForeignKey(
//                 name: "FK_Messages_Users_SenderId",
//                 table: "Messages",
//                 column: "SenderId",
//                 principalTable: "Users",
//                 principalColumn: "UserId",
//                 onDelete: ReferentialAction.Restrict);
//
//             migrationBuilder.AddForeignKey(
//                 name: "FK_Photos_Users_UserId",
//                 table: "Photos",
//                 column: "UserId",
//                 principalTable: "Users",
//                 principalColumn: "UserId",
//                 onDelete: ReferentialAction.Cascade);
//
//             migrationBuilder.AddForeignKey(
//                 name: "FK_Reminder_Users_UserId",
//                 table: "Reminder",
//                 column: "UserId",
//                 principalTable: "Users",
//                 principalColumn: "UserId",
//                 onDelete: ReferentialAction.Restrict);
//
//             migrationBuilder.AddForeignKey(
//                 name: "FK_TeamUsers_Users_UserId",
//                 table: "TeamUsers",
//                 column: "UserId",
//                 principalTable: "Users",
//                 principalColumn: "UserId",
//                 onDelete: ReferentialAction.Cascade);
//
//             migrationBuilder.AddForeignKey(
//                 name: "FK_Users_ChatUsers_ChatUsersId",
//                 table: "Users",
//                 column: "ChatUsersId",
//                 principalTable: "ChatUsers",
//                 principalColumn: "ChatUsersId",
//                 onDelete: ReferentialAction.Restrict);
//         }
//     }
// }
