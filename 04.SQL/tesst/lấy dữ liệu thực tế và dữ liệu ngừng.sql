--DELETE FROM dbo.HMIAction
--DELETE FROM dbo.ActualHMI WHERE CONVERT(DATE,Date) = CONVERT(DATE,GETDATE())
--DELETE FROM dbo.ProductionRunDetails WHERE CONVERT(DATE,StartTime) = CONVERT(DATE,GETDATE())
--DELETE FROM dbo.THOI_GIAN_DUNG_MAY WHERE CONVERT(DATE,TU_GIO) = CONVERT(DATE,GETDATE())

	DECLARE @MS_MAY NVARCHAR(50) ='IMM-02';
	DECLARE @Ngay DATETIME= '2022-04-14 14:26:51.560'
	DECLARE @item INT = -1
	SELECT 0 AS TT,N'Mấy chạy' AS HANH_DONG,  FORMAT(Date, 'dd/MM/yyyy HH:mm:ss') AS Date ,MS_MAY,(SELECT ItemCode FROM dbo.Item WHERE ID = B.ItemID) AS Item,CONVERT(NVARCHAR(500),ActualQuanity) AS Value,
	(SELECT CASE A.ButtonCode WHEN	2 THEN  A.Note WHEN 31 THEN A.Note ELSE N'Auto Refresh' end FROM dbo.ButtonDefinition A WHERE A.ButtonCode = B.ButtonCode ) AS Note ,CONVERT(NVARCHAR(50),Run) Run
	FROM dbo.ActualHMI B
	INNER JOIN dbo.ProductionOrder C ON B.ProID = C.ID AND   dbo.fnGetNgayTheoCa(c.StartDate)  = dbo.fnGetNgayTheoCa(@Ngay) 
	WHERE  B.ItemID =@item OR @item = -1 AND B.MS_MAY =@MS_MAY AND CONVERT(DATE,Date) = dbo.fnGetNgayTheoCa(@Ngay) 
	UNION
	SELECT 2,N'Ngừng mấy',  FORMAT(B.DEN_GIO, 'dd/MM/yyyy HH:mm:ss'),MS_MAY,'',NGUYEN_NHAN, FORMAT(B.TU_GIO, 'dd/MM/yyyy HH:mm:ss') ,''
	FROM dbo.THOI_GIAN_DUNG_MAY B WHERE MS_MAY = @MS_MAY AND  dbo.fnGetNgayTheoCa(B.TU_GIO)  = dbo.fnGetNgayTheoCa(@Ngay) 
	UNION
	(SELECT 1, N'Thao tác',FORMAT(A.Date, 'dd/MM/yyyy HH:mm:ss'),A.May,'',(SELECT OperatorName FROM dbo.Operator WHERE CONVERT(NVARCHAR(50),ID_Operator) =A.Value),B.Note,''
	FROM HMIAction A
	INNER JOIN dbo.ButtonDefinition B ON B.ButtonCode = A.ButtonCode WHERE A.May = @MS_MAY AND  dbo.fnGetNgayTheoCa(A.Date)  = dbo.fnGetNgayTheoCa(@Ngay)  ) 
	ORDER BY Date,TT
--SELECT * FROM dbo.ActualHMI WHERE CONVERT(DATE,Date) = CONVERT(DATE,GETDATE()) ORDER BY Date
--SELECT * FROM dbo.HMIAction
--SELECT * FROM dbo.ActualHMI WHERE CONVERT(DATE,Date) = CONVERT(DATE,GETDATE()) AND MS_MAY ='IMM-15' ORDER BY Date

 SELECT * FROM dbo.ActualHMI WHERE MS_MAY ='IMM-10' AND CONVERT(DATE,Date) ='2022-04-14' ORDER BY Date


