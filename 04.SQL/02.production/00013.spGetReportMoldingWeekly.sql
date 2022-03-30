
ALTER PROCEDURE [dbo].[spGetReportMoldingWeekly] 
	@NNgu INT = 0,
	@FormName NVARCHAR(100) = 'ucBaocaoMoldingWeekly',
	@TNgay DATETIME = '2022-02-15 00:00:00',
	@DNgay DATETIME = '2022-02-15 00:00:00',
	@ID_CA INT = -1,
	@ShiftLeader BIGINT = -1,
	@sBT NVARCHAR(500) = 'sBT_MS_MAYadmin'
	--@MS_MAY NVARCHAR(1000) = '''MOLD-01'',''MOLD-10'',''MOLD-11'',''MOLD-12'',''MOLD-15'',''MOLD-02'',''MOLD-03'',''MOLD-04'',''MOLD-05'',''MOLD-06'',''MOLD-07'',''MOLD-08'',''MOLD-09'''
AS
BEGIN
	--Get list MS_MAY
	CREATE TABLE #MS_MAY (MS_MAY NVARCHAR(30));

	DECLARE @sql_#MS_MAY NVARCHAR(MAX) = ''
	SET @sql_#MS_MAY = 'INSERT INTO #MS_MAY(MS_MAY) SELECT MS_MAY FROM ' + @sBT
	EXEC(@sql_#MS_MAY);
	EXEC('DROP TABLE ' + @sBT);
	--Get list date
	CREATE TABLE #NGAY (NGAY DATE)
	--DECLARE	@TNgay DATETIME = '2022-01-05 00:00:00'
	--DECLARE @DNgay DATETIME = '2022-01-05 00:00:00'
	DECLARE @FromDate DATE = CONVERT(DATE, @TNgay)
	DECLARE @ToDate DATE = CONVERT(DATE, @DNgay)
	
	WHILE @FromDate <= @ToDate
	BEGIN
		INSERT INTO #NGAY(NGAY)
		VALUES(@FromDate)
		SET @FromDate = DATEADD(DAY, 1, @FromDate)
    END

	
	--DECLARE @ID_CA INT = -1
	--DECLARE @ShiftLeader BIGINT = -1
	SELECT #N.NGAY,
	-- TheoreticalOutput = (((Second)(StartTime - EndTime)) / 60) * ((60 / WorkingCycle) * NumberPerCycle)
 	SUM(ISNULL(CASE ISNULL(PRD.WorkingCycle, 0) WHEN 0 THEN 0 ELSE((CONVERT(FLOAT,DATEDIFF(SECOND, PRD.StartTime, PRD.EndTime)) / 60) * ((60 / CONVERT(FLOAT, ISNULL(PRD.WorkingCycle, 0))) * PRD.NumberPerCycle)) END, 0)) AS TheoreticalOutput,
	-- ActualQuantity = SUM(ActualQuantity)
	SUM(ISNULL(PRD.ActualQuantity, 0)) AS ActualQuantity,
	-- ScrapParts = SUM(DefeactQuanity)
	(SUM(ISNULL(TMP_QC.DefeactQuanity, 0))) AS ScrapParts, 
	-- ScrapRate = SUM(DefeactQuanity) / SUM(CheckQuantity)
	CASE SUM(ISNULL(TMP_QC.CheckQuantity,0)) WHEN 0 THEN 0 ELSE (SUM(ISNULL(TMP_QC.DefeactQuanity, 0)) / SUM(ISNULL(TMP_QC.CheckQuantity,0))) END AS ScrapRate,
	-- TotalWorkingTime = SUM(StartTime - EndTime)
	SUM(CASE PRD.StartTime + PRD.EndTime WHEN NULL THEN 0 ELSE CONVERT(FLOAT, (DATEDIFF(SECOND, PRD.StartTime, PRD.EndTime))) END / 60) AS TotalWorkingTime,
	-- AvailableRunningTime = COUNT(DISTINCT MS_MAY) * (24)
    ((SELECT COUNT(DISTINCT MS_MAY) FROM dbo.ProductionRunDetails WHERE CONVERT(DATE, StartTime) = CONVERT(DATE, #N.NGAY)) * (24)) AS AvailableRunningTime,
	-- Performance = ActualQuantity / TheoreticalOutput 
	(CASE (SUM(ISNULL(CASE ISNULL(PRD.WorkingCycle, 0) WHEN 0 THEN 0 ELSE((CONVERT(FLOAT, DATEDIFF(SECOND, PRD.StartTime, PRD.EndTime)) / 60) * ((60 / CONVERT(FLOAT, ISNULL(PRD.WorkingCycle, 0))) * PRD.NumberPerCycle)) END, 0))) WHEN 0 THEN 0 ELSE SUM(ISNULL(PRD.ActualQuantity, 0)) / SUM(ISNULL(CASE ISNULL(PRD.WorkingCycle, 0) WHEN 0 THEN 0 ELSE((CONVERT(FLOAT, DATEDIFF(SECOND, PRD.StartTime, PRD.EndTime)) / 60) * ((60 / CONVERT(FLOAT, ISNULL(PRD.WorkingCycle, 0))) * PRD.NumberPerCycle)) END, 0)) END) AS Performance,
	(SUM(ISNULL(PRD.ActualQuantity, 0)) * SUM(ISNULL(IM.Consumption, 0))) AS StandardLabor
	INTO #T1
	FROM #NGAY #N 
	LEFT JOIN dbo.ProductionRunDetails PRD ON CONVERT(DATE, PRD.StartTime) = CONVERT(DATE, #N.NGAY) AND PRD.MS_MAY IN (SELECT MS_MAY FROM #MS_MAY)
	LEFT JOIN dbo.ItemMay IM ON IM.MS_MAY = PRD.MS_MAY AND IM.ItemID = PRD.ItemID
	LEFT JOIN (	SELECT SUM(T1.CheckQuantity) AS CheckQuantity, SUM(T1.DefeactQuanity) AS DefeactQuanity, T1.PrOID, T1.ItemID, T1.ID_CA,												T1.ProductionDate, T1.MS_MAY
				FROM (	SELECT ISNULL(B.CheckQuantity, 0) AS CheckQuantity,SUM(ISNULL(C.DefeactQuanity, 0)) AS DefeactQuanity, A.ID, A.ID_CA, CONVERT(DATE,						A.ProductionDate) AS ProductionDate, B.PrOID, B.ItemID, B.MS_MAY
						FROM dbo.QCData A
						LEFT JOIN dbo.QCDataDetails B ON B.ID_QC = A.ID
						LEFT JOIN  dbo.QCDataDefect C ON C.QCDataDetailsID = B.ID
						WHERE A.CheckStepID = 1
						GROUP BY  A.ID, ProductionDate, A.ID_CA, B.CheckQuantity, B.PrOID, B.ItemID, B.MS_MAY) T1 
				GROUP BY  T1.PrOID, T1.ProductionDate, T1.ItemID, T1.ID_CA, T1.MS_MAY) TMP_QC ON TMP_QC.ID_CA = PRD.ID_CA AND TMP_QC.ItemID = PRD.ItemID AND TMP_QC.MS_MAY = PRD.MS_MAY AND TMP_QC.PrOID = PRD.PrOID AND CONVERT(DATE, TMP_QC.ProductionDate) = CONVERT(DATE,PRD.StartTime)
	LEFT JOIN (	SELECT SUM(T1.CheckQuantity) AS CheckQuantity, SUM(T1.DefeactQuanity) AS DefeactQuanity, T1.PrOID, T1.ItemID, T1.ID_CA,												T1.ProductionDate, T1.MS_MAY
				FROM (	SELECT ISNULL(B.CheckQuantity, 0) AS CheckQuantity,SUM(ISNULL(C.DefeactQuanity, 0)) AS DefeactQuanity, A.ID, A.ID_CA, CONVERT(DATE,						A.ProductionDate) AS ProductionDate, B.PrOID, B.ItemID, B.MS_MAY
						FROM dbo.QCData A
						LEFT JOIN dbo.QCDataDetails B ON B.ID_QC = A.ID
						LEFT JOIN  dbo.QCDataDefect C ON C.QCDataDetailsID = B.ID
						WHERE A.CheckStepID = 2
						GROUP BY  A.ID, ProductionDate, A.ID_CA, B.CheckQuantity, B.PrOID, B.ItemID, B.MS_MAY) T1 
				GROUP BY  T1.PrOID, T1.ProductionDate, T1.ItemID, T1.ID_CA, T1.MS_MAY) TMP_QC1 ON TMP_QC1.ID_CA = PRD.ID_CA AND TMP_QC1.ItemID = PRD.ItemID AND TMP_QC1.MS_MAY = PRD.MS_MAY AND TMP_QC1.PrOID = PRD.PrOID AND CONVERT(DATE, TMP_QC1.ProductionDate) = CONVERT(DATE,PRD.StartTime)
	LEFT JOIN dbo.CA ON CA.STT = PRD.ID_CA
	LEFT JOIN dbo.SHIFT_LEADER SL ON SL.ID_CA = CA.STT AND CONVERT(DATE, SL.NGAY) = CONVERT(DATE, #N.NGAY)
	WHERE (PRD.ID_CA = @ID_CA OR @ID_CA = -1) AND (SL.ID_Operator = @ShiftLeader OR @ShiftLeader = -1) 
	GROUP BY #N.NGAY

	-- Warm Up Time
	SELECT N.NGAY, SUM(ISNULL(TGDM_WU.THOI_GIAN_SUA, 0)) AS WarmUpTime
	INTO #T2
	FROM #NGAY N 
	LEFT JOIN dbo.THOI_GIAN_DUNG_MAY TGDM_WU ON CONVERT(DATE, TGDM_WU.NGAY_DUNG) = CONVERT(DATE, N.NGAY)
	LEFT JOIN dbo.NGUYEN_NHAN_DUNG_MAY NNDM_WU ON NNDM_WU.MS_NGUYEN_NHAN = TGDM_WU.MS_NGUYEN_NHAN 
	LEFT JOIN dbo.CA ON CA.STT = TGDM_WU.CaID
	LEFT JOIN dbo.SHIFT_LEADER SL ON SL.ID_CA = CA.STT AND CONVERT(DATE, SL.NGAY) = CONVERT(DATE, N.NGAY)
	WHERE NNDM_WU.DownTimeTypeID = 22 AND (TGDM_WU.CaID = @ID_CA OR @ID_CA = -1) AND (SL.ID_Operator = @ShiftLeader OR @ShiftLeader = -1) AND TGDM_WU.MS_MAY IN (SELECT MS_MAY FROM #MS_MAY)
	GROUP BY N.NGAY
	
	-- Change Over
	SELECT N.NGAY, SUM(ISNULL(TGDM_CO.THOI_GIAN_SUA, 0)) AS ChangeOverTime
	INTO #T3
	FROM #NGAY N 
	LEFT JOIN dbo.THOI_GIAN_DUNG_MAY TGDM_CO ON CONVERT(DATE, TGDM_CO.NGAY_DUNG) = CONVERT(DATE, N.NGAY) 
	LEFT JOIN dbo.NGUYEN_NHAN_DUNG_MAY NNDM_CO ON NNDM_CO.MS_NGUYEN_NHAN = TGDM_CO.MS_NGUYEN_NHAN 
	LEFT JOIN dbo.CA ON CA.STT = TGDM_CO.CaID
	LEFT JOIN dbo.SHIFT_LEADER SL ON SL.ID_CA = CA.STT AND CONVERT(DATE, SL.NGAY) = CONVERT(DATE, N.NGAY)
	WHERE NNDM_CO.DownTimeTypeID = 21 AND (TGDM_CO.CaID = @ID_CA OR @ID_CA = -1) AND (SL.ID_Operator = @ShiftLeader OR @ShiftLeader = -1) AND TGDM_CO.MS_MAY IN (SELECT MS_MAY FROM #MS_MAY)
	GROUP BY N.NGAY

	--No Change Over
	SELECT N.NGAY, COUNT(TGDM_CO.THOI_GIAN_SUA) AS NoChangeOver
	INTO #T3#1
	FROM #NGAY N 
	LEFT JOIN dbo.THOI_GIAN_DUNG_MAY TGDM_CO ON CONVERT(DATE, TGDM_CO.NGAY_DUNG) = CONVERT(DATE, N.NGAY) 
	LEFT JOIN dbo.NGUYEN_NHAN_DUNG_MAY NNDM_CO ON NNDM_CO.MS_NGUYEN_NHAN = TGDM_CO.MS_NGUYEN_NHAN 
	LEFT JOIN dbo.CA ON CA.STT = TGDM_CO.CaID
	LEFT JOIN dbo.SHIFT_LEADER SL ON SL.ID_CA = CA.STT AND CONVERT(DATE, SL.NGAY) = CONVERT(DATE, N.NGAY)
	WHERE NNDM_CO.DownTimeTypeID = 21 AND (TGDM_CO.CaID = @ID_CA OR @ID_CA = -1) AND (SL.ID_Operator = @ShiftLeader OR @ShiftLeader = -1) AND TGDM_CO.MS_MAY IN (SELECT MS_MAY FROM #MS_MAY) AND ISNULL(TGDM_CO.ID_CHA, 0) = 0
	GROUP BY N.NGAY

	-- Stop End Of Week
	SELECT N.NGAY, SUM(ISNULL(TGDM_SEOW.THOI_GIAN_SUA, 0)) AS StopEndOfWeekTime
	INTO #T4
	FROM #NGAY N 
	LEFT JOIN dbo.THOI_GIAN_DUNG_MAY TGDM_SEOW ON CONVERT(DATE, TGDM_SEOW.NGAY_DUNG) = CONVERT(DATE, N.NGAY)
	LEFT JOIN dbo.NGUYEN_NHAN_DUNG_MAY NNDM_SEOW ON NNDM_SEOW.MS_NGUYEN_NHAN = TGDM_SEOW.MS_NGUYEN_NHAN 
	LEFT JOIN dbo.CA ON CA.STT = TGDM_SEOW.CaID
	LEFT JOIN dbo.SHIFT_LEADER SL ON SL.ID_CA = CA.STT AND CONVERT(DATE, SL.NGAY) = CONVERT(DATE, N.NGAY)
	WHERE  NNDM_SEOW.DownTimeTypeID = 25 AND (TGDM_SEOW.CaID = @ID_CA OR @ID_CA = -1) AND (SL.ID_Operator = @ShiftLeader OR @ShiftLeader = -1) AND TGDM_SEOW.MS_MAY IN (SELECT MS_MAY FROM #MS_MAY)
	GROUP BY N.NGAY

	-- Unplaned DownTime
	SELECT N.NGAY, SUM(ISNULL(TGDM_UD.THOI_GIAN_SUA, 0)) AS UnplannedDownTime
	INTO #T5
	FROM #NGAY N 
	LEFT JOIN dbo.THOI_GIAN_DUNG_MAY TGDM_UD ON CONVERT(DATE, TGDM_UD.NGAY_DUNG) = CONVERT(DATE, N.NGAY)
	LEFT JOIN dbo.NGUYEN_NHAN_DUNG_MAY NNDM_UD ON NNDM_UD.MS_NGUYEN_NHAN = TGDM_UD.MS_NGUYEN_NHAN
	LEFT JOIN dbo.DownTimeType DT_UD ON DT_UD.ID_DownTime = NNDM_UD.DownTimeTypeID 
	LEFT JOIN dbo.CA ON CA.STT = TGDM_UD.CaID
	LEFT JOIN dbo.SHIFT_LEADER SL ON SL.ID_CA = CA.STT AND CONVERT(DATE, SL.NGAY) = CONVERT(DATE, N.NGAY)
	WHERE (TGDM_UD.CaID = @ID_CA OR @ID_CA = -1) AND (SL.ID_Operator = @ShiftLeader OR @ShiftLeader = -1) AND TGDM_UD.MS_MAY IN (SELECT MS_MAY FROM #MS_MAY) AND ISNULL(DT_UD.Planned, 0) = 0
	GROUP BY N.NGAY

	--No Unplaned DownTime
	SELECT N.NGAY, COUNT(TGDM_UD.THOI_GIAN_SUA) AS NoUnplannedDownTime
	INTO #T5#1
	FROM #NGAY N 
	LEFT JOIN dbo.THOI_GIAN_DUNG_MAY TGDM_UD ON CONVERT(DATE, TGDM_UD.NGAY_DUNG) = CONVERT(DATE, N.NGAY)
	LEFT JOIN dbo.NGUYEN_NHAN_DUNG_MAY NNDM_UD ON NNDM_UD.MS_NGUYEN_NHAN = TGDM_UD.MS_NGUYEN_NHAN
	LEFT JOIN dbo.DownTimeType DT_UD ON DT_UD.ID_DownTime = NNDM_UD.DownTimeTypeID 
	LEFT JOIN dbo.CA ON CA.STT = TGDM_UD.CaID
	LEFT JOIN dbo.SHIFT_LEADER SL ON SL.ID_CA = CA.STT AND CONVERT(DATE, SL.NGAY) = CONVERT(DATE, N.NGAY)
	WHERE (TGDM_UD.CaID = @ID_CA OR @ID_CA = -1) AND (SL.ID_Operator = @ShiftLeader OR @ShiftLeader = -1) AND TGDM_UD.MS_MAY IN (SELECT MS_MAY FROM #MS_MAY) AND ISNULL(DT_UD.Planned, 0) = 0 AND ISNULL(TGDM_UD.ID_CHA, 0) = 0
	GROUP BY N.NGAY

	-- Planed DownTime
	SELECT N.NGAY, SUM(ISNULL(TGDM_PD.THOI_GIAN_SUA, 0)) AS PlannedDownTime
	INTO #T6
	FROM #NGAY N 
	LEFT JOIN dbo.THOI_GIAN_DUNG_MAY TGDM_PD ON CONVERT(DATE, TGDM_PD.NGAY_DUNG) = CONVERT(DATE, N.NGAY)
	LEFT JOIN dbo.NGUYEN_NHAN_DUNG_MAY NNDM_UD ON NNDM_UD.MS_NGUYEN_NHAN = TGDM_PD.MS_NGUYEN_NHAN
	LEFT JOIN dbo.DownTimeType DT_UD ON DT_UD.ID_DownTime = NNDM_UD.DownTimeTypeID 
	LEFT JOIN dbo.CA ON CA.STT = TGDM_PD.CaID
	LEFT JOIN dbo.SHIFT_LEADER SL ON SL.ID_CA = CA.STT AND CONVERT(DATE, SL.NGAY) = CONVERT(DATE, N.NGAY)
	WHERE (TGDM_PD.CaID = @ID_CA OR @ID_CA = -1) AND (SL.ID_Operator = @ShiftLeader OR @ShiftLeader = -1) AND TGDM_PD.MS_MAY IN (SELECT MS_MAY FROM #MS_MAY) AND ISNULL(DT_UD.Planned, 1) = 1 
	GROUP BY N.NGAY

	--No Planed DownTime
	SELECT N.NGAY, COUNT(TGDM_PD.THOI_GIAN_SUA) AS NoPlannedDownTime
	INTO #T6#1
	FROM #NGAY N 
	LEFT JOIN dbo.THOI_GIAN_DUNG_MAY TGDM_PD ON CONVERT(DATE, TGDM_PD.NGAY_DUNG) = CONVERT(DATE, N.NGAY)
	LEFT JOIN dbo.NGUYEN_NHAN_DUNG_MAY NNDM_UD ON NNDM_UD.MS_NGUYEN_NHAN = TGDM_PD.MS_NGUYEN_NHAN
	LEFT JOIN dbo.DownTimeType DT_UD ON DT_UD.ID_DownTime = NNDM_UD.DownTimeTypeID 
	LEFT JOIN dbo.CA ON CA.STT = TGDM_PD.CaID
	LEFT JOIN dbo.SHIFT_LEADER SL ON SL.ID_CA = CA.STT AND CONVERT(DATE, SL.NGAY) = CONVERT(DATE, N.NGAY)
	WHERE (TGDM_PD.CaID = @ID_CA OR @ID_CA = -1) AND (SL.ID_Operator = @ShiftLeader OR @ShiftLeader = -1) AND TGDM_PD.MS_MAY IN (SELECT MS_MAY FROM #MS_MAY) AND ISNULL(DT_UD.Planned, 1) = 1 AND ISNULL(TGDM_PD.ID_CHA, 0) = 0
	GROUP BY N.NGAY

	-- Total Down Time
	SELECT N.NGAY, SUM(ISNULL(TGDM_T.THOI_GIAN_SUA, 0)) AS TotalDownTime
	INTO #T7
	FROM #NGAY N 
	LEFT JOIN dbo.THOI_GIAN_DUNG_MAY TGDM_T ON CONVERT(DATE, TGDM_T.NGAY_DUNG) = CONVERT(DATE, N.NGAY)
	LEFT JOIN dbo.CA ON CA.STT = TGDM_T.CaID
	LEFT JOIN dbo.SHIFT_LEADER SL ON SL.ID_CA = CA.STT AND CONVERT(DATE, SL.NGAY) = CONVERT(DATE, N.NGAY)
	WHERE (TGDM_T.CaID = @ID_CA OR @ID_CA = -1) AND (SL.ID_Operator = @ShiftLeader OR @ShiftLeader = -1) AND TGDM_T.MS_MAY IN (SELECT MS_MAY FROM #MS_MAY)
	GROUP BY N.NGAY

	SELECT #T1.NGAY, TheoreticalOutput, ActualQuantity, ScrapParts, ScrapRate, WarmUpTime, NoUnplannedDownTime, UnplannedDownTime, NoPlannedDownTime, PlannedDownTime, NoChangeOver, ChangeOverTime, StopEndOfWeekTime, TotalDownTime, 
	CASE (ISNULL(TotalWorkingTime, 0) - ISNULL(PlannedDownTime, 0)) WHEN 0 THEN 0 ELSE ((ISNULL(TotalWorkingTime, 0) - ISNULL(TotalDownTime, 0)) / (ISNULL(TotalWorkingTime, 0) - ISNULL(PlannedDownTime, 0))) END AS OEE, AvailableRunningTime, 
	(CONVERT(FLOAT, (ISNULL(TotalWorkingTime, 0) - ISNULL(TotalDownTime, 0))) / 60) AS RunningTime, (Performance * 100) AS Performance, (StandardLabor / 60) AS StandardLabor, ISNULL(A.ACTUAL_LABOR, 0) AS ActualLabor
	INTO #TMP_CHUNG
	FROM #T1 
	LEFT JOIN #T2 ON #T2.NGAY = #T1.NGAY
	LEFT JOIN #T3 ON #T3.NGAY = #T1.NGAY
	LEFT JOIN #T3#1 ON #T3#1.NGAY = #T1.NGAY
	LEFT JOIN #T4 ON #T4.NGAY = #T1.NGAY
	LEFT JOIN #T5 ON #T5.NGAY = #T1.NGAY
	LEFT JOIN #T5#1 ON #T5#1.NGAY = #T1.NGAY
	LEFT JOIN #T6 ON #T6.NGAY = #T1.NGAY
	LEFT JOIN #T6#1 ON #T6#1.NGAY = #T1.NGAY
	LEFT JOIN #T7 ON #T7.NGAY = #T1.NGAY
	LEFT JOIN dbo.ACTUAL_LABOR A ON A.NGAY = #T1.NGAY
	ORDER BY #T1.NGAY

	-- Chuyen sang table ngang
	DECLARE @sSql NVARCHAR(MAX)
	DECLARE @sSqlSelect NVARCHAR(MAX) = ''
	DECLARE @sSql_Result NVARCHAR(MAX) = ''
	DECLARE @sSql_Result1 NVARCHAR(MAX) = ''
	--DECLARE @TNgay DATE = CONVERT(DATE, '2022-01-02')
	--DECLARE @DNgay DATE = CONVERT(DATE, '2022-01-08')
	--DECLARE @NNgu INT = 0
	--DECLARE @FormName NVARCHAR(100) = 'ucBaocaoMoldingWeekly'

	SET @sSql = ''
	SET @sSqlSelect = ''
	SELECT @sSql = COALESCE(ISNULL(@sSql,'') + CASE LEN(@sSql) WHEN 0 THEN '' ELSE ',' END , '') + ISNULL(NGAY,''), @sSqlSelect = COALESCE(ISNULL(@sSqlSelect,'') + CASE LEN(@sSqlSelect) WHEN 0 THEN '' ELSE ',' END , '') + ' CASE ' + NGAY + ' WHEN 0 THEN NULL ELSE ' + NGAY + ' END AS '  + NGAY
	FROM 
	(
		SELECT DISTINCT number,
		N' [' +CONVERT(NVARCHAR(10), DATEADD(day,number,@TNgay),103)+N']'  AS NGAY
			from master.dbo.spt_values WHERE number between 0 and 1000 AND DATEADD(day,number,@TNgay) <= @DNgay
	) T1

	SET @sSql_Result = '
	SELECT * FROM (
	SELECT CONVERT(NVARCHAR(10), NGAY, 103) AS NGAY, 1 AS ID_Result, (SELECT TOP 1 CASE ' + CONVERT(NVARCHAR, @NNgu) + ' WHEN 0 THEN VIETNAM WHEN 1 THEN ISNULL(NULLIF(ENGLISH, ''), VIETNAM) ELSE ISNULL(NULLIF(CHINESE, ''), VIETNAM) END AS Name_Result FROM dbo.LANGUAGES WHERE FORM = ''' + @FormName + ''' AND KEYWORD = ''TheoreticalOutput'') AS Name_Result, ISNULL(TheoreticalOutput,0) AS Result FROM #TMP_CHUNG
	UNION
	SELECT CONVERT(NVARCHAR(10), NGAY, 103) AS NGAY, 2 AS ID_Result, (SELECT TOP 1 CASE ' + CONVERT(NVARCHAR, @NNgu) + ' WHEN 0 THEN VIETNAM WHEN 1 THEN ISNULL(NULLIF(ENGLISH, ''), VIETNAM) ELSE ISNULL(NULLIF(CHINESE, ''), VIETNAM) END AS Name_Result FROM dbo.LANGUAGES WHERE FORM = ''' + @FormName + ''' AND KEYWORD = ''ActualQuantity'') AS Name_Result, ISNULL(ActualQuantity,0) AS Result FROM #TMP_CHUNG
	UNION
	SELECT CONVERT(NVARCHAR(10), NGAY, 103) AS NGAY, 3 AS ID_Result, (SELECT TOP 1 CASE ' + CONVERT(NVARCHAR, @NNgu) + ' WHEN 0 THEN VIETNAM WHEN 1 THEN ISNULL(NULLIF(ENGLISH, ''), VIETNAM) ELSE ISNULL(NULLIF(CHINESE, ''), VIETNAM) END AS Name_Result FROM dbo.LANGUAGES WHERE FORM = ''' + @FormName + ''' AND KEYWORD = ''ScrapParts'') AS Name_Result, ISNULL(ScrapParts,0) AS Result FROM #TMP_CHUNG
	UNION
	SELECT CONVERT(NVARCHAR(10), NGAY, 103) AS NGAY, 4 AS ID_Result, (SELECT TOP 1 CASE ' + CONVERT(NVARCHAR, @NNgu) + ' WHEN 0 THEN VIETNAM WHEN 1 THEN ISNULL(NULLIF(ENGLISH, ''), VIETNAM) ELSE ISNULL(NULLIF(CHINESE, ''), VIETNAM) END AS Name_Result FROM dbo.LANGUAGES WHERE FORM = ''' + @FormName + ''' AND KEYWORD = ''ScrapRate'') AS Name_Result, ISNULL(ScrapRate,0) AS Result FROM #TMP_CHUNG
	UNION
	SELECT CONVERT(NVARCHAR(10), NGAY, 103) AS NGAY, 5 AS ID_Result, (SELECT TOP 1 CASE ' + CONVERT(NVARCHAR, @NNgu) + ' WHEN 0 THEN VIETNAM WHEN 1 THEN ISNULL(NULLIF(ENGLISH, ''), VIETNAM) ELSE ISNULL(NULLIF(CHINESE, ''), VIETNAM) END AS Name_Result FROM dbo.LANGUAGES WHERE FORM = ''' + @FormName + ''' AND KEYWORD = ''WarmUpTime'') AS Name_Result, ISNULL(WarmUpTime,0) AS Result FROM #TMP_CHUNG
	UNION
	SELECT CONVERT(NVARCHAR(10), NGAY, 103) AS NGAY, 6 AS ID_Result, (SELECT TOP 1 CASE ' + CONVERT(NVARCHAR, @NNgu) + ' WHEN 0 THEN VIETNAM WHEN 1 THEN ISNULL(NULLIF(ENGLISH, ''), VIETNAM) ELSE ISNULL(NULLIF(CHINESE, ''), VIETNAM) END AS Name_Result FROM dbo.LANGUAGES WHERE FORM = ''' + @FormName + ''' AND KEYWORD = ''NoUnplannedDownTime'') AS Name_Result, ISNULL(NoUnplannedDownTime,0) AS Result FROM #TMP_CHUNG
	UNION
	SELECT CONVERT(NVARCHAR(10), NGAY, 103) AS NGAY, 7 AS ID_Result, (SELECT TOP 1 CASE ' + CONVERT(NVARCHAR, @NNgu) + ' WHEN 0 THEN VIETNAM WHEN 1 THEN ISNULL(NULLIF(ENGLISH, ''), VIETNAM) ELSE ISNULL(NULLIF(CHINESE, ''), VIETNAM) END AS Name_Result FROM dbo.LANGUAGES WHERE FORM = ''' + @FormName + ''' AND KEYWORD = ''UnplannedDownTime'') AS Name_Result, ISNULL(UnplannedDownTime,0) AS Result FROM #TMP_CHUNG
	UNION
	SELECT CONVERT(NVARCHAR(10), NGAY, 103) AS NGAY, 8 AS ID_Result, (SELECT TOP 1 CASE ' + CONVERT(NVARCHAR, @NNgu) + ' WHEN 0 THEN VIETNAM WHEN 1 THEN ISNULL(NULLIF(ENGLISH, ''), VIETNAM) ELSE ISNULL(NULLIF(CHINESE, ''), VIETNAM) END AS Name_Result FROM dbo.LANGUAGES WHERE FORM = ''' + @FormName + ''' AND KEYWORD = ''NoPlannedDownTime'') AS Name_Result, ISNULL(NoPlannedDownTime,0) AS Result FROM #TMP_CHUNG
	UNION
	SELECT CONVERT(NVARCHAR(10), NGAY, 103) AS NGAY, 9 AS ID_Result, (SELECT TOP 1 CASE ' + CONVERT(NVARCHAR, @NNgu) + ' WHEN 0 THEN VIETNAM WHEN 1 THEN ISNULL(NULLIF(ENGLISH, ''), VIETNAM) ELSE ISNULL(NULLIF(CHINESE, ''), VIETNAM) END AS Name_Result FROM dbo.LANGUAGES WHERE FORM = ''' + @FormName + ''' AND KEYWORD = ''PlannedDownTime'') AS Name_Result, ISNULL(PlannedDownTime,0) AS Result FROM #TMP_CHUNG
	UNION'

	SET @sSql_Result1 = '
	SELECT CONVERT(NVARCHAR(10), NGAY, 103) AS NGAY, 10 AS ID_Result, (SELECT TOP 1 CASE ' + CONVERT(NVARCHAR, @NNgu) + ' WHEN 0 THEN VIETNAM WHEN 1 THEN ISNULL(NULLIF(ENGLISH, ''), VIETNAM) ELSE ISNULL(NULLIF(CHINESE, ''), VIETNAM) END AS Name_Result FROM dbo.LANGUAGES WHERE FORM = ''' + @FormName + ''' AND KEYWORD = ''NoChangeOver'') AS Name_Result, ISNULL(NoChangeOver,0) AS Result FROM #TMP_CHUNG
	UNION
	SELECT CONVERT(NVARCHAR(10), NGAY, 103) AS NGAY, 11 AS ID_Result, (SELECT TOP 1 CASE ' + CONVERT(NVARCHAR, @NNgu) + ' WHEN 0 THEN VIETNAM WHEN 1 THEN ISNULL(NULLIF(ENGLISH, ''), VIETNAM) ELSE ISNULL(NULLIF(CHINESE, ''), VIETNAM) END AS Name_Result FROM dbo.LANGUAGES WHERE FORM = ''' + @FormName + ''' AND KEYWORD = ''ChangeOverTime'') AS Name_Result, ISNULL(ChangeOverTime,0) AS Result FROM #TMP_CHUNG
	UNION
	SELECT CONVERT(NVARCHAR(10), NGAY, 103) AS NGAY, 12 AS ID_Result, (SELECT TOP 1 CASE ' + CONVERT(NVARCHAR, @NNgu) + ' WHEN 0 THEN VIETNAM WHEN 1 THEN ISNULL(NULLIF(ENGLISH, ''), VIETNAM) ELSE ISNULL(NULLIF(CHINESE, ''), VIETNAM) END AS Name_Result FROM dbo.LANGUAGES WHERE FORM = ''' + @FormName + ''' AND KEYWORD = ''StopEndOfWeekTime'') AS Name_Result, ISNULL(StopEndOfWeekTime,0) AS Result FROM #TMP_CHUNG
	UNION
	SELECT CONVERT(NVARCHAR(10), NGAY, 103) AS NGAY, 13 AS ID_Result, (SELECT TOP 1 CASE ' + CONVERT(NVARCHAR, @NNgu) + ' WHEN 0 THEN VIETNAM WHEN 1 THEN ISNULL(NULLIF(ENGLISH, ''), VIETNAM) ELSE ISNULL(NULLIF(CHINESE, ''), VIETNAM) END AS Name_Result FROM dbo.LANGUAGES WHERE FORM = ''' + @FormName + ''' AND KEYWORD = ''TotalDownTime'') AS Name_Result, ISNULL(TotalDownTime,0) AS Result FROM #TMP_CHUNG
	UNION
	SELECT CONVERT(NVARCHAR(10), NGAY, 103) AS NGAY, 14 AS ID_Result, (SELECT TOP 1 CASE ' + CONVERT(NVARCHAR, @NNgu) + ' WHEN 0 THEN VIETNAM WHEN 1 THEN ISNULL(NULLIF(ENGLISH, ''), VIETNAM) ELSE ISNULL(NULLIF(CHINESE, ''), VIETNAM) END AS Name_Result FROM dbo.LANGUAGES WHERE FORM = ''' + @FormName + ''' AND KEYWORD = ''OEE'') AS Name_Result, ISNULL(OEE,0) AS Result FROM #TMP_CHUNG
	UNION
	SELECT CONVERT(NVARCHAR(10), NGAY, 103) AS NGAY, 15 AS ID_Result, (SELECT TOP 1 CASE ' + CONVERT(NVARCHAR, @NNgu) + ' WHEN 0 THEN VIETNAM WHEN 1 THEN ISNULL(NULLIF(ENGLISH, ''), VIETNAM) ELSE ISNULL(NULLIF(CHINESE, ''), VIETNAM) END AS Name_Result FROM dbo.LANGUAGES WHERE FORM = ''' + @FormName + ''' AND KEYWORD = ''AvailableRunningTime'') AS Name_Result, ISNULL(AvailableRunningTime,0) AS Result FROM #TMP_CHUNG
	UNION
	SELECT CONVERT(NVARCHAR(10), NGAY, 103) AS NGAY, 16 AS ID_Result, (SELECT TOP 1 CASE ' + CONVERT(NVARCHAR, @NNgu) + ' WHEN 0 THEN VIETNAM WHEN 1 THEN ISNULL(NULLIF(ENGLISH, ''), VIETNAM) ELSE ISNULL(NULLIF(CHINESE, ''), VIETNAM) END AS Name_Result FROM dbo.LANGUAGES WHERE FORM = ''' + @FormName + ''' AND KEYWORD = ''RunningTime'') AS Name_Result, ISNULL(RunningTime,0) AS Result FROM #TMP_CHUNG
	UNION
	SELECT CONVERT(NVARCHAR(10), NGAY, 103) AS NGAY, 17 AS ID_Result, (SELECT TOP 1 CASE ' + CONVERT(NVARCHAR, @NNgu) + ' WHEN 0 THEN VIETNAM WHEN 1 THEN ISNULL(NULLIF(ENGLISH, ''), VIETNAM) ELSE ISNULL(NULLIF(CHINESE, ''), VIETNAM) END AS Name_Result FROM dbo.LANGUAGES WHERE FORM = ''' + @FormName + ''' AND KEYWORD = ''Performance'') AS Name_Result, ISNULL(Performance,0) AS Result FROM #TMP_CHUNG
	UNION
	SELECT CONVERT(NVARCHAR(10), NGAY, 103) AS NGAY, 18 AS ID_Result, (SELECT TOP 1 CASE ' + CONVERT(NVARCHAR, @NNgu) + ' WHEN 0 THEN VIETNAM WHEN 1 THEN ISNULL(NULLIF(ENGLISH, ''), VIETNAM) ELSE ISNULL(NULLIF(CHINESE, ''), VIETNAM) END AS Name_Result FROM dbo.LANGUAGES WHERE FORM = ''' + @FormName + ''' AND KEYWORD = ''StandardLabor'') AS Name_Result, ISNULL(StandardLabor,0) AS Result FROM #TMP_CHUNG
	UNION
	SELECT CONVERT(NVARCHAR(10), NGAY, 103) AS NGAY, 19 AS ID_Result, (SELECT TOP 1 CASE ' + CONVERT(NVARCHAR, @NNgu) + ' WHEN 0 THEN VIETNAM WHEN 1 THEN ISNULL(NULLIF(ENGLISH, ''), VIETNAM) ELSE ISNULL(NULLIF(CHINESE, ''), VIETNAM) END AS Name_Result FROM dbo.LANGUAGES WHERE FORM = ''' + @FormName + ''' AND KEYWORD = ''ActualLabor'') AS Name_Result, ISNULL(ActualLabor,0) AS Result FROM #TMP_CHUNG
	) src 
	PIVOT ( SUM(Result) FOR NGAY IN (' + @sSql + ')) piv
	ORDER BY piv.ID_Result'
	EXEC(@sSql_Result + @sSql_Result1) 



END
