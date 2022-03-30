
IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'spSendMailNoProSchedule')
   exec('CREATE PROCEDURE spSendMailNoProSchedule AS BEGIN SET NOCOUNT ON; END')
GO
ALTER PROCEDURE dbo.spSendMailNoProSchedule
AS
BEGIN
    DECLARE @MsNgay1 Nvarchar(1000)
	SELECT @MsNgay1 =COALESCE(@MsNgay1 + '; ', '') +
	CAST(T1.MS_MAY AS Nvarchar(1000))
	FROM 
	(
		SELECT MS_MAY FROM dbo.MAY A WHERE NOT EXISTS (SELECT * FROM dbo.ProSchedule B WHERE A.MS_MAY = B.MS_MAY AND CONVERT(DATE,B.PlannedStartTime) = CONVERT(DATE,DATEADD(DAY,1,GETDATE())))
	)T1
	DECLARE @MsNgay2 Nvarchar(1000)
	SELECT @MsNgay2 =COALESCE(@MsNgay2 + '; ', '') +
	CAST(T2.MS_MAY AS Nvarchar(1000))
	FROM 
	(
		SELECT MS_MAY FROM dbo.MAY A WHERE NOT EXISTS (SELECT * FROM dbo.ProSchedule B WHERE A.MS_MAY = B.MS_MAY AND CONVERT(DATE,B.PlannedStartTime) = CONVERT(DATE,DATEADD(DAY,2,GETDATE())))
	)T2

	IF TRIM(@MsNgay1 + @MsNgay2) <> ''
	BEGIN
	DECLARE @body Nvarchar(1000)
	DECLARE  @rec Nvarchar(1000)
	SET @rec = (SELECT TOP 1 MailProSchedule FROM dbo.THONG_TIN_CHUNG)
	SET @body = N'Ngày '+ CONVERT(NVARCHAR(10),DATEADD(DAY,1,GETDATE()),103) + N' Những máy chưa được phân kế khoạch:' +  @MsNgay1 + ' <br />' 
			+N'Ngày '+ CONVERT(NVARCHAR(10),DATEADD(DAY,2,GETDATE()),103) + N' Những máy chưa được phân kế khoạch:' +  @MsNgay2 + ' <br />' 

	EXEC  msdb.dbo.sp_send_dbmail
		  @profile_name = 'MailVS', --Tên profile tạo ở trên
		  @recipients =  @rec, --list các địa chỉ nhận
		  @body =  @body, --nội dung email
		  @body_format = 'HTML', --format html hay text
		  @subject = N'Báo cáo máy chưa có kế hoạch'; --tiêu đề
	END
END
GO

