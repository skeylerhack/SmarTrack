
ALTER PROCEDURE [dbo].[spGetReportMoldingDaily] 
	@TNgay DATETIME = '12-23-2021 00:00:00',
	@DNgay DATETIME = '12-23-2021 00:00:00',
	@ID_CA INT = -1,
	@ShiftLeader BIGINT = -1,
	@MS_MAY NVARCHAR(1000) = '''MOLD-01'',''MOLD-10'',''MOLD-11'',''MOLD-12'',''MOLD-15'',''MOLD-02'',''MOLD-03'',''MOLD-04'',''MOLD-05'',''MOLD-06'',''MOLD-07'',''MOLD-08'',''MOLD-09'''
AS
BEGIN
	--XOA BANG TAM
	IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'TEMP_BCMoldingDaily')
		DROP TABLE dbo.TEMP_BCMoldingDaily
	IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'TMP_TGDM')
		DROP TABLE dbo.TMP_TGDM


	-- LAY DU LIEU NGUNG MAY
	DECLARE @columns NVARCHAR(MAX) = '';
	--SELECT 
	--	@columns += QUOTENAME(ID_DownTime) + ','
	--FROM 
	--	DownTimeType
	--ORDER BY 
	--	ID_DownTime;
	--SET @columns = LEFT(@columns, LEN(@columns) - 1);

	--DECLARE @columns NVARCHAR(MAX) = '';

	SET @columns = '[18],[19],[20],[21],[22],[23],[25],[27],[28],[29],[31],[32],[30],[34],[35],[36]'

	DECLARE @TU_PHUT INT = (SELECT MIN(TU_PHUT) FROM CA)
	DECLARE @DEN_PHUT INT = (SELECT MAX(DEN_PHUT) FROM CA)
	DECLARE @sql NVARCHAR(MAX) = '';
	SET @sql = '
	SELECT * INTO TMP_TGDM FROM (SELECT TGDM.MS_MAY, DTT.ID_DownTime, TGDM.CaID, TGDM.ID_Operator, CONVERT(DATE, TGDM.TU_GIO) AS NGAY, SUM(ISNULL(TGDM.THOI_GIAN_SUA, 0)) AS THOI_GIAN_SUA
					FROM dbo.THOI_GIAN_DUNG_MAY TGDM
					LEFT JOIN dbo.NGUYEN_NHAN_DUNG_MAY NNDM ON NNDM.MS_NGUYEN_NHAN = TGDM.MS_NGUYEN_NHAN
					LEFT JOIN dbo.DownTimeType DTT ON DTT.ID_DownTime = NNDM.DownTimeTypeID
					WHERE TGDM.MS_MAY IN (' + @MS_MAY + ') AND (TGDM.CaID = ' + CONVERT(NVARCHAR, @ID_CA) + ' OR ' + CONVERT(NVARCHAR, @ID_CA) + ' = -1) AND TGDM.TU_GIO BETWEEN DATEADD(MINUTE, ' + CONVERT(NVARCHAR, @TU_PHUT) + ', (CONVERT(DATETIME, CONVERT(DATE, ''' + CONVERT(NVARCHAR, @TNGAY, 120) + '''), 120))) AND DATEADD(MINUTE, ' +  CONVERT(NVARCHAR, @DEN_PHUT) + ', (CONVERT(DATETIME, CONVERT(DATE, ''' +  CONVERT(NVARCHAR, @DNGAY, 120) + '''), 120)))
					GROUP BY TGDM.MS_MAY, DTT.ID_DownTime, TGDM.CaID, TGDM.ID_Operator, CONVERT(DATE, TGDM.TU_GIO)) src
	PIVOT (SUM(THOI_GIAN_SUA) FOR ID_DownTime IN (' + @columns + ')) piv'

	EXEC(@sql)
	
	-- LAY DU LIEU THEO TIEN DO
	SET @sql = '
	    SELECT A.StartTime, A.EndTime, CASE 0 WHEN 0 THEN B.CA WHEN 1 THEN ISNULL(NULLIF(B.CA_ANH, ''), B.CA) ELSE ISNULL(NULLIF(B.CA_HOA, ''), B.CA) END AS CA, CASE 0 WHEN 0 THEN E.OperatorName WHEN 1 THEN ISNULL(NULLIF(E.OperatorNameA, ''), E.OperatorName) ELSE ISNULL(NULLIF(E.OperatorNameH, ''), E.OperatorName) END AS ShiftLeader, CASE 0 WHEN 0 THEN C.OperatorName WHEN 1 THEN ISNULL(NULLIF(C.OperatorNameA, ''), C.OperatorName) ELSE ISNULL(NULLIF(C.OperatorNameH, ''), C.OperatorName) END AS OperatorName, A.MS_MAY, F.ItemName, F.ItemCode, A.NumberPerCycle, A.WorkingCycle, A.ActualQuantity, A.ID_CA, A.OperatorID, A.ItemID, A.PrOID
	    	INTO TEMP_BCMoldingDaily
	    	FROM dbo.ProductionRunDetails A
	    	LEFT JOIN dbo.CA B ON B.STT = A.ID_CA
	    	LEFT JOIN dbo.Operator C ON A.OperatorID = C.ID_Operator
	    	LEFT JOIN dbo.SHIFT_LEADER D ON D.ID_CA = B.STT AND CONVERT(DATE,A.StartTime) = CONVERT(DATE,D.NGAY)
	    	LEFT JOIN dbo.Operator E ON D.ID_Operator = E.ID_Operator
	    	LEFT JOIN dbo.Item F ON F.ID = A.ItemID
	    	WHERE A.MS_MAY IN (' + @MS_MAY + ') AND (A.ID_CA = ' + CONVERT(NVARCHAR, @ID_CA) + ' OR ' + CONVERT(NVARCHAR, @ID_CA) + ' = -1) AND (A.OperatorID = ' + CONVERT(NVARCHAR, @ShiftLeader) + ' OR ' + CONVERT(NVARCHAR, @ShiftLeader) + ' = -1) AND A.StartTime BETWEEN DATEADD(MINUTE, ' + CONVERT(NVARCHAR, @TU_PHUT) + ', (CONVERT(DATETIME, CONVERT(DATE, ''' + CONVERT(NVARCHAR, @TNGAY, 120) + '''), 120))) AND DATEADD(MINUTE, ' +  CONVERT(NVARCHAR, @DEN_PHUT) + ', (CONVERT(DATETIME, CONVERT(DATE, ''' +  CONVERT(NVARCHAR, @DNGAY, 120) + '''), 120)))'
	EXEC(@sql)


	--LEFT JOIN 2 BANG => TINH TOAN
	SELECT T.StartTime, T.CA, T.ShiftLeader, T.OperatorName, T.MS_MAY, T.ItemName, T.ItemCode, T.NumberPerCycle, T.WorkingCycle, T.ActualQuantity,
	-- ScrapRate = SUM(DefeactQuanity) / SUM(CheckQuantity) WHERE CHECKSTEP = 1
	CASE SUM(ISNULL(TMP_QC.CheckQuantity,0)) WHEN 0 THEN 0 ELSE (SUM(ISNULL(TMP_QC.DefeactQuanity, 0)) / SUM(ISNULL(TMP_QC.CheckQuantity,0))) END AS ScrapRate, 
	-- ScrapParts = SUM(DefeactQuanity) WHERE CHECKSTEP = 1
	(SUM(ISNULL(TMP_QC.DefeactQuanity, 0))) AS ScrapParts,
	-- AcceptableParts = ActualQuantity - ScrapParts
	(ISNULL(T.ActualQuantity, 0) - SUM(ISNULL(TMP_QC.DefeactQuanity, 0))) AS AcceptableParts, 
	-- QCPassedParts = SUM(CheckQuantity) - SUM(DefeactQuanity)  WHERE CHECKSTEP = 2
	(SUM(ISNULL(TMP_QC1.CheckQuantity, 0)) - SUM(ISNULL(TMP_QC1.DefeactQuanity, 0))) AS QCPassedParts, 
	-- TheoreticalOutput = PlanProductionTime * IdealRunRate
	CASE ISNULL(T.WorkingCycle, 0) WHEN 0 THEN 0 ELSE((CONVERT(FLOAT,DATEDIFF(SECOND, T.StartTime, T.EndTime)) / 60) * ((60 / CONVERT(FLOAT,ISNULL(T.WorkingCycle, 0))) * T.NumberPerCycle)) END AS TheoreticalOutput, 
	-- PlanProductionTime = StartTime - EndTime
	(CONVERT(FLOAT,DATEDIFF(SECOND, T.StartTime, T.EndTime)) / 60) AS PlanProductionTime, 
	-- ActualOperatingTime = PlanProductionTime - DownTime
	((CONVERT(FLOAT,DATEDIFF(SECOND, T.StartTime, T.EndTime)) / 60) - (ISNULL(N.[18], 0) + ISNULL(N.[19], 0) +ISNULL(N.[20], 0) + ISNULL(N.[21], 0) + ISNULL(N.[22], 0) + ISNULL(N.[23], 0) + ISNULL(N.[25], 0) + ISNULL(N.[27], 0) + ISNULL(N.[28], 0) + ISNULL(N.[29], 0) + ISNULL(N.[31], 0) + ISNULL(N.[32], 0) + ISNULL(N.[30], 0) + ISNULL(N.[34], 0) + ISNULL(N.[35], 0) + ISNULL(N.[36], 0))) AS ActualOperatingTime,
	ISNULL(N.[18], 0) AS [18], ISNULL(N.[19], 0) AS [19], ISNULL(N.[20], 0) AS [20],ISNULL(N.[21], 0) AS [21], ISNULL(N.[22], 0) AS [22], ISNULL(N.[23], 0) AS [23], ISNULL(N.[25], 0) AS [25], ISNULL(N.[27], 0) AS [27], ISNULL(N.[28], 0) AS [28], ISNULL(N.[29], 0) AS [29], ISNULL(N.[31], 0) AS [31], ISNULL(N.[32], 0) AS [32], ISNULL(N.[30], 0) AS [30], ISNULL(N.[34], 0) AS [34], ISNULL(N.[35], 0) AS [35], ISNULL(N.[36], 0) AS [36],
	-- IdealRunRate = (60 / WorkingCycle) * NumberPerCycle
	CASE ISNULL(T.WorkingCycle, 0) WHEN 0 THEN 0 ELSE ((60 / CONVERT(FLOAT, ISNULL(T.WorkingCycle, 0))) * T.NumberPerCycle) END AS IdealRunRate,
	-- AvailabilityRate = ActualOperatingTime / PlanProductionTime
	CASE (CONVERT(FLOAT,DATEDIFF(SECOND, T.StartTime, T.EndTime)) / 60) WHEN 0 THEN 0 ELSE (((CONVERT(FLOAT,DATEDIFF(SECOND, T.StartTime, T.EndTime)) / 60) - (ISNULL(N.[18], 0) + ISNULL(N.[19], 0) +ISNULL(N.[20], 0) + ISNULL(N.[21], 0) + ISNULL(N.[22], 0) + ISNULL(N.[23], 0) + ISNULL(N.[25], 0) + ISNULL(N.[27], 0) + ISNULL(N.[28], 0) + ISNULL(N.[29], 0) + ISNULL(N.[31], 0) + ISNULL(N.[32], 0) + ISNULL(N.[30], 0) + ISNULL(N.[34], 0) + ISNULL(N.[35], 0) + ISNULL(N.[36], 0))) / (CONVERT(FLOAT,DATEDIFF(SECOND, T.StartTime, T.EndTime)) / 60)) END AS AvailabilityRate,
	-- PerformanceRate = ActualQuantity / TheoreticalOutput
	CASE (CASE ISNULL(T.WorkingCycle, 0) WHEN 0 THEN 0 ELSE((CONVERT(FLOAT,DATEDIFF(SECOND, T.StartTime, T.EndTime)) / 60) * ((60 / CONVERT(FLOAT,ISNULL(T.WorkingCycle, 0))) * T.NumberPerCycle)) END) WHEN 0 THEN 0 ELSE  (T.ActualQuantity /  CASE ISNULL(T.WorkingCycle, 0) WHEN 0 THEN 0 ELSE((CONVERT(FLOAT,DATEDIFF(SECOND, T.StartTime, T.EndTime)) / 60) * ((60 / CONVERT(FLOAT,ISNULL(T.WorkingCycle, 0))) * T.NumberPerCycle)) END) END AS PerformanceRate,
	-- QualityRate = (ActualQuantity - QCPassedParts) / ActualQuantity
	CASE ISNULL(T.ActualQuantity, 0) WHEN 0 THEN 0 ELSE ((T.ActualQuantity - (SUM(ISNULL(TMP_QC1.CheckQuantity, 0)) - SUM(ISNULL(TMP_QC1.DefeactQuanity, 0)))) / T.ActualQuantity) END AS QualityRate,
	-- OEERate = AvailabilityRate * PerformanceRate * QualityRate
	(CASE (CONVERT(FLOAT,DATEDIFF(SECOND, T.StartTime, T.EndTime)) / 60) WHEN 0 THEN 0 ELSE (((CONVERT(FLOAT,DATEDIFF(SECOND, T.StartTime, T.EndTime)) / 60) - (ISNULL(N.[18], 0) + ISNULL(N.[19], 0) +ISNULL(N.[20], 0) + ISNULL(N.[21], 0) + ISNULL(N.[22], 0) + ISNULL(N.[23], 0) + ISNULL(N.[25], 0) + ISNULL(N.[27], 0) + ISNULL(N.[28], 0) + ISNULL(N.[29], 0) + ISNULL(N.[31], 0) + ISNULL(N.[32], 0) + ISNULL(N.[30], 0) + ISNULL(N.[34], 0) + ISNULL(N.[35], 0) + ISNULL(N.[36], 0))) / (CONVERT(FLOAT,DATEDIFF(SECOND, T.StartTime, T.EndTime)) / 60)) END * CASE (CASE ISNULL(T.WorkingCycle, 0) WHEN 0 THEN 0 ELSE((CONVERT(FLOAT,DATEDIFF(SECOND, T.StartTime, T.EndTime)) / 60) * ((60 / CONVERT(FLOAT, ISNULL(T.WorkingCycle, 0))) * T.NumberPerCycle)) END) WHEN 0 THEN 0 ELSE  (T.ActualQuantity /  CASE ISNULL(T.WorkingCycle, 0) WHEN 0 THEN 0 ELSE((CONVERT(FLOAT,DATEDIFF(SECOND, T.StartTime, T.EndTime)) / 60) * ((60 / CONVERT(FLOAT, ISNULL(T.WorkingCycle, 0))) * T.NumberPerCycle)) END) END * CASE ISNULL(T.ActualQuantity, 0) WHEN 0 THEN 0 ELSE ((T.ActualQuantity - (SUM(ISNULL(TMP_QC1.CheckQuantity, 0)) - SUM(ISNULL(TMP_QC1.DefeactQuanity, 0)))) / T.ActualQuantity) END) AS OEERate
	FROM TEMP_BCMoldingDaily T 
	LEFT JOIN (	SELECT SUM(T1.CheckQuantity) AS CheckQuantity, SUM(T1.DefeactQuanity) AS DefeactQuanity, T1.PrOID, T1.ItemID, T1.ID_CA,												T1.ProductionDate, T1.MS_MAY
				FROM (	SELECT ISNULL(B.CheckQuantity, 0) AS CheckQuantity,SUM(ISNULL(C.DefeactQuanity, 0)) AS DefeactQuanity, A.ID, A.ID_CA, CONVERT(DATE,						A.ProductionDate) AS ProductionDate, B.PrOID, B.ItemID, B.MS_MAY
						FROM dbo.QCData A
						LEFT JOIN dbo.QCDataDetails B ON B.ID_QC = A.ID
						LEFT JOIN  dbo.QCDataDefect C ON C.QCDataDetailsID = B.ID
						WHERE A.CheckStepID = 1
						GROUP BY  A.ID, ProductionDate, A.ID_CA, B.CheckQuantity, B.PrOID, B.ItemID, B.MS_MAY) T1 
				GROUP BY  T1.PrOID, T1.ProductionDate, T1.ItemID, T1.ID_CA, T1.MS_MAY) TMP_QC ON TMP_QC.ID_CA = T.ID_CA AND TMP_QC.ItemID = T.ItemID AND TMP_QC.MS_MAY = T.MS_MAY AND TMP_QC.PrOID = T.PrOID AND CONVERT(DATE, TMP_QC.ProductionDate) = CONVERT(DATE,T.StartTime)
	LEFT JOIN (	SELECT SUM(T1.CheckQuantity) AS CheckQuantity, SUM(T1.DefeactQuanity) AS DefeactQuanity, T1.PrOID, T1.ItemID, T1.ID_CA,												T1.ProductionDate, T1.MS_MAY
				FROM (	SELECT ISNULL(B.CheckQuantity, 0) AS CheckQuantity,SUM(ISNULL(C.DefeactQuanity, 0)) AS DefeactQuanity, A.ID, A.ID_CA, CONVERT(DATE,						A.ProductionDate) AS ProductionDate, B.PrOID, B.ItemID, B.MS_MAY
						FROM dbo.QCData A
						LEFT JOIN dbo.QCDataDetails B ON B.ID_QC = A.ID
						LEFT JOIN  dbo.QCDataDefect C ON C.QCDataDetailsID = B.ID
						WHERE A.CheckStepID = 2
						GROUP BY  A.ID, ProductionDate, A.ID_CA, B.CheckQuantity, B.PrOID, B.ItemID, B.MS_MAY) T1 
				GROUP BY  T1.PrOID, T1.ProductionDate, T1.ItemID, T1.ID_CA, T1.MS_MAY) TMP_QC1 ON TMP_QC1.ID_CA = T.ID_CA AND TMP_QC1.ItemID = T.ItemID AND TMP_QC1.MS_MAY = T.MS_MAY AND TMP_QC1.PrOID = T.PrOID AND CONVERT(DATE, TMP_QC1.ProductionDate) = CONVERT(DATE,T.StartTime)
	LEFT JOIN TMP_TGDM N ON N.MS_MAY = T.MS_MAY AND N.CAID = T.ID_CA AND N.ID_Operator = T.OperatorID AND CONVERT(DATE,N.NGAY) = CONVERT(DATE,T.StartTime)
	GROUP BY T.StartTime, T.EndTime, T.CA, T.OperatorName, T.OperatorName, T.MS_MAY, T.ItemName, T.ItemCode, T.NumberPerCycle, T.WorkingCycle, T.ActualQuantity, T.ID_CA, T.OperatorID, T.ItemID, T.PrOID, T.ShiftLeader, N.[18], N.[19], N.[20], N.[21], N.[22], N.[23], N.[25], N.[27], N.[28], N.[29], N.[31], N.[32], N.[30], N.[34], N.[35], N.[36]

	--XOA BANG TAM
	IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'TEMP_BCMoldingDaily')
		DROP TABLE dbo.TEMP_BCMoldingDaily
	IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'TMP_TGDM')
		DROP TABLE dbo.TMP_TGDM
END
