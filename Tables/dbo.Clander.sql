CREATE TABLE [dbo].[Clander]
(
[Persian_Date] [int] NOT NULL,
[Gregorian_Date] [int] NOT NULL,
[DayOfWeek] [tinyint] NOT NULL,
[Pr_DateDisplay] [nvarchar] (10) COLLATE Persian_100_CI_AS NULL,
[Gr_DateDisplay] [nvarchar] (10) COLLATE Persian_100_CI_AS NULL,
[Pr_Year] [smallint] NOT NULL,
[Gr_Year] [smallint] NOT NULL,
[Pr_Month] [tinyint] NOT NULL,
[Gr_Month] [tinyint] NOT NULL,
[Pr_Day] [tinyint] NOT NULL,
[Gr_Day] [tinyint] NOT NULL,
[DayCounter] [int] NULL,
[AppName] [nvarchar] (128) COLLATE Persian_100_CI_AS_SC_UTF8 NULL,
[gr_date] [date] NULL,
[DayCounterPwKara] [int] NULL
) ON [PRIMARY]
GO
