--SELECT [dbo].fnGetThoiGianChay('MOLD-03',GETDATE())
ALTER FUNCTION [dbo].[fnGetThoiGianChay]
(
	@MS_MAY NVARCHAR(30),
	@Ngay DATETIME = NULL
)
returns DECIMAL(18,2)
as 
begin
declare @Resulst DECIMAL(18,2);
declare @Dowtime DECIMAL(18,2);/*thời gian ngừng*/
declare @Runtime DECIMAL(18,2);/*thời gian chậy thực tế*/
DECLARE @TuNgay DATETIME;
DECLARE @DenNgay DATETIME;

--Lấy tổng thời gian cần sản xuất của ngày hôm đó
	 SELECT @Runtime = SUM(DATEDIFF(MINUTE,B.StartTime,B.EndTime)), @TuNgay = MIN(B.StartTime),@DenNgay =  MAX(B.EndTime) FROM dbo.ProductionRun A
	INNER JOIN dbo.ProductionRunDetails B ON B.ProductionRunID = A.ID
	WHERE CONVERT(DATE,dbo.fnGetNgayTheoCa(A.StartTime)) =dbo.fnGetNgayTheoCa(GETDATE()) AND B.MS_MAY =@MS_MAY

--lấy min ngày và max ngày của tiến độ

	SET @Dowtime =(SELECT SUM(A.THOI_GIAN_SUA_CHUA) AS SO_PHUT FROM dbo.THOI_GIAN_DUNG_MAY A
	INNER JOIN dbo.NGUYEN_NHAN_DUNG_MAY B ON B.MS_NGUYEN_NHAN = A.MS_NGUYEN_NHAN
	INNER JOIN dbo.DownTimeType C ON C.ID_DownTime = B.DownTimeTypeID
	WHERE CONVERT(DATE,A.TU_GIO) BETWEEN @TuNgay AND @DenNgay AND (B.MS_NGUYEN_NHAN != 14) AND A.MS_MAY = @MS_MAY) /*trừ ra thằng nào không có đơn hàng điều kiệu thời gian kết thúc không hớn hơn ngày*/

	SET @Resulst = CONVERT(DECIMAL(18,2),(@Runtime - ISNULL(@Dowtime,0))/60);
	RETURN ISNULL(@Resulst,1)
end
GO

