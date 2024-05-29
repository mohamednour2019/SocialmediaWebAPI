using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialMedia.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class LikeNotificationTrigger : Migration
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
                    IF EXISTS (SELECT 1 FROM inserted WHERE NotificationId IS NOT NULL)
                    begin
                        insert into Notifications(id,DateTime,NotificationType,UserId,PostId,EmmiterName,EmmiterId)
                            select inserted.NotificationId,GETDATE(),'Like',Posts.UserId,inserted.PostId,CONCAT(Users.FirstName,' ',Users.LastName),inserted.UserId
                            from inserted inner join Posts 
                            on inserted.PostId=Posts.Id
                            inner join Users
                            on inserted.UserId=Users.Id
                    end
                end

            ");
        }

        /// <inheritdoc />


        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP TRIGGER trg_AfterInsertLike");
        }
    }
}
