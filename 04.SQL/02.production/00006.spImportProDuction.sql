
ALTER PROCEDURE [dbo].[spImportProDuction]
	@ItemCode NVARCHAR(50) ='1000003',
	@MS_MAY NVARCHAR(30) ='MOLD-01',
	@SoLuong DECIMAL(18,2)=10,
	@NgayBD DATETIME = '2022-02-12 19:09:36.390'
AS
BEGIN

	DECLARE @PrOrNumber NVARCHAR(50)
	DECLARE @ItemID BIGINT
	DECLARE @PrOID BIGINT
	DECLARE @PrODetailsID BIGINT


	SET @NgayBD = (SELECT CONVERT(DATE,@NgayBD) + MIN(TU_GIO) FROM dbo.CA)
	
	select @NgayBD

	DECLARE @NgayKT DATETIME
	SET @NgayKT = (SELECT DATEADD(MINUTE,-1,DATEADD(DAY,1,@NgayBD)))


	SET @ItemID = (SELECT TOP 1 ID FROM dbo.Item WHERE ItemCode =@ItemCode)
	
	IF EXISTS(SELECT * FROM dbo.ProductionOrder WHERE CONVERT(DATE,StartDate) = (SELECT dbo.fnGetNgayTheoCa(@NgayBD)))
	BEGIN
		SET @PrOID = (SELECT TOP 1 ID FROM dbo.ProductionOrder WHERE CONVERT(DATE,StartDate) = (SELECT dbo.fnGetNgayTheoCa(@NgayBD)) )
	END
	ELSE
    BEGIN
		SET @PrOrNumber =(SELECT dbo.AUTO_CREATE_SO_KHSX((SELECT dbo.fnGetNgayTheoCa(@NgayBD))))
	    INSERT INTO dbo.ProductionOrder(PrOrNumber,OrderDate,StartDate,DueDate,Status,Note)	     
		VALUES(@PrOrNumber,@NgayBD,@NgayBD,@NgayKT,1,'Import')
		SET @PrOID  =  SCOPE_IDENTITY()
	END
    
	INSERT INTO dbo.PrODetails(PrOID,ItemID,ItemName,UOMID,PlannedQuantity,PlannedStartTime,DueDate)
	SELECT TOP 1 @PrOID,ID,ItemName,UOM,@SoLuong,@NgayBD,@NgayKT FROM dbo.Item WHERE ID = @ItemID

	SET @PrODetailsID = SCOPE_IDENTITY()

	INSERT INTO dbo.ProSchedule(PrOID,DetailsID,MS_HE_THONG,MS_MAY,PlannedQuantity,PlannedStartTime,DueTime,
	EndTime,StandardOutput,WorkingCycle,NumberPerCycle,DownTimeRecord)
	SELECT TOP 1 @PrOID,@PrODetailsID,(SELECT TOP 1 MS_HE_THONG FROM dbo.MAY_HE_THONG WHERE MS_MAY =@MS_MAY),@MS_MAY,@SoLuong,
	@NgayBD,@NgayKT,@NgayKT,StandardOutput,WorkingCycle,NumberPerCyle,DownTimeRecord FROM dbo.ItemMay WHERE MS_MAY =@MS_MAY AND ItemID = @ItemID
	
END


