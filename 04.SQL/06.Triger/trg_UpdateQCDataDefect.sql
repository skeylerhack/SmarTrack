
ALTER TRIGGER [dbo].[trg_UpdateQCDataDefect] ON [dbo].[QCDataDefect] AFTER UPDATE AS 
BEGIN
	DECLARE @ID_CA INT = NULL
	DECLARE @ItemID BIGINT = NULL
	DECLARE @MS_NAY NVARCHAR(30) = NULL
	DECLARE @PrOID BIGINT = NULL
	DECLARE @ProductionDate DATETIME = NULL
	DECLARE @CheckQuantity NUMERIC(18,2) = NULL
	DECLARE @CheckStepID BIGINT = NULL
	DECLARE @DefeactQuanity NUMERIC(18,2) = NULL
	DECLARE @DefeactQuanity1 NUMERIC(18,2) = NULL
	DECLARE @DefeactQuanity_TMP NUMERIC(18,2) = NULL
	DECLARE @TMP_ROW INT = NULL
	DECLARE @TMP1_ROW INT = NULL
	DECLARE @RATE FLOAT = NULL
	DECLARE @TOTAL_ActualQuantity NUMERIC(18,2) = NULL

	SELECT QCData.ID_CA, CONVERT(DATE, QCData.ProductionDate) AS ProductionDate, QCDetails.PrOID, QCDetails.ItemID,	QCDetails.MS_MAY, ISNULL(QCData.CheckStepID, 0) AS CheckStepID, SUM(ISNULL(QCDetails.CheckQuantity, 0)) AS CheckQuantity, SUM(ISNULL(QCDefect.DefeactQuanity, 0)) AS DefeactQuanity, ROW_NUMBER() OVER (ORDER BY QCData.ID_CA, CONVERT(DATE, QCData.ProductionDate), QCDetails.PrOID, QCDetails.ItemID,	QCDetails.MS_MAY, QCData.CheckStepID) AS ROW_NUM
	INTO #TMP
	FROM dbo.QCData QCData
	LEFT JOIN dbo.QCDataDetails QCDetails ON QCDetails.ID_QC = QCData.ID
	LEFT JOIN dbo.QCDataDefect QCDefect ON QCDefect.QCDataDetailsID = QCDetails.ID
	WHERE CONCAT(QCData.ID_CA, ';', CONVERT(DATE, QCData.ProductionDate), ';', QCDetails.PrOID, ';', QCDetails.ItemID, ';', QCDetails.MS_MAY, ';', QCData.CheckStepID)
			IN (SELECT CONCAT(Dta.ID_CA, ';', CONVERT(DATE, Dta.ProductionDate), ';', Details.PrOID, ';', Details.ItemID, ';', Details.MS_MAY, ';', Dta.CheckStepID)
			FROM dbo.QCData Dta
			INNER JOIN dbo.QCDataDetails Details ON Details.ID_QC = Dta.ID
			INNER JOIN Inserted I ON I.QCDataDetailsID = Details.ID)
	GROUP BY QCData.ID_CA, CONVERT(DATE, QCData.ProductionDate), QCDetails.PrOID, QCDetails.ItemID, QCDetails.MS_MAY, QCData.CheckStepID

	SET @TMP_ROW = 1
	WHILE @TMP_ROW <= (SELECT ISNULL(MAX(ROW_NUM), 0) FROM #TMP)
	BEGIN

		SET @ID_CA = (SELECT TOP 1 ID_CA FROM #TMP WHERE ROW_NUM = @TMP_ROW)
		SET @ItemID = (SELECT TOP 1 ItemID FROM #TMP WHERE ROW_NUM = @TMP_ROW)
		SET @MS_NAY = (SELECT TOP 1 MS_MAY FROM #TMP WHERE ROW_NUM = @TMP_ROW)
		SET @PrOID  = (SELECT TOP 1 PrOID FROM #TMP WHERE ROW_NUM = @TMP_ROW)
		SET @ProductionDate  = (SELECT TOP 1 ProductionDate FROM #TMP WHERE ROW_NUM = @TMP_ROW)
		SET @CheckQuantity = (SELECT TOP 1 CheckQuantity FROM #TMP WHERE ROW_NUM = @TMP_ROW)
		SET @CheckStepID = (SELECT TOP 1 CheckStepID FROM #TMP WHERE ROW_NUM = @TMP_ROW)
		SET @DefeactQuanity = (SELECT TOP 1 DefeactQuanity FROM #TMP WHERE CheckStepID = 1 AND ROW_NUM = @TMP_ROW)
		SET @DefeactQuanity1 = (SELECT TOP 1 DefeactQuanity FROM #TMP WHERE CheckStepID = 2 AND ROW_NUM = @TMP_ROW)
		IF @CheckStepID = 1
			SET @DefeactQuanity_TMP = @DefeactQuanity
		ELSE
			SET @DefeactQuanity_TMP = @DefeactQuanity1

		SELECT PRD.DetailID, PRD.ActualQuantity, PRD.DefectQuantity, PRD.DefectQuantity1, ROW_NUMBER() OVER (ORDER BY PRD.DetailID) AS ROW_NUM
		INTO #TMP1
		FROM dbo.ProductionRunDetails PRD 
		WHERE ID_CA = @ID_CA AND ItemID = @ItemID AND MS_MAY = @MS_NAY AND PrOID = @PrOID AND dbo.fnGetNgayTheoCa(StartTime) = CONVERT(DATE, @ProductionDate)

		SET @TMP1_ROW = 1
		SET @RATE = 0
		SET @TOTAL_ActualQuantity = (SELECT SUM(ActualQuantity) FROM #TMP1)


		WHILE @TMP1_ROW <= (SELECT ISNULL(MAX(ROW_NUM), 0) FROM #TMP1)
		BEGIN
			SET @RATE = CASE @TOTAL_ActualQuantity WHEN 0 THEN 0 else ISNULL((SELECT ActualQuantity FROM #TMP1 WHERE ROW_NUM = @TMP1_ROW) / @TOTAL_ActualQuantity, 0)end

			IF @CheckStepID = 1
			BEGIN
				IF @TMP1_ROW = (SELECT ISNULL(MAX(ROW_NUM), 0) FROM #TMP1)
					UPDATE PRD
					SET PRD.DefectQuantity = @DefeactQuanity_TMP
					FROM dbo.ProductionRunDetails PRD
					INNER JOIN #TMP1 T1 ON T1.DetailID = PRD.DetailID 
					WHERE T1.ROW_NUM = @TMP1_ROW
				ELSE	
					UPDATE PRD
					SET PRD.DefectQuantity = CASE WHEN ROUND(@DefeactQuanity * @RATE, 0) < T1.ActualQuantity THEN ROUND(@DefeactQuanity * @RATE, 0) ELSE T1.ActualQuantity END
					FROM dbo.ProductionRunDetails PRD
					INNER JOIN #TMP1 T1 ON T1.DetailID = PRD.DetailID 
					WHERE T1.ROW_NUM = @TMP1_ROW

				SET @DefeactQuanity_TMP = @DefeactQuanity_TMP - (SELECT TOP 1 PRD.DefectQuantity FROM dbo.ProductionRunDetails PRD
																	INNER JOIN #TMP1 T1 ON T1.DetailID = PRD.DetailID 
																	WHERE T1.ROW_NUM = @TMP1_ROW)
			END
			IF @CheckStepID = 2
			BEGIN
				IF @TMP1_ROW = (SELECT ISNULL(MAX(ROW_NUM), 0) FROM #TMP1)
					UPDATE PRD
					SET PRD.DefectQuantity1 = @DefeactQuanity_TMP
					FROM dbo.ProductionRunDetails PRD
					INNER JOIN #TMP1 T1 ON T1.DetailID = PRD.DetailID 
					WHERE T1.ROW_NUM = @TMP1_ROW
				ELSE	
					UPDATE PRD
					SET PRD.DefectQuantity1 = CASE WHEN ROUND(@DefeactQuanity1 * @RATE, 0) < T1.ActualQuantity THEN ROUND(@DefeactQuanity1 * @RATE, 0) ELSE T1.ActualQuantity END
					FROM dbo.ProductionRunDetails PRD
					INNER JOIN #TMP1 T1 ON T1.DetailID = PRD.DetailID 
					WHERE T1.ROW_NUM = @TMP1_ROW

				SET @DefeactQuanity_TMP = @DefeactQuanity_TMP - (SELECT TOP 1 PRD.DefectQuantity1 FROM dbo.ProductionRunDetails PRD
																	INNER JOIN #TMP1 T1 ON T1.DetailID = PRD.DetailID 
																	WHERE T1.ROW_NUM = @TMP1_ROW)
			END
			
			SET @TMP1_ROW = @TMP1_ROW + 1
		END

		DROP TABLE #TMP1
		SET @TMP_ROW = @TMP_ROW + 1
	END
END

