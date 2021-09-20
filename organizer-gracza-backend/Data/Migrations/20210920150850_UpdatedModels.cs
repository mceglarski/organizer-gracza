using Microsoft.EntityFrameworkCore.Migrations;

namespace organizer_gracza_backend.Data.Migrations
{
    public partial class UpdatedModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Achievements_Profile_ProfileIdProfile",
                table: "Achievements");

            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Users_UserIdUser",
                table: "Articles");

            migrationBuilder.DropForeignKey(
                name: "FK_ChatUsers_Chats_ChatIdChat",
                table: "ChatUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_EventRegistrations_Events_EventIdEvent",
                table: "EventRegistrations");

            migrationBuilder.DropForeignKey(
                name: "FK_EventRegistrations_Teams_TeamIdTeam",
                table: "EventRegistrations");

            migrationBuilder.DropForeignKey(
                name: "FK_EventRegistrations_Users_UserIdUser",
                table: "EventRegistrations");

            migrationBuilder.DropForeignKey(
                name: "FK_EventResults_Events_EventIdEvent",
                table: "EventResults");

            migrationBuilder.DropForeignKey(
                name: "FK_ForumPost_ForumThread_ForumThreadIdForumThread",
                table: "ForumPost");

            migrationBuilder.DropForeignKey(
                name: "FK_ForumPost_Users_UserIdUser",
                table: "ForumPost");

            migrationBuilder.DropForeignKey(
                name: "FK_ForumThread_Users_UserIdUser",
                table: "ForumThread");

            migrationBuilder.DropForeignKey(
                name: "FK_GameStatistics_Games_GameIdGame",
                table: "GameStatistics");

            migrationBuilder.DropForeignKey(
                name: "FK_GameStatistics_Profile_ProfileIdProfile",
                table: "GameStatistics");

            migrationBuilder.DropForeignKey(
                name: "FK_GeneralStatistics_Profile_ProfileIdProfile",
                table: "GeneralStatistics");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Chats_ChatIdChat",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Users_UserIdUser",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Reminder_Users_UserIdUser",
                table: "Reminder");

            migrationBuilder.DropForeignKey(
                name: "FK_Streams_Games_GameIdGame",
                table: "Streams");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamUsers_Teams_IdTeam",
                table: "TeamUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamUsers_Users_IdUser",
                table: "TeamUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_ChatUsers_ChatUsersIdChatUsers",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "ChatUsersIdChatUsers",
                table: "Users",
                newName: "ChatUsersId");

            migrationBuilder.RenameColumn(
                name: "IdUser",
                table: "Users",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_ChatUsersIdChatUsers",
                table: "Users",
                newName: "IX_Users_ChatUsersId");

            migrationBuilder.RenameColumn(
                name: "IdUser",
                table: "TeamUsers",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "IdTeam",
                table: "TeamUsers",
                newName: "TeamId");

            migrationBuilder.RenameColumn(
                name: "IdTeamUser",
                table: "TeamUsers",
                newName: "TeamUserId");

            migrationBuilder.RenameIndex(
                name: "IX_TeamUsers_IdUser",
                table: "TeamUsers",
                newName: "IX_TeamUsers_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_TeamUsers_IdTeam",
                table: "TeamUsers",
                newName: "IX_TeamUsers_TeamId");

            migrationBuilder.RenameColumn(
                name: "IdTeam",
                table: "Teams",
                newName: "TeamId");

            migrationBuilder.RenameColumn(
                name: "GameIdGame",
                table: "Streams",
                newName: "GameId");

            migrationBuilder.RenameColumn(
                name: "IdStream",
                table: "Streams",
                newName: "StreamId");

            migrationBuilder.RenameIndex(
                name: "IX_Streams_GameIdGame",
                table: "Streams",
                newName: "IX_Streams_GameId");

            migrationBuilder.RenameColumn(
                name: "UserIdUser",
                table: "Reminder",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "IdReminder",
                table: "Reminder",
                newName: "ReminderId");

            migrationBuilder.RenameIndex(
                name: "IX_Reminder_UserIdUser",
                table: "Reminder",
                newName: "IX_Reminder_UserId");

            migrationBuilder.RenameColumn(
                name: "IdProfile",
                table: "Profile",
                newName: "ProfileId");

            migrationBuilder.RenameColumn(
                name: "UserIdUser",
                table: "Messages",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "ChatIdChat",
                table: "Messages",
                newName: "ChatId");

            migrationBuilder.RenameColumn(
                name: "IdMessage",
                table: "Messages",
                newName: "MessageId");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_UserIdUser",
                table: "Messages",
                newName: "IX_Messages_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_ChatIdChat",
                table: "Messages",
                newName: "IX_Messages_ChatId");

            migrationBuilder.RenameColumn(
                name: "ProfileIdProfile",
                table: "GeneralStatistics",
                newName: "ProfileId");

            migrationBuilder.RenameColumn(
                name: "IdGeneralStatistics",
                table: "GeneralStatistics",
                newName: "GeneralStatisticsId");

            migrationBuilder.RenameIndex(
                name: "IX_GeneralStatistics_ProfileIdProfile",
                table: "GeneralStatistics",
                newName: "IX_GeneralStatistics_ProfileId");

            migrationBuilder.RenameColumn(
                name: "ProfileIdProfile",
                table: "GameStatistics",
                newName: "ProfileId");

            migrationBuilder.RenameColumn(
                name: "GameIdGame",
                table: "GameStatistics",
                newName: "GameId");

            migrationBuilder.RenameColumn(
                name: "IdGameStatistics",
                table: "GameStatistics",
                newName: "GameStatisticsId");

            migrationBuilder.RenameIndex(
                name: "IX_GameStatistics_ProfileIdProfile",
                table: "GameStatistics",
                newName: "IX_GameStatistics_ProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_GameStatistics_GameIdGame",
                table: "GameStatistics",
                newName: "IX_GameStatistics_GameId");

            migrationBuilder.RenameColumn(
                name: "IdGame",
                table: "Games",
                newName: "GameId");

            migrationBuilder.RenameColumn(
                name: "UserIdUser",
                table: "ForumThread",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "IdForumThread",
                table: "ForumThread",
                newName: "ForumThreadId");

            migrationBuilder.RenameIndex(
                name: "IX_ForumThread_UserIdUser",
                table: "ForumThread",
                newName: "IX_ForumThread_UserId");

            migrationBuilder.RenameColumn(
                name: "UserIdUser",
                table: "ForumPost",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "ForumThreadIdForumThread",
                table: "ForumPost",
                newName: "ForumThreadId");

            migrationBuilder.RenameColumn(
                name: "IdForumPost",
                table: "ForumPost",
                newName: "ForumPostId");

            migrationBuilder.RenameIndex(
                name: "IX_ForumPost_UserIdUser",
                table: "ForumPost",
                newName: "IX_ForumPost_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_ForumPost_ForumThreadIdForumThread",
                table: "ForumPost",
                newName: "IX_ForumPost_ForumThreadId");

            migrationBuilder.RenameColumn(
                name: "IdEvent",
                table: "Events",
                newName: "EventId");

            migrationBuilder.RenameColumn(
                name: "EventIdEvent",
                table: "EventResults",
                newName: "EventId");

            migrationBuilder.RenameColumn(
                name: "IdEventResult",
                table: "EventResults",
                newName: "EventResultId");

            migrationBuilder.RenameIndex(
                name: "IX_EventResults_EventIdEvent",
                table: "EventResults",
                newName: "IX_EventResults_EventId");

            migrationBuilder.RenameColumn(
                name: "UserIdUser",
                table: "EventRegistrations",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "TeamIdTeam",
                table: "EventRegistrations",
                newName: "TeamId");

            migrationBuilder.RenameColumn(
                name: "EventIdEvent",
                table: "EventRegistrations",
                newName: "EventId");

            migrationBuilder.RenameColumn(
                name: "IdEventRegistration",
                table: "EventRegistrations",
                newName: "EventRegistrationId");

            migrationBuilder.RenameIndex(
                name: "IX_EventRegistrations_UserIdUser",
                table: "EventRegistrations",
                newName: "IX_EventRegistrations_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_EventRegistrations_TeamIdTeam",
                table: "EventRegistrations",
                newName: "IX_EventRegistrations_TeamId");

            migrationBuilder.RenameIndex(
                name: "IX_EventRegistrations_EventIdEvent",
                table: "EventRegistrations",
                newName: "IX_EventRegistrations_EventId");

            migrationBuilder.RenameColumn(
                name: "ChatIdChat",
                table: "ChatUsers",
                newName: "ChatId");

            migrationBuilder.RenameColumn(
                name: "IdChatUsers",
                table: "ChatUsers",
                newName: "ChatUsersId");

            migrationBuilder.RenameIndex(
                name: "IX_ChatUsers_ChatIdChat",
                table: "ChatUsers",
                newName: "IX_ChatUsers_ChatId");

            migrationBuilder.RenameColumn(
                name: "IdChat",
                table: "Chats",
                newName: "ChatId");

            migrationBuilder.RenameColumn(
                name: "UserIdUser",
                table: "Articles",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "IdArticles",
                table: "Articles",
                newName: "ArticlesId");

            migrationBuilder.RenameIndex(
                name: "IX_Articles_UserIdUser",
                table: "Articles",
                newName: "IX_Articles_UserId");

            migrationBuilder.RenameColumn(
                name: "ProfileIdProfile",
                table: "Achievements",
                newName: "ProfileId");

            migrationBuilder.RenameColumn(
                name: "IdAchievements",
                table: "Achievements",
                newName: "AchievementsId");

            migrationBuilder.RenameIndex(
                name: "IX_Achievements_ProfileIdProfile",
                table: "Achievements",
                newName: "IX_Achievements_ProfileId");

            migrationBuilder.CreateTable(
                name: "Photos",
                columns: table => new
                {
                    PhotoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Url = table.Column<string>(type: "TEXT", nullable: true),
                    isMain = table.Column<bool>(type: "INTEGER", nullable: false),
                    PublicId = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.PhotoId);
                    table.ForeignKey(
                        name: "FK_Photos_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Photos_UserId",
                table: "Photos",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Achievements_Profile_ProfileId",
                table: "Achievements",
                column: "ProfileId",
                principalTable: "Profile",
                principalColumn: "ProfileId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Users_UserId",
                table: "Articles",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ChatUsers_Chats_ChatId",
                table: "ChatUsers",
                column: "ChatId",
                principalTable: "Chats",
                principalColumn: "ChatId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EventRegistrations_Events_EventId",
                table: "EventRegistrations",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "EventId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EventRegistrations_Teams_TeamId",
                table: "EventRegistrations",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "TeamId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EventRegistrations_Users_UserId",
                table: "EventRegistrations",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EventResults_Events_EventId",
                table: "EventResults",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "EventId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ForumPost_ForumThread_ForumThreadId",
                table: "ForumPost",
                column: "ForumThreadId",
                principalTable: "ForumThread",
                principalColumn: "ForumThreadId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ForumPost_Users_UserId",
                table: "ForumPost",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ForumThread_Users_UserId",
                table: "ForumThread",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GameStatistics_Games_GameId",
                table: "GameStatistics",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "GameId",
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

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Chats_ChatId",
                table: "Messages",
                column: "ChatId",
                principalTable: "Chats",
                principalColumn: "ChatId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Users_UserId",
                table: "Messages",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reminder_Users_UserId",
                table: "Reminder",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Streams_Games_GameId",
                table: "Streams",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "GameId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamUsers_Teams_TeamId",
                table: "TeamUsers",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "TeamId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamUsers_Users_UserId",
                table: "TeamUsers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_ChatUsers_ChatUsersId",
                table: "Users",
                column: "ChatUsersId",
                principalTable: "ChatUsers",
                principalColumn: "ChatUsersId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Achievements_Profile_ProfileId",
                table: "Achievements");

            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Users_UserId",
                table: "Articles");

            migrationBuilder.DropForeignKey(
                name: "FK_ChatUsers_Chats_ChatId",
                table: "ChatUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_EventRegistrations_Events_EventId",
                table: "EventRegistrations");

            migrationBuilder.DropForeignKey(
                name: "FK_EventRegistrations_Teams_TeamId",
                table: "EventRegistrations");

            migrationBuilder.DropForeignKey(
                name: "FK_EventRegistrations_Users_UserId",
                table: "EventRegistrations");

            migrationBuilder.DropForeignKey(
                name: "FK_EventResults_Events_EventId",
                table: "EventResults");

            migrationBuilder.DropForeignKey(
                name: "FK_ForumPost_ForumThread_ForumThreadId",
                table: "ForumPost");

            migrationBuilder.DropForeignKey(
                name: "FK_ForumPost_Users_UserId",
                table: "ForumPost");

            migrationBuilder.DropForeignKey(
                name: "FK_ForumThread_Users_UserId",
                table: "ForumThread");

            migrationBuilder.DropForeignKey(
                name: "FK_GameStatistics_Games_GameId",
                table: "GameStatistics");

            migrationBuilder.DropForeignKey(
                name: "FK_GameStatistics_Profile_ProfileId",
                table: "GameStatistics");

            migrationBuilder.DropForeignKey(
                name: "FK_GeneralStatistics_Profile_ProfileId",
                table: "GeneralStatistics");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Chats_ChatId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Users_UserId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Reminder_Users_UserId",
                table: "Reminder");

            migrationBuilder.DropForeignKey(
                name: "FK_Streams_Games_GameId",
                table: "Streams");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamUsers_Teams_TeamId",
                table: "TeamUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamUsers_Users_UserId",
                table: "TeamUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_ChatUsers_ChatUsersId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Photos");

            migrationBuilder.RenameColumn(
                name: "ChatUsersId",
                table: "Users",
                newName: "ChatUsersIdChatUsers");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Users",
                newName: "IdUser");

            migrationBuilder.RenameIndex(
                name: "IX_Users_ChatUsersId",
                table: "Users",
                newName: "IX_Users_ChatUsersIdChatUsers");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "TeamUsers",
                newName: "IdUser");

            migrationBuilder.RenameColumn(
                name: "TeamId",
                table: "TeamUsers",
                newName: "IdTeam");

            migrationBuilder.RenameColumn(
                name: "TeamUserId",
                table: "TeamUsers",
                newName: "IdTeamUser");

            migrationBuilder.RenameIndex(
                name: "IX_TeamUsers_UserId",
                table: "TeamUsers",
                newName: "IX_TeamUsers_IdUser");

            migrationBuilder.RenameIndex(
                name: "IX_TeamUsers_TeamId",
                table: "TeamUsers",
                newName: "IX_TeamUsers_IdTeam");

            migrationBuilder.RenameColumn(
                name: "TeamId",
                table: "Teams",
                newName: "IdTeam");

            migrationBuilder.RenameColumn(
                name: "GameId",
                table: "Streams",
                newName: "GameIdGame");

            migrationBuilder.RenameColumn(
                name: "StreamId",
                table: "Streams",
                newName: "IdStream");

            migrationBuilder.RenameIndex(
                name: "IX_Streams_GameId",
                table: "Streams",
                newName: "IX_Streams_GameIdGame");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Reminder",
                newName: "UserIdUser");

            migrationBuilder.RenameColumn(
                name: "ReminderId",
                table: "Reminder",
                newName: "IdReminder");

            migrationBuilder.RenameIndex(
                name: "IX_Reminder_UserId",
                table: "Reminder",
                newName: "IX_Reminder_UserIdUser");

            migrationBuilder.RenameColumn(
                name: "ProfileId",
                table: "Profile",
                newName: "IdProfile");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Messages",
                newName: "UserIdUser");

            migrationBuilder.RenameColumn(
                name: "ChatId",
                table: "Messages",
                newName: "ChatIdChat");

            migrationBuilder.RenameColumn(
                name: "MessageId",
                table: "Messages",
                newName: "IdMessage");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_UserId",
                table: "Messages",
                newName: "IX_Messages_UserIdUser");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_ChatId",
                table: "Messages",
                newName: "IX_Messages_ChatIdChat");

            migrationBuilder.RenameColumn(
                name: "ProfileId",
                table: "GeneralStatistics",
                newName: "ProfileIdProfile");

            migrationBuilder.RenameColumn(
                name: "GeneralStatisticsId",
                table: "GeneralStatistics",
                newName: "IdGeneralStatistics");

            migrationBuilder.RenameIndex(
                name: "IX_GeneralStatistics_ProfileId",
                table: "GeneralStatistics",
                newName: "IX_GeneralStatistics_ProfileIdProfile");

            migrationBuilder.RenameColumn(
                name: "ProfileId",
                table: "GameStatistics",
                newName: "ProfileIdProfile");

            migrationBuilder.RenameColumn(
                name: "GameId",
                table: "GameStatistics",
                newName: "GameIdGame");

            migrationBuilder.RenameColumn(
                name: "GameStatisticsId",
                table: "GameStatistics",
                newName: "IdGameStatistics");

            migrationBuilder.RenameIndex(
                name: "IX_GameStatistics_ProfileId",
                table: "GameStatistics",
                newName: "IX_GameStatistics_ProfileIdProfile");

            migrationBuilder.RenameIndex(
                name: "IX_GameStatistics_GameId",
                table: "GameStatistics",
                newName: "IX_GameStatistics_GameIdGame");

            migrationBuilder.RenameColumn(
                name: "GameId",
                table: "Games",
                newName: "IdGame");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "ForumThread",
                newName: "UserIdUser");

            migrationBuilder.RenameColumn(
                name: "ForumThreadId",
                table: "ForumThread",
                newName: "IdForumThread");

            migrationBuilder.RenameIndex(
                name: "IX_ForumThread_UserId",
                table: "ForumThread",
                newName: "IX_ForumThread_UserIdUser");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "ForumPost",
                newName: "UserIdUser");

            migrationBuilder.RenameColumn(
                name: "ForumThreadId",
                table: "ForumPost",
                newName: "ForumThreadIdForumThread");

            migrationBuilder.RenameColumn(
                name: "ForumPostId",
                table: "ForumPost",
                newName: "IdForumPost");

            migrationBuilder.RenameIndex(
                name: "IX_ForumPost_UserId",
                table: "ForumPost",
                newName: "IX_ForumPost_UserIdUser");

            migrationBuilder.RenameIndex(
                name: "IX_ForumPost_ForumThreadId",
                table: "ForumPost",
                newName: "IX_ForumPost_ForumThreadIdForumThread");

            migrationBuilder.RenameColumn(
                name: "EventId",
                table: "Events",
                newName: "IdEvent");

            migrationBuilder.RenameColumn(
                name: "EventId",
                table: "EventResults",
                newName: "EventIdEvent");

            migrationBuilder.RenameColumn(
                name: "EventResultId",
                table: "EventResults",
                newName: "IdEventResult");

            migrationBuilder.RenameIndex(
                name: "IX_EventResults_EventId",
                table: "EventResults",
                newName: "IX_EventResults_EventIdEvent");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "EventRegistrations",
                newName: "UserIdUser");

            migrationBuilder.RenameColumn(
                name: "TeamId",
                table: "EventRegistrations",
                newName: "TeamIdTeam");

            migrationBuilder.RenameColumn(
                name: "EventId",
                table: "EventRegistrations",
                newName: "EventIdEvent");

            migrationBuilder.RenameColumn(
                name: "EventRegistrationId",
                table: "EventRegistrations",
                newName: "IdEventRegistration");

            migrationBuilder.RenameIndex(
                name: "IX_EventRegistrations_UserId",
                table: "EventRegistrations",
                newName: "IX_EventRegistrations_UserIdUser");

            migrationBuilder.RenameIndex(
                name: "IX_EventRegistrations_TeamId",
                table: "EventRegistrations",
                newName: "IX_EventRegistrations_TeamIdTeam");

            migrationBuilder.RenameIndex(
                name: "IX_EventRegistrations_EventId",
                table: "EventRegistrations",
                newName: "IX_EventRegistrations_EventIdEvent");

            migrationBuilder.RenameColumn(
                name: "ChatId",
                table: "ChatUsers",
                newName: "ChatIdChat");

            migrationBuilder.RenameColumn(
                name: "ChatUsersId",
                table: "ChatUsers",
                newName: "IdChatUsers");

            migrationBuilder.RenameIndex(
                name: "IX_ChatUsers_ChatId",
                table: "ChatUsers",
                newName: "IX_ChatUsers_ChatIdChat");

            migrationBuilder.RenameColumn(
                name: "ChatId",
                table: "Chats",
                newName: "IdChat");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Articles",
                newName: "UserIdUser");

            migrationBuilder.RenameColumn(
                name: "ArticlesId",
                table: "Articles",
                newName: "IdArticles");

            migrationBuilder.RenameIndex(
                name: "IX_Articles_UserId",
                table: "Articles",
                newName: "IX_Articles_UserIdUser");

            migrationBuilder.RenameColumn(
                name: "ProfileId",
                table: "Achievements",
                newName: "ProfileIdProfile");

            migrationBuilder.RenameColumn(
                name: "AchievementsId",
                table: "Achievements",
                newName: "IdAchievements");

            migrationBuilder.RenameIndex(
                name: "IX_Achievements_ProfileId",
                table: "Achievements",
                newName: "IX_Achievements_ProfileIdProfile");

            migrationBuilder.AddForeignKey(
                name: "FK_Achievements_Profile_ProfileIdProfile",
                table: "Achievements",
                column: "ProfileIdProfile",
                principalTable: "Profile",
                principalColumn: "IdProfile",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Users_UserIdUser",
                table: "Articles",
                column: "UserIdUser",
                principalTable: "Users",
                principalColumn: "IdUser",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ChatUsers_Chats_ChatIdChat",
                table: "ChatUsers",
                column: "ChatIdChat",
                principalTable: "Chats",
                principalColumn: "IdChat",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EventRegistrations_Events_EventIdEvent",
                table: "EventRegistrations",
                column: "EventIdEvent",
                principalTable: "Events",
                principalColumn: "IdEvent",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EventRegistrations_Teams_TeamIdTeam",
                table: "EventRegistrations",
                column: "TeamIdTeam",
                principalTable: "Teams",
                principalColumn: "IdTeam",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EventRegistrations_Users_UserIdUser",
                table: "EventRegistrations",
                column: "UserIdUser",
                principalTable: "Users",
                principalColumn: "IdUser",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EventResults_Events_EventIdEvent",
                table: "EventResults",
                column: "EventIdEvent",
                principalTable: "Events",
                principalColumn: "IdEvent",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ForumPost_ForumThread_ForumThreadIdForumThread",
                table: "ForumPost",
                column: "ForumThreadIdForumThread",
                principalTable: "ForumThread",
                principalColumn: "IdForumThread",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ForumPost_Users_UserIdUser",
                table: "ForumPost",
                column: "UserIdUser",
                principalTable: "Users",
                principalColumn: "IdUser",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ForumThread_Users_UserIdUser",
                table: "ForumThread",
                column: "UserIdUser",
                principalTable: "Users",
                principalColumn: "IdUser",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GameStatistics_Games_GameIdGame",
                table: "GameStatistics",
                column: "GameIdGame",
                principalTable: "Games",
                principalColumn: "IdGame",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GameStatistics_Profile_ProfileIdProfile",
                table: "GameStatistics",
                column: "ProfileIdProfile",
                principalTable: "Profile",
                principalColumn: "IdProfile",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GeneralStatistics_Profile_ProfileIdProfile",
                table: "GeneralStatistics",
                column: "ProfileIdProfile",
                principalTable: "Profile",
                principalColumn: "IdProfile",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Chats_ChatIdChat",
                table: "Messages",
                column: "ChatIdChat",
                principalTable: "Chats",
                principalColumn: "IdChat",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Users_UserIdUser",
                table: "Messages",
                column: "UserIdUser",
                principalTable: "Users",
                principalColumn: "IdUser",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reminder_Users_UserIdUser",
                table: "Reminder",
                column: "UserIdUser",
                principalTable: "Users",
                principalColumn: "IdUser",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Streams_Games_GameIdGame",
                table: "Streams",
                column: "GameIdGame",
                principalTable: "Games",
                principalColumn: "IdGame",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamUsers_Teams_IdTeam",
                table: "TeamUsers",
                column: "IdTeam",
                principalTable: "Teams",
                principalColumn: "IdTeam",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamUsers_Users_IdUser",
                table: "TeamUsers",
                column: "IdUser",
                principalTable: "Users",
                principalColumn: "IdUser",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_ChatUsers_ChatUsersIdChatUsers",
                table: "Users",
                column: "ChatUsersIdChatUsers",
                principalTable: "ChatUsers",
                principalColumn: "IdChatUsers",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
