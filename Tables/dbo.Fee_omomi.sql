CREATE TABLE [dbo].[Fee_omomi]
(
[groh_moshtary] [nvarchar] (4) COLLATE Persian_100_CI_AS NULL,
[code_noae] [nvarchar] (4) COLLATE Persian_100_CI_AS NULL,
[code_kala] [nvarchar] (10) COLLATE Persian_100_CI_AS NULL,
[code_groh_kala] [nvarchar] (4) COLLATE Persian_100_CI_AS NULL,
[ghemat] [nvarchar] (10) COLLATE Persian_100_CI_AS NULL,
[start_date] [nvarchar] (10) COLLATE Persian_100_CI_AS NULL,
[end_date] [nvarchar] (10) COLLATE Persian_100_CI_AS NULL,
[tarikh_ejra] [nvarchar] (10) COLLATE Persian_100_CI_AS NULL,
[lock] [bit] NULL,
[active] [bit] NULL,
[username] [nvarchar] (30) COLLATE Persian_100_CI_AS NULL,
[machine] [nvarchar] (40) COLLATE Persian_100_CI_AS NULL,
[datetime] [nvarchar] (50) COLLATE Persian_100_CI_AS NULL,
[Ghymat_Masraf_konandeh] [nvarchar] (10) COLLATE Persian_100_CI_AS NULL,
[Counter] [bigint] NOT NULL IDENTITY(1, 1),
[Flag_Marjoie] [bit] NULL,
[Ghymat_Be_Pakhsh] [nvarchar] (10) COLLATE Persian_100_CI_AS NULL,
[FirstActive] [bit] NULL,
[UserTayid] [nvarchar] (30) COLLATE Persian_100_CI_AS NULL,
[TarikhTayid] [nvarchar] (10) COLLATE Persian_100_CI_AS NULL,
[StartTime] [datetime2] NOT NULL CONSTRAINT [DF__Fee_omomi__Start__2EAD1236] DEFAULT (sysutcdatetime()),
[EndTime] [datetime2] NOT NULL CONSTRAINT [DF__Fee_omomi__EndTi__2FA1366F] DEFAULT (CONVERT([datetime2],'9999-12-31 23:59:59.9999999',(0))),
[AppName] [nvarchar] (max) COLLATE Persian_100_CI_AS_SC_UTF8 NULL,
[start_date_int] [nvarchar] (max) COLLATE Persian_100_CI_AS_SC_UTF8 NULL,
[End_date_int] [nvarchar] (max) COLLATE Persian_100_CI_AS_SC_UTF8 NULL
) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [Fee_omomiddd] ON [dbo].[Fee_omomi] ([groh_moshtary], [code_noae], [lock], [active], [start_date], [end_date]) INCLUDE ([code_groh_kala], [code_kala], [ghemat], [Ghymat_Masraf_konandeh]) ON [PRIMARY]
GO
