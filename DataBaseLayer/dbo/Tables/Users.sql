CREATE TABLE [dbo].[Users] (
 	[id] [int] NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[Fullname] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[UserType] [int] NOT NULL,
	[IsEnabled] [bit] NOT NULL,
	[TeamLeader] [int] NOT NULL,
	[date] [datetime] NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([id] ASC)
);
