ALTER PROCEDURE [dbo].[spGetThaoTacHMI]
	@MS_MAY NVARCHAR(30) = 'IMM-02',
	@Ngay DATE = '2022-04-14'
AS 
BEGIN
	DECLARE @item INT = -1
	SELECT 0 AS TT,N'Mấy chạy' AS HANH_DONG,  FORMAT(Date, 'dd/MM/yyyy HH:mm:ss') AS Date ,MS_MAY,(SELECT ItemCode FROM dbo.Item WHERE ID = B.ItemID) AS Item,CONVERT(NVARCHAR(500),ActualQuanity) AS Value,
	(SELECT CASE A.ButtonCode WHEN	2 THEN  A.Note WHEN 31 THEN A.Note ELSE N'Auto Refresh' end FROM dbo.ButtonDefinition A WHERE A.ButtonCode = B.ButtonCode ) AS Note ,Run
	FROM dbo.ActualHMI B
	INNER JOIN dbo.ProductionOrder C ON B.ProID = C.ID AND   dbo.fnGetNgayTheoCa(c.StartDate)  = @Ngay
	WHERE  B.ItemID =@item OR @item = -1 AND B.MS_MAY =@MS_MAY AND CONVERT(DATE,Date) = @Ngay 
	UNION
	SELECT 2,N'Ngừng mấy',  FORMAT(B.DEN_GIO, 'dd/MM/yyyy HH:mm:ss'),MS_MAY,'',NGUYEN_NHAN, FORMAT(B.TU_GIO, 'dd/MM/yyyy HH:mm:ss') ,NULL
	FROM dbo.THOI_GIAN_DUNG_MAY B WHERE MS_MAY = @MS_MAY AND  dbo.fnGetNgayTheoCa(B.TU_GIO)  = @Ngay 
	UNION
	(SELECT 1, N'Thao tác',FORMAT(A.Date, 'dd/MM/yyyy HH:mm:ss'),A.May,'',(SELECT OperatorName FROM dbo.Operator WHERE CONVERT(NVARCHAR(50),ID_Operator) =A.Value),B.Note,NULL
	FROM HMIAction A
	INNER JOIN dbo.ButtonDefinition B ON B.ButtonCode = A.ButtonCode WHERE A.May = @MS_MAY AND  dbo.fnGetNgayTheoCa(A.Date)  = @Ngay ) 
	ORDER BY Date,TT
END	




