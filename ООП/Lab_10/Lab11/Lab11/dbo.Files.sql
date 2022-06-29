CREATE TABLE [dbo].[Files]
(
	[file_id] nvarchar(50) NOT NULL PRIMARY KEY,
	[format] nvarchar(5),
	[file_size] real
)
