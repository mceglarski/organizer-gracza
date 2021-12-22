using Microsoft.EntityFrameworkCore.Migrations;

namespace organizer_gracza_backend.Data.Migrations
{
    public partial class AddedEventResults : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_ChatUsers_ChatUsersId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "ChatUsers");

            migrationBuilder.DropTable(
                name: "Streams");

            migrationBuilder.DropTable(
                name: "Chats");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ChatUsersId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ChatUsersId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "EventResultId",
                table: "EventUserRegistration",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EventResultId",
                table: "EventTeamRegistration",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EventTeamRegistrationId",
                table: "EventResults",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EventUserRegistrationId",
                table: "EventResults",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EventResults_EventTeamRegistrationId",
                table: "EventResults",
                column: "EventTeamRegistrationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EventResults_EventUserRegistrationId",
                table: "EventResults",
                column: "EventUserRegistrationId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_EventResults_EventTeamRegistration_EventTeamRegistrationId",
                table: "EventResults",
                column: "EventTeamRegistrationId",
                principalTable: "EventTeamRegistration",
                principalColumn: "EventTeamRegistrationId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EventResults_EventUserRegistration_EventUserRegistrationId",
                table: "EventResults",
                column: "EventUserRegistrationId",
                principalTable: "EventUserRegistration",
                principalColumn: "EventUserRegistrationId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventResults_EventTeamRegistration_EventTeamRegistrationId",
                table: "EventResults");

            migrationBuilder.DropForeignKey(
                name: "FK_EventResults_EventUserRegistration_EventUserRegistrationId",
                table: "EventResults");

            migrationBuilder.DropIndex(
                name: "IX_EventResults_EventTeamRegistrationId",
                table: "EventResults");

            migrationBuilder.DropIndex(
                name: "IX_EventResults_EventUserRegistrationId",
                table: "EventResults");

            migrationBuilder.DropColumn(
                name: "EventResultId",
                table: "EventUserRegistration");

            migrationBuilder.DropColumn(
                name: "EventResultId",
                table: "EventTeamRegistration");

            migrationBuilder.DropColumn(
                name: "EventTeamRegistrationId",
                table: "EventResults");

            migrationBuilder.DropColumn(
                name: "EventUserRegistrationId",
                table: "EventResults");

            migrationBuilder.AddColumn<int>(
                name: "ChatUsersId",
                table: "AspNetUsers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Chats",
                columns: table => new
                {
                    ChatId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chats", x => x.ChatId);
                });

            migrationBuilder.CreateTable(
                name: "Streams",
                columns: table => new
                {
                    StreamId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    GameId = table.Column<int>(type: "INTEGER", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Url = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Streams", x => x.StreamId);
                    table.ForeignKey(
                        name: "FK_Streams_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "GameId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChatUsers",
                columns: table => new
                {
                    ChatUsersId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ChatId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatUsers", x => x.ChatUsersId);
                    table.ForeignKey(
                        name: "FK_ChatUsers_Chats_ChatId",
                        column: x => x.ChatId,
                        principalTable: "Chats",
                        principalColumn: "ChatId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ChatUsersId",
                table: "AspNetUsers",
                column: "ChatUsersId");

            migrationBuilder.CreateIndex(
                name: "IX_ChatUsers_ChatId",
                table: "ChatUsers",
                column: "ChatId");

            migrationBuilder.CreateIndex(
                name: "IX_Streams_GameId",
                table: "Streams",
                column: "GameId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_ChatUsers_ChatUsersId",
                table: "AspNetUsers",
                column: "ChatUsersId",
                principalTable: "ChatUsers",
                principalColumn: "ChatUsersId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
