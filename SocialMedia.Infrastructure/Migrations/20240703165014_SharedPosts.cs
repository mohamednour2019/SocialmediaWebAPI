using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialMedia.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SharedPosts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "SharedFromPostId",
                table: "Posts",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Posts_SharedFromPostId",
                table: "Posts",
                column: "SharedFromPostId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Posts_SharedFromPostId",
                table: "Posts",
                column: "SharedFromPostId",
                principalTable: "Posts",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Posts_SharedFromPostId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_SharedFromPostId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "SharedFromPostId",
                table: "Posts");
        }
    }
}
