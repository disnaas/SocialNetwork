CREATE PROCEDURE [dbo].[SP_DelUser]
	@Id int
AS
	DELETE Utilisateurs
	WHERE @Id = UsersID
	IF EXISTS(SELECT * FROM Amis WHERE UsersID = @Id)
	BEGIN
		DELETE Amis
		WHERE @Id = AmisID
		DELETE Amis
		WHERE @Id = UsersID
	END
	IF EXISTS(SELECT * FROM Fil Where @ID = UsersID)
	BEGIN 
		DELETE Fil
		WHERE @Id = UsersID
	END