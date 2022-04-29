

ALTER proc [dbo].[spGetBaoCaoThoiGianChayMay]
	@MS_MAY nvarchar(30) ='IMM-01',
	@TNgay DATETIME = '2022-04-18 10:20:19.323',
	@DNgay DATETIME ='2022-04-18 10:20:19.323',
	@USERNAME  nvarchar(50) ='admin',
	@NNgu INT = 0
AS
begin
	SELECT T1.MS_MAY,CONVERT(DECIMAL(18,2),T1.TongTG/60.0) AS TongTG,CONVERT(DECIMAL(18,2),T1.TGNgung/60)AS TGNgung
	INTO #TMP
	FROM (
	SELECT T.MS_MAY,T.TongTG,((SELECT ISNULL(SUM(THOI_GIAN_SUA_CHUA),0) FROM dbo.THOI_GIAN_DUNG_MAY WHERE MS_MAY = T.MS_MAY AND TU_GIO >= MIN(T.StartTime) AND DEN_GIO <= MAX(T.EndTime))) AS TGNgung
	FROM (
	SELECT dbo.fnGetNgayTheoCa(MIN(StartTime)) AS NGAY,MS_MAY,MIN(StartTime) StartTime,MAX(EndTime) EndTime, (DATEDIFF(SECOND,MIN(StartTime),MAX(EndTime))/ 60.0) AS TongTG
	FROM dbo.ProductionRunDetails
	WHERE dbo.fnGetNgayTheoCa(StartTime) BETWEEN CONVERT(DATE,@TNgay) AND CONVERT(DATE,@DNgay)
	 GROUP BY MS_MAY)T
	GROUP BY T.MS_MAY,T.TongTG
	)T1 GROUP BY T1.MS_MAY,T1.TongTG,T1.TGNgung 
	ORDER BY T1.MS_MAY
	SELECT A.MS_MAY,
					ISNULL(B.TGNgung,0) AS TGNgung,
					ISNULL(B.TongTG,0) - ISNULL(B.TGNgung,0) AS TGChay,
					((DATEDIFF(DAY,@TNgay,@DNgay) + 1) * 24.0) -ISNULL(B.TongTG,0) AS TGKSX,
                    ((DATEDIFF(DAY,@TNgay,@DNgay) + 1) * 24.0) AS TongTG
                     FROM dbo.MAY A
	LEFT JOIN #TMP B ON B.MS_MAY = A.MS_MAY
	ORDER BY A.MS_MAY
END


