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
USE [master];


GO

IF (DB_ID(N'$(DatabaseName)') IS NOT NULL) 
BEGIN
    ALTER DATABASE [$(DatabaseName)]
    SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE [$(DatabaseName)];
END

GO
PRINT N'Création de $(DatabaseName)...'
GO
CREATE DATABASE [$(DatabaseName)]
    ON 
    PRIMARY(NAME = [$(DatabaseName)], FILENAME = N'$(DefaultDataPath)$(DefaultFilePrefix)_Primary.mdf')
    LOG ON (NAME = [$(DatabaseName)_log], FILENAME = N'$(DefaultLogPath)$(DefaultFilePrefix)_Primary.ldf') COLLATE SQL_Latin1_General_CP1_CI_AS
GO
USE [$(DatabaseName)];


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET ANSI_NULLS ON,
                ANSI_PADDING ON,
                ANSI_WARNINGS ON,
                ARITHABORT ON,
                CONCAT_NULL_YIELDS_NULL ON,
                NUMERIC_ROUNDABORT OFF,
                QUOTED_IDENTIFIER ON,
                ANSI_NULL_DEFAULT ON,
                CURSOR_DEFAULT LOCAL,
                RECOVERY FULL,
                CURSOR_CLOSE_ON_COMMIT OFF,
                AUTO_CREATE_STATISTICS ON,
                AUTO_SHRINK OFF,
                AUTO_UPDATE_STATISTICS ON,
                RECURSIVE_TRIGGERS OFF 
            WITH ROLLBACK IMMEDIATE;
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_CLOSE OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET ALLOW_SNAPSHOT_ISOLATION OFF;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET READ_COMMITTED_SNAPSHOT OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_UPDATE_STATISTICS_ASYNC OFF,
                PAGE_VERIFY NONE,
                DATE_CORRELATION_OPTIMIZATION OFF,
                DISABLE_BROKER,
                PARAMETERIZATION SIMPLE,
                SUPPLEMENTAL_LOGGING OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF IS_SRVROLEMEMBER(N'sysadmin') = 1
    BEGIN
        IF EXISTS (SELECT 1
                   FROM   [master].[dbo].[sysdatabases]
                   WHERE  [name] = N'$(DatabaseName)')
            BEGIN
                EXECUTE sp_executesql N'ALTER DATABASE [$(DatabaseName)]
    SET TRUSTWORTHY OFF,
        DB_CHAINING OFF 
    WITH ROLLBACK IMMEDIATE';
            END
    END
ELSE
    BEGIN
        PRINT N'Impossible de modifier les paramètres de base de données. Vous devez être administrateur système pour appliquer ces paramètres.';
    END


GO
IF IS_SRVROLEMEMBER(N'sysadmin') = 1
    BEGIN
        IF EXISTS (SELECT 1
                   FROM   [master].[dbo].[sysdatabases]
                   WHERE  [name] = N'$(DatabaseName)')
            BEGIN
                EXECUTE sp_executesql N'ALTER DATABASE [$(DatabaseName)]
    SET HONOR_BROKER_PRIORITY OFF 
    WITH ROLLBACK IMMEDIATE';
            END
    END
ELSE
    BEGIN
        PRINT N'Impossible de modifier les paramètres de base de données. Vous devez être administrateur système pour appliquer ces paramètres.';
    END


GO
ALTER DATABASE [$(DatabaseName)]
    SET TARGET_RECOVERY_TIME = 0 SECONDS 
    WITH ROLLBACK IMMEDIATE;


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET FILESTREAM(NON_TRANSACTED_ACCESS = OFF),
                CONTAINMENT = NONE 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_CREATE_STATISTICS ON(INCREMENTAL = OFF),
                MEMORY_OPTIMIZED_ELEVATE_TO_SNAPSHOT = OFF,
                DELAYED_DURABILITY = DISABLED 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF fulltextserviceproperty(N'IsFulltextInstalled') = 1
    EXECUTE sp_fulltext_database 'enable';


GO
PRINT N'Création de [dbo].[Amis]...';


GO
CREATE TABLE [dbo].[Amis] (
    [UsersID] INT NOT NULL,
    [AmisID]  INT NOT NULL,
    [EstAMIS] BIT NOT NULL
);


GO
PRINT N'Création de [dbo].[Fil]...';


