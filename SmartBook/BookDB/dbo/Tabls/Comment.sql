CREATE TABLE [dbo].[Forum]
(
	[CommentId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [UserName] NVARCHAR(50) NOT NULL, 
    [CommentText] NVARCHAR(MAX) NOT NULL, 
    [CommentDate] DATETIME NOT NULL
)
