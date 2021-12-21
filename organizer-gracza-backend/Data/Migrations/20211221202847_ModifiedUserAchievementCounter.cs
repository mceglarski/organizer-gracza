using Microsoft.EntityFrameworkCore.Migrations;

namespace organizer_gracza_backend.Data.Migrations
{
    public partial class ModifiedUserAchievementCounter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumberOfEventUserJoined",
                table: "UserAchievementCounters",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfPostsCreated",
                table: "UserAchievementCounters",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfThreadsCreated",
                table: "UserAchievementCounters",
                type: "INTEGER",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfEventUserJoined",
                table: "UserAchievementCounters");

            migrationBuilder.DropColumn(
                name: "NumberOfPostsCreated",
                table: "UserAchievementCounters");

            migrationBuilder.DropColumn(
                name: "NumberOfThreadsCreated",
                table: "UserAchievementCounters");
        }
    }
}
