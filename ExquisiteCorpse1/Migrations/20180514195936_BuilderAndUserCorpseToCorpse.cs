using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ExquisiteCorpse1.Migrations
{
    public partial class BuilderAndUserCorpseToCorpse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Corpses_CorpseId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersCorpses_AspNetUsers_UserId",
                table: "UsersCorpses");

            migrationBuilder.DropIndex(
                name: "IX_UsersCorpses_UserId",
                table: "UsersCorpses");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_CorpseId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CorpseId",
                table: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "UsersSections",
                columns: table => new
                {
                    UserSectionId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGeneratedOnAdd", true),
                    SectionId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersSections", x => x.UserSectionId);
                    table.ForeignKey(
                        name: "FK_UsersSections_Sections_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Sections",
                        principalColumn: "SectionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsersSections_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UsersCorpses",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserCorpseId",
                table: "UsersCorpses",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("MySql:ValueGeneratedOnAdd", true);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_UsersCorpses_UserCorpseId",
                table: "UsersCorpses",
                column: "UserCorpseId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersSections_SectionId",
                table: "UsersSections",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersSections_UserId",
                table: "UsersSections",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UsersCorpses_AspNetUsers_UserId",
                table: "UsersCorpses",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersCorpses_AspNetUsers_UserId",
                table: "UsersCorpses");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_UsersCorpses_UserCorpseId",
                table: "UsersCorpses");

            migrationBuilder.DropTable(
                name: "UsersSections");

            migrationBuilder.AddColumn<int>(
                name: "CorpseId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserCorpseId",
                table: "UsersCorpses",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("MySql:ValueGeneratedOnAdd", true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UsersCorpses",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.CreateIndex(
                name: "IX_UsersCorpses_UserId",
                table: "UsersCorpses",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CorpseId",
                table: "AspNetUsers",
                column: "CorpseId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Corpses_CorpseId",
                table: "AspNetUsers",
                column: "CorpseId",
                principalTable: "Corpses",
                principalColumn: "CorpseId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersCorpses_AspNetUsers_UserId",
                table: "UsersCorpses",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
