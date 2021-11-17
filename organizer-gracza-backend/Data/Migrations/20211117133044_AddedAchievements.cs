using Microsoft.EntityFrameworkCore.Migrations;

namespace organizer_gracza_backend.Data.Migrations
{
    public partial class AddedAchievements : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GeneralStatistics_AspNetUsers_UserId",
                table: "GeneralStatistics");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "GeneralStatistics",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "PostWritten",
                table: "GeneralStatistics",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "EventsWon",
                table: "GeneralStatistics",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "EventsParticipated",
                table: "GeneralStatistics",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<string>(
                name: "PhotoUrl",
                table: "Achievements",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Achievements",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UserAchievementCounters",
                columns: table => new
                {
                    UserAchievementCounterId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NumberOfTeamsCreated = table.Column<int>(type: "INTEGER", nullable: true),
                    NumberOfTeamsJoined = table.Column<int>(type: "INTEGER", nullable: true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAchievementCounters", x => x.UserAchievementCounterId);
                    table.ForeignKey(
                        name: "FK_UserAchievementCounters_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Achievements_UserId",
                table: "Achievements",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAchievementCounters_UserId",
                table: "UserAchievementCounters",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Achievements_AspNetUsers_UserId",
                table: "Achievements",
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
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Achievements_AspNetUsers_UserId",
                table: "Achievements");

            migrationBuilder.DropForeignKey(
                name: "FK_GeneralStatistics_AspNetUsers_UserId",
                table: "GeneralStatistics");

            migrationBuilder.DropTable(
                name: "UserAchievementCounters");

            migrationBuilder.DropIndex(
                name: "IX_Achievements_UserId",
                table: "Achievements");

            migrationBuilder.DropColumn(
                name: "PhotoUrl",
                table: "Achievements");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Achievements");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "GeneralStatistics",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PostWritten",
                table: "GeneralStatistics",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EventsWon",
                table: "GeneralStatistics",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EventsParticipated",
                table: "GeneralStatistics",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_GeneralStatistics_AspNetUsers_UserId",
                table: "GeneralStatistics",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
