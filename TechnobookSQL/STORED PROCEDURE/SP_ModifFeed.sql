CREATE PROCEDURE [dbo].[SP_ModifFeed]
	@Id INT,
	@Text VARCHAR(500),
	@UsersID INT
AS
	UPDATE Fil
	SET Text = @Text, DateLigne = GETDATE()
	WHERE @UsersID = UsersID AND FilID = @Id
