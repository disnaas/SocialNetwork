/*
Script de déploiement pour Technobook

Ce code a été généré par un outil.
La modification de ce fichier peut provoquer un comportement incorrect et sera perdue si
le code est régénéré.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "Technobook"
:setvar DefaultFilePrefix "Technobook"
:setvar DefaultDataPath "C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\"
:setvar DefaultLogPath "C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\"

GO
:on error exit
GO
/*
Détectez le mode SQLCMD et désactivez l'exécution du script si le mode SQLCMD n'est pas pris en charge.
Pour réactiver le script une fois le mode SQLCMD activé, exécutez ce qui suit :
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'Le mode SQLCMD doit être activé de manière à pouvoir exécuter ce script.';
        SET NOEXEC ON;
    END


GO
USE [$(DatabaseName)];


GO
PRINT N'Création de contrainte sans nom sur [dbo].[Fil]...';


GO
ALTER TABLE [dbo].[Fil]
    ADD DEFAULT CONVERT (date, SYSDATETIME()) FOR [DateLigne];


GO
PRINT N'Création de [dbo].[FK_AmisID_User]...';


GO
ALTER TABLE [dbo].[Amis] WITH NOCHECK
    ADD CONSTRAINT [FK_AmisID_User] FOREIGN KEY ([AmisID]) REFERENCES [dbo].[Utilisateurs] ([UsersID]);


GO
PRINT N'Création de [dbo].[FK_FilActu]...';


GO
ALTER TABLE [dbo].[Amis] WITH NOCHECK
    ADD CONSTRAINT [FK_FilActu] FOREIGN KEY ([FilID]) REFERENCES [dbo].[Fil] ([FilID]);


GO
PRINT N'Création de [dbo].[FK_UserID_User]...';


GO
ALTER TABLE [dbo].[Amis] WITH NOCHECK
    ADD CONSTRAINT [FK_UserID_User] FOREIGN KEY ([UsersID]) REFERENCES [dbo].[Utilisateurs] ([UsersID]);


GO
PRINT N'Création de [dbo].[SP_New_User]...';


GO
CREATE PROCEDURE [dbo].[SP_New_User]
	@Nom NVARCHAR(25),
	@Prenom NVARCHAR(25),
	@Pays NVARCHAR(18),
	@Rue NVARCHAR(75),
	@Numero INT,
	@CP NVARCHAR(6),
	@AdresseMail NVARCHAR(200),
	@Password VARBINARY(256)
AS
	INSERT INTO Utilisateurs(Nom,Prenom,Pays,Rue,NumeroMaison,CodePostale,AdresseMail,Password) VALUES (@Nom,@Prenom,@Pays,@Rue,@Numero,@CP,@AdresseMail,HASHBYTES('SHA2_512',@Password))
GO
PRINT N'Vérification de données existantes par rapport aux nouvelles contraintes';


GO
USE [$(DatabaseName)];


GO
ALTER TABLE [dbo].[Amis] WITH CHECK CHECK CONSTRAINT [FK_AmisID_User];

ALTER TABLE [dbo].[Amis] WITH CHECK CHECK CONSTRAINT [FK_FilActu];

ALTER TABLE [dbo].[Amis] WITH CHECK CHECK CONSTRAINT [FK_UserID_User];


GO
PRINT N'Mise à jour terminée.';


GO
