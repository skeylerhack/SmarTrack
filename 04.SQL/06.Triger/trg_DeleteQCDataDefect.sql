

ALTER TRIGGER [dbo].[trg_DeleteQCDataDefect] ON [dbo].[QCDataDefect] AFTER DELETE AS 
BEGIN
	SELECT QCData.ID_CA, CONVERT(DATE, QCData.ProductionDate) AS ProductionDate, QCDetails.PrOID, QCDetails.ItemID,	QCDetails.MS_MAY, ISNULL(QCData.CheckStepID, 0) AS CheckStepID, SUM(ISNULL(QCDetails.CheckQuantity, 0)) AS CheckQuantity, SUM(ISNULL(QCDefect.DefeactQuanity, 0)) AS DefeactQuanity
	INTO #TMP
	FROM dbo.QCData QCData
	LEFT JOIN dbo.QCDataDetails QCDetails ON QCDetails.ID_QC = QCData.ID
	LEFT JOIN dbo.QCDataDefect QCDefect ON QCDefect.QCDataDetailsID = QCDetails.ID
	WHERE CONCAT(QCData.ID_CA, ';', CONVERT(DATE, QCData.ProductionDate), ';', QCDetails.PrOID, ';', QCDetails.ItemID, ';', QCDetails.MS_MAY, ';', QCData.CheckStepID)
			IN (SELECT TOP 1 CONCAT(Dta.ID_CA, ';', CONVERT(DATE, Dta.ProductionDate), ';', Details.PrOID, ';', Details.ItemID, ';', Details.MS_MAY, ';', Dta.CheckStepID)
			FROM dbo.QCData Dta
			INNER JOIN dbo.QCDataDetails Details ON Details.ID_QC = Dta.ID
			INNER JOIN Deleted I ON I.QCDataDetailsID = Details.ID)
	GROUP BY QCData.ID_CA, CONVERT(DATE, QCData.ProductionDate), QCDetails.PrOID, QCDetails.ItemID, QCDetails.MS_MAY, QCData.CheckStepID

	

	DECLARE @ID_CA INT = (SELECT TOP 1 ID_CA FROM #TMP)
	DECLARE @ItemID BIGINT = (SELECT TOP 1 ItemID FROM #TMP)
	DECLARE @MS_MAY NVARCHAR(30) = (SELECT TOP 1 MS_MAY FROM #TMP)
	DECLARE @PrOID BIGINT = (SELECT TOP 1 PrOID FROM #TMP)
	DECLARE @ProductionDate DATETIME = (SELECT TOP 1 ProductionDate FROM #TMP)	

	DECLARE @CheckQuantity NUMERIC(18,2) = (SELECT TOP 1 CheckQuantity FROM #TMP)
	DECLARE @CheckStepID BIGINT = (SELECT TOP 1 CheckStepID FROM #TMP)
	DECLARE @DefeactQuanity NUMERIC(18,2) = ISNULL((SELECT TOP 1 DefeactQuanity FROM #TMP WHERE CheckStepID = 1), 0)
	DECLARE @DefeactQuanity1 NUMERIC(18,2) = ISNULL((SELECT TOP 1 DefeactQuanity FROM #TMP WHERE CheckStepID = 2), 0)

	DECLARE @DefeactQuanity_TMP NUMERIC(18,2)
	IF @CheckStepID = 1
		SET @DefeactQuanity_TMP = @DefeactQuanity
	ELSE
		SET @DefeactQuanity_TMP = @DefeactQuanity1

	SELECT PRD.DetailID, PRD.ActualQuantity, PRD.DefectQuantity, PRD.DefectQuantity1, ROW_NUMBER() OVER (ORDER BY PRD.DetailID) AS ROW_NUM
	INTO #TMP1
	FROM dbo.ProductionRunDetails PRD 
	WHERE ID_CA = @ID_CA AND ItemID = @ItemID AND MS_MAY = @MS_MAY AND PrOID = @PrOID AND dbo.fnGetNgayTheoCa(StartTime) = CONVERT(DATE, @ProductionDate)

	DECLARE @ROW INT = 1
	DECLARE @RATE FLOAT = 0
	DECLARE @TOTAL_ActualQuantity NUMERIC(18,2) = (SELECT SUM(ActualQuantity) FROM #TMP1)
	WHILE @ROW <= (SELECT ISNULL(MAX(ROW_NUM), 0) FROM #TMP1)
	BEGIN

		SET @RATE = CASE @TOTAL_ActualQuantity WHEN 0 THEN 0 else ISNULL((SELECT ActualQuantity FROM #TMP1 WHERE ROW_NUM = @ROW) / @TOTAL_ActualQuantity, 0)end

		IF @CheckStepID = 1
		BEGIN
			IF @ROW = (SELECT ISNULL(MAX(ROW_NUM), 0) FROM #TMP1)
				UPDATE PRD
				SET PRD.DefectQuantity = @DefeactQuanity_TMP
				FROM dbo.ProductionRunDetails PRD
				INNER JOIN #TMP1 T1 ON T1.DetailID = PRD.DetailID 
				WHERE T1.ROW_NUM = @ROW
			ELSE	
				UPDATE PRD
				SET PRD.DefectQuantity = CASE WHEN ROUND(@DefeactQuanity * @RATE, 0) < T1.ActualQuantity THEN ROUND(@DefeactQuanity * @RATE, 0) ELSE T1.ActualQuantity END
				FROM dbo.ProductionRunDetails PRD
				INNER JOIN #TMP1 T1 ON T1.DetailID = PRD.DetailID 
				WHERE T1.ROW_NUM = @ROW

			SET @DefeactQuanity_TMP = @DefeactQuanity_TMP - (SELECT TOP 1 PRD.DefectQuantity FROM dbo.ProductionRunDetails PRD
																INNER JOIN #TMP1 T1 ON T1.DetailID = PRD.DetailID 
																WHERE T1.ROW_NUM = @ROW)

		END
		IF @CheckStepID = 2
		BEGIN
			IF @ROW = (SELECT ISNULL(MAX(ROW_NUM), 0) FROM #TMP1)
				UPDATE PRD
				SET PRD.DefectQuantity1 = @DefeactQuanity_TMP
				FROM dbo.ProductionRunDetails PRD
				INNER JOIN #TMP1 T1 ON T1.DetailID = PRD.DetailID 
				WHERE T1.ROW_NUM = @ROW
			ELSE	
				UPDATE PRD
				SET PRD.DefectQuantity1 = CASE WHEN ROUND(@DefeactQuanity1 * @RATE, 0) < T1.ActualQuantity THEN ROUND(@DefeactQuanity1 * @RATE, 0) ELSE T1.ActualQuantity END
				FROM dbo.ProductionRunDetails PRD
				INNER JOIN #TMP1 T1 ON T1.DetailID = PRD.DetailID 
				WHERE T1.ROW_NUM = @ROW

				SET @DefeactQuanity_TMP = @DefeactQuanity_TMP - (SELECT TOP 1 PRD.DefectQuantity1 FROM dbo.ProductionRunDetails PRD
																INNER JOIN #TMP1 T1 ON T1.DetailID = PRD.DetailID 
																WHERE T1.ROW_NUM = @ROW)
		END
			
		SET @ROW = @ROW + 1
	END
END

