CREATE TABLE [dbo].[Darkhast_anbar_new]
(
[Code_noae] [nvarchar] (20) COLLATE Persian_100_CI_AS NULL,
[Groh] [nvarchar] (20) COLLATE Persian_100_CI_AS_SC_UTF8 NULL,
[Shomareh_anbar] [nvarchar] (20) COLLATE Persian_100_CI_AS NULL,
[active] [bit] NULL,
[date_time] [nvarchar] (50) COLLATE Persian_100_CI_AS NULL,
[username] [nvarchar] (30) COLLATE Persian_100_CI_AS NULL,
[machine] [nvarchar] (40) COLLATE Persian_100_CI_AS NULL,
[Name_Latin] [nvarchar] (max) COLLATE Persian_100_CI_AS_SC_UTF8 NULL,
[Name_Farsi] [nvarchar] (max) COLLATE Persian_100_CI_AS_SC_UTF8 NULL,
[Counter] [bigint] NOT NULL IDENTITY(1, 1)
) ON [PRIMARY]
GO
