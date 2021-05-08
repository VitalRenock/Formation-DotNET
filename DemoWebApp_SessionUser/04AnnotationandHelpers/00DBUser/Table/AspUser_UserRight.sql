CREATE TABLE [dbo].[AspUser_UserRight]
(
	[IdUser] INT NOT NULL,
	[IdRight] INT NOT NULL,

    CONSTRAINT [PK_AspUser_UserRight] PRIMARY KEY ([IdUser], [IdRight]),

	CONSTRAINT FK_ToUserId FOREIGN KEY ([IdUser]) REFERENCES [AspUser]([Id]),
	CONSTRAINT FK_ToRightId FOREIGN KEY ([IdRight]) REFERENCES [UserRight]([Id])
)
