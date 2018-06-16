CREATE PROCEDURE [dbo].[SP_RemoveFeed]
	@UsersID INT,
	@ID INT
AS
	DELETE Fil 
	WHERE @UsersID = UsersID AND @ID = FilID
