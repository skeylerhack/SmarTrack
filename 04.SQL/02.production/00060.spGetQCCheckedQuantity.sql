

ALTER PROCEDURE [dbo].[spGetQCCheckedQuantity]
	@ID_QC BIGINT = NULL,
    @CheckStep BIGINT = NULL, 
    @ID_CA INT = NULL,
    @ProductionDate DATETIME = NULL,
	@PrOID BIGINT = NULL, 
	@ItemID BIGINT = NULL,
	@MS_MAY NVARCHAR(30) = NULL,
	@CheckQuantity NUMERIC(18,2) = NULL
AS
BEGIN
	DECLARE @CheckedQuantity NUMERIC(18,2) = (SELECT SUM(ISNULL(QCDetails.CheckQuantity, 0))
							FROM dbo.QCData QCData 
							INNER JOIN dbo.QCDataDetails QCDetails ON QCDetails.ID_QC = QCData.ID 
							WHERE QCData.CheckStepID = @CheckStep AND QCData.ID_CA = @ID_CA AND CONVERT(DATE, QCData.ProductionDate) = CONVERT(DATE, @ProductionDate)
								AND QCDetails.PrOID = @PrOID AND QCDetails.ItemID = @ItemID AND ISNULL(QCDetails.MS_MAY, '') = ISNULL(@MS_MAY, '') AND QCData.ID <> @ID_QC)
	DECLARE @ActualQuantity NUMERIC(18,2) = (SELECT TOP 1 SUM(ISNULL(ActualQuantity, 0)) FROM dbo.ProductionRunDetails WHERE ID_CA = @ID_CA AND PrOID = @PrOID AND ItemID = @ItemID AND ISNULL(MS_MAY, '') = ISNULL(@MS_MAY, '') AND dbo.fnGetNgayTheoCa(StartTime) = CONVERT(DATE, @ProductionDate))

	IF ISNULL(@CheckQuantity, 0) + ISNULL(@CheckedQuantity, 0) >  ISNULL(@ActualQuantity, 0)
		SELECT 1
	ELSE 
		SELECT 0

	
END	






	
