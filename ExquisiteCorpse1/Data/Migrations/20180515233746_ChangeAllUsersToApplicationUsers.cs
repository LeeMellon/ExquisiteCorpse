using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ExquisiteCorpse1.Migrations
{
    public partial class ChangeAllUsersToApplicationUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersSections_AspNetUsers_UserId",
                table: "UsersSections");

            migrationBuilder.DropIndex(
                name: "IX_UsersSections_UserId",
                table: "UsersSections");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "UsersSections",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UsersSections",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UsersSections_ApplicationUserId",
                table: "UsersSections",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UsersSections_AspNetUsers_ApplicationUserId",
                table: "UsersSections",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersSections_AspNetUsers_ApplicationUserId",
                table: "UsersSections");

            migrationBuilder.DropIndex(
                name: "IX_UsersSections_ApplicationUserId",
                table: "UsersSections");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "UsersSections");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UsersSections",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UsersSections_UserId",
                table: "UsersSections",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UsersSections_AspNetUsers_UserId",
                table: "UsersSections",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
