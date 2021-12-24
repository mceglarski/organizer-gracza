using Microsoft.EntityFrameworkCore.Migrations;

namespace organizer_gracza_backend.Data.Migrations
{
    public partial class UpdatedResultLogic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventTeam_EventResult_EventResultId",
                table: "EventTeam");

            migrationBuilder.DropForeignKey(
                name: "FK_EventUser_EventResult_EventResultId",
                table: "EventUser");

            migrationBuilder.DropForeignKey(
                name: "FK_EventUserResult_EventUser_EventUserId",
                table: "EventUserResult");

            migrationBuilder.DropTable(
                name: "EventResult");

            migrationBuilder.DropIndex(
                name: "IX_EventUserResult_EventUserId",
                table: "EventUserResult");

            migrationBuilder.DropIndex(
                name: "IX_EventUser_EventResultId",
                table: "EventUser");

            migrationBuilder.DropColumn(
                name: "EventResultId",
                table: "EventUser");

            migrationBuilder.RenameColumn(
                name: "EventResultId",
                table: "EventTeam",
                newName: "EventTeamResultId");

            migrationBuilder.RenameIndex(
                name: "IX_EventTeam_EventResultId",
                table: "EventTeam",
                newName: "IX_EventTeam_EventTeamResultId");

            migrationBuilder.CreateTable(
                name: "EventTeamResult",
                columns: table => new
                {
                    EventTeamResultId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TeamId = table.Column<int>(type: "INTEGER", nullable: true),
                    EventTeamId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventTeamResult", x => x.EventTeamResultId);
                    table.ForeignKey(
                        name: "FK_EventTeamResult_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "TeamId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventUser_EventUserResultId",
                table: "EventUser",
                column: "EventUserResultId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EventTeamResult_TeamId",
                table: "EventTeamResult",
                column: "TeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_EventTeam_EventTeamResult_EventTeamResultId",
                table: "EventTeam",
                column: "EventTeamResultId",
                principalTable: "EventTeamResult",
                principalColumn: "EventTeamResultId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EventUser_EventUserResult_EventUserResultId",
                table: "EventUser",
                column: "EventUserResultId",
                principalTable: "EventUserResult",
                principalColumn: "EventUserResultId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventTeam_EventTeamResult_EventTeamResultId",
                table: "EventTeam");

            migrationBuilder.DropForeignKey(
                name: "FK_EventUser_EventUserResult_EventUserResultId",
                table: "EventUser");

            migrationBuilder.DropTable(
                name: "EventTeamResult");

            migrationBuilder.DropIndex(
                name: "IX_EventUser_EventUserResultId",
                table: "EventUser");

            migrationBuilder.RenameColumn(
                name: "EventTeamResultId",
                table: "EventTeam",
                newName: "EventResultId");

            migrationBuilder.RenameIndex(
                name: "IX_EventTeam_EventTeamResultId",
                table: "EventTeam",
                newName: "IX_EventTeam_EventResultId");

            migrationBuilder.AddColumn<int>(
                name: "EventResultId",
                table: "EventUser",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "EventResult",
                columns: table => new
                {
                    EventResultId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EventTeamId = table.Column<int>(type: "INTEGER", nullable: true),
                    EventUserId = table.Column<int>(type: "INTEGER", nullable: true),
                    WinnerName = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventResult", x => x.EventResultId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventUserResult_EventUserId",
                table: "EventUserResult",
                column: "EventUserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EventUser_EventResultId",
                table: "EventUser",
                column: "EventResultId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_EventTeam_EventResult_EventResultId",
                table: "EventTeam",
                column: "EventResultId",
                principalTable: "EventResult",
                principalColumn: "EventResultId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EventUser_EventResult_EventResultId",
                table: "EventUser",
                column: "EventResultId",
                principalTable: "EventResult",
                principalColumn: "EventResultId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EventUserResult_EventUser_EventUserId",
                table: "EventUserResult",
                column: "EventUserId",
                principalTable: "EventUser",
                principalColumn: "EventUserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
