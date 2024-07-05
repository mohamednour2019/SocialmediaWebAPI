using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialMedia.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeRelationShipChatMessage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Chat_LastMessegeId",
                table: "Chat");

            migrationBuilder.CreateIndex(
                name: "IX_Chat_LastMessegeId",
                table: "Chat",
                column: "LastMessegeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Chat_LastMessegeId",
                table: "Chat");

            migrationBuilder.CreateIndex(
                name: "IX_Chat_LastMessegeId",
                table: "Chat",
                column: "LastMessegeId",
                unique: true);
        }
    }
}
