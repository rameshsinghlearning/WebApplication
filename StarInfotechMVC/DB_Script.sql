
CREATE DATABASE StarInfotech;
GO

USE StarInfotech;

-- ****************************************************************************************************
CREATE TABLE [Role]
(
	[Id] INT NOT NULL IDENTITY(1,1) CONSTRAINT pk_Role_Id PRIMARY KEY,
	[Name] VARCHAR(20) NOT NULL CONSTRAINT uk_Role_Name UNIQUE,
    [Description] VARCHAR(100) NOT NULL,
    [IsActive] BIT NOT NULL,
    [AddedDate] DATETIME NOT NULL,
    [AddedById] INT,
    [ModifiedDate] DATETIME,
    [ModifiedById] INT
)

INSERT INTO [Role]([Name],[Description],[IsActive],[AddedDate],[AddedById],[ModifiedDate],[ModifiedById])
VALUES('Admin','Admin have full rights',1,GETDATE(),1, NULL,NULL)

INSERT INTO [Role]([Name],[Description],[IsActive],[AddedDate],[AddedById],[ModifiedDate],[ModifiedById])
VALUES('Staff','Staff have limited rights',1,GETDATE(),1, NULL,NULL)


-- ****************************************************************************************************
CREATE TABLE [User]
(
	[Id] INT NOT NULL IDENTITY(1,1) CONSTRAINT pk_User_Id PRIMARY KEY,
	[FirstName] VARCHAR(20) NOT NULL,
    [LastName] VARCHAR(20) NOT NULL,
    [Username] VARCHAR(20) NOT NULL CONSTRAINT uk_User_Username UNIQUE,
    [Password] CHAR(60) NOT NULL,
    [MobileNo] VARCHAR(12),
    [Email] VARCHAR(50),
    [RoleId] INT,
    [IsActive] BIT NOT NULL,
    [AddedDate] DATETIME NOT NULL,
    [AddedById] INT,
    [ModifiedDate] DATETIME,
    [ModifiedById] INT,
    CONSTRAINT fk_User_RoleId FOREIGN KEY([RoleId]) REFERENCES [Role]([Id]),
	CONSTRAINT fk_User_AddedById FOREIGN KEY([AddedById]) REFERENCES [User]([Id]),
	CONSTRAINT fk_User_ModifiedById FOREIGN KEY([ModifiedById]) REFERENCES [User]([Id])
)

INSERT INTO [User]([FirstName],[LastName],[Username],[Password],[MobileNo],[Email],[RoleId],[IsActive],[AddedDate],[AddedById],[ModifiedDate],[ModifiedById])
VALUES('Star','Infotech','star','infotech','9898989898','starinfotech@gmail.com',1,1,GETDATE(),1, NULL,NULL)

-- ****************************************************************************************************
SELECT * FROM [Role]
SELECT * FROM [User]
-- ****************************************************************************************************
