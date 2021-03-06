// // <auto-generated />
// using System;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.EntityFrameworkCore.Infrastructure;
// using Microsoft.EntityFrameworkCore.Migrations;
// using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
// using organizer_gracza_backend.Data;
//
// namespace organizer_gracza_backend.Data.Migrations
// {
//     [DbContext(typeof(DataContext))]
//     [Migration("20210914160658_UserModelModified")]
//     partial class UserModelModified
//     {
//         protected override void BuildTargetModel(ModelBuilder modelBuilder)
//         {
// #pragma warning disable 612, 618
//             modelBuilder
//                 .HasAnnotation("ProductVersion", "5.0.9");
//
//             modelBuilder.Entity("organizer_gracza_backend.Model.Achievements", b =>
//                 {
//                     b.Property<int>("IdAchievements")
//                         .ValueGeneratedOnAdd()
//                         .HasColumnType("INTEGER");
//
//                     b.Property<string>("Details")
//                         .HasColumnType("TEXT");
//
//                     b.Property<string>("Name")
//                         .HasColumnType("TEXT");
//
//                     b.Property<int?>("ProfileIdProfile")
//                         .HasColumnType("INTEGER");
//
//                     b.HasKey("IdAchievements");
//
//                     b.HasIndex("ProfileIdProfile");
//
//                     b.ToTable("Achievements");
//                 });
//
//             modelBuilder.Entity("organizer_gracza_backend.Model.Articles", b =>
//                 {
//                     b.Property<int>("IdArticles")
//                         .ValueGeneratedOnAdd()
//                         .HasColumnType("INTEGER");
//
//                     b.Property<string>("Content")
//                         .HasColumnType("TEXT");
//
//                     b.Property<DateTime>("PublicationDate")
//                         .HasColumnType("TEXT");
//
//                     b.Property<string>("Title")
//                         .HasColumnType("TEXT");
//
//                     b.Property<int?>("UserIdUser")
//                         .HasColumnType("INTEGER");
//
//                     b.HasKey("IdArticles");
//
//                     b.HasIndex("UserIdUser");
//
//                     b.ToTable("Articles");
//                 });
//
//             modelBuilder.Entity("organizer_gracza_backend.Model.Chat", b =>
//                 {
//                     b.Property<int>("IdChat")
//                         .ValueGeneratedOnAdd()
//                         .HasColumnType("INTEGER");
//
//                     b.Property<string>("Name")
//                         .HasColumnType("TEXT");
//
//                     b.HasKey("IdChat");
//
//                     b.ToTable("Chats");
//                 });
//
//             modelBuilder.Entity("organizer_gracza_backend.Model.ChatUsers", b =>
//                 {
//                     b.Property<int>("IdChatUsers")
//                         .ValueGeneratedOnAdd()
//                         .HasColumnType("INTEGER");
//
//                     b.Property<int?>("ChatIdChat")
//                         .HasColumnType("INTEGER");
//
//                     b.HasKey("IdChatUsers");
//
//                     b.HasIndex("ChatIdChat");
//
//                     b.ToTable("ChatUsers");
//                 });
//
//             modelBuilder.Entity("organizer_gracza_backend.Model.Event", b =>
//                 {
//                     b.Property<int>("IdEvent")
//                         .ValueGeneratedOnAdd()
//                         .HasColumnType("INTEGER");
//
//                     b.Property<string>("Description")
//                         .HasColumnType("TEXT");
//
//                     b.Property<DateTime>("EndDate")
//                         .HasColumnType("TEXT");
//
//                     b.Property<string>("EventType")
//                         .HasColumnType("TEXT");
//
//                     b.Property<string>("Name")
//                         .HasColumnType("TEXT");
//
//                     b.Property<DateTime>("StartDate")
//                         .HasColumnType("TEXT");
//
//                     b.HasKey("IdEvent");
//
//                     b.ToTable("Events");
//                 });
//
//             modelBuilder.Entity("organizer_gracza_backend.Model.EventRegistration", b =>
//                 {
//                     b.Property<int>("IdEventRegistration")
//                         .ValueGeneratedOnAdd()
//                         .HasColumnType("INTEGER");
//
//                     b.Property<int?>("EventIdEvent")
//                         .HasColumnType("INTEGER");
//
//                     b.Property<int?>("TeamIdTeam")
//                         .HasColumnType("INTEGER");
//
//                     b.Property<int?>("UserIdUser")
//                         .HasColumnType("INTEGER");
//
//                     b.HasKey("IdEventRegistration");
//
//                     b.HasIndex("EventIdEvent");
//
//                     b.HasIndex("TeamIdTeam");
//
//                     b.HasIndex("UserIdUser");
//
//                     b.ToTable("EventRegistrations");
//                 });
//
//             modelBuilder.Entity("organizer_gracza_backend.Model.EventResult", b =>
//                 {
//                     b.Property<int>("IdEventResult")
//                         .ValueGeneratedOnAdd()
//                         .HasColumnType("INTEGER");
//
//                     b.Property<int?>("EventIdEvent")
//                         .HasColumnType("INTEGER");
//
//                     b.Property<string>("WinnerName")
//                         .HasColumnType("TEXT");
//
//                     b.HasKey("IdEventResult");
//
//                     b.HasIndex("EventIdEvent");
//
//                     b.ToTable("EventResults");
//                 });
//
//             modelBuilder.Entity("organizer_gracza_backend.Model.ForumPost", b =>
//                 {
//                     b.Property<int>("IdForumPost")
//                         .ValueGeneratedOnAdd()
//                         .HasColumnType("INTEGER");
//
//                     b.Property<string>("Content")
//                         .HasColumnType("TEXT");
//
//                     b.Property<int?>("ForumThreadIdForumThread")
//                         .HasColumnType("INTEGER");
//
//                     b.Property<DateTime>("PostDate")
//                         .HasColumnType("TEXT");
//
//                     b.Property<int?>("UserIdUser")
//                         .HasColumnType("INTEGER");
//
//                     b.HasKey("IdForumPost");
//
//                     b.HasIndex("ForumThreadIdForumThread");
//
//                     b.HasIndex("UserIdUser");
//
//                     b.ToTable("ForumPost");
//                 });
//
//             modelBuilder.Entity("organizer_gracza_backend.Model.ForumThread", b =>
//                 {
//                     b.Property<int>("IdForumThread")
//                         .ValueGeneratedOnAdd()
//                         .HasColumnType("INTEGER");
//
//                     b.Property<string>("Content")
//                         .HasColumnType("TEXT");
//
//                     b.Property<DateTime>("ThreadDate")
//                         .HasColumnType("TEXT");
//
//                     b.Property<string>("Title")
//                         .HasColumnType("TEXT");
//
//                     b.Property<int?>("UserIdUser")
//                         .HasColumnType("INTEGER");
//
//                     b.HasKey("IdForumThread");
//
//                     b.HasIndex("UserIdUser");
//
//                     b.ToTable("ForumThread");
//                 });
//
//             modelBuilder.Entity("organizer_gracza_backend.Model.Game", b =>
//                 {
//                     b.Property<int>("IdGame")
//                         .ValueGeneratedOnAdd()
//                         .HasColumnType("INTEGER");
//
//                     b.Property<string>("Title")
//                         .HasColumnType("TEXT");
//
//                     b.HasKey("IdGame");
//
//                     b.ToTable("Games");
//                 });
//
//             modelBuilder.Entity("organizer_gracza_backend.Model.GameStatistics", b =>
//                 {
//                     b.Property<int>("IdGameStatistics")
//                         .ValueGeneratedOnAdd()
//                         .HasColumnType("INTEGER");
//
//                     b.Property<int?>("GameIdGame")
//                         .HasColumnType("INTEGER");
//
//                     b.Property<int>("LostGames")
//                         .HasColumnType("INTEGER");
//
//                     b.Property<int?>("ProfileIdProfile")
//                         .HasColumnType("INTEGER");
//
//                     b.Property<int>("WonGames")
//                         .HasColumnType("INTEGER");
//
//                     b.HasKey("IdGameStatistics");
//
//                     b.HasIndex("GameIdGame");
//
//                     b.HasIndex("ProfileIdProfile");
//
//                     b.ToTable("GameStatistics");
//                 });
//
//             modelBuilder.Entity("organizer_gracza_backend.Model.GeneralStatistics", b =>
//                 {
//                     b.Property<int>("IdGeneralStatistics")
//                         .ValueGeneratedOnAdd()
//                         .HasColumnType("INTEGER");
//
//                     b.Property<int>("EventsParticipated")
//                         .HasColumnType("INTEGER");
//
//                     b.Property<int>("EventsWon")
//                         .HasColumnType("INTEGER");
//
//                     b.Property<int>("PostWritten")
//                         .HasColumnType("INTEGER");
//
//                     b.Property<int?>("ProfileIdProfile")
//                         .HasColumnType("INTEGER");
//
//                     b.HasKey("IdGeneralStatistics");
//
//                     b.HasIndex("ProfileIdProfile");
//
//                     b.ToTable("GeneralStatistics");
//                 });
//
//             modelBuilder.Entity("organizer_gracza_backend.Model.Message", b =>
//                 {
//                     b.Property<int>("IdMessage")
//                         .ValueGeneratedOnAdd()
//                         .HasColumnType("INTEGER");
//
//                     b.Property<int?>("ChatIdChat")
//                         .HasColumnType("INTEGER");
//
//                     b.Property<string>("Content")
//                         .HasColumnType("TEXT");
//
//                     b.Property<DateTime>("MessageDate")
//                         .HasColumnType("TEXT");
//
//                     b.Property<int?>("UserIdUser")
//                         .HasColumnType("INTEGER");
//
//                     b.HasKey("IdMessage");
//
//                     b.HasIndex("ChatIdChat");
//
//                     b.HasIndex("UserIdUser");
//
//                     b.ToTable("Messages");
//                 });
//
//             modelBuilder.Entity("organizer_gracza_backend.Model.Profile", b =>
//                 {
//                     b.Property<int>("IdProfile")
//                         .ValueGeneratedOnAdd()
//                         .HasColumnType("INTEGER");
//
//                     b.Property<string>("Description")
//                         .HasColumnType("TEXT");
//
//                     b.Property<string>("Url")
//                         .HasColumnType("TEXT");
//
//                     b.HasKey("IdProfile");
//
//                     b.ToTable("Profile");
//                 });
//
//             modelBuilder.Entity("organizer_gracza_backend.Model.Reminder", b =>
//                 {
//                     b.Property<int>("IdReminder")
//                         .ValueGeneratedOnAdd()
//                         .HasColumnType("INTEGER");
//
//                     b.Property<string>("Content")
//                         .HasColumnType("TEXT");
//
//                     b.Property<DateTime>("ReminderDate")
//                         .HasColumnType("TEXT");
//
//                     b.Property<string>("Title")
//                         .HasColumnType("TEXT");
//
//                     b.Property<int?>("UserIdUser")
//                         .HasColumnType("INTEGER");
//
//                     b.HasKey("IdReminder");
//
//                     b.HasIndex("UserIdUser");
//
//                     b.ToTable("Reminder");
//                 });
//
//             modelBuilder.Entity("organizer_gracza_backend.Model.Stream", b =>
//                 {
//                     b.Property<int>("IdStream")
//                         .ValueGeneratedOnAdd()
//                         .HasColumnType("INTEGER");
//
//                     b.Property<int?>("GameIdGame")
//                         .HasColumnType("INTEGER");
//
//                     b.Property<string>("Name")
//                         .HasColumnType("TEXT");
//
//                     b.Property<string>("Url")
//                         .HasColumnType("TEXT");
//
//                     b.HasKey("IdStream");
//
//                     b.HasIndex("GameIdGame");
//
//                     b.ToTable("Streams");
//                 });
//
//             modelBuilder.Entity("organizer_gracza_backend.Model.Team", b =>
//                 {
//                     b.Property<int>("IdTeam")
//                         .ValueGeneratedOnAdd()
//                         .HasColumnType("INTEGER");
//
//                     b.Property<string>("Name")
//                         .HasColumnType("TEXT");
//
//                     b.HasKey("IdTeam");
//
//                     b.ToTable("Teams");
//                 });
//
//             modelBuilder.Entity("organizer_gracza_backend.Model.TeamUser", b =>
//                 {
//                     b.Property<int>("IdTeamUser")
//                         .ValueGeneratedOnAdd()
//                         .HasColumnType("INTEGER");
//
//                     b.Property<int>("IdTeam")
//                         .HasColumnType("INTEGER");
//
//                     b.Property<int>("IdUser")
//                         .HasColumnType("INTEGER");
//
//                     b.HasKey("IdTeamUser");
//
//                     b.HasIndex("IdTeam");
//
//                     b.HasIndex("IdUser");
//
//                     b.ToTable("TeamUsers");
//                 });
//
//             modelBuilder.Entity("organizer_gracza_backend.Model.User", b =>
//                 {
//                     b.Property<int>("IdUser")
//                         .ValueGeneratedOnAdd()
//                         .HasColumnType("INTEGER");
//
//                     b.Property<int?>("ChatUsersIdChatUsers")
//                         .HasColumnType("INTEGER");
//
//                     b.Property<string>("Email")
//                         .HasColumnType("TEXT");
//
//                     b.Property<string>("Nickname")
//                         .HasColumnType("TEXT");
//
//                     b.Property<byte[]>("PasswordHash")
//                         .HasColumnType("BLOB");
//
//                     b.Property<byte[]>("PasswordSalt")
//                         .HasColumnType("BLOB");
//
//                     b.Property<string>("Username")
//                         .HasColumnType("TEXT");
//
//                     b.HasKey("IdUser");
//
//                     b.HasIndex("ChatUsersIdChatUsers");
//
//                     b.ToTable("Users");
//                 });
//
//             modelBuilder.Entity("organizer_gracza_backend.Model.Achievements", b =>
//                 {
//                     b.HasOne("organizer_gracza_backend.Model.Profile", null)
//                         .WithMany("Achievements")
//                         .HasForeignKey("ProfileIdProfile");
//                 });
//
//             modelBuilder.Entity("organizer_gracza_backend.Model.Articles", b =>
//                 {
//                     b.HasOne("organizer_gracza_backend.Model.User", "User")
//                         .WithMany()
//                         .HasForeignKey("UserIdUser");
//
//                     b.Navigation("User");
//                 });
//
//             modelBuilder.Entity("organizer_gracza_backend.Model.ChatUsers", b =>
//                 {
//                     b.HasOne("organizer_gracza_backend.Model.Chat", "Chat")
//                         .WithMany()
//                         .HasForeignKey("ChatIdChat");
//
//                     b.Navigation("Chat");
//                 });
//
//             modelBuilder.Entity("organizer_gracza_backend.Model.EventRegistration", b =>
//                 {
//                     b.HasOne("organizer_gracza_backend.Model.Event", "Event")
//                         .WithMany()
//                         .HasForeignKey("EventIdEvent");
//
//                     b.HasOne("organizer_gracza_backend.Model.Team", "Team")
//                         .WithMany()
//                         .HasForeignKey("TeamIdTeam");
//
//                     b.HasOne("organizer_gracza_backend.Model.User", "User")
//                         .WithMany()
//                         .HasForeignKey("UserIdUser");
//
//                     b.Navigation("Event");
//
//                     b.Navigation("Team");
//
//                     b.Navigation("User");
//                 });
//
//             modelBuilder.Entity("organizer_gracza_backend.Model.EventResult", b =>
//                 {
//                     b.HasOne("organizer_gracza_backend.Model.Event", "Event")
//                         .WithMany()
//                         .HasForeignKey("EventIdEvent");
//
//                     b.Navigation("Event");
//                 });
//
//             modelBuilder.Entity("organizer_gracza_backend.Model.ForumPost", b =>
//                 {
//                     b.HasOne("organizer_gracza_backend.Model.ForumThread", "ForumThread")
//                         .WithMany()
//                         .HasForeignKey("ForumThreadIdForumThread");
//
//                     b.HasOne("organizer_gracza_backend.Model.User", "User")
//                         .WithMany()
//                         .HasForeignKey("UserIdUser");
//
//                     b.Navigation("ForumThread");
//
//                     b.Navigation("User");
//                 });
//
//             modelBuilder.Entity("organizer_gracza_backend.Model.ForumThread", b =>
//                 {
//                     b.HasOne("organizer_gracza_backend.Model.User", "User")
//                         .WithMany()
//                         .HasForeignKey("UserIdUser");
//
//                     b.Navigation("User");
//                 });
//
//             modelBuilder.Entity("organizer_gracza_backend.Model.GameStatistics", b =>
//                 {
//                     b.HasOne("organizer_gracza_backend.Model.Game", "Game")
//                         .WithMany()
//                         .HasForeignKey("GameIdGame");
//
//                     b.HasOne("organizer_gracza_backend.Model.Profile", null)
//                         .WithMany("GameStatistics")
//                         .HasForeignKey("ProfileIdProfile");
//
//                     b.Navigation("Game");
//                 });
//
//             modelBuilder.Entity("organizer_gracza_backend.Model.GeneralStatistics", b =>
//                 {
//                     b.HasOne("organizer_gracza_backend.Model.Profile", null)
//                         .WithMany("GeneralStatistics")
//                         .HasForeignKey("ProfileIdProfile");
//                 });
//
//             modelBuilder.Entity("organizer_gracza_backend.Model.Message", b =>
//                 {
//                     b.HasOne("organizer_gracza_backend.Model.Chat", "Chat")
//                         .WithMany()
//                         .HasForeignKey("ChatIdChat");
//
//                     b.HasOne("organizer_gracza_backend.Model.User", "User")
//                         .WithMany()
//                         .HasForeignKey("UserIdUser");
//
//                     b.Navigation("Chat");
//
//                     b.Navigation("User");
//                 });
//
//             modelBuilder.Entity("organizer_gracza_backend.Model.Reminder", b =>
//                 {
//                     b.HasOne("organizer_gracza_backend.Model.User", "User")
//                         .WithMany()
//                         .HasForeignKey("UserIdUser");
//
//                     b.Navigation("User");
//                 });
//
//             modelBuilder.Entity("organizer_gracza_backend.Model.Stream", b =>
//                 {
//                     b.HasOne("organizer_gracza_backend.Model.Game", "Game")
//                         .WithMany()
//                         .HasForeignKey("GameIdGame");
//
//                     b.Navigation("Game");
//                 });
//
//             modelBuilder.Entity("organizer_gracza_backend.Model.TeamUser", b =>
//                 {
//                     b.HasOne("organizer_gracza_backend.Model.Team", "Team")
//                         .WithMany("TeamUser")
//                         .HasForeignKey("IdTeam")
//                         .OnDelete(DeleteBehavior.Cascade)
//                         .IsRequired();
//
//                     b.HasOne("organizer_gracza_backend.Model.User", "User")
//                         .WithMany("TeamUser")
//                         .HasForeignKey("IdUser")
//                         .OnDelete(DeleteBehavior.Cascade)
//                         .IsRequired();
//
//                     b.Navigation("Team");
//
//                     b.Navigation("User");
//                 });
//
//             modelBuilder.Entity("organizer_gracza_backend.Model.User", b =>
//                 {
//                     b.HasOne("organizer_gracza_backend.Model.ChatUsers", null)
//                         .WithMany("User")
//                         .HasForeignKey("ChatUsersIdChatUsers");
//                 });
//
//             modelBuilder.Entity("organizer_gracza_backend.Model.ChatUsers", b =>
//                 {
//                     b.Navigation("User");
//                 });
//
//             modelBuilder.Entity("organizer_gracza_backend.Model.Profile", b =>
//                 {
//                     b.Navigation("Achievements");
//
//                     b.Navigation("GameStatistics");
//
//                     b.Navigation("GeneralStatistics");
//                 });
//
//             modelBuilder.Entity("organizer_gracza_backend.Model.Team", b =>
//                 {
//                     b.Navigation("TeamUser");
//                 });
//
//             modelBuilder.Entity("organizer_gracza_backend.Model.User", b =>
//                 {
//                     b.Navigation("TeamUser");
//                 });
// #pragma warning restore 612, 618
//         }
//     }
// }
