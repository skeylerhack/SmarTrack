
ALTER PROCEDURE [dbo].[spGetReportMoldingDaily] 
	@NNgu INT = 0,
	@TNgay DATETIME = '12-23-2021 00:00:00',
	@DNgay DATETIME = '12-23-2021 00:00:00',
	@ID_CA INT = -1,
	@ShiftLeader BIGINT = -1,
	@sBT NVARCHAR(500) = NULL
AS
BEGIN
	CREATE TABLE #MS_MAY (MS_MAY NVARCHAR(30));
	DECLARE @sql_#MS_MAY NVARCHAR(MAX) = ''
	SET @sql_#MS_MAY = 'INSERT INTO #MS_MAY(MS_MAY) SELECT MS_MAY FROM ' + @sBT
	EXEC(@sql_#MS_MAY);
	EXEC('DROP TABLE ' + @sBT);

	-- LAY DU LIEU DUNG MAY
	SELECT * INTO #TMP_TGDM FROM (
					SELECT TGDM.ID, TGDM.MS_MAY, DTT.ID_DownTime, TGDM.CaID, TGDM.ID_Operator, TGDM.TU_GIO, TGDM.NGAY_DUNG, SUM(ISNULL(TGDM.THOI_GIAN_SUA, 0)) AS THOI_GIAN_SUA
					FROM dbo.THOI_GIAN_DUNG_MAY TGDM
					LEFT JOIN dbo.NGUYEN_NHAN_DUNG_MAY NNDM ON NNDM.MS_NGUYEN_NHAN = TGDM.MS_NGUYEN_NHAN
					LEFT JOIN dbo.DownTimeType DTT ON DTT.ID_DownTime = NNDM.DownTimeTypeID
					WHERE TGDM.MS_MAY IN (SELECT MS_MAY FROM #MS_MAY) AND (TGDM.CaID = @ID_CA OR @ID_CA = -1) AND TGDM.NGAY_DUNG BETWEEN CONVERT(DATE, @TNgay) AND CONVERT(DATE, @DNgay)
					GROUP BY TGDM.ID, TGDM.MS_MAY, DTT.ID_DownTime, TGDM.CaID, TGDM.ID_Operator, TGDM.TU_GIO, TGDM.NGAY_DUNG) src
	PIVOT (SUM(THOI_GIAN_SUA) FOR ID_DownTime IN ([18],[19],[20],[21],[22],[23],[25],[27],[28],[29],[31],[32],[30],[34],[35],[36])) piv

	-- LAY DU LIEU THEO TIEN DO
	 SELECT A.StartTime, A.EndTime, CASE @NNgu WHEN 0 THEN B.CA WHEN 1 THEN ISNULL(NULLIF(B.CA_ANH, ''), B.CA) ELSE ISNULL(NULLIF(B.CA_HOA, ''), B.CA) END AS CA, CASE @NNgu WHEN 0 THEN E.OperatorName WHEN 1 THEN ISNULL(NULLIF(E.OperatorNameA, ''), E.OperatorName) ELSE ISNULL(NULLIF(E.OperatorNameH, ''), E.OperatorName) END AS ShiftLeader, CASE @NNgu WHEN 0 THEN C.OperatorName WHEN 1 THEN ISNULL(NULLIF(C.OperatorNameA, ''), C.OperatorName) ELSE ISNULL(NULLIF(C.OperatorNameH, ''), C.OperatorName) END AS OperatorName, A.MS_MAY, F.ItemName, F.ItemCode, A.NumberPerCycle, A.WorkingCycle, ISNULL(A.ActualQuantity, 0) AS ActualQuantity, A.ID_CA, A.OperatorID, A.ItemID, A.PrOID, A.StandardOutput, ISNULL([dbo].fnGetUptimeReport(A.DetailID, 1), 0) AS PlanProductionTime, ISNULL([dbo].fnGetUptimeReport(A.DetailID, -1), 0) AS ActualOperatingTime
	INTO #TEMP_BCMoldingDaily
	FROM dbo.ProductionRunDetails A
	    LEFT JOIN dbo.CA B ON B.STT = A.ID_CA
	    LEFT JOIN dbo.Operator C ON A.OperatorID = C.ID_Operator
	    LEFT JOIN dbo.SHIFT_LEADER D ON D.ID_CA = B.STT AND CONVERT(DATE,A.StartTime) = CONVERT(DATE,D.NGAY)
	    LEFT JOIN dbo.Operator E ON D.ID_Operator = E.ID_Operator
	    LEFT JOIN dbo.Item F ON F.ID = A.ItemID
		LEFT JOIN dbo.ProductionOrder G ON G.ID = A.PrOID
	 WHERE A.MS_MAY IN (SELECT MS_MAY FROM #MS_MAY) AND (A.ID_CA = @ID_CA OR @ID_CA = -1) AND (A.OperatorID = @ShiftLeader OR @ShiftLeader = -1) AND dbo.fnGetNgayTheoCa(A.StartTime) BETWEEN CONVERT(DATE, @TNgay) AND CONVERT(DATE, @DNgay)


	--LEFT JOIN 2 BANG => TINH TOAN
		SELECT T.StartTime, T.EndTime, T.ID_CA, T.CA, T.ShiftLeader, T.OperatorName, T.MS_MAY, T.ItemName, T.ItemCode, T.NumberPerCycle, T.WorkingCycle, T.ActualQuantity,
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

		SUM(ISNULL(N.[18], 0)) AS [18], SUM(ISNULL(N.[19], 0)) AS [19], SUM(ISNULL(N.[20], 0)) AS [20], SUM(ISNULL(N.[21], 0)) AS [21], SUM(ISNULL(N.[22], 0)) AS [22], SUM(ISNULL(N.[23], 0)) AS [23], SUM(ISNULL(N.[25], 0)) AS [25], SUM(ISNULL(N.[27], 0)) AS [27], SUM(ISNULL(N.[28], 0)) AS [28], SUM(ISNULL(N.[29], 0)) AS [29], SUM(ISNULL(N.[31], 0)) AS [31], SUM(ISNULL(N.[32], 0)) AS [32], SUM(ISNULL(N.[30], 0)) AS [30], SUM(ISNULL(N.[34], 0)) AS [34], SUM(ISNULL(N.[35], 0)) AS [35], SUM(ISNULL(N.[36], 0)) AS [36],
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
		INTO #T1
		FROM #TEMP_BCMoldingDaily T 
		LEFT JOIN (	SELECT SUM(T1.CheckQuantity) AS CheckQuantity, SUM(T1.DefeactQuanity) AS DefeactQuanity, T1.PrOID, T1.ItemID, T1.ID_CA,												T1.ProductionDate, T1.MS_MAY
					FROM (	SELECT ISNULL(B.CheckQuantity, 0) AS CheckQuantity,SUM(ISNULL(C.DefeactQuanity, 0)) AS DefeactQuanity, A.ID, A.ID_CA, CONVERT(DATE,						A.ProductionDate) AS ProductionDate, B.PrOID, B.ItemID, B.MS_MAY
							FROM dbo.QCData A
							LEFT JOIN dbo.QCDataDetails B ON B.ID_QC = A.ID
							LEFT JOIN  dbo.QCDataDefect C ON C.QCDataDetailsID = B.ID
							WHERE A.CheckStepID = 1
							GROUP BY  A.ID, ProductionDate, A.ID_CA, B.CheckQuantity, B.PrOID, B.ItemID, B.MS_MAY) T1 
					GROUP BY  T1.PrOID, T1.ProductionDate, T1.ItemID, T1.ID_CA, T1.MS_MAY) TMP_QC ON TMP_QC.ID_CA = T.ID_CA AND TMP_QC.ItemID = T.ItemID AND TMP_QC.MS_MAY = T.MS_MAY AND TMP_QC.PrOID = T.PrOID AND CONVERT(DATE, TMP_QC.ProductionDate) = CONVERT(DATE,T.StartTime)
		LEFT JOIN #TMP_TGDM N ON N.MS_MAY = T.MS_MAY AND N.CAID = T.ID_CA AND N.TU_GIO BETWEEN T.StartTime AND T.EndTime
		GROUP BY T.StartTime, T.EndTime, T.ID_CA, T.CA, T.OperatorName, T.OperatorName, T.MS_MAY, T.ItemName, T.ItemCode, T.NumberPerCycle, T.WorkingCycle, T.ActualQuantity, T.ID_CA, T.OperatorID, T.ItemID, T.PrOID, T.ShiftLeader, T.StandardOutput, T.PlanProductionTime, T.ActualOperatingTime--, N.[18], N.[19], N.[20], N.[21], N.[22], N.[23], N.[25], N.[27], N.[28], N.[29], N.[31], N.[32], N.[30], N.[34], N.[35], N.[36]
	
	
	--UNION VS DUNG MAY KHONG TIEN DO
	SELECT dbo.fnGetNgayTheoCa(StartTime) AS StartTime, CA, ShiftLeader, OperatorName, MS_MAY, ItemName, ItemCode, NumberPerCycle, WorkingCycle, ActualQuantity, ScrapRate, ScrapParts, AcceptableParts, TheoreticalOutput, PlanProductionTime, ActualOperatingTime, [18], [19], [20], [21], [22], [23], [25], [27], [28], [29], [31], [32], [30], [34], [35], [36], IdealRunRate, AvailabilityRate, PerformanceRate, QualityRate, OEERate FROM #T1
	UNION 
	SELECT dbo.fnGetNgayTheoCa(TGDM.TU_GIO), CASE @NNgu WHEN 0 THEN C.CA WHEN 1 THEN ISNULL(NULLIF(C.CA_ANH, ''), C.CA) ELSE ISNULL(NULLIF(C.CA_HOA, ''), C.CA) END AS CA, '', '', TGDM.MS_MAY, '', '', 0, 0, 0, 0, 0, 0, 0, 0, 0, SUM(ISNULL(TGDM.[18], 0)) AS [18], SUM(ISNULL(TGDM.[19], 0)) AS [19], SUM(ISNULL(TGDM.[20], 0)) AS [20], SUM(ISNULL(TGDM.[21], 0)) AS [21], SUM(ISNULL(TGDM.[22], 0)) AS [22], SUM(ISNULL(TGDM.[23], 0)) AS [23], SUM(ISNULL(TGDM.[25], 0)) AS [25], SUM(ISNULL(TGDM.[27], 0)) AS [27], SUM(ISNULL(TGDM.[28], 0)) AS [28], SUM(ISNULL(TGDM.[29], 0)) AS [29], SUM(ISNULL(TGDM.[31], 0)) AS [31], SUM(ISNULL(TGDM.[32], 0)) AS [32], SUM(ISNULL(TGDM.[30], 0)) AS [30], SUM(ISNULL(TGDM.[34], 0)) AS [34], SUM(ISNULL(TGDM.[35], 0)) AS [35], SUM(ISNULL(TGDM.[36], 0)) AS [36], 0, 0, 0, 0, 0 
	FROM #TMP_TGDM TGDM
	LEFT JOIN dbo.CA C ON C.STT = TGDM.CaID
	LEFT JOIN dbo.SHIFT_LEADER D ON D.ID_CA = C.STT AND CONVERT(DATE,TGDM.NGAY_DUNG) = CONVERT(DATE,D.NGAY)
	LEFT JOIN dbo.Operator S ON D.ID_Operator = S.ID_Operator
	LEFT JOIN dbo.Operator O ON O.ID_Operator = TGDM.ID_Operator
	WHERE TGDM.ID NOT IN (SELECT ID 
							FROM #TMP_TGDM TGDM 
							INNER JOIN #T1 T ON TGDM.MS_MAY = T.MS_MAY AND TGDM.CAID = T.ID_CA AND TGDM.TU_GIO BETWEEN T.StartTime AND T.EndTime)
	GROUP BY dbo.fnGetNgayTheoCa(TGDM.TU_GIO), TGDM.CaID, C.CA, C.CA_ANH, C.CA_HOA, TGDM.MS_MAY 
	ORDER BY StartTime, CA, ShiftLeader, MS_MAY
END
