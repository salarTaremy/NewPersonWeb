CREATE TABLE [dbo].[tedad]
(
[code] [nvarchar] (4) COLLATE Persian_100_CI_AS NULL,
[tedad_dar_shiling] [nvarchar] (4) COLLATE Persian_100_CI_AS_SC_UTF8 NULL,
[tedad_dar_karton] [nvarchar] (4) COLLATE Persian_100_CI_AS_SC_UTF8 NULL,
[sharh] [nvarchar] (20) COLLATE Persian_100_CI_AS NULL,
[active] [bit] NULL,
[username] [nvarchar] (30) COLLATE Persian_100_CI_AS NULL,
[machine] [nvarchar] (40) COLLATE Persian_100_CI_AS NULL,
[date_time] [nvarchar] (50) COLLATE Persian_100_CI_AS NULL,
[Counter] [bigint] NOT NULL IDENTITY(1, 1),
[Meghdar_Kol_Tedad] AS (CONVERT([bigint],[tedad_dar_karton],(0))*CONVERT([bigint],[tedad_dar_shiling],(0)))
) ON [PRIMARY]
GO
