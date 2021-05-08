CREATE PROCEDURE [dbo].[SP_AspUser_HaveDefaultRight]
	@userid INTEGER
AS
	SELECT IdUser FROM AspUser_UserRight WHERE IdRight =(
		SELECT Id FROM UserRight WHERE [Right] LIKE 'Default'
	)
	AND IdUser = @userid
RETURN 0
