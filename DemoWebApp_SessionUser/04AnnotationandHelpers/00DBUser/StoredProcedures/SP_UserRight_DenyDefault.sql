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
