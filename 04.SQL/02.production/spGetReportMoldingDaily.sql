ALTER PROCEDURE [dbo].[spGetReportMoldingDaily] 
	@NNgu INT = 0,
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
	IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'TMP_TGDM1')
		DROP TABLE dbo.TMP_TGDM1


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
	DECLARE @DEN_PHUT INT = (SELECT MAX(DEN_PHUT) FROM CA) - 0.001
	DECLARE @sql NVARCHAR(MAX) = '';

	-- LAY DU LIEU DUNG MAY THEO TIEN DO
	SET @sql = '
	SELECT * INTO TMP_TGDM FROM (SELECT TGDM.MS_MAY, DTT.ID_DownTime, TGDM.CaID, TGDM.ID_Operator, CONVERT(DATE, TGDM.TU_GIO) AS NGAY, SUM(ISNULL(TGDM.THOI_GIAN_SUA, 0)) AS THOI_GIAN_SUA
					FROM dbo.THOI_GIAN_DUNG_MAY TGDM
					LEFT JOIN dbo.NGUYEN_NHAN_DUNG_MAY NNDM ON NNDM.MS_NGUYEN_NHAN = TGDM.MS_NGUYEN_NHAN
					LEFT JOIN dbo.DownTimeType DTT ON DTT.ID_DownTime = NNDM.DownTimeTypeID
					WHERE TGDM.MS_MAY IN (' + @MS_MAY + ') AND (TGDM.CaID = ' + CONVERT(NVARCHAR, @ID_CA) + ' OR ' + CONVERT(NVARCHAR, @ID_CA) + ' = -1) AND TGDM.TU_GIO BETWEEN DATEADD(MINUTE, ' + CONVERT(NVARCHAR, @TU_PHUT) + ', (CONVERT(DATETIME, CONVERT(DATE, ''' + CONVERT(NVARCHAR, @TNGAY, 120) + '''), 120))) AND DATEADD(MINUTE, ' +  CONVERT(NVARCHAR, @DEN_PHUT) + ', (CONVERT(DATETIME, CONVERT(DATE, ''' +  CONVERT(NVARCHAR, @DNGAY, 120) + '''), 120)))
					GROUP BY TGDM.MS_MAY, DTT.ID_DownTime, TGDM.CaID, TGDM.ID_Operator, CONVERT(DATE, TGDM.TU_GIO)) src
	PIVOT (SUM(THOI_GIAN_SUA) FOR ID_DownTime IN (' + @columns + ')) piv'
	EXEC(@sql)

	-- LAY DU LIEU DUNG MAY KHONG THEO TIEN DO
	SET @sql = '
	SELECT * INTO TMP_TGDM1 FROM (SELECT TGDM.MS_MAY, DTT.ID_DownTime, TGDM.CaID, CASE ' + CONVERT(NVARCHAR, @NNgu) + ' WHEN 0 THEN C.CA WHEN 1 THEN ISNULL(NULLIF(C.CA_ANH, ''), C.CA) ELSE ISNULL(NULLIF(C.CA_HOA, ''), C.CA) END AS CA, TGDM.ID_Operator, CASE ' + CONVERT(NVARCHAR, @NNgu) + ' WHEN 0 THEN L.OperatorName WHEN 1 THEN ISNULL(NULLIF(L.OperatorNameA, ''), L.OperatorName) ELSE ISNULL(NULLIF(L.OperatorNameH, ''), L.OperatorName) END AS ShiftLEader, CASE ' + CONVERT(NVARCHAR, @NNgu) + ' WHEN 0 THEN O.OperatorName WHEN 1 THEN ISNULL(NULLIF(O.OperatorNameA, ''), O.OperatorName) ELSE ISNULL(NULLIF(O.OperatorNameH, ''), O.OperatorName) END AS OperatorName, CONVERT(DATE, TGDM.NGAY_DUNG) AS NGAY, SUM(ISNULL(TGDM.THOI_GIAN_SUA, 0)) AS THOI_GIAN_SUA
					FROM dbo.THOI_GIAN_DUNG_MAY TGDM
					LEFT JOIN dbo.NGUYEN_NHAN_DUNG_MAY NNDM ON NNDM.MS_NGUYEN_NHAN = TGDM.MS_NGUYEN_NHAN
					LEFT JOIN dbo.DownTimeType DTT ON DTT.ID_DownTime = NNDM.DownTimeTypeID
					LEFT JOIN dbo.CA C ON C.STT = TGDM.CaID 
	    			LEFT JOIN dbo.SHIFT_LEADER SD ON SD.ID_CA = C.STT AND CONVERT(DATE,TGDM.NGAY_DUNG) = CONVERT(DATE,SD.NGAY)
					LEFT JOIN dbo.Operator L ON L.ID_Operator = SD.ID_Operator
					LEFT JOIN dbo.Operator O ON O.ID_Operator = TGDM.ID_Operator
					WHERE TGDM.MS_MAY IN (' + @MS_MAY + ') AND (TGDM.CaID = ' + CONVERT(NVARCHAR, @ID_CA) + ' OR ' + CONVERT(NVARCHAR, @ID_CA) + ' = -1) AND TGDM.TU_GIO BETWEEN DATEADD(MINUTE, ' + CONVERT(NVARCHAR, @TU_PHUT) + ', (CONVERT(DATETIME, CONVERT(DATE, ''' + CONVERT(NVARCHAR, @TNGAY, 120) + '''), 120))) AND DATEADD(MINUTE, ' +  CONVERT(NVARCHAR, @DEN_PHUT) + ', (CONVERT(DATETIME, CONVERT(DATE, ''' +  CONVERT(NVARCHAR, @DNGAY, 120) + '''), 120))) AND CONCAT(TGDM.MS_MAY, '';'', CONVERT(DATE, TGDM.TU_GIO), '';'', TGDM.CaID) NOT IN (SELECT CONCAT(MS_MAY, '';'', CONVERT(DATE, StartTime), '';'', ID_CA) FROM dbo.ProductionRunDetails)
					GROUP BY TGDM.MS_MAY, DTT.ID_DownTime, TGDM.CaID, C.CA, C.CA_ANH, C.CA_HOA, TGDM.ID_Operator, L.OperatorName, L.OperatorNameA, L.OperatorNameH, O.OperatorName, O.OperatorNameA, O.OperatorNameH, CONVERT(DATE, TGDM.NGAY_DUNG)) src
	PIVOT (SUM(THOI_GIAN_SUA) FOR ID_DownTime IN (' + @columns + ')) piv'
	EXEC(@sql)
	
	-- LAY DU LIEU THEO TIEN DO
	SET @sql = '
	    SELECT CONVERT(DATE, A.StartTime) AS StartTime, CONVERT(DATE, A.EndTime) AS EndTime, CASE ' + CONVERT(NVARCHAR, @NNgu) + ' WHEN 0 THEN B.CA WHEN 1 THEN ISNULL(NULLIF(B.CA_ANH, ''), B.CA) ELSE ISNULL(NULLIF(B.CA_HOA, ''), B.CA) END AS CA, CASE ' + CONVERT(NVARCHAR, @NNgu) + ' WHEN 0 THEN E.OperatorName WHEN 1 THEN ISNULL(NULLIF(E.OperatorNameA, ''), E.OperatorName) ELSE ISNULL(NULLIF(E.OperatorNameH, ''), E.OperatorName) END AS ShiftLeader, CASE ' + CONVERT(NVARCHAR, @NNgu) + ' WHEN 0 THEN C.OperatorName WHEN 1 THEN ISNULL(NULLIF(C.OperatorNameA, ''), C.OperatorName) ELSE ISNULL(NULLIF(C.OperatorNameH, ''), C.OperatorName) END AS OperatorName, A.MS_MAY, F.ItemName, F.ItemCode, A.NumberPerCycle, A.WorkingCycle, ISNULL(A.Ac ualQuantity, 0) AS ActualQuantity, A.ID_CA, A.OperatorID, A.ItemID, A.PrOID, A.StandardOutput, ISNULL([dbo].fnGetUptimeReport(A.DetailID, 1), 0) AS PlanProductionTime, ISNULL([dbo].fnGetUptimeReport(A.DetailID, -1), 0) AS ActualOperatingTime
	    	INTO TEMP_BCMoldingDaily
	    	FROM dbo.ProductionRunDetails A
	    	LEFT JOIN dbo.CA B ON B.STT = A.ID_CA
	    	LEFT JOIN dbo.Operator C ON A.OperatorID = C.ID_Operator
	    	LEFT JOIN dbo.SHIFT_LEADER D ON D.ID_CA = B.STT AND CONVERT(DATE,A.StartTime) = CONVERT(DATE,D.NGAY)
	    	LEFT JOIN dbo.Operator E ON D.ID_Operator = E.ID_Operator
	    	LEFT JOIN dbo.Item F ON F.ID = A.ItemID
			LEFT JOIN dbo.ProductionOrder G ON G.ID = A.PrOID
	    	WHERE A.MS_MAY IN (' + @MS_MAY + ') AND (A.ID_CA = ' + CONVERT(NVARCHAR, @ID_CA) + ' OR ' + CONVERT(NVARCHAR, @ID_CA) + ' = -1) AND (A.OperatorID = ' + CONVERT(NVARCHAR, @ShiftLeader) + ' OR ' + CONVERT(NVARCHAR, @ShiftLeader) + ' = -1) AND A.StartTime BETWEEN DATEADD(MINUTE, ' + CONVERT(NVARCHAR, @TU_PHUT) + ', (CONVERT(DATETIME, CONVERT(DATE, ''' + CONVERT(NVARCHAR, @TNGAY, 120) + '''), 120))) AND DATEADD(MINUTE, ' +  CONVERT(NVARCHAR, @DEN_PHUT) + ', (CONVERT(DATETIME, CONVERT(DATE, ''' +  CONVERT(NVARCHAR, @DNGAY, 120) + '''), 120)))'
	EXEC(@sql)


	--LEFT JOIN 2 BANG => TINH TOAN
	SELECT CONVERT(DATE, T.StartTime) AS StartTime, T.CA, T.ShiftLeader, T.OperatorName, T.MS_MAY, T.ItemName, T.ItemCode, T.NumberPerCycle, T.WorkingCycle, T.ActualQuantity,
	-- ScrapRate = SUM(DefeactQuanity) / SUM(CheckQuantity) WHERE CHECKSTEP = 1
	CASE SUM(ISNULL(TMP_QC.CheckQuantity,0)) WHEN 0 THEN 0 ELSE (SUM(ISNULL(TMP_QC.DefeactQuanity, 0)) / SUM(ISNULL(TMP_QC.CheckQuantity,0))) END AS ScrapRate, 
	-- ScrapParts = SUM(DefeactQuanity) WHERE CHECKSTEP = 1
	(SUM(ISNULL(TMP_QC.DefeactQuanity, 0))) AS ScrapParts,
	-- AcceptableParts = ActualQuantity - ScrapParts
	(ISNULL(T.ActualQuantity, 0) - SUM(ISNULL(TMP_QC.DefeactQuanity, 0))) AS AcceptableParts, 
	-- TheoreticalOutput = PlanProductionTime * IdealRunRate
	(T.PlanProductionTime * (T.StandardOutput / 60)) AS TheoreticalOutput, 
	-- PlanProductionTime
	T.PlanProductionTime, 
	-- ActualOperatingTime
	T.ActualOperatingTime,

	ISNULL(N.[18], 0) AS [18], ISNULL(N.[19], 0) AS [19], ISNULL(N.[20], 0) AS [20],ISNULL(N.[21], 0) AS [21], ISNULL(N.[22], 0) AS [22], ISNULL(N.[23], 0) AS [23], ISNULL(N.[25], 0) AS [25], ISNULL(N.[27], 0) AS [27], ISNULL(N.[28], 0) AS [28], ISNULL(N.[29], 0) AS [29], ISNULL(N.[31], 0) AS [31], ISNULL(N.[32], 0) AS [32], ISNULL(N.[30], 0) AS [30], ISNULL(N.[34], 0) AS [34], ISNULL(N.[35], 0) AS [35], ISNULL(N.[36], 0) AS [36],
	-- IdealRunRate = (60 / WorkingCycle) * NumberPerCycle --------OR--------- (StandardOutput / 60)
	(T.StandardOutput / 60) AS IdealRunRate,
	-- AvailabilityRate = ActualOperatingTime / PlanProductionTime
	CASE ISNULL(T.PlanProductionTime, 0)  WHEN 0 THEN 0 ELSE (ISNULL(T.ActualOperatingTime, 0) / ISNULL(T.PlanProductionTime, 0)) END AS AvailabilityRate,
	-- PerformanceRate = (ActualQuantity / ActualOperatingTime) / IdealRunRate
	CASE (ISNULL(T.ActualOperatingTime, 0) * ISNULL(T.StandardOutput, 0))  WHEN 0 THEN 0 ELSE ((ISNULL(T.ActualQuantity, 0) / ISNULL(T.ActualOperatingTime, 0)) / (ISNULL(T.StandardOutput, 0) / 60)) END AS PerformanceRate,
	-- QualityRate = (ActualQuantity - DefeactQuanity) / ActualQuantity
	CASE ISNULL(T.ActualQuantity, 0) WHEN 0 THEN 0 ELSE ((T.ActualQuantity - SUM(ISNULL(TMP_QC.DefeactQuanity, 0))) / T.ActualQuantity) END AS QualityRate,
	-- OEERate = AvailabilityRate * PerformanceRate * QualityRate
	(CASE ISNULL(T.PlanProductionTime, 0)  WHEN 0 THEN 0 ELSE (ISNULL(T.ActualOperatingTime, 0) / ISNULL(T.PlanProductionTime, 0)) END * CASE (ISNULL(T.ActualOperatingTime, 0) * ISNULL(T.StandardOutput, 0))  WHEN 0 THEN 0 ELSE ((ISNULL(T.ActualQuantity, 0) / ISNULL(T.ActualOperatingTime, 0)) / (ISNULL(T.StandardOutput, 0) / 60)) END * CASE ISNULL(T.ActualQuantity, 0) WHEN 0 THEN 0 ELSE ((T.ActualQuantity - SUM(ISNULL(TMP_QC.DefeactQuanity, 0))) / T.ActualQuantity) END) AS OEERate
	FROM TEMP_BCMoldingDaily T 
	LEFT JOIN (	SELECT SUM(T1.CheckQuantity) AS CheckQuantity, SUM(T1.DefeactQuanity) AS DefeactQuanity, T1.PrOID, T1.ItemID, T1.ID_CA,												T1.ProductionDate, T1.MS_MAY
				FROM (	SELECT ISNULL(B.CheckQuantity, 0) AS CheckQuantity,SUM(ISNULL(C.DefeactQuanity, 0)) AS DefeactQuanity, A.ID, A.ID_CA, CONVERT(DATE,						A.ProductionDate) AS ProductionDate, B.PrOID, B.ItemID, B.MS_MAY
						FROM dbo.QCData A
						LEFT JOIN dbo.QCDataDetails B ON B.ID_QC = A.ID
						LEFT JOIN  dbo.QCDataDefect C ON C.QCDataDetailsID = B.ID
						WHERE A.CheckStepID = 1
						GROUP BY  A.ID, ProductionDate, A.ID_CA, B.CheckQuantity, B.PrOID, B.ItemID, B.MS_MAY) T1 
				GROUP BY  T1.PrOID, T1.ProductionDate, T1.ItemID, T1.ID_CA, T1.MS_MAY) TMP_QC ON TMP_QC.ID_CA = T.ID_CA AND TMP_QC.ItemID = T.ItemID AND TMP_QC.MS_MAY = T.MS_MAY AND TMP_QC.PrOID = T.PrOID AND CONVERT(DATE, TMP_QC.ProductionDate) = CONVERT(DATE,T.StartTime)
	LEFT JOIN TMP_TGDM N ON N.MS_MAY = T.MS_MAY AND N.CAID = T.ID_CA AND N.ID_Operator = T.OperatorID AND CONVERT(DATE, N.NGAY) = CONVERT(DATE, T.StartTime)
	GROUP BY CONVERT(DATE, T.StartTime), T.CA, T.OperatorName, T.OperatorName, T.MS_MAY, T.ItemName, T.ItemCode, T.NumberPerCycle, T.WorkingCycle, T.ActualQuantity, T.ID_CA, T.OperatorID, T.ItemID, T.PrOID, T.ShiftLeader, N.[18], N.[19], N.[20], N.[21], N.[22], N.[23], N.[25], N.[27], N.[28], N.[29], N.[31], N.[32], N.[30], N.[34], N.[35], N.[36], T.StandardOutput, T.PlanProductionTime, T.ActualOperatingTime
	UNION 
	SELECT NGAY, CA, ShiftLeader, OperatorName, MS_MAY, '', '', 0, 0, 0, 0, 0, 0, 0, 0, 0, ISNULL([18], 0) AS [18], ISNULL([19], 0) AS [19], ISNULL([20], 0) AS [20],ISNULL([21], 0) AS [21], ISNULL([22], 0) AS [22], ISNULL([23], 0) AS [23], ISNULL([25], 0) AS [25], ISNULL([27], 0) AS [27], ISNULL([28], 0) AS [28], ISNULL([29], 0) AS [29], ISNULL([31], 0) AS [31], ISNULL([32], 0) AS [32], ISNULL([30], 0) AS [30], ISNULL([34], 0) AS [34], ISNULL([35], 0) AS [35], ISNULL([36], 0) AS [36], 0, 0, 0, 0, 0 FROM TMP_TGDM1

	ORDER BY StartTime, CA, ShiftLeader, MS_MAY


	--XOA BANG TAM
	IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'TEMP_BCMoldingDaily')
		DROP TABLE dbo.TEMP_BCMoldingDaily
	IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'TMP_TGDM')
		DROP TABLE dbo.TMP_TGDM
	IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'TMP_TGDM1')
		DROP TABLE dbo.TMP_TGDM1
END
