CREATE TABLE [dbo].[user_info]
(
	[user_id] INT NOT NULL PRIMARY KEY, 
    [username] VARCHAR(50) NULL, 
    [password] VARCHAR(20) NULL, 
    [first_name] VARCHAR(20) NULL, 
    [last_name] VARCHAR(20) NULL, 
    [occupation] INT NULL, 
    [birth_date] DATE NULL, 
    [isActive] BIT NULL
)
