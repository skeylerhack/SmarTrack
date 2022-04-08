DECLARE @Resulst DECIMAL(18,2);
	declare @Dowtime DECIMAL(18,2);/*thời gian ngừng*/
	DECLARE @Runtime DECIMAL(18,2);

	DECLARE @TuNgay DATETIME;
	DECLARE @DenNgay DATETIME;
	DECLARE @MS_MAY NVARCHAR(30)


	SELECT @Runtime = CONVERT(DECIMAL(18,2),SUM(DATEDIFF(SECOND,B.StartTime,B.EndTime))/60.0), @TuNgay = MIN(B.StartTime),@DenNgay =  MAX(B.EndTime),@MS_MAY = B.MS_MAY FROM dbo.ProductionRun A
	INNER JOIN dbo.ProductionRunDetails B ON B.ProductionRunID = A.ID
	WHERE B.DetailID = 3701
	GROUP BY B.MS_MAY
	--cách tính 1 : Planned production time - không tính OEE
	
	SET @Dowtime =(SELECT SUM(A.THOI_GIAN_SUA_CHUA) AS SO_PHUT FROM dbo.THOI_GIAN_DUNG_MAY A
	INNER JOIN dbo.NGUYEN_NHAN_DUNG_MAY B ON B.MS_NGUYEN_NHAN = A.MS_NGUYEN_NHAN
	INNER JOIN dbo.DownTimeType C ON C.ID_DownTime = B.DownTimeTypeID
	WHERE (A.TU_GIO BETWEEN @TuNgay AND @DenNgay) AND (A.DEN_GIO BETWEEN @TuNgay AND @DenNgay) AND B.OEE = 0 AND MS_MAY = @MS_MAY)
	
	SET @Resulst = CONVERT(DECIMAL(18,2),((@Runtime - ISNULL(@Dowtime,0))));

	SELECT @Resulst,@Dowtime,@Runtime