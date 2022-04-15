--SELECT [dbo].fnGetUptime('MOLD-09',GETDATE(),1)
ALTER FUNCTION [dbo].[fnGetUptime]
(
	@MS_MAY NVARCHAR(30) ='MOLD-11',
	@Ngay DATETIME = NULL,
	@CachTinh INT
	-- 1 tính uptime
	-- 2 tính Util
)
returns DECIMAL(18,2)
as 
begin
	declare @Resulst DECIMAL(18,2);
	declare @Dowtime DECIMAL(18,2);/*thời gian ngừng*/
	DECLARE @TuNgay DATETIME;
	DECLARE @DenNgay DATETIME;
	declare @Runtime DECIMAL(18,2);

	SELECT @TuNgay = MIN(B.StartTime),@DenNgay = MAX(B.EndTime) FROM dbo.ProductionRun A
	INNER JOIN dbo.ProductionRunDetails B ON B.ProductionRunID = A.ID
	WHERE CONVERT(DATE,dbo.fnGetNgayTheoCa(A.StartTime)) =dbo.fnGetNgayTheoCa(@Ngay) AND B.MS_MAY =@MS_MAY
	
	SET @Runtime = DATEDIFF(MINUTE,@TuNgay,@DenNgay);

	
	SET @Dowtime =(SELECT SUM(A.THOI_GIAN_SUA_CHUA) AS SO_PHUT FROM dbo.THOI_GIAN_DUNG_MAY A
	INNER JOIN dbo.NGUYEN_NHAN_DUNG_MAY B ON B.MS_NGUYEN_NHAN = A.MS_NGUYEN_NHAN
	INNER JOIN dbo.DownTimeType C ON C.ID_DownTime = B.DownTimeTypeID
	WHERE dbo.fnGetNgayTheoCa(A.TU_GIO) = dbo.fnGetNgayTheoCa(@Ngay)  AND A.MS_MAY = @MS_MAY AND B.OEE = 1 AND A.TU_GIO BETWEEN @TuNgay AND @DenNgay)
	
	IF @Runtime = 0
	SET @Resulst = 0
	ELSE
	SET @Resulst = CONVERT(DECIMAL(18,2),((@Runtime - ISNULL(@Dowtime,0))/ISNULL(@Runtime,1)) * 100);

return ISNULL(@Resulst,0)
end
GO

