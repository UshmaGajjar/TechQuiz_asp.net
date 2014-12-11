CREATE TABLE [dbo].[question_bank]
(
	[que_id] INT NOT NULL PRIMARY KEY, 
    [question] VARCHAR(300) NULL, 
    [option1] VARCHAR(150) NULL, 
    [option2] VARCHAR(150) NULL, 
    [option3] VARCHAR(150) NULL, 
    [option4] VARCHAR(150) NULL, 
    [answer] CHAR NULL, 
    [category] INT NULL, 
    [isDeleted] BIT NULL
)
