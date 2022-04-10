
CREATE TABLE [dbo].[ButtonDefinition]
(
[ButtonCode] NVARCHAR(50) NOT NULL,
[Form] [nvarchar] (250)  NULL,
[ButtonName] [nvarchar] (250)  NULL,
[Note] [nvarchar] (250)  NULL
) ON [PRIMARY]
GO


CREATE TABLE [dbo].[HMIAction]
(
May NVARCHAR(30),
[Date] [datetime] NULL,
[ButtonCode] NVARCHAR(50) NULL,
[Value] [nvarchar] (250)  NULL
) ON [PRIMARY]
Go