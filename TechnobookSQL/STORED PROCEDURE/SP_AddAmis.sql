CREATE PROCEDURE [dbo].[SP_AddAmis]
	@UsersID INT,
	@AmisID INT,
	@IsAmis BIT,
	@Send BIT
AS
	INSERT INTO Amis(UsersID,AmisID,EstAMIS,DemandeAmis) VALUES (@UsersID,@AmisID,@IsAmis,@Send)
	INSERT INTO Amis(UsersID,AmisID,EstAMIS,DemandeAmis) VALueS (@AmisID,@UsersID,@IsAmis,@Send)
