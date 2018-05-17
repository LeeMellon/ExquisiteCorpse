using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ExquisiteCorpse1.Migrations
{
    public partial class AddStatusAndCurrentPlayerIndex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sections_AspNetUsers_ApplicationUserId",
                table: "Sections");

            migrationBuilder.DropIndex(
                name: "IX_Sections_ApplicationUserId",
                table: "Sections");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Sections");

            migrationBuilder.AddColumn<int>(
                name: "CurrentPlayerIndex",
                table: "Corpses",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Corpses",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Sections",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sections_UserId",
                table: "Sections",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sections_AspNetUsers_UserId",
                table: "Sections",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sections_AspNetUsers_UserId",
                table: "Sections");

            migrationBuilder.DropIndex(
                name: "IX_Sections_UserId",
                table: "Sections");

            migrationBuilder.DropColumn(
                name: "CurrentPlayerIndex",
                table: "Corpses");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Corpses");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Sections",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Sections",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sections_ApplicationUserId",
                table: "Sections",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sections_AspNetUsers_ApplicationUserId",
                table: "Sections",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
