
--SELECT [dbo].fnGetUptime('MOLD-11',GETDATE(),1)
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

DECLARE @TuNgay DATETIME = (SELECT CONVERT(DATE,GETDATE())+ MIN(TU_GIO) FROM dbo.CA)
DECLARE @DenNgay DATETIME= GETDATE()
declare @Runtime DECIMAL(18,2)= DATEDIFF(MINUTE,@TuNgay,@DenNgay);/*thời gian chậy thực tế*/


	--SELECT @Runtime = SUM(DATEDIFF(MINUTE,B.StartTime,B.EndTime)), @TuNgay = MIN(B.StartTime),@DenNgay =  MAX(B.EndTime) FROM dbo.ProductionRun A
	--INNER JOIN dbo.ProductionRunDetails B ON B.ProductionRunID = A.ID
	--WHERE CONVERT(DATE,dbo.fnGetNgayTheoCa(A.StartTime)) =dbo.fnGetNgayTheoCa(GETDATE()) AND B.MS_MAY =@MS_MAY

	IF @CachTinh  =1 
	BEGIN
			SET @Dowtime =(SELECT SUM(A.THOI_GIAN_SUA_CHUA) AS SO_PHUT FROM dbo.THOI_GIAN_DUNG_MAY A
			INNER JOIN dbo.NGUYEN_NHAN_DUNG_MAY B ON B.MS_NGUYEN_NHAN = A.MS_NGUYEN_NHAN
			INNER JOIN dbo.DownTimeType C ON C.ID_DownTime = B.DownTimeTypeID
			WHERE CONVERT(DATE,A.NGAY_DUNG) = CONVERT(DATE,@TuNgay) AND B.OEE = 1 AND A.MS_MAY = @MS_MAY) /*trừ ra thằng nào không có đơn hàng điều kiệu thời gian kết thúc không hớn hơn ngày*/
	END
	ELSE
	BEGIN
		SET @Dowtime =(SELECT SUM(A.THOI_GIAN_SUA_CHUA) AS SO_PHUT FROM dbo.THOI_GIAN_DUNG_MAY A
			INNER JOIN dbo.NGUYEN_NHAN_DUNG_MAY B ON B.MS_NGUYEN_NHAN = A.MS_NGUYEN_NHAN
			INNER JOIN dbo.DownTimeType C ON C.ID_DownTime = B.DownTimeTypeID
			WHERE CONVERT(DATE,A.NGAY_DUNG) = CONVERT(DATE,@TuNgay) AND B.OEE = 1 AND  A.MS_MAY = @MS_MAY)/*trừ ra thằng nào không có đơn hàng*/
	END
	SET @Resulst = CONVERT(DECIMAL(18,2),((@Runtime - ISNULL(@Dowtime,0))/ISNULL(@Runtime,1)) * 100);

return ISNULL(@Resulst,0)
end
