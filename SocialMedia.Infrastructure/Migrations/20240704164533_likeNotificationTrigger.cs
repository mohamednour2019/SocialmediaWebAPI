using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialMedia.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class likeNotificationTrigger : Migration
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
                     IF EXISTS (SELECT 1 FROM inserted)
                     begin

	                  declare @likeOwnerId uniqueidentifier;
	                  set @likeOwnerId= (select top(1) UserId from inserted);
	                  declare @postOwnerId uniqueidentifier;
	                  set @postOwnerId= (select top(1) Posts.UserId from Posts inner join inserted 
	                  on Posts.Id=inserted.PostId);
	                  if(@likeOwnerId <> @postOwnerId)
		                  begin
			                 insert into Notifications(id,DateTime,NotificationType,UserId,PostId,EmmiterName,EmmiterId)
				                 select inserted.Id,GETDATE(),'Like',Posts.UserId,inserted.PostId,CONCAT(Users.FirstName,' ',Users.LastName),inserted.UserId
				                 from inserted inner join Posts 
				                 on inserted.PostId=Posts.Id
				                 inner join Users
				                 on inserted.UserId=Users.Id
		                  end
                     end
                 end
           ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP Trigger trg_AfterInsertLike");
        }
    }
}
