using Microsoft.EntityFrameworkCore.Migrations;

namespace organizer_gracza_backend.Data.Migrations
{
    public partial class UpdatedEventResult : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventResults_EventTeamRegistration_EventTeamRegistrationId",
                table: "EventResults");

            migrationBuilder.DropForeignKey(
                name: "FK_EventResults_EventUserRegistration_EventUserRegistrationId",
                table: "EventResults");

            migrationBuilder.DropForeignKey(
                name: "FK_EventTeam_EventResults_EventResultId",
                table: "EventTeam");

            migrationBuilder.DropForeignKey(
                name: "FK_EventUser_EventResults_EventResultId",
                table: "EventUser");

            migrationBuilder.DropIndex(
                name: "IX_EventUser_EventResultId",
                table: "EventUser");

            migrationBuilder.DropIndex(
                name: "IX_EventTeam_EventResultId",
                table: "EventTeam");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventResults",
                table: "EventResults");

            migrationBuilder.DropIndex(
                name: "IX_EventResults_EventTeamRegistrationId",
                table: "EventResults");

            migrationBuilder.DropIndex(
                name: "IX_EventResults_EventUserRegistrationId",
                table: "EventResults");

            migrationBuilder.RenameTable(
                name: "EventResults",
                newName: "EventResult");

            migrationBuilder.RenameColumn(
                name: "EventUserRegistrationId",
                table: "EventResult",
                newName: "EventUserId");

            migrationBuilder.RenameColumn(
                name: "EventTeamRegistrationId",
                table: "EventResult",
                newName: "EventTeamId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventResult",
                table: "EventResult",
                column: "EventResultId");

            migrationBuilder.CreateIndex(
                name: "IX_EventUser_EventResultId",
                table: "EventUser",
                column: "EventResultId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EventTeam_EventResultId",
                table: "EventTeam",
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventTeam_EventResult_EventResultId",
                table: "EventTeam");

            migrationBuilder.DropForeignKey(
                name: "FK_EventUser_EventResult_EventResultId",
                table: "EventUser");

            migrationBuilder.DropIndex(
                name: "IX_EventUser_EventResultId",
                table: "EventUser");

            migrationBuilder.DropIndex(
                name: "IX_EventTeam_EventResultId",
                table: "EventTeam");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventResult",
                table: "EventResult");

            migrationBuilder.RenameTable(
                name: "EventResult",
                newName: "EventResults");

            migrationBuilder.RenameColumn(
                name: "EventUserId",
                table: "EventResults",
                newName: "EventUserRegistrationId");

            migrationBuilder.RenameColumn(
                name: "EventTeamId",
                table: "EventResults",
                newName: "EventTeamRegistrationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventResults",
                table: "EventResults",
                column: "EventResultId");

            migrationBuilder.CreateIndex(
                name: "IX_EventUser_EventResultId",
                table: "EventUser",
                column: "EventResultId");

            migrationBuilder.CreateIndex(
                name: "IX_EventTeam_EventResultId",
                table: "EventTeam",
                column: "EventResultId");

            migrationBuilder.CreateIndex(
                name: "IX_EventResults_EventTeamRegistrationId",
                table: "EventResults",
                column: "EventTeamRegistrationId");

            migrationBuilder.CreateIndex(
                name: "IX_EventResults_EventUserRegistrationId",
                table: "EventResults",
                column: "EventUserRegistrationId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_EventTeam_EventResults_EventResultId",
                table: "EventTeam",
                column: "EventResultId",
                principalTable: "EventResults",
                principalColumn: "EventResultId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EventUser_EventResults_EventResultId",
                table: "EventUser",
                column: "EventResultId",
                principalTable: "EventResults",
                principalColumn: "EventResultId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
