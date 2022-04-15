

ALTER PROC [dbo].[spApiXoaDungMay]
	@Ngay DATETIME ='2022-04-14 15:27:24.000', 
	@MS_MAY NVARCHAR(30) = 'IMM-03',
	@ID_Operator BIGINT =NULL
AS
BEGIN
    DECLARE @MaxDate DATETIME;
	SELECT  @Max = MAX(TU_GIO) FROM THOI_GIAN_DUNG_MAY WHERE MS_MAY = @MS_MAY 
	IF EXISTS (SELECT * FROM THOI_GIAN_DUNG_MAY WHERE TU_GIO =@Date AND MS_NGUYEN_NHAN =22 AND MS_MAY = @MS_MAY)
	BEGIN
		DELETE dbo.THOI_GIAN_DUNG_MAY WHERE MS_NGUYEN_NHAN = 22 AND  TU_GIO = @Date AND MS_MAY = @MS_MAY
	END
	ELSE
	BEGIN
		DELETE dbo.THOI_GIAN_DUNG_MAY WHERE MS_NGUYEN_NHAN = 22 AND  TU_GIO = @Ngay AND MS_MAY = @MS_MAY
	END
END	
--SELECT * FROM dbo.THOI_GIAN_DUNG_MAY WHERE MS_MAY ='IMM-02' AND CONVERT(DATE,TU_GIO) = CONVERT(DATE,GETDATE())