GO
CREATE TABLE [dbo].[Fil] (
    [FilID]     INT            IDENTITY (1, 1) NOT NULL,
    [Text]      NVARCHAR (500) NOT NULL,
    [DateLigne] DATETIME2 (7)  NOT NULL,
    [UsersID]   INT            NOT NULL,
    CONSTRAINT [PK_FilID] PRIMARY KEY CLUSTERED ([FilID] ASC)
);


GO
PRINT N'Création de [dbo].[Utilisateurs]...';


GO
CREATE TABLE [dbo].[Utilisateurs] (
    [UsersID]         INT             IDENTITY (1, 1) NOT NULL,
    [Nom]             NVARCHAR (25)   NOT NULL,
    [Prenom]          NVARCHAR (25)   NOT NULL,
    [AdresseMail]     NVARCHAR (200)  NOT NULL,
    [Password]        VARBINARY (256) NOT NULL,
    [DateNaissance]   DATETIME2 (7)   NOT NULL,
    [DateInscription] DATETIME2 (7)   NOT NULL,
    CONSTRAINT [PK_UserID] PRIMARY KEY CLUSTERED ([UsersID] ASC),
    UNIQUE NONCLUSTERED ([AdresseMail] ASC)
);


GO
PRINT N'Création de contrainte sans nom sur [dbo].[Amis]...';


GO
ALTER TABLE [dbo].[Amis]
    ADD DEFAULT 0 FOR [EstAMIS];


GO
PRINT N'Création de contrainte sans nom sur [dbo].[Fil]...';


GO
ALTER TABLE [dbo].[Fil]
    ADD DEFAULT CONVERT (date, SYSDATETIME()) FOR [DateLigne];


GO
PRINT N'Création de contrainte sans nom sur [dbo].[Utilisateurs]...';


GO
ALTER TABLE [dbo].[Utilisateurs]
    ADD DEFAULT GETDATE() FOR [DateInscription];


GO
PRINT N'Création de [dbo].[FK_UserID_User]...';


GO
ALTER TABLE [dbo].[Amis]
    ADD CONSTRAINT [FK_UserID_User] FOREIGN KEY ([UsersID]) REFERENCES [dbo].[Utilisateurs] ([UsersID]);


GO
PRINT N'Création de [dbo].[FK_AmisID_User]...';


GO
ALTER TABLE [dbo].[Amis]
    ADD CONSTRAINT [FK_AmisID_User] FOREIGN KEY ([AmisID]) REFERENCES [dbo].[Utilisateurs] ([UsersID]);


GO
PRINT N'Création de [dbo].[FK_UsersID]...';


GO
ALTER TABLE [dbo].[Fil]
    ADD CONSTRAINT [FK_UsersID] FOREIGN KEY ([UsersID]) REFERENCES [dbo].[Utilisateurs] ([UsersID]);


GO
PRINT N'Création de [dbo].[SP_New_User]...';


GO
CREATE PROCEDURE [dbo].[SP_New_User]
	@Nom NVARCHAR(25),
	@Prenom NVARCHAR(25),
	@AdresseMail NVARCHAR(200),
	@Password NVARCHAR(256),
	@DateNaissance DATETIME2(7)
AS
	INSERT INTO Utilisateurs(Nom,Prenom,AdresseMail,[Password],DateNaissance) VALUES (@Nom,@Prenom,@AdresseMail,HASHBYTES('SHA2_512',@Password),@DateNaissance)
	DECLARE @UserID INT;
	SET @UserID = (SELECT MAX(UsersID) FROM Utilisateurs)
	INSERT INTO Amis(UsersID,AmisID) SELECT UsersID,@UserID FROM Utilisateurs
GO
DECLARE @VarDecimalSupported AS BIT;

SELECT @VarDecimalSupported = 0;

IF ((ServerProperty(N'EngineEdition') = 3)
    AND (((@@microsoftversion / power(2, 24) = 9)
          AND (@@microsoftversion & 0xffff >= 3024))
         OR ((@@microsoftversion / power(2, 24) = 10)
             AND (@@microsoftversion & 0xffff >= 1600))))
    SELECT @VarDecimalSupported = 1;

IF (@VarDecimalSupported > 0)
    BEGIN
        EXECUTE sp_db_vardecimal_storage_format N'$(DatabaseName)', 'ON';
    END


GO
PRINT N'Mise à jour terminée.';


GO
