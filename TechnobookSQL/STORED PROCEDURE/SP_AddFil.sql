CREATE PROCEDURE [dbo].[SP_AddFil]
	@UsersID INT,
	@Text VARCHAR(500)
AS
	SELECT UsersID FROM Utilisateurs WHERE @UsersID = UsersID
	INSERT INTO Fil(UsersID,Text) VALUES (@UsersID,@Text)
