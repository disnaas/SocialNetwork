CREATE PROCEDURE [dbo].[SP_RemoveFriend]
	@UsersID INT,
	@AmisID INT
AS
	DELETE FROM Amis
	WHERE @UsersID = UsersID AND @AmisID = AmisID
	DELETE FROM Amis
	WHERE @UsersID = AmisID AND @AmisID = UsersID
