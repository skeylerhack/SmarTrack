--SELECT [dbo].fnGetThoiGianChay('IMM-03','2022-04-13 22:00:00.717')
ALTER FUNCTION [dbo].[fnGetThoiGianChay]
(
	@MS_MAY NVARCHAR(30),
	@Ngay DATETIME = NULL
)
returns DECIMAL(18,5)
as 
begin
declare @Resulst DECIMAL(18,5);
	SET @Resulst =(SELECT SUM(T.SO_PHUT) FROM (
	SELECT (DATEDIFF(SECOND,B.StartTime,B.EndTime) - ISNULL((SELECT SUM(A.THOI_GIAN_SUA_CHUA*60)  FROM dbo.THOI_GIAN_DUNG_MAY A
	INNER JOIN dbo.NGUYEN_NHAN_DUNG_MAY B1 ON B1.MS_NGUYEN_NHAN = A.MS_NGUYEN_NHAN
	INNER JOIN dbo.DownTimeType C ON C.ID_DownTime = B1.DownTimeTypeID
	WHERE (A.TU_GIO >= B.StartTime AND A.DEN_GIO <= B.EndTime) AND B1.OEE = 0 AND A.MS_MAY = @MS_MAY),0)) AS SO_PHUT  
	FROM dbo.ProductionRun A
	INNER JOIN dbo.ProductionRunDetails B ON B.ProductionRunID = A.ID
	WHERE CONVERT(DATE,dbo.fnGetNgayTheoCa(A.StartTime)) =dbo.fnGetNgayTheoCa(@Ngay) AND B.MS_MAY =@MS_MAY
	) AS T)
	RETURN ISNULL(CASE ISNULL(@Resulst,0) WHEN 0 THEN 1 ELSE @Resulst/3600 END,1)
end
GO

