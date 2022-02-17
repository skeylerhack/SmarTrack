
CREATE PROCEDURE dbo.spIPKiemTraSanLuong
	@ItemCode NVARCHAR(50),
	@MS_MAY NVARCHAR(30),
	@SoLuong DECIMAL(18,2),
	@TuNgay DATETIME

AS
BEGIN

	DECLARE @Standard DECIMAL(18,2) = (SELECT TOP 1 StandardOutput FROM dbo.ItemMay WHERE MS_MAY = @MS_MAY  AND ItemID = (SELECT TOP 1 ID FROM dbo.Item WHERE ItemCode =@ItemCode))

	SET @TuNgay = (SELECT CONVERT(DATE,GETDATE()) + MIN(TU_GIO) FROM dbo.CA)
	
	DECLARE @DenNgay DATETIME
	SET @DenNgay = (SELECT DATEADD(MINUTE,-1,DATEADD(DAY,1,@TuNgay)))

	
    -- số phút cần sản xuất hết sản phẩm
	DECLARE @SPSX INT = @SoLuong/(@Standard/60)
	-- số phút được phân có thể sản xuất
	DECLARE @SPDP INT = DATEDIFF(MINUTE,@TuNgay,@DenNgay)
	--số phút không có kế hoạch

	DECLARE @SPKKH INT

	SELECT @SPKKH = SUM(A.THOI_GIAN_SUA_CHUA) FROM dbo.THOI_GIAN_DUNG_MAY A
	INNER JOIN dbo.NGUYEN_NHAN_DUNG_MAY B ON B.MS_NGUYEN_NHAN = A.MS_NGUYEN_NHAN
	INNER JOIN dbo.DownTimeType C ON C.ID_DownTime = B.DownTimeTypeID
	WHERE A.MS_MAY =@MS_MAY AND A.TU_GIO BETWEEN @TuNgay AND @DenNgay AND C.Planned = 1
	-- số phút được phân không nhỏ hơn số phút cần sản xuất
	SELECT  @SPDP - @SPSX - ISNULL(@SPKKH,0)

END
GO