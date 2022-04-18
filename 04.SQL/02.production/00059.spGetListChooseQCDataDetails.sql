



ALTER PROCEDURE [dbo].[spGetListChooseQCDataDetails]
	@Username NVARCHAR(100) ='admin',
	@NNgu INT = 0,
	@ID_CA INT = 3,
	@CheckStep BIGINT = 1,
	@ProductionDate DATETIME = '2022-04-14',
	@sBT nvarchar(50) ='frmChooseQCDataDetailsadmin'
AS 
BEGIN
	CREATE TABLE #TMPChooseQCDataDetails(
		PrOID BIGINT,
		ItemID BIGINT,
		MS_MAY NVARCHAR(30))
	DECLARE @sSql nvarchar(4000)
	set @sSql = 'INSERT INTO #TMPChooseQCDataDetails SELECT PrOID, ItemID, MS_MAY  FROM ' + @sBT
	EXEC (@sSql)
	EXEC ('DROP TABLE ' + @sBT)


	SELECT QCDetails.PrOID, QCDetails.ItemID, QCDetails.MS_MAY, SUM(ISNULL(QCDetails.CheckQuantity, 0)) AS CheckQuantity
	INTO #CHECKED
	FROM dbo.QCData QCData 
	INNER JOIN dbo.QCDataDetails QCDetails ON QCDetails.ID_QC = QCData.ID 
	WHERE QCData.CheckStepID = @CheckStep AND QCData.ID_CA = @ID_CA AND CONVERT(DATE, QCData.ProductionDate) = CONVERT(DATE, @ProductionDate)
	GROUP BY QCDetails.PrOID, QCDetails.ItemID, QCDetails.MS_MAY

	SELECT CONVERT(BIT, 0) AS CHON, PRD.PrOID, PRD.ItemID, PRD.MS_MAY, ISNULL(PRD.ActualQuantity, 0) AS ActualQuantity INTO #TEMP 
	FROM dbo.ProductionRunDetails PRD
	
	WHERE PRD.ID_CA = @ID_CA AND dbo.fnGetNgayTheoCa(PRD.StartTime) = CAST(@ProductionDate AS DATE)

	UPDATE A
	set A.CHON = 1
	FROM #TEMP A
	INNER JOIN #TMPChooseQCDataDetails B ON B.ItemID = A.ItemID AND B.MS_MAY = A.MS_MAY AND B.PrOID = A.PrOID

	SELECT #T.CHON, #T.PrOID, PO.PrOrNumber, #T.ItemID, I.ItemCode, CASE @NNgu WHEN 0 THEN I.ItemName WHEN 1 THEN ISNULL(NULLIF(I.ItemNameA, ''), I.ItemName) ELSE ISNULL(NULLIF(I.ItemNameH, ''), I.ItemName) END AS ItemName, #T.MS_MAY, SUM(ISNULL(#T.ActualQuantity, 0)) - ISNULL(CHK.CheckQuantity, 0) AS CheckQuantity
	FROM #TEMP #T
	LEFT JOIN dbo.ProductionOrder PO ON PO.ID = #T.PrOID
	LEFT JOIN dbo.Item I ON I.ID = #T.ItemID
	LEFT JOIN #CHECKED CHK ON CHK.ItemID = #T.ItemID AND CHK.MS_MAY = #T.MS_MAY AND CHK.PrOID = #T.PrOID
	GROUP BY #T.CHON, #T.PrOID, PO.PrOrNumber, #T.ItemID, I.ItemCode, I.ItemName, I.ItemNameA, I.ItemNameH, #T.MS_MAY,CHK.CheckQuantity
	HAVING SUM(ISNULL(#T.ActualQuantity, 0)) - ISNULL(CHK.CheckQuantity, 0) > 0
	ORDER BY PO.PrOrNumber, I.ItemCode
END	
