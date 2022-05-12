
ALTER proc [dbo].[spApiUpdatreConsumption]
		@THOI_GIAN DATETIME,
	    @MS_MAY NVARCHAR(30),
	    @I1 DECIMAL(18,2),
	    @I2 DECIMAL(18,2),
	    @I3	DECIMAL(18,2),
	    @U1 DECIMAL(18,2),
	    @U2 DECIMAL(18,2),
	    @U3 DECIMAL(18,2),
	    @W DECIMAL(18,2)
AS
BEGIN
--kiểm tra điện năng tiêu thụ ngày đó đã tồn tại hay chưa
--nếu chưa tồn tại thì insert vào
--nếu có thì update
IF NOT EXISTS(SELECT * FROM dbo.PowerConsumption WHERE MS_MAY = @MS_MAY AND CONVERT(DATE,THOI_GIAN) = dbo.fnGetNgayTheoCa(@THOI_GIAN))
	BEGIN
		INSERT INTO	dbo.PowerConsumption(THOI_GIAN,MS_MAY,I1,I2,I3,U1,U2,U3,W)VALUES(dbo.fnGetNgayTheoCa(@THOI_GIAN),@MS_MAY,@I1,@I2,@I3,@U1,@U2,@U3,@W)
	END
	ELSE
    BEGIN
		UPDATE dbo.PowerConsumption 
		SET I1 = CASE WHEN @I1 > 0  THEN @I1 ELSE I1 END,
		I2 = CASE WHEN @I2 > 0  THEN @I2 ELSE I2 END,
		I3 = CASE WHEN @I3 > 0  THEN @I3 ELSE I3 END,
		U1 = CASE WHEN @U1 > 0  THEN @U1 ELSE U1 END,
		U2 = CASE WHEN @U2 > 0  THEN @U2 ELSE U2 END,
		U3 = CASE WHEN @U3 > 0  THEN @U3 ELSE U3 END,
		W = CASE WHEN @W > W  THEN @W ELSE W END
		WHERE MS_MAY = @MS_MAY AND CONVERT(DATE,THOI_GIAN) = dbo.fnGetNgayTheoCa(@THOI_GIAN)
	END
END	
GO

