using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialMedia.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class sharePostNotificationTrigger : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                create trigger trg_AfterSharePost
                on dbo.Posts
                after insert
                as
                begin
                  if exists(Select 1 from inserted where SharedFromPostId is not null)
                  begin
	                  declare @newPostUserId uniqueidentifier;
	                  set @newPostUserId= (select top(1) UserId from inserted);
	                  declare @SharedPostUserId uniqueidentifier;
	                  set @SharedPostUserId= (select top(1) Posts.UserId from Posts inner join inserted 
	                  on Posts.Id=inserted.SharedFromPostId);
	                  if(@SharedPostUserId <> @newPostUserId)
	                  begin
		                  insert into Notifications (Id,DateTime,NotificationType,PostId,EmmiterName,EmmiterId,UserId,NotificationImage)
		                  select inserted.Id,inserted.DateTime,'Share',inserted.SharedFromPostId,CONCAT(Users.FirstName,' ',Users.LastName),Users.Id,Posts.UserId,Users.ProfilePicture
		                  from Users inner join inserted
		                  on Users.Id=inserted.UserId inner join Posts
		                  on inserted.SharedFromPostId=Posts.Id
	                  end
                  end
                end
                ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP Trigger trg_AfterSharePost");
        }
    }
}
