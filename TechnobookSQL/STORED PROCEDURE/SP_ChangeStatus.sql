CREATE PROCEDURE [dbo].[SP_ChangeStatus]
	@UsersID INT,
	@AmisID INT
AS
	UPDATE Amis
	SET EstAMIS = 1, DemandeAmis = 0
	WHERE UsersID = @UsersID AND AmisID = @AmisID
	UPDATE Amis
	SET EstAMIS = 1, DemandeAmis = 0
	WHERE UsersID = @AmisID AND AmisID = @UsersID
