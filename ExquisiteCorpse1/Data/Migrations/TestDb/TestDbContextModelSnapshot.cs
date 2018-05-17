using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using ExquisiteCorpse1.Data.Tests.Models;

namespace ExquisiteCorpse1.Migrations.TestDb
{
    [DbContext(typeof(TestDbContext))]
    partial class TestDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2");

            modelBuilder.Entity("ExquisiteCorpse1.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ApplicationUserId");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<int?>("CorpseId");

                    b.Property<string>("Email")
                        .HasMaxLength(127);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(127);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(127);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("ProfileName");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(127);

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("CorpseId");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("ExquisiteCorpse1.Models.Corpse", b =>
                {
                    b.Property<int>("CorpseId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CurrentPlayerIndex");

                    b.Property<int>("CurrentRound");

                    b.Property<int>("Rounds");

                    b.Property<string>("Status");

                    b.Property<string>("Title");

                    b.HasKey("CorpseId");

                    b.ToTable("Corpses");
                });

            modelBuilder.Entity("ExquisiteCorpse1.Models.Section", b =>
                {
                    b.Property<int>("SectionId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CorpseId");

                    b.Property<string>("SectionText");

                    b.Property<string>("Stub");

                    b.Property<string>("UserId");

                    b.HasKey("SectionId");

                    b.HasIndex("CorpseId");

                    b.HasIndex("UserId");

                    b.ToTable("Sections");
                });

            modelBuilder.Entity("ExquisiteCorpse1.Models.UserCorpse", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<int>("CorpseId");

                    b.Property<int>("UserCorpseId");

                    b.HasKey("UserId", "CorpseId");

                    b.HasAlternateKey("UserCorpseId");

                    b.HasIndex("CorpseId");

                    b.ToTable("UsersCorpses");
                });

            modelBuilder.Entity("ExquisiteCorpse1.Models.UserSection", b =>
                {
                    b.Property<int>("UserSectionId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ApplicationUserId");

                    b.Property<int>("SectionId");

                    b.Property<string>("UserId");

                    b.HasKey("UserSectionId");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("SectionId");

                    b.ToTable("UsersSections");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(127);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(127);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("ExquisiteCorpse1.Models.ApplicationUser", b =>
                {
                    b.HasOne("ExquisiteCorpse1.Models.ApplicationUser")
                        .WithMany("Friends")
                        .HasForeignKey("ApplicationUserId");

                    b.HasOne("ExquisiteCorpse1.Models.Corpse")
                        .WithMany("Players")
                        .HasForeignKey("CorpseId");
                });

            modelBuilder.Entity("ExquisiteCorpse1.Models.Section", b =>
                {
                    b.HasOne("ExquisiteCorpse1.Models.Corpse", "Corpse")
                        .WithMany("Sections")
                        .HasForeignKey("CorpseId");

                    b.HasOne("ExquisiteCorpse1.Models.ApplicationUser", "User")
                        .WithMany("Sections")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("ExquisiteCorpse1.Models.UserCorpse", b =>
                {
                    b.HasOne("ExquisiteCorpse1.Models.Corpse", "Corpse")
                        .WithMany("UserCorpses")
                        .HasForeignKey("CorpseId");

                    b.HasOne("ExquisiteCorpse1.Models.ApplicationUser", "ApplicationUser")
                        .WithMany("UserCorpses")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("ExquisiteCorpse1.Models.UserSection", b =>
                {
                    b.HasOne("ExquisiteCorpse1.Models.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("ApplicationUserId");

                    b.HasOne("ExquisiteCorpse1.Models.Section", "Section")
                        .WithMany()
                        .HasForeignKey("SectionId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("ExquisiteCorpse1.Models.ApplicationUser")
                        .WithMany("Claims")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("ExquisiteCorpse1.Models.ApplicationUser")
                        .WithMany("Logins")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Users")
                        .HasForeignKey("RoleId");

                    b.HasOne("ExquisiteCorpse1.Models.ApplicationUser")
                        .WithMany("Roles")
                        .HasForeignKey("UserId");
                });
        }
    }
}
