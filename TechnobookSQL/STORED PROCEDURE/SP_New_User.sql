CREATE PROCEDURE [dbo].[SP_New_User]
	@Nom VARCHAR(25),
	@Prenom VARCHAR(25),
	@AdresseMail VARCHAR(200),
	@Password VARCHAR(256),
	@DateNaissance DATETIME2(7)
AS
	INSERT INTO Utilisateurs(Nom,Prenom,AdresseMail,[Password],DateNaissance) VALUES (@Nom,@Prenom,@AdresseMail,HASHBYTES('SHA2_512',@Password),@DateNaissance)
	DECLARE @UserID INT;
	SELECT @UserID = @@Identity FROM Utilisateurs