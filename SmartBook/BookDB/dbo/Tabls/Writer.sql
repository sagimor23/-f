CREATE TABLE [dbo].[Writer]
(
	[WriterId] INT NOT NULL PRIMARY KEY, 
    [WriterName] NVARCHAR(100) NOT NULL, 
    [PlaceOfBirth] NVARCHAR(50) NOT NULL, 
    [DateOfBirth] DATETIME NOT NULL
)
