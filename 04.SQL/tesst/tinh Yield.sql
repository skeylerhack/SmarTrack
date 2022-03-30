	declare	@MS_MAY NVARCHAR(30) ='MOLD-04';
	DECLARE @Ngay DATETIME = '2022-03-22 09:13:38.077';
	declare @Resulst DECIMAL(18,2);
	declare @Dowtime DECIMAL(18,2);/*thời gian ngừng*/

	DECLARE @TuNgay DATETIME = (SELECT CONVERT(DATE,GETDATE())+ MIN(TU_GIO) FROM dbo.CA)

	DECLARE @DenNgay DATETIME= GETDATE()
	declare @RuntimeNow DECIMAL(18,2) = SUM(DATEDIFF(MINUTE,@TuNgay,@DenNgay));
	declare @Runtime DECIMAL(18,2);

--= DATEDIFF(MINUTE,@TuNgay,@DenNgay);/*thời gian chậy thực tế*/

	SELECT @TuNgay = MIN(B.StartTime),@DenNgay = MAX(B.EndTime)   FROM dbo.ProductionRun A
	INNER JOIN dbo.ProductionRunDetails B ON B.ProductionRunID = A.ID
	WHERE CONVERT(DATE,dbo.fnGetNgayTheoCa(A.StartTime)) =dbo.fnGetNgayTheoCa(GETDATE()) AND B.MS_MAY =@MS_MAY

	SET @Dowtime =(SELECT SUM(A.THOI_GIAN_SUA_CHUA) AS SO_PHUT FROM dbo.THOI_GIAN_DUNG_MAY A
	INNER JOIN dbo.NGUYEN_NHAN_DUNG_MAY B ON B.MS_NGUYEN_NHAN = A.MS_NGUYEN_NHAN
	INNER JOIN dbo.DownTimeType C ON C.ID_DownTime = B.DownTimeTypeID
	WHERE dbo.fnGetNgayTheoCa(A.TU_GIO) = dbo.fnGetNgayTheoCa(@Ngay)  AND A.MS_MAY = @MS_MAY  AND A.TU_GIO BETWEEN @TuNgay AND @DenNgay)


	SET @Runtime = SUM(DATEDIFF(MINUTE,@TuNgay,@DenNgay));

	SELECT @Runtime - ISNULL(@Dowtime,0) AS D,@RuntimeNow AS C,@Runtime AS runtime,@Dowtime AS dow

	IF @Runtime = 0
	SET @Resulst = 0
	ELSE
	SET @Resulst = CONVERT(DECIMAL(18,2),((@Runtime - ISNULL(@Dowtime,0))/ISNULL(@RuntimeNow,1)) * 100);
	SELECT @Resulst AS yield