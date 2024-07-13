using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialMedia.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NotificationCommentTrigger : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
		    CREATE TRIGGER [dbo].[trg_AfterInsertCommentTrigger]
            ON [dbo].[Comments]
            AFTER INSERT
            AS
            BEGIN
                IF EXISTS (SELECT 1 FROM inserted)
                BEGIN
                    DECLARE @insertedCommentId UNIQUEIDENTIFIER;
                    DECLARE @DateCreated DATETIME;
                    DECLARE @postId UNIQUEIDENTIFIER;
                    DECLARE @commentOwnerId UNIQUEIDENTIFIER;
                    DECLARE @parentCommentId UNIQUEIDENTIFIER;
                    DECLARE @postOwnerId UNIQUEIDENTIFIER;
                    DECLARE @parentCommentUserId UNIQUEIDENTIFIER;
                    DECLARE @EmmiterFirstName NVARCHAR(100);
                    DECLARE @EmmiterLastName NVARCHAR(100);
					Declare @NotificationPicture nvarchar(max);

                    SELECT @insertedCommentId = Id,
                           @DateCreated = DateCreated,
                           @postId = PostId,
                           @commentOwnerId = UserId,
                           @parentCommentId = CommentParentId
                    FROM inserted;

                    SELECT @postOwnerId = UserId 
                    FROM Posts 
                    WHERE Id = @postId;

                    IF @parentCommentId IS NOT NULL
                    BEGIN
                        SELECT @parentCommentUserId = UserId 
                        FROM Comments 
                        WHERE Id = @parentCommentId;
                    END

                    SELECT @EmmiterFirstName = FirstName,
                           @EmmiterLastName = LastName,
                           @NotificationPicture=ProfilePicture
                    FROM Users 
                    WHERE Id = @commentOwnerId;

                    IF (@parentCommentId IS NULL)
                    BEGIN
                        IF (@commentOwnerId <> @postOwnerId)
                        BEGIN
                            INSERT INTO Notifications(Id, DateTime, NotificationType, UserId, PostId, EmmiterName, EmmiterId,NotificationImage)
                            VALUES(@insertedCommentId, @DateCreated, 'Comment', @postOwnerId, @postId, CONCAT(@EmmiterFirstName, ' ', @EmmiterLastName), @commentOwnerId,@NotificationPicture);
                        END
                    END
                    ELSE
                    BEGIN
                        IF (@commentOwnerId <> @parentCommentUserId)
                        BEGIN
                            INSERT INTO Notifications(Id, DateTime, NotificationType, UserId, PostId, EmmiterName, EmmiterId,NotificationImage)
                            VALUES(@insertedCommentId, @DateCreated, 'Reply', @parentCommentUserId, @postId, CONCAT(@EmmiterFirstName, ' ', @EmmiterLastName), @commentOwnerId,@NotificationPicture);
                        END
                    END
                END
            END;


           ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@" Drop Trigger trg_AfterInsertCommentTrigger");
        }
    }
}
