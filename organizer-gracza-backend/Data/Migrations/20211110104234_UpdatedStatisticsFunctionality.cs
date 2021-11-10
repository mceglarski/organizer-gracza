using Microsoft.EntityFrameworkCore.Migrations;

namespace organizer_gracza_backend.Data.Migrations
{
    public partial class UpdatedStatisticsFunctionality : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Achievements_Profile_ProfileId",
                table: "Achievements");

            migrationBuilder.DropForeignKey(
                name: "FK_GameStatistics_Profile_ProfileId",
                table: "GameStatistics");

            migrationBuilder.DropForeignKey(
                name: "FK_GeneralStatistics_Profile_ProfileId",
                table: "GeneralStatistics");

            migrationBuilder.DropTable(
                name: "Profile");

            migrationBuilder.DropIndex(
                name: "IX_GeneralStatistics_ProfileId",
                table: "GeneralStatistics");

            migrationBuilder.DropIndex(
                name: "IX_GameStatistics_GameId",
                table: "GameStatistics");

            migrationBuilder.DropIndex(
                name: "IX_Achievements_ProfileId",
                table: "Achievements");

            migrationBuilder.DropColumn(
                name: "ProfileId",
                table: "GeneralStatistics");

            migrationBuilder.DropColumn(
                name: "ProfileId",
                table: "Achievements");

            migrationBuilder.RenameColumn(
                name: "ProfileId",
                table: "GameStatistics",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_GameStatistics_ProfileId",
                table: "GameStatistics",
                newName: "IX_GameStatistics_UserId");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "GeneralStatistics",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "WonGames",
                table: "GameStatistics",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "LostGames",
                table: "GameStatistics",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralStatistics_UserId",
                table: "GeneralStatistics",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GameStatistics_GameId",
                table: "GameStatistics",
                column: "GameId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_GameStatistics_AspNetUsers_UserId",
                table: "GameStatistics",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GeneralStatistics_AspNetUsers_UserId",
                table: "GeneralStatistics",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameStatistics_AspNetUsers_UserId",
                table: "GameStatistics");

            migrationBuilder.DropForeignKey(
                name: "FK_GeneralStatistics_AspNetUsers_UserId",
                table: "GeneralStatistics");

            migrationBuilder.DropIndex(
                name: "IX_GeneralStatistics_UserId",
                table: "GeneralStatistics");

            migrationBuilder.DropIndex(
                name: "IX_GameStatistics_GameId",
                table: "GameStatistics");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "GeneralStatistics");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "GameStatistics",
                newName: "ProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_GameStatistics_UserId",
                table: "GameStatistics",
                newName: "IX_GameStatistics_ProfileId");

            migrationBuilder.AddColumn<int>(
                name: "ProfileId",
                table: "GeneralStatistics",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "WonGames",
                table: "GameStatistics",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LostGames",
                table: "GameStatistics",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProfileId",
                table: "Achievements",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Profile",
                columns: table => new
                {
                    ProfileId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Url = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profile", x => x.ProfileId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GeneralStatistics_ProfileId",
                table: "GeneralStatistics",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_GameStatistics_GameId",
                table: "GameStatistics",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Achievements_ProfileId",
                table: "Achievements",
                column: "ProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Achievements_Profile_ProfileId",
                table: "Achievements",
                column: "ProfileId",
                principalTable: "Profile",
                principalColumn: "ProfileId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GameStatistics_Profile_ProfileId",
                table: "GameStatistics",
                column: "ProfileId",
                principalTable: "Profile",
                principalColumn: "ProfileId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GeneralStatistics_Profile_ProfileId",
                table: "GeneralStatistics",
                column: "ProfileId",
                principalTable: "Profile",
                principalColumn: "ProfileId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
