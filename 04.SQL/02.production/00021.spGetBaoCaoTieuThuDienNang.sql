
ALTER proc [dbo].[spGetBaoCaoTieuThuDienNang]
	@MS_MAY nvarchar(30),
	@TNgay DATETIME,
	@DNgay DATETIME,
	@USERNAME  nvarchar(50),
	@NNgu int
AS
begin
	SELECT THOI_GIAN,MS_MAY,I1,I2,I3,U1,U2,U3,W FROM dbo.PowerConsumption 
	WHERE THOI_GIAN BETWEEN @TNgay AND @DNgay AND (MS_MAY = @MS_MAY OR @MS_MAY = '-1')
	ORDER BY THOI_GIAN,MS_MAY
END


