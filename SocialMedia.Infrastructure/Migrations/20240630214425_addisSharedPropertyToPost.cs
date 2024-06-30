using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialMedia.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addisSharedPropertyToPost : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsShared",
                table: "Posts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "ShareFromUserId",
                table: "Posts",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Posts_ShareFromUserId",
                table: "Posts",
                column: "ShareFromUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Users_ShareFromUserId",
                table: "Posts",
                column: "ShareFromUserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Users_ShareFromUserId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_ShareFromUserId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "IsShared",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "ShareFromUserId",
                table: "Posts");
        }
    }
}
