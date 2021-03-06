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
//     [Migration("20210920150850_UpdatedModels")]
//     partial class UpdatedModels
//     {
//         protected override void BuildTargetModel(ModelBuilder modelBuilder)
//         {
// #pragma warning disable 612, 618
//             modelBuilder
//                 .HasAnnotation("ProductVersion", "5.0.9");
//
//             modelBuilder.Entity("organizer_gracza_backend.Model.Achievements", b =>
//                 {
//                     b.Property<int>("AchievementsId")
//                         .ValueGeneratedOnAdd()
//                         .HasColumnType("INTEGER");
//
//                     b.Property<string>("Details")
//                         .HasColumnType("TEXT");
//
//                     b.Property<string>("Name")
//                         .HasColumnType("TEXT");
//
//                     b.Property<int?>("ProfileId")
//                         .HasColumnType("INTEGER");
//
//                     b.HasKey("AchievementsId");
//
//                     b.HasIndex("ProfileId");
//
//                     b.ToTable("Achievements");
//                 });
//
//             modelBuilder.Entity("organizer_gracza_backend.Model.Articles", b =>
//                 {
//                     b.Property<int>("ArticlesId")
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
//                     b.Property<int?>("UserId")
//                         .HasColumnType("INTEGER");
//
//                     b.HasKey("ArticlesId");
//
//                     b.HasIndex("UserId");
//
//                     b.ToTable("Articles");
//                 });
//
//             modelBuilder.Entity("organizer_gracza_backend.Model.Chat", b =>
//                 {
//                     b.Property<int>("ChatId")
//                         .ValueGeneratedOnAdd()
//                         .HasColumnType("INTEGER");
//
//                     b.Property<string>("Name")
//                         .HasColumnType("TEXT");
//
//                     b.HasKey("ChatId");
//
//                     b.ToTable("Chats");
//                 });
//
//             modelBuilder.Entity("organizer_gracza_backend.Model.ChatUsers", b =>
//                 {
//                     b.Property<int>("ChatUsersId")
//                         .ValueGeneratedOnAdd()
//                         .HasColumnType("INTEGER");
//
//                     b.Property<int?>("ChatId")
//                         .HasColumnType("INTEGER");
//
//                     b.HasKey("ChatUsersId");
//
//                     b.HasIndex("ChatId");
//
//                     b.ToTable("ChatUsers");
//                 });
//
//             modelBuilder.Entity("organizer_gracza_backend.Model.Event", b =>
//                 {
//                     b.Property<int>("EventId")
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
//                     b.HasKey("EventId");
//
//                     b.ToTable("Events");
//                 });
//
//             modelBuilder.Entity("organizer_gracza_backend.Model.EventRegistration", b =>
//                 {
//                     b.Property<int>("EventRegistrationId")
//                         .ValueGeneratedOnAdd()
//                         .HasColumnType("INTEGER");
//
//                     b.Property<int?>("EventId")
//                         .HasColumnType("INTEGER");
//
//                     b.Property<int?>("TeamId")
//                         .HasColumnType("INTEGER");
//
//                     b.Property<int?>("UserId")
//                         .HasColumnType("INTEGER");
//
//                     b.HasKey("EventRegistrationId");
//
//                     b.HasIndex("EventId");
//
//                     b.HasIndex("TeamId");
//
//                     b.HasIndex("UserId");
//
//                     b.ToTable("EventRegistrations");
//                 });
//
//             modelBuilder.Entity("organizer_gracza_backend.Model.EventResult", b =>
//                 {
//                     b.Property<int>("EventResultId")
//                         .ValueGeneratedOnAdd()
//                         .HasColumnType("INTEGER");
//
//                     b.Property<int?>("EventId")
//                         .HasColumnType("INTEGER");
//
//                     b.Property<string>("WinnerName")
//                         .HasColumnType("TEXT");
//
//                     b.HasKey("EventResultId");
//
//                     b.HasIndex("EventId");
//
//                     b.ToTable("EventResults");
//                 });
//
//             modelBuilder.Entity("organizer_gracza_backend.Model.ForumPost", b =>
//                 {
//                     b.Property<int>("ForumPostId")
//                         .ValueGeneratedOnAdd()
//                         .HasColumnType("INTEGER");
//
//                     b.Property<string>("Content")
//                         .HasColumnType("TEXT");
//
//                     b.Property<int?>("ForumThreadId")
//                         .HasColumnType("INTEGER");
//
//                     b.Property<DateTime>("PostDate")
//                         .HasColumnType("TEXT");
//
//                     b.Property<int?>("UserId")
//                         .HasColumnType("INTEGER");
//
//                     b.HasKey("ForumPostId");
//
//                     b.HasIndex("ForumThreadId");
//
//                     b.HasIndex("UserId");
//
//                     b.ToTable("ForumPost");
//                 });
//
//             modelBuilder.Entity("organizer_gracza_backend.Model.ForumThread", b =>
//                 {
//                     b.Property<int>("ForumThreadId")
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
//                     b.Property<int?>("UserId")
//                         .HasColumnType("INTEGER");
//
//                     b.HasKey("ForumThreadId");
//
//                     b.HasIndex("UserId");
//
//                     b.ToTable("ForumThread");
//                 });
//
//             modelBuilder.Entity("organizer_gracza_backend.Model.Game", b =>
//                 {
//                     b.Property<int>("GameId")
//                         .ValueGeneratedOnAdd()
//                         .HasColumnType("INTEGER");
//
//                     b.Property<string>("Title")
//                         .HasColumnType("TEXT");
//
//                     b.HasKey("GameId");
//
//                     b.ToTable("Games");
//                 });
//
//             modelBuilder.Entity("organizer_gracza_backend.Model.GameStatistics", b =>
//                 {
//                     b.Property<int>("GameStatisticsId")
//                         .ValueGeneratedOnAdd()
//                         .HasColumnType("INTEGER");
//
//                     b.Property<int?>("GameId")
//                         .HasColumnType("INTEGER");
//
//                     b.Property<int>("LostGames")
//                         .HasColumnType("INTEGER");
//
//                     b.Property<int?>("ProfileId")
//                         .HasColumnType("INTEGER");
//
//                     b.Property<int>("WonGames")
//                         .HasColumnType("INTEGER");
//
//                     b.HasKey("GameStatisticsId");
//
//                     b.HasIndex("GameId");
//
//                     b.HasIndex("ProfileId");
//
//                     b.ToTable("GameStatistics");
//                 });
//
//             modelBuilder.Entity("organizer_gracza_backend.Model.GeneralStatistics", b =>
//                 {
//                     b.Property<int>("GeneralStatisticsId")
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
//                     b.Property<int?>("ProfileId")
//                         .HasColumnType("INTEGER");
//
//                     b.HasKey("GeneralStatisticsId");
//
//                     b.HasIndex("ProfileId");
//
//                     b.ToTable("GeneralStatistics");
//                 });
//
//             modelBuilder.Entity("organizer_gracza_backend.Model.Message", b =>
//                 {
//                     b.Property<int>("MessageId")
//                         .ValueGeneratedOnAdd()
//                         .HasColumnType("INTEGER");
//
//                     b.Property<int?>("ChatId")
//                         .HasColumnType("INTEGER");
//
//                     b.Property<string>("Content")
//                         .HasColumnType("TEXT");
//
//                     b.Property<DateTime>("MessageDate")
//                         .HasColumnType("TEXT");
//
//                     b.Property<int?>("UserId")
//                         .HasColumnType("INTEGER");
//
//                     b.HasKey("MessageId");
//
//                     b.HasIndex("ChatId");
//
//                     b.HasIndex("UserId");
//
//                     b.ToTable("Messages");
//                 });
//
//             modelBuilder.Entity("organizer_gracza_backend.Model.Photo", b =>
//                 {
//                     b.Property<int>("PhotoId")
//                         .ValueGeneratedOnAdd()
//                         .HasColumnType("INTEGER");
//
//                     b.Property<string>("PublicId")
//                         .HasColumnType("TEXT");
//
//                     b.Property<string>("Url")
//                         .HasColumnType("TEXT");
//
//                     b.Property<int>("UserId")
//                         .HasColumnType("INTEGER");
//
//                     b.Property<bool>("isMain")
//                         .HasColumnType("INTEGER");
//
//                     b.HasKey("PhotoId");
//
//                     b.HasIndex("UserId");
//
//                     b.ToTable("Photos");
//                 });
//
//             modelBuilder.Entity("organizer_gracza_backend.Model.Profile", b =>
//                 {
//                     b.Property<int>("ProfileId")
//                         .ValueGeneratedOnAdd()
//                         .HasColumnType("INTEGER");
//
//                     b.Property<string>("Description")
//                         .HasColumnType("TEXT");
//
//                     b.Property<string>("Url")
//                         .HasColumnType("TEXT");
//
//                     b.HasKey("ProfileId");
//
//                     b.ToTable("Profile");
//                 });
//
//             modelBuilder.Entity("organizer_gracza_backend.Model.Reminder", b =>
//                 {
//                     b.Property<int>("ReminderId")
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
//                     b.Property<int?>("UserId")
//                         .HasColumnType("INTEGER");
//
//                     b.HasKey("ReminderId");
//
//                     b.HasIndex("UserId");
//
//                     b.ToTable("Reminder");
//                 });
//
//             modelBuilder.Entity("organizer_gracza_backend.Model.Stream", b =>
//                 {
//                     b.Property<int>("StreamId")
//                         .ValueGeneratedOnAdd()
//                         .HasColumnType("INTEGER");
//
//                     b.Property<int?>("GameId")
//                         .HasColumnType("INTEGER");
//
//                     b.Property<string>("Name")
//                         .HasColumnType("TEXT");
//
//                     b.Property<string>("Url")
//                         .HasColumnType("TEXT");
//
//                     b.HasKey("StreamId");
//
//                     b.HasIndex("GameId");
//
//                     b.ToTable("Streams");
//                 });
//
//             modelBuilder.Entity("organizer_gracza_backend.Model.Team", b =>
//                 {
//                     b.Property<int>("TeamId")
//                         .ValueGeneratedOnAdd()
//                         .HasColumnType("INTEGER");
//
//                     b.Property<string>("Name")
//                         .HasColumnType("TEXT");
//
//                     b.HasKey("TeamId");
//
//                     b.ToTable("Teams");
//                 });
//
//             modelBuilder.Entity("organizer_gracza_backend.Model.TeamUser", b =>
//                 {
//                     b.Property<int>("TeamUserId")
//                         .ValueGeneratedOnAdd()
//                         .HasColumnType("INTEGER");
//
//                     b.Property<int>("TeamId")
//                         .HasColumnType("INTEGER");
//
//                     b.Property<int>("UserId")
//                         .HasColumnType("INTEGER");
//
//                     b.HasKey("TeamUserId");
//
//                     b.HasIndex("TeamId");
//
//                     b.HasIndex("UserId");
//
//                     b.ToTable("TeamUsers");
//                 });
//
//             modelBuilder.Entity("organizer_gracza_backend.Model.User", b =>
//                 {
//                     b.Property<int>("UserId")
//                         .ValueGeneratedOnAdd()
//                         .HasColumnType("INTEGER");
//
//                     b.Property<int?>("ChatUsersId")
//                         .HasColumnType("INTEGER");
//
//                     b.Property<DateTime>("Created")
//                         .HasColumnType("TEXT");
//
//                     b.Property<string>("Email")
//                         .HasColumnType("TEXT");
//
//                     b.Property<DateTime>("LastActive")
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
//                     b.HasKey("UserId");
//
//                     b.HasIndex("ChatUsersId");
//
//                     b.ToTable("Users");
//                 });
//
//             modelBuilder.Entity("organizer_gracza_backend.Model.Achievements", b =>
//                 {
//                     b.HasOne("organizer_gracza_backend.Model.Profile", null)
//                         .WithMany("Achievements")
//                         .HasForeignKey("ProfileId");
//                 });
//
//             modelBuilder.Entity("organizer_gracza_backend.Model.Articles", b =>
//                 {
//                     b.HasOne("organizer_gracza_backend.Model.User", "User")
//                         .WithMany()
//                         .HasForeignKey("UserId");
//
//                     b.Navigation("User");
//                 });
//
//             modelBuilder.Entity("organizer_gracza_backend.Model.ChatUsers", b =>
//                 {
//                     b.HasOne("organizer_gracza_backend.Model.Chat", "Chat")
//                         .WithMany()
//                         .HasForeignKey("ChatId");
//
//                     b.Navigation("Chat");
//                 });
//
//             modelBuilder.Entity("organizer_gracza_backend.Model.EventRegistration", b =>
//                 {
//                     b.HasOne("organizer_gracza_backend.Model.Event", "Event")
//                         .WithMany()
//                         .HasForeignKey("EventId");
//
//                     b.HasOne("organizer_gracza_backend.Model.Team", "Team")
//                         .WithMany()
//                         .HasForeignKey("TeamId");
//
//                     b.HasOne("organizer_gracza_backend.Model.User", "User")
//                         .WithMany()
//                         .HasForeignKey("UserId");
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
//                         .HasForeignKey("EventId");
//
//                     b.Navigation("Event");
//                 });
//
//             modelBuilder.Entity("organizer_gracza_backend.Model.ForumPost", b =>
//                 {
//                     b.HasOne("organizer_gracza_backend.Model.ForumThread", "ForumThread")
//                         .WithMany()
//                         .HasForeignKey("ForumThreadId");
//
//                     b.HasOne("organizer_gracza_backend.Model.User", "User")
//                         .WithMany()
//                         .HasForeignKey("UserId");
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
//                         .HasForeignKey("UserId");
//
//                     b.Navigation("User");
//                 });
//
//             modelBuilder.Entity("organizer_gracza_backend.Model.GameStatistics", b =>
//                 {
//                     b.HasOne("organizer_gracza_backend.Model.Game", "Game")
//                         .WithMany()
//                         .HasForeignKey("GameId");
//
//                     b.HasOne("organizer_gracza_backend.Model.Profile", null)
//                         .WithMany("GameStatistics")
//                         .HasForeignKey("ProfileId");
//
//                     b.Navigation("Game");
//                 });
//
//             modelBuilder.Entity("organizer_gracza_backend.Model.GeneralStatistics", b =>
//                 {
//                     b.HasOne("organizer_gracza_backend.Model.Profile", null)
//                         .WithMany("GeneralStatistics")
//                         .HasForeignKey("ProfileId");
//                 });
//
//             modelBuilder.Entity("organizer_gracza_backend.Model.Message", b =>
//                 {
//                     b.HasOne("organizer_gracza_backend.Model.Chat", "Chat")
//                         .WithMany()
//                         .HasForeignKey("ChatId");
//
//                     b.HasOne("organizer_gracza_backend.Model.User", "User")
//                         .WithMany()
//                         .HasForeignKey("UserId");
//
//                     b.Navigation("Chat");
//
//                     b.Navigation("User");
//                 });
//
//             modelBuilder.Entity("organizer_gracza_backend.Model.Photo", b =>
//                 {
//                     b.HasOne("organizer_gracza_backend.Model.User", "User")
//                         .WithMany("Photos")
//                         .HasForeignKey("UserId")
//                         .OnDelete(DeleteBehavior.Cascade)
//                         .IsRequired();
//
//                     b.Navigation("User");
//                 });
//
//             modelBuilder.Entity("organizer_gracza_backend.Model.Reminder", b =>
//                 {
//                     b.HasOne("organizer_gracza_backend.Model.User", "User")
//                         .WithMany()
//                         .HasForeignKey("UserId");
//
//                     b.Navigation("User");
//                 });
//
//             modelBuilder.Entity("organizer_gracza_backend.Model.Stream", b =>
//                 {
//                     b.HasOne("organizer_gracza_backend.Model.Game", "Game")
//                         .WithMany()
//                         .HasForeignKey("GameId");
//
//                     b.Navigation("Game");
//                 });
//
//             modelBuilder.Entity("organizer_gracza_backend.Model.TeamUser", b =>
//                 {
//                     b.HasOne("organizer_gracza_backend.Model.Team", "Team")
//                         .WithMany("TeamUser")
//                         .HasForeignKey("TeamId")
//                         .OnDelete(DeleteBehavior.Cascade)
//                         .IsRequired();
//
//                     b.HasOne("organizer_gracza_backend.Model.User", "User")
//                         .WithMany("TeamUser")
//                         .HasForeignKey("UserId")
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
//                         .HasForeignKey("ChatUsersId");
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
//                     b.Navigation("Photos");
//
//                     b.Navigation("TeamUser");
//                 });
// #pragma warning restore 612, 618
//         }
//     }
// }
