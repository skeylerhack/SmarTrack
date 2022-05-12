CREATE TABLE [dbo].[TargetMold]
(
[MOLD_ID] [nvarchar] (50)  NOT NULL,
[NGAY] [date] NULL,
[TarGetActual] [decimal] (18, 2) NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[TargetMold] ADD CONSTRAINT [PK_TargetMold_1] PRIMARY KEY CLUSTERED ([MOLD_ID]) ON [PRIMARY]
GO
