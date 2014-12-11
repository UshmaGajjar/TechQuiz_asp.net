CREATE TABLE [dbo].[quiz_info]
(
	[quiz_id] INT NOT NULL PRIMARY KEY, 
    [user_id] INT NULL, 
    [date_time] DATETIME NULL, 
    [category] INT NULL, 
    [score] INT NULL
)
