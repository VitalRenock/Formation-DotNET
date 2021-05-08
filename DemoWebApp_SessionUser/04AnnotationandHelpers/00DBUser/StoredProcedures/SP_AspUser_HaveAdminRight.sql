CREATE PROCEDURE [dbo].[SP_AspUser_HaveAdminRight]
	@userid INTEGER
AS
	SELECT IdUser FROM AspUser_UserRight WHERE IdRight =(
		SELECT Id FROM UserRight WHERE [Right] LIKE 'Admin'
	)
	AND IdUser = @userid
RETURN 0
