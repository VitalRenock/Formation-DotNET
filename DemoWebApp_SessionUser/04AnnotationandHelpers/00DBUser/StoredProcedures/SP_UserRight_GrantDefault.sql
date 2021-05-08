﻿CREATE PROCEDURE [dbo].[SP_UserRight_GrantDefault]
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
