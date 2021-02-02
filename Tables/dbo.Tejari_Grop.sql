CREATE TABLE [dbo].[Tejari_Grop]
(
[code] [nvarchar] (4) COLLATE Persian_100_CI_AS NULL,
[name] [nvarchar] (20) COLLATE Persian_100_CI_AS NULL,
[code_moshakhas_konnande] [nvarchar] (20) COLLATE Persian_100_CI_AS NULL,
[active] [bit] NULL,
[username] [nvarchar] (30) COLLATE Persian_100_CI_AS NULL,
[machine] [nvarchar] (40) COLLATE Persian_100_CI_AS NULL,
[date_time] [nvarchar] (50) COLLATE Persian_100_CI_AS NULL,
[Name_English] [nvarchar] (50) COLLATE Persian_100_CI_AS NULL,
[Rate_Saderat] [nvarchar] (50) COLLATE Persian_100_CI_AS NULL,
[Counter] [bigint] NOT NULL IDENTITY(1, 1),
[ProductType] [nvarchar] (50) COLLATE Persian_100_CI_AS NULL,
[IdTafsil] [bigint] NULL,
[ID] AS (CONVERT([smallint],case  when isnumeric([code])=(1) then concat([code_moshakhas_konnande],right(concat('00',[code]),(3))) else ([code_moshakhas_konnande]+CONVERT([nvarchar](2),ascii(upper(left([code],(2)))),(0)))+CONVERT([nvarchar](2),ascii(upper(right([code],(1)))),(0)) end,(0))) PERSISTED NOT NULL
) ON [PRIMARY]
GO
