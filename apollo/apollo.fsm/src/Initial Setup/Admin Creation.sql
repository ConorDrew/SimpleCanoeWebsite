USE [RftFsm_Beta]
GO

DECLARE @user_password VARCHAR(255)
SET @user_password = 'RftAdm!n57'

EXEC [dbo].[User_Import_Mk1]
		@Fullname = 'System Administrator',
		@Username = 'admin',
		@EmailAddress = 'sysadmin@company.com',
		@DefaultRegion = 0,
		@Password = @user_password,
		@Admin = 1
GO

