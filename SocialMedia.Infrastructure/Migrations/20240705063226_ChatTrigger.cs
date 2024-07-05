using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialMedia.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChatTrigger : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
               create trigger trg_AfterSendMessage
                on [dbo].[Messages]
                after insert
                as
                begin
                 if exists(select 1 from inserted)
                 begin
    
	                Declare @SenderId uniqueidentifier ;
                    Declare @ReciverId uniqueidentifier ;
	                Declare @MessageId uniqueidentifier ;
	                set @SenderId=(select top(1) SenderId from inserted)
	                set @ReciverId=(select top(1) ReciverId from inserted)
	                set @MessageId=(select top(1) Id from inserted)

	                if exists( select 1 from Chats where FirstUserId=@SenderId and SecondUserId=@ReciverId)
	                begin
		                update Chats 
		                set LastMessegeId=@MessageId
		                where (FirstUserId=@SenderId and SecondUserId=@ReciverId) or(FirstUserId=@ReciverId and SecondUserId=@SenderId);
	                end

                    else

	                begin
		                insert into [dbo].[Chats](FirstUserId,SecondUserId,LastMessegeId)
		                values(@ReciverId,@SenderId,@MessageId)

		                insert into [dbo].[Chats](FirstUserId,SecondUserId,LastMessegeId)
		                values(@SenderId,@ReciverId,@MessageId);
	                end

                 end
                end
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP Trigger trg_AfterSendMessage");
        }
    }
}
