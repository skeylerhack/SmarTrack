ALTER FUNCTION [dbo].[fnGetYield]
(
	@MS_MAY NVARCHAR(30) ='MOLD-07',
	@Ngay DATETIME = '2022-03-22 09:13:38.077'
	-- 1 tính uptime
	-- 2 tính Util
)
returns DECIMAL(18,2)
as 
begin
	declare @Resulst DECIMAL(18,2);
	declare @Dowtime DECIMAL(18,2);/*thời gian ngừng*/

	DECLARE @TuNgay DATETIME = (SELECT CONVERT(DATE,GETDATE())+ MIN(TU_GIO) FROM dbo.CA)
	DECLARE @DenNgay DATETIME= GETDATE()
	declare @RuntimeNow DECIMAL(18,2) = SUM(DATEDIFF(MINUTE,@TuNgay,@DenNgay));
	declare @Runtime DECIMAL(18,2);

--= DATEDIFF(MINUTE,@TuNgay,@DenNgay);/*thời gian chậy thực tế*/

	SELECT @TuNgay = MIN(B.StartTime),@DenNgay = MAX(B.EndTime)   FROM dbo.ProductionRun A
	INNER JOIN dbo.ProductionRunDetails B ON B.ProductionRunID = A.ID
	WHERE CONVERT(DATE,dbo.fnGetNgayTheoCa(A.StartTime)) =dbo.fnGetNgayTheoCa(@Ngay) AND B.MS_MAY =@MS_MAY

	SET @Dowtime =(SELECT SUM(A.THOI_GIAN_SUA_CHUA) AS SO_PHUT FROM dbo.THOI_GIAN_DUNG_MAY A
	INNER JOIN dbo.NGUYEN_NHAN_DUNG_MAY B ON B.MS_NGUYEN_NHAN = A.MS_NGUYEN_NHAN
	INNER JOIN dbo.DownTimeType C ON C.ID_DownTime = B.DownTimeTypeID
	WHERE dbo.fnGetNgayTheoCa(A.TU_GIO) = dbo.fnGetNgayTheoCa(@Ngay)  AND A.MS_MAY = @MS_MAY  AND A.TU_GIO BETWEEN @TuNgay AND @DenNgay)

	SET @Runtime = DATEDIFF(MINUTE,@TuNgay,@DenNgay);

	IF @Runtime = 0
	SET @Resulst = 0
	ELSE
	SET @Resulst = CONVERT(DECIMAL(18,2),((@Runtime - ISNULL(@Dowtime,0))/ISNULL(@RuntimeNow,1)) * 100);

return ISNULL(@Resulst,0)
end
