CREATE PROCEDURE [dbo].[SP_CheckUser]
	@Email VARCHAR(200),
	@Password VARCHAR(256)
AS
	IF EXISTS(SELECT UsersID FROM Utilisateurs WHERE @Email LIKE AdresseMail AND HASHBYTES('SHA2_512',@Password) LIKE Password)
	BEGIN
		SELECT * FROM Utilisateurs WHERE @Email = AdresseMail
	END
