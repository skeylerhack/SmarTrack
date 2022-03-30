CREATE FUNCTION [dbo].[fnGetActualByDate]
(
	@ProID BIGINT,
	@ItemID BIGINT,
	@MS_MAY NVARCHAR(30),
	@Date DATETIME,
	@type BIT	
)
returns DECIMAL(18,2)
as 
BEGIN
---type 0 lấy số lượng thực tế
---type = 1 lấy số lượng hàng lỗi
declare @Resulst DECIMAL(18,2);
	IF @type = 0
	BEGIN
	SELECT @Resulst = SUM(ActualQuantity)  FROM dbo.ProductionRunDetails WHERE PrOID = @ProID AND ItemID =@ItemID AND MS_MAY = @MS_MAY AND dbo.fnGetNgayTheoCa(StartTime) = dbo.fnGetNgayTheoCa(@Date)
	END
	ELSE
    BEGIN
		SELECT @Resulst = SUM(ActualQuantity) - (ISNULL((SUM(DefectQuantity)),0) + ISNULL((SUM(DefectQuantity1)),0))  FROM dbo.ProductionRunDetails WHERE PrOID = @ProID AND ItemID =@ItemID AND MS_MAY = @MS_MAY AND dbo.fnGetNgayTheoCa(StartTime) = dbo.fnGetNgayTheoCa(@Date)
	END
	RETURN ISNULL(@Resulst,0)
end
GO

