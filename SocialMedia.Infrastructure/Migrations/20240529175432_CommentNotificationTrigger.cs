using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialMedia.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CommentNotificationTrigger : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
             create trigger trg_AfterInsertComment
             on Comments
             after insert
             as
             begin
             IF exists(select 1 from inserted where NotificationId is not null)
                 begin
                     insert into Notifications(id,DateTime,NotificationType,UserId,PostId,EmmiterName,EmmiterId)
                      select inserted.NotificationId,inserted.DateCreated,'Comment',Posts.UserId,inserted.PostId,CONCAT(Users.FirstName,' ',Users.LastName),inserted.UserId
                      from inserted inner join Users
                      on inserted.UserId=Users.Id
                      inner join Posts 
                      on inserted.PostId=Posts.Id
                 end
             end


             ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP TRIGGER trg_AfterInsertComment");
        }
    }
}
