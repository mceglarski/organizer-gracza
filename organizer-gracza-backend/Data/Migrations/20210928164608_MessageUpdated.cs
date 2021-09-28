using Microsoft.EntityFrameworkCore.Migrations;

namespace organizer_gracza_backend.Data.Migrations
{
    public partial class MessageUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RecipientNickname",
                table: "Messages",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SenderNickname",
                table: "Messages",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RecipientNickname",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "SenderNickname",
                table: "Messages");
        }
    }
}
