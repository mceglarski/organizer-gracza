﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using organizer_gracza_backend.Data;

namespace organizer_gracza_backend.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.9");

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<int>("RoleId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("organizer_gracza_backend.Model.Achievements", b =>
                {
                    b.Property<int>("AchievementsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Details")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhotoUrl")
                        .HasColumnType("TEXT");

                    b.Property<int?>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("AchievementsId");

                    b.HasIndex("UserId");

                    b.ToTable("Achievements");
                });

            modelBuilder.Entity("organizer_gracza_backend.Model.AppRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("organizer_gracza_backend.Model.Articles", b =>
                {
                    b.Property<int>("ArticlesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Content")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhotoUrl")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("PublicationDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.Property<int?>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ArticlesId");

                    b.HasIndex("UserId");

                    b.ToTable("Articles");
                });

            modelBuilder.Entity("organizer_gracza_backend.Model.Chat", b =>
                {
                    b.Property<int>("ChatId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("ChatId");

                    b.ToTable("Chats");
                });

            modelBuilder.Entity("organizer_gracza_backend.Model.ChatUsers", b =>
                {
                    b.Property<int>("ChatUsersId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ChatId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ChatUsersId");

                    b.HasIndex("ChatId");

                    b.ToTable("ChatUsers");
                });

            modelBuilder.Entity("organizer_gracza_backend.Model.Connection", b =>
                {
                    b.Property<string>("ConnectionId")
                        .HasColumnType("TEXT");

                    b.Property<string>("GroupName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Username")
                        .HasColumnType("TEXT");

                    b.HasKey("ConnectionId");

                    b.HasIndex("GroupName");

                    b.ToTable("Connections");
                });

            modelBuilder.Entity("organizer_gracza_backend.Model.EventResult", b =>
                {
                    b.Property<int>("EventResultId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("WinnerName")
                        .HasColumnType("TEXT");

                    b.HasKey("EventResultId");

                    b.ToTable("EventResults");
                });

            modelBuilder.Entity("organizer_gracza_backend.Model.EventTeam", b =>
                {
                    b.Property<int>("EventTeamId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("EventOrganiser")
                        .HasColumnType("TEXT");

                    b.Property<string>("EventType")
                        .HasColumnType("TEXT");

                    b.Property<int?>("GameId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhotoUrl")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("TEXT");

                    b.Property<double?>("WinnerPrize")
                        .HasColumnType("REAL");

                    b.HasKey("EventTeamId");

                    b.HasIndex("GameId");

                    b.ToTable("EventTeam");
                });

            modelBuilder.Entity("organizer_gracza_backend.Model.EventTeamRegistration", b =>
                {
                    b.Property<int>("EventTeamRegistrationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("EventTeamId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TeamId")
                        .HasColumnType("INTEGER");

                    b.HasKey("EventTeamRegistrationId");

                    b.HasIndex("EventTeamId");

                    b.HasIndex("TeamId");

                    b.ToTable("EventTeamRegistration");
                });

            modelBuilder.Entity("organizer_gracza_backend.Model.EventUser", b =>
                {
                    b.Property<int>("EventUserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("EventOrganiser")
                        .HasColumnType("TEXT");

                    b.Property<string>("EventType")
                        .HasColumnType("TEXT");

                    b.Property<int?>("GameId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhotoUrl")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("TEXT");

                    b.Property<double?>("WinnerPrize")
                        .HasColumnType("REAL");

                    b.HasKey("EventUserId");

                    b.HasIndex("GameId");

                    b.ToTable("EventUser");
                });

            modelBuilder.Entity("organizer_gracza_backend.Model.EventUserRegistration", b =>
                {
                    b.Property<int>("EventUserRegistrationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("EventUserId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("EventUserRegistrationId");

                    b.HasIndex("EventUserId");

                    b.HasIndex("UserId");

                    b.ToTable("EventUserRegistration");
                });

            modelBuilder.Entity("organizer_gracza_backend.Model.ForumPost", b =>
                {
                    b.Property<int>("ForumPostId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Content")
                        .HasColumnType("TEXT");

                    b.Property<int?>("ForumThreadId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("PostDate")
                        .HasColumnType("TEXT");

                    b.Property<int?>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ForumPostId");

                    b.HasIndex("ForumThreadId");

                    b.HasIndex("UserId");

                    b.ToTable("ForumPost");
                });

            modelBuilder.Entity("organizer_gracza_backend.Model.ForumThread", b =>
                {
                    b.Property<int>("ForumThreadId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Content")
                        .HasColumnType("TEXT");

                    b.Property<int?>("GameId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("ThreadDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.Property<int?>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ForumThreadId");

                    b.HasIndex("GameId");

                    b.HasIndex("UserId");

                    b.ToTable("ForumThread");
                });

            modelBuilder.Entity("organizer_gracza_backend.Model.Game", b =>
                {
                    b.Property<int>("GameId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("PhotoUrl")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.HasKey("GameId");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("organizer_gracza_backend.Model.GameStatistics", b =>
                {
                    b.Property<int>("GameStatisticsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("GameId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("LostGames")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("UserId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("WonGames")
                        .HasColumnType("INTEGER");

                    b.HasKey("GameStatisticsId");

                    b.HasIndex("GameId");

                    b.HasIndex("UserId");

                    b.ToTable("GameStatistics");
                });

            modelBuilder.Entity("organizer_gracza_backend.Model.GeneralStatistics", b =>
                {
                    b.Property<int>("GeneralStatisticsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("EventsParticipated")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("EventsWon")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("PostWritten")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("GeneralStatisticsId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("GeneralStatistics");
                });

            modelBuilder.Entity("organizer_gracza_backend.Model.Group", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Name");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("organizer_gracza_backend.Model.Message", b =>
                {
                    b.Property<int>("MessageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Content")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DateRead")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("MessageSent")
                        .HasColumnType("TEXT");

                    b.Property<bool>("RecipientDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RecipientId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("RecipientUsername")
                        .HasColumnType("TEXT");

                    b.Property<bool>("SenderDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SenderId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SenderUsername")
                        .HasColumnType("TEXT");

                    b.HasKey("MessageId");

                    b.HasIndex("RecipientId");

                    b.HasIndex("SenderId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("organizer_gracza_backend.Model.Photo", b =>
                {
                    b.Property<int>("PhotoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsMain")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PublicId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Url")
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("PhotoId");

                    b.HasIndex("UserId");

                    b.ToTable("Photos");
                });

            modelBuilder.Entity("organizer_gracza_backend.Model.Reminder", b =>
                {
                    b.Property<int>("ReminderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.Property<int?>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ReminderId");

                    b.HasIndex("UserId");

                    b.ToTable("Reminder");
                });

            modelBuilder.Entity("organizer_gracza_backend.Model.Stream", b =>
                {
                    b.Property<int>("StreamId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("GameId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Url")
                        .HasColumnType("TEXT");

                    b.HasKey("StreamId");

                    b.HasIndex("GameId");

                    b.ToTable("Streams");
                });

            modelBuilder.Entity("organizer_gracza_backend.Model.Team", b =>
                {
                    b.Property<int>("TeamId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhotoUrl")
                        .HasColumnType("TEXT");

                    b.HasKey("TeamId");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("organizer_gracza_backend.Model.TeamUser", b =>
                {
                    b.Property<int>("TeamUserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("TeamId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("TeamUserId");

                    b.HasIndex("TeamId");

                    b.HasIndex("UserId");

                    b.ToTable("TeamUsers");
                });

            modelBuilder.Entity("organizer_gracza_backend.Model.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ChatUsersId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("LastActive")
                        .HasColumnType("TEXT");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nickname")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("TEXT");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ChatUsersId");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("organizer_gracza_backend.Model.UserAchievementCounter", b =>
                {
                    b.Property<int>("UserAchievementCounterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("NumberOfTeamsCreated")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("NumberOfTeamsJoined")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("UserAchievementCounterId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("UserAchievementCounters");
                });

            modelBuilder.Entity("organizer_gracza_backend.Model.UserRole", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RoleId")
                        .HasColumnType("INTEGER");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("organizer_gracza_backend.Model.AppRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("organizer_gracza_backend.Model.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("organizer_gracza_backend.Model.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("organizer_gracza_backend.Model.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("organizer_gracza_backend.Model.Achievements", b =>
                {
                    b.HasOne("organizer_gracza_backend.Model.User", "User")
                        .WithMany("Achievements")
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("organizer_gracza_backend.Model.Articles", b =>
                {
                    b.HasOne("organizer_gracza_backend.Model.User", "User")
                        .WithMany("Articles")
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("organizer_gracza_backend.Model.ChatUsers", b =>
                {
                    b.HasOne("organizer_gracza_backend.Model.Chat", "Chat")
                        .WithMany()
                        .HasForeignKey("ChatId");

                    b.Navigation("Chat");
                });

            modelBuilder.Entity("organizer_gracza_backend.Model.Connection", b =>
                {
                    b.HasOne("organizer_gracza_backend.Model.Group", null)
                        .WithMany("Connections")
                        .HasForeignKey("GroupName");
                });

            modelBuilder.Entity("organizer_gracza_backend.Model.EventTeam", b =>
                {
                    b.HasOne("organizer_gracza_backend.Model.Game", "Game")
                        .WithMany("EventTeam")
                        .HasForeignKey("GameId");

                    b.Navigation("Game");
                });

            modelBuilder.Entity("organizer_gracza_backend.Model.EventTeamRegistration", b =>
                {
                    b.HasOne("organizer_gracza_backend.Model.EventTeam", "EventTeam")
                        .WithMany("EventTeamRegistration")
                        .HasForeignKey("EventTeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("organizer_gracza_backend.Model.Team", "Team")
                        .WithMany("EventTeamRegistration")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EventTeam");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("organizer_gracza_backend.Model.EventUser", b =>
                {
                    b.HasOne("organizer_gracza_backend.Model.Game", "Game")
                        .WithMany("EventUser")
                        .HasForeignKey("GameId");

                    b.Navigation("Game");
                });

            modelBuilder.Entity("organizer_gracza_backend.Model.EventUserRegistration", b =>
                {
                    b.HasOne("organizer_gracza_backend.Model.EventUser", "EventUser")
                        .WithMany("EventUserRegistration")
                        .HasForeignKey("EventUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("organizer_gracza_backend.Model.User", "User")
                        .WithMany("EventUserRegistration")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EventUser");

                    b.Navigation("User");
                });

            modelBuilder.Entity("organizer_gracza_backend.Model.ForumPost", b =>
                {
                    b.HasOne("organizer_gracza_backend.Model.ForumThread", "ForumThread")
                        .WithMany("ForumPosts")
                        .HasForeignKey("ForumThreadId");

                    b.HasOne("organizer_gracza_backend.Model.User", "User")
                        .WithMany("ForumPosts")
                        .HasForeignKey("UserId");

                    b.Navigation("ForumThread");

                    b.Navigation("User");
                });

            modelBuilder.Entity("organizer_gracza_backend.Model.ForumThread", b =>
                {
                    b.HasOne("organizer_gracza_backend.Model.Game", "Game")
                        .WithMany("ForumThread")
                        .HasForeignKey("GameId");

                    b.HasOne("organizer_gracza_backend.Model.User", "User")
                        .WithMany("ForumThreads")
                        .HasForeignKey("UserId");

                    b.Navigation("Game");

                    b.Navigation("User");
                });

            modelBuilder.Entity("organizer_gracza_backend.Model.GameStatistics", b =>
                {
                    b.HasOne("organizer_gracza_backend.Model.Game", "Game")
                        .WithMany("GameStatistics")
                        .HasForeignKey("GameId");

                    b.HasOne("organizer_gracza_backend.Model.User", "User")
                        .WithMany("GameStatistics")
                        .HasForeignKey("UserId");

                    b.Navigation("Game");

                    b.Navigation("User");
                });

            modelBuilder.Entity("organizer_gracza_backend.Model.GeneralStatistics", b =>
                {
                    b.HasOne("organizer_gracza_backend.Model.User", "User")
                        .WithOne("GeneralStatistics")
                        .HasForeignKey("organizer_gracza_backend.Model.GeneralStatistics", "UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("organizer_gracza_backend.Model.Message", b =>
                {
                    b.HasOne("organizer_gracza_backend.Model.User", "Recipient")
                        .WithMany("MessagesReceived")
                        .HasForeignKey("RecipientId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("organizer_gracza_backend.Model.User", "Sender")
                        .WithMany("MessagesSent")
                        .HasForeignKey("SenderId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Recipient");

                    b.Navigation("Sender");
                });

            modelBuilder.Entity("organizer_gracza_backend.Model.Photo", b =>
                {
                    b.HasOne("organizer_gracza_backend.Model.User", "User")
                        .WithMany("Photos")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("organizer_gracza_backend.Model.Reminder", b =>
                {
                    b.HasOne("organizer_gracza_backend.Model.User", "User")
                        .WithMany("Reminders")
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("organizer_gracza_backend.Model.Stream", b =>
                {
                    b.HasOne("organizer_gracza_backend.Model.Game", "Game")
                        .WithMany()
                        .HasForeignKey("GameId");

                    b.Navigation("Game");
                });

            modelBuilder.Entity("organizer_gracza_backend.Model.TeamUser", b =>
                {
                    b.HasOne("organizer_gracza_backend.Model.Team", "Team")
                        .WithMany("TeamUser")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("organizer_gracza_backend.Model.User", "User")
                        .WithMany("TeamUser")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Team");

                    b.Navigation("User");
                });

            modelBuilder.Entity("organizer_gracza_backend.Model.User", b =>
                {
                    b.HasOne("organizer_gracza_backend.Model.ChatUsers", null)
                        .WithMany("User")
                        .HasForeignKey("ChatUsersId");
                });

            modelBuilder.Entity("organizer_gracza_backend.Model.UserAchievementCounter", b =>
                {
                    b.HasOne("organizer_gracza_backend.Model.User", "User")
                        .WithOne("UserAchievementCounter")
                        .HasForeignKey("organizer_gracza_backend.Model.UserAchievementCounter", "UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("organizer_gracza_backend.Model.UserRole", b =>
                {
                    b.HasOne("organizer_gracza_backend.Model.AppRole", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("organizer_gracza_backend.Model.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("organizer_gracza_backend.Model.AppRole", b =>
                {
                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("organizer_gracza_backend.Model.ChatUsers", b =>
                {
                    b.Navigation("User");
                });

            modelBuilder.Entity("organizer_gracza_backend.Model.EventTeam", b =>
                {
                    b.Navigation("EventTeamRegistration");
                });

            modelBuilder.Entity("organizer_gracza_backend.Model.EventUser", b =>
                {
                    b.Navigation("EventUserRegistration");
                });

            modelBuilder.Entity("organizer_gracza_backend.Model.ForumThread", b =>
                {
                    b.Navigation("ForumPosts");
                });

            modelBuilder.Entity("organizer_gracza_backend.Model.Game", b =>
                {
                    b.Navigation("EventTeam");

                    b.Navigation("EventUser");

                    b.Navigation("ForumThread");

                    b.Navigation("GameStatistics");
                });

            modelBuilder.Entity("organizer_gracza_backend.Model.Group", b =>
                {
                    b.Navigation("Connections");
                });

            modelBuilder.Entity("organizer_gracza_backend.Model.Team", b =>
                {
                    b.Navigation("EventTeamRegistration");

                    b.Navigation("TeamUser");
                });

            modelBuilder.Entity("organizer_gracza_backend.Model.User", b =>
                {
                    b.Navigation("Achievements");

                    b.Navigation("Articles");

                    b.Navigation("EventUserRegistration");

                    b.Navigation("ForumPosts");

                    b.Navigation("ForumThreads");

                    b.Navigation("GameStatistics");

                    b.Navigation("GeneralStatistics");

                    b.Navigation("MessagesReceived");

                    b.Navigation("MessagesSent");

                    b.Navigation("Photos");

                    b.Navigation("Reminders");

                    b.Navigation("TeamUser");

                    b.Navigation("UserAchievementCounter");

                    b.Navigation("UserRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
