using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialMedia.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RenameReplyTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reply_Comments_CommentId",
                table: "Reply");

            migrationBuilder.DropForeignKey(
                name: "FK_Reply_Reply_ReplyId",
                table: "Reply");

            migrationBuilder.DropForeignKey(
                name: "FK_Reply_Users_UserId",
                table: "Reply");

            migrationBuilder.DropForeignKey(
                name: "FK_ReplyLike_Reply_ReplyId",
                table: "ReplyLike");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reply",
                table: "Reply");

            migrationBuilder.RenameTable(
                name: "Reply",
                newName: "Replies");

            migrationBuilder.RenameIndex(
                name: "IX_Reply_UserId",
                table: "Replies",
                newName: "IX_Replies_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Reply_ReplyId",
                table: "Replies",
                newName: "IX_Replies_ReplyId");

            migrationBuilder.RenameIndex(
                name: "IX_Reply_CommentId",
                table: "Replies",
                newName: "IX_Replies_CommentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Replies",
                table: "Replies",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Replies_Comments_CommentId",
                table: "Replies",
                column: "CommentId",
                principalTable: "Comments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Replies_Replies_ReplyId",
                table: "Replies",
                column: "ReplyId",
                principalTable: "Replies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Replies_Users_UserId",
                table: "Replies",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReplyLike_Replies_ReplyId",
                table: "ReplyLike",
                column: "ReplyId",
                principalTable: "Replies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Replies_Comments_CommentId",
                table: "Replies");

            migrationBuilder.DropForeignKey(
                name: "FK_Replies_Replies_ReplyId",
                table: "Replies");

            migrationBuilder.DropForeignKey(
                name: "FK_Replies_Users_UserId",
                table: "Replies");

            migrationBuilder.DropForeignKey(
                name: "FK_ReplyLike_Replies_ReplyId",
                table: "ReplyLike");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Replies",
                table: "Replies");

            migrationBuilder.RenameTable(
                name: "Replies",
                newName: "Reply");

            migrationBuilder.RenameIndex(
                name: "IX_Replies_UserId",
                table: "Reply",
                newName: "IX_Reply_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Replies_ReplyId",
                table: "Reply",
                newName: "IX_Reply_ReplyId");

            migrationBuilder.RenameIndex(
                name: "IX_Replies_CommentId",
                table: "Reply",
                newName: "IX_Reply_CommentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reply",
                table: "Reply",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reply_Comments_CommentId",
                table: "Reply",
                column: "CommentId",
                principalTable: "Comments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reply_Reply_ReplyId",
                table: "Reply",
                column: "ReplyId",
                principalTable: "Reply",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reply_Users_UserId",
                table: "Reply",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReplyLike_Reply_ReplyId",
                table: "ReplyLike",
                column: "ReplyId",
                principalTable: "Reply",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
