if not exists(select * from sys.columns 
           where Name = N'MailProSchedule' and Object_ID = Object_ID(N'THONG_TIN_CHUNG'))
begin
ALTER TABLE dbo.THONG_TIN_CHUNG ADD MailProSchedule NVARCHAR(1000) END  







