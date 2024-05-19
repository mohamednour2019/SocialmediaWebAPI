using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialMedia.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class likeTrigger : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                create trigger trg_AfterInsertLike
                on Likes
                after insert
                as
                begin
                insert into Notifications(id,DateTime,NotificationType,UserId,PostId,NotificationImage,EmmiterName)
                    select inserted.NotificationId,GETDATE(),'Like',Posts.UserId,inserted.PostId,Users.ProfilePicture,CONCAT(Users.FirstName,' ',Users.LastName)
                    from inserted inner join Posts 
                    on inserted.PostId=Posts.Id
                    inner join Users
                    on inserted.UserId=Users.Id

                end

            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP TRIGGER trg_AfterInsertLike");
        }
    }
}
