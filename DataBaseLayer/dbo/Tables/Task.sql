CREATE TABLE [dbo].[Task] (
	[id] [int] IDENTITY(1,1) NOT NULL,
	[ToUser] [int] NOT NULL,
	[TypeTask] [int] NOT NULL,
	[FilePath] [nvarchar](150) NULL,
	[DateTime] [datetime] NULL,
	[TitleTask] [nvarchar](50) NULL,
	[FromUser] [int] NULL,
	[SubjectTask] [nchar](500) NULL,
    CONSTRAINT [PK_Task] PRIMARY KEY CLUSTERED ([id] ASC)
);
