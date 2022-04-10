if not exists(select * from sys.columns 
           where Name = N'ButtonCode' and Object_ID = Object_ID(N'ActualHMI'))
begin
ALTER TABLE dbo.ActualHMI ADD ButtonCode NVARCHAR(50) END  

if not exists(select * from sys.columns 
           where Name = N'Run' and Object_ID = Object_ID(N'ActualHMI'))
begin
ALTER TABLE dbo.ActualHMI ADD Run BIT END  






