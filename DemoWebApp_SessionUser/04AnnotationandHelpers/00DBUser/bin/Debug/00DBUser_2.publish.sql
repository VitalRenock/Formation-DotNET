/*
Script de déploiement pour DBUser

Ce code a été généré par un outil.
La modification de ce fichier peut provoquer un comportement incorrect et sera perdue si
le code est régénéré.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "DBUser"
:setvar DefaultFilePrefix "DBUser"
:setvar DefaultDataPath "C:\Users\renau\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\"
:setvar DefaultLogPath "C:\Users\renau\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\"

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
PRINT N'Création de la base de données $(DatabaseName)...'
GO
CREATE DATABASE [$(DatabaseName)]
    ON 
    PRIMARY(NAME = [$(DatabaseName)], FILENAME = N'$(DefaultDataPath)$(DefaultFilePrefix)_Primary.mdf')
    LOG ON (NAME = [$(DatabaseName)_log], FILENAME = N'$(DefaultLogPath)$(DefaultFilePrefix)_Primary.ldf') COLLATE SQL_Latin1_General_CP1_CI_AS
GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_CLOSE OFF 
            WITH ROLLBACK IMMEDIATE;
    END


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
                CURSOR_CLOSE_ON_COMMIT OFF,
                AUTO_CREATE_STATISTICS ON,
                AUTO_SHRINK OFF,
                AUTO_UPDATE_STATISTICS ON,
                RECURSIVE_TRIGGERS OFF 
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
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET QUERY_STORE (QUERY_CAPTURE_MODE = ALL, DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_PLANS_PER_QUERY = 200, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 367), MAX_STORAGE_SIZE_MB = 100) 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET QUERY_STORE = OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
        ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
        ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
        ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
    END


GO
IF fulltextserviceproperty(N'IsFulltextInstalled') = 1
    EXECUTE sp_fulltext_database 'enable';


GO
PRINT N'Création de Table [dbo].[AspUser]...';


GO
CREATE TABLE [dbo].[AspUser] (
    [Id]          INT              IDENTITY (1, 1) NOT NULL,
    [Mail]        NVARCHAR (256)   NOT NULL,
    [Password]    VARBINARY (32)   NOT NULL,
    [Salt]        UNIQUEIDENTIFIER NOT NULL,
    [LastName]    NVARCHAR (64)    NOT NULL,
    [FirstName]   NVARCHAR (64)    NOT NULL,
    [BirthDate]   DATE             NOT NULL,
    [RegNational] CHAR (11)        NOT NULL,
    [Bio]         NVARCHAR (120)   NULL,
    [Disabled]    DATETIME2 (7)    NULL,
    CONSTRAINT [PK_AspUser] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [UK_AspUser_Email] UNIQUE NONCLUSTERED ([Mail] ASC),
    CONSTRAINT [UK_AspUser_RegNational] UNIQUE NONCLUSTERED ([RegNational] ASC)
);


GO
PRINT N'Création de Table [dbo].[AspUser_UserRight]...';


GO
CREATE TABLE [dbo].[AspUser_UserRight] (
    [IdUser]  INT NOT NULL,
    [IdRight] INT NOT NULL,
    CONSTRAINT [PK_AspUser_UserRight] PRIMARY KEY CLUSTERED ([IdUser] ASC, [IdRight] ASC)
);


GO
PRINT N'Création de Table [dbo].[UserRight]...';


GO
CREATE TABLE [dbo].[UserRight] (
    [Id]    INT           IDENTITY (1, 1) NOT NULL,
    [Right] NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    UNIQUE NONCLUSTERED ([Right] ASC)
);


GO
PRINT N'Création de Clé étrangère [dbo].[FK_ToUserId]...';


GO
ALTER TABLE [dbo].[AspUser_UserRight]
    ADD CONSTRAINT [FK_ToUserId] FOREIGN KEY ([IdUser]) REFERENCES [dbo].[AspUser] ([Id]);


GO
PRINT N'Création de Clé étrangère [dbo].[FK_ToRightId]...';


GO
ALTER TABLE [dbo].[AspUser_UserRight]
    ADD CONSTRAINT [FK_ToRightId] FOREIGN KEY ([IdRight]) REFERENCES [dbo].[UserRight] ([Id]);


GO
PRINT N'Création de Contrainte de validation [dbo].[CK_AspUser_BirthDate]...';


GO
ALTER TABLE [dbo].[AspUser]
    ADD CONSTRAINT [CK_AspUser_BirthDate] CHECK (DATEDIFF(YEAR,[BirthDate],GETDATE()) > 16);


GO
PRINT N'Création de Contrainte de validation [dbo].[CK_AspUser_RegNational]...';


GO
ALTER TABLE [dbo].[AspUser]
    ADD CONSTRAINT [CK_AspUser_RegNational] CHECK (ISNUMERIC([RegNational]) = 1);


GO
PRINT N'Création de Vue [dbo].[V_AspUser_Enable]...';


GO
CREATE VIEW [dbo].[V_AspUser_Enable]
	AS	SELECT 
			[Id],
			[Mail],
			'********' AS [Password],
			[LastName],
			[FirstName],
			[BirthDate],
			[RegNational],
			[Bio]
		FROM AspUser
		WHERE [Disabled] IS NULL
GO
PRINT N'Création de Fonction [dbo].[SF_SaltAndHash]...';


GO
CREATE FUNCTION [dbo].[SF_SaltAndHash]
(
	@value NVARCHAR(32),
	@salt UNIQUEIDENTIFIER
)
RETURNS VARBINARY(32)
AS
BEGIN
	DECLARE @encrypted NVARCHAR(68);
	SET @encrypted = CONCAT(@salt,@value);
	RETURN HASHBYTES('SHA2_512', @encrypted)
END
GO
PRINT N'Création de Procédure [dbo].[SP_AspUser_CheckPassword]...';


GO
CREATE PROCEDURE [dbo].[SP_AspUser_CheckPassword]
	@identifier NVARCHAR(256),
	@password NVARCHAR(32)
AS
	SELECT Id
		FROM AspUser
		WHERE [Mail] = @identifier
			AND [Password] = [dbo].SF_SaltAndHash(@password,[Salt])
			AND [Disabled] IS NULL
RETURN 0
GO
PRINT N'Création de Procédure [dbo].[SP_AspUser_Delete]...';


GO
CREATE PROCEDURE [dbo].[SP_AspUser_Delete]
	@id INT
AS
	UPDATE AspUser
		SET [Disabled] = GETDATE()
		WHERE [Id] = @id
RETURN 0
GO
PRINT N'Création de Procédure [dbo].[SP_AspUser_GetAll]...';


GO
CREATE PROCEDURE [dbo].[SP_AspUser_GetAll]
AS
	SELECT * FROM V_AspUser_Enable
RETURN 0
GO
PRINT N'Création de Procédure [dbo].[SP_AspUser_GetById]...';


GO
CREATE PROCEDURE [dbo].[SP_AspUser_GetById]
	@id INT
AS
	SELECT * FROM V_AspUser_Enable WHERE Id = @id
RETURN 0
GO
PRINT N'Création de Procédure [dbo].[SP_AspUser_HaveAdminRight]...';


GO
CREATE PROCEDURE [dbo].[SP_AspUser_HaveAdminRight]
	@userid INTEGER
AS
	SELECT IdUser FROM AspUser_UserRight WHERE IdRight =(
		SELECT Id FROM UserRight WHERE [Right] LIKE 'Admin'
	)
	AND IdUser = @userid
RETURN 0
GO
PRINT N'Création de Procédure [dbo].[SP_AspUser_HaveDefaultRight]...';


GO
CREATE PROCEDURE [dbo].[SP_AspUser_HaveDefaultRight]
	@userid INTEGER
AS
	SELECT IdUser FROM AspUser_UserRight WHERE IdRight =(
		SELECT Id FROM UserRight WHERE [Right] LIKE 'Default'
	)
	AND IdUser = @userid
RETURN 0
GO
PRINT N'Création de Procédure [dbo].[SP_AspUser_Insert]...';


GO
CREATE PROCEDURE [dbo].[SP_AspUser_Insert]
	@mail NVARCHAR(256),
	@password NVARCHAR(32),
	@lastname NVARCHAR(64),
	@firstname NVARCHAR(64),
	@birthdate DATE,
	@regnational CHAR(11),
	@bio NVARCHAR(120)
AS
	DECLARE @uid UNIQUEIDENTIFIER;
	SET @uid = NEWID();
	INSERT INTO AspUser(
		[Mail],
		[Password],
		[Salt],
		[LastName],
		[FirstName],
		[BirthDate],
		[RegNational],
		[Bio])
	OUTPUT inserted.[Id]
	VALUES (
		@mail,
		[dbo].SF_SaltAndHash(@password,@uid),
		@uid,
		@lastname,
		@firstname,
		@birthdate,
		@regnational,
		@bio)
RETURN 0
GO
PRINT N'Création de Procédure [dbo].[SP_AspUser_Update]...';


GO
CREATE PROCEDURE [dbo].[SP_AspUser_Update]
	@id INT,
	@password NVARCHAR(32),
	@lastname NVARCHAR(64),
	@firstname NVARCHAR(64),
	@birthdate DATE,
	@regnational CHAR(11),
	@bio NVARCHAR(120)
AS
	UPDATE AspUser
	SET LastName = @lastname,
		FirstName = @firstname,
		[Password] = [dbo].SF_SaltAndHash(@password,[Salt]),
		BirthDate = @birthdate,
		RegNational = @regnational,
		Bio = @bio
	WHERE Id = @id
		AND [Disabled] IS NULL
RETURN 0
GO
PRINT N'Création de Procédure [dbo].[SP_UserRight_DenyAdmin]...';


GO
CREATE PROCEDURE [dbo].[SP_UserRight_DenyAdmin]
	@userid INTEGER
AS
	IF EXISTS 
	(
		SELECT * FROM AspUser_UserRight 
			WHERE IdRight = (SELECT Id FROM UserRight 
								WHERE [Right] LIKE 'Admin')
			AND IdUser = @userid
	)
		
	DELETE FROM AspUser_UserRight 
		WHERE IdUser = @userid
		AND IdRight = (SELECT Id FROM UserRight 
							WHERE [Right] LIKE 'Admin')
RETURN 0
GO
PRINT N'Création de Procédure [dbo].[SP_UserRight_DenyDefault]...';


GO
CREATE PROCEDURE [dbo].[SP_UserRight_DenyDefault]
	@userid INTEGER
AS
	IF EXISTS 
	(
		SELECT * FROM AspUser_UserRight 
			WHERE IdRight = (SELECT Id FROM UserRight 
									WHERE [Right] LIKE 'Default')
			AND IdUser = @userid
	)

	DELETE FROM AspUser_UserRight 
	WHERE IdUser = @userid
		AND IdRight = (SELECT Id 
							FROM UserRight 
							WHERE [Right] LIKE 'Default')
RETURN 0
GO
PRINT N'Création de Procédure [dbo].[SP_UserRight_GrantAdmin]...';


GO
CREATE PROCEDURE [dbo].[SP_UserRight_GrantAdmin]
	@userid INTEGER
AS
	IF NOT EXISTS 
	(
		SELECT * FROM AspUser_UserRight 
			WHERE IdRight = (SELECT Id FROM UserRight WHERE [Right] LIKE 'Admin')
			AND IdUser = @userid
	)

	INSERT INTO AspUser_UserRight VALUES (@userid,
		(SELECT Id FROM UserRight WHERE [Right] LIKE 'Admin'))
RETURN 0
GO
PRINT N'Création de Procédure [dbo].[SP_UserRight_GrantDefault]...';


GO
CREATE PROCEDURE [dbo].[SP_UserRight_GrantDefault]
	@userid INTEGER
AS
	IF NOT EXISTS 
	(
		SELECT * FROM AspUser_UserRight 
			WHERE IdRight = (SELECT Id FROM UserRight WHERE [Right] LIKE 'Default')
			AND IdUser = @userid
	)

	INSERT INTO AspUser_UserRight VALUES 
		(@userid, (SELECT Id FROM UserRight WHERE [Right] LIKE 'Default'))
RETURN 0
GO
INSERT INTO [UserRight] ([Right])
	VALUES	('Admin'),
			('Default'),
			('NotAgree');


EXEC SP_AspUser_Insert	@mail = 'admin@admin.adm',
						@password = 'Admin1234#',
						@lastname = 'Admin',
						@firstname = 'Admin',
						@birthdate = '01-01-01',
						@regnational = '01010199999',
						@bio = 'Administrator account'


DECLARE @adminID INTEGER = (SELECT Id FROM AspUser WHERE Mail LIKE 'admin@admin.adm')

EXEC SP_UserRight_GrantDefault @userid = @adminID

EXEC SP_UserRight_GrantAdmin @userid = @adminID
GO

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
