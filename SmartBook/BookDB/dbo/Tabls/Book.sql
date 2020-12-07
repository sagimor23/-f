CREATE TABLE [dbo].[Book]
(
	[BookId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [BookName] NVARCHAR(100) NOT NULL, 
    [WriterName] NVARCHAR(50) NOT NULL, 
    [YearOfPublish] INT NOT NULL, 
    [Number_of_pages] INT NOT NULL, 
    [Summary] NVARCHAR(2000) NOT NULL, 
    [PictureId] INT NOT NULL, 
    [BookUrl] NVARCHAR(500) NOT NULL, 
)
