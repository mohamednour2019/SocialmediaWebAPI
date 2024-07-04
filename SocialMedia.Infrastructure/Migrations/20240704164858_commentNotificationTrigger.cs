using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialMedia.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class commentNotificationTrigger : Migration
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
                 IF exists(select 1 from inserted)
                  declare @commentOwnerId uniqueidentifier;
	                  set @commentOwnerId= (select top(1) UserId from inserted);
	                  declare @postOwnerId uniqueidentifier;
	                  set @postOwnerId= (select top(1) Posts.UserId from Posts inner join inserted 
	                  on Posts.Id=inserted.PostId);
	                  if(@commentOwnerId <> @postOwnerId)
	                  begin
		                 begin
			                 insert into Notifications(id,DateTime,NotificationType,UserId,PostId,EmmiterName,EmmiterId)
			                  select inserted.Id,inserted.DateCreated,'Comment',Posts.UserId,inserted.PostId,CONCAT(Users.FirstName,' ',Users.LastName),inserted.UserId
			                  from inserted inner join Users
			                  on inserted.UserId=Users.Id
			                  inner join Posts 
			                  on inserted.PostId=Posts.Id
		                  end
	                 end
                 end
              
            ");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP Trigger trg_AfterInsertComment");
        }
    }
}
