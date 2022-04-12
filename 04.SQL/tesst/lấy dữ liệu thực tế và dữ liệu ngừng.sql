--DELETE FROM dbo.HMIAction
--DELETE FROM dbo.ActualHMI WHERE CONVERT(DATE,Date) = CONVERT(DATE,GETDATE())
--DELETE FROM dbo.ProductionRunDetails WHERE CONVERT(DATE,StartTime) = CONVERT(DATE,GETDATE())
--DELETE FROM dbo.THOI_GIAN_DUNG_MAY WHERE CONVERT(DATE,TU_GIO) = CONVERT(DATE,GETDATE())

	DECLARE @MS_MAY NVARCHAR(50) ='IMM-02';
	DECLARE @Ngay DATETIME= GETDATE()
	DECLARE @item INT = 5
	SELECT N'0Mấy chạy' AS ten,  FORMAT(Date, 'dd/MM/yyyy HH:mm:ss') AS Date ,MS_MAY,CONVERT(NVARCHAR(50),ItemID) AS Item,CONVERT(NVARCHAR(500),ActualQuanity) AS Value,CONVERT(NVARCHAR(50),Run) Run,(SELECT A.Note FROM dbo.ButtonDefinition A WHERE A.ButtonCode = B.ButtonCode ) AS Note 
	FROM dbo.ActualHMI B WHERE MS_MAY = @MS_MAY AND  ButtonCode NOT IN(51,53) AND B.ItemID =@item AND CONVERT(DATE,Date) = dbo.fnGetNgayTheoCa(@Ngay) 
	UNION
	SELECT N'2Ngừng mấy',  FORMAT(B.DEN_GIO, 'dd/MM/yyyy HH:mm:ss'),MS_MAY,'',NGUYEN_NHAN,'', FORMAT(B.TU_GIO, 'dd/MM/yyyy HH:mm:ss') from dbo.THOI_GIAN_DUNG_MAY B WHERE MS_MAY = @MS_MAY AND CONVERT(DATE,TU_GIO) = dbo.fnGetNgayTheoCa(@Ngay) 
	UNION
	(SELECT N'1Thao tác',FORMAT(A.Date, 'dd/MM/yyyy HH:mm:ss'),A.May,'',A.Value,'',B.Note FROM HMIAction A
	INNER JOIN dbo.ButtonDefinition B ON B.ButtonCode = A.ButtonCode WHERE A.May = @MS_MAY AND CONVERT(DATE,A.Date) = dbo.fnGetNgayTheoCa(@Ngay)  ) 
	ORDER BY Date,ten

--SELECT * FROM dbo.ActualHMI WHERE CONVERT(DATE,Date) = CONVERT(DATE,GETDATE()) ORDER BY Date
--SELECT * FROM dbo.HMIAction
--SELECT * FROM dbo.ActualHMI WHERE CONVERT(DATE,Date) = CONVERT(DATE,GETDATE()) AND MS_MAY ='IMM-15' ORDER BY Date
