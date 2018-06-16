CREATE PROCEDURE [dbo].[SP_UpdateUtilisateurs]
	@Nom VARCHAR(25),
	@Prenom VARCHAR(25),
	@AdresseMail VARCHAR(200),
	@UsersID INT
AS
	UPDATE Utilisateurs
	SET Nom = @Nom,Prenom = @Prenom, AdresseMail = @AdresseMail
	WHERE UsersID = @UsersID
