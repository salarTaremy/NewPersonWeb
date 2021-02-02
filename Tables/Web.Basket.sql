CREATE TABLE [Web].[Basket]
(
[ID] [int] NOT NULL IDENTITY(1000, 1),
[CreateDate] [datetime] NULL CONSTRAINT [DF__Basket__CreateDa__49C3F6B7] DEFAULT (getdate()),
[Ssn] [varchar] (10) COLLATE Persian_100_CI_AS_SC_UTF8 NOT NULL,
[Description] [nvarchar] (300) COLLATE Persian_100_CI_AS NULL,
[OrderID] [varchar] (20) COLLATE Persian_100_CI_AS NULL
) ON [PRIMARY]
GO
ALTER TABLE [Web].[Basket] ADD CONSTRAINT [PK__Basket__3214EC275AD90E52] PRIMARY KEY CLUSTERED  ([ID]) ON [PRIMARY]
GO
