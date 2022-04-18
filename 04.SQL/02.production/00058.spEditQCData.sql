

ALTER PROCEDURE [dbo].[spEditQCData]
	@ID BIGINT = -1,
	@DocNum NVARCHAR(12) = 'TestID',
	@QCName NVARCHAR(50) = 'test',
	@QCDate DATETIME = '2021-12-14',
	@CheckStepID BIGINT = 1,
	@ID_CA BIGINT = 1,
	@ProductionDate DATETIME = '2021-12-14',
	@sBTQCDataDetails NVARCHAR(500)='TMPQCDataDetailsadmin', 
	@sBTQCDataDefect NVARCHAR(500)='TMPQCDataDefectadmin'
AS 
BEGIN

	CREATE TABLE #TMPQCDataDetails (
	ID BIGINT,
	ID_QC BIGINT,
	PrOID BIGINT,
	ItemID BIGINT,
	MS_MAY NVARCHAR(30),
	CheckQuantity INT,
	Note NVARCHAR(250),
	ID_TEMP BIGINT)
	DECLARE @sSql_#TMPQCDataDetails NVARCHAR(4000)
	set @sSql_#TMPQCDataDetails = 'INSERT INTO #TMPQCDataDetails SELECT ID, ID_QC, PrOID, ItemID, MS_MAY, CheckQuantity, Note, ID_TEMP FROM ' + @sBTQCDataDetails
	EXEC (@sSql_#TMPQCDataDetails)
	EXEC ('DROP TABLE ' + @sBTQCDataDetails)


	CREATE TABLE #TMPQCDataDefect (
	QCDataDetailsID BIGINT,
	ID_Defect BIGINT,
	DefeactQuanity NUMERIC(18,2),
	Note NVARCHAR(500),
	ID_TEMP BIGINT)
	DECLARE @sSql_#TMPQCDataDefect NVARCHAR(4000)
	set @sSql_#TMPQCDataDefect = 'INSERT INTO #TMPQCDataDefect SELECT QCDataDetailsID, ID_Defect, DefeactQuanity, Note, ID_TEMP FROM ' + @sBTQCDataDefect
	EXEC (@sSql_#TMPQCDataDefect)
	EXEC ('DROP TABLE ' + @sBTQCDataDefect)

	BEGIN TRY
	BEGIN TRANSACTION INS_QCData

		IF EXISTS (SELECT TOP 1 * FROM dbo.QCData WHERE ID = @ID)
		BEGIN
			UPDATE dbo.QCData
			SET DocNum = @DocNum,
				QCName = @QCName,
				QCDate = @QCDate,
				CheckStepID = @CheckStepID,
				ID_CA = @ID_CA,
				ProductionDate = @ProductionDate
			WHERE ID = @ID
		END
		ELSE 
		BEGIN
			DBCC CHECKIDENT (QCData,RESEED,0)
			DBCC CHECKIDENT (QCData,RESEED)
			INSERT dbo.QCData(DocNum, QCName, QCDate, CheckStepID, ID_CA, ProductionDate, CreatedTime)
			VALUES(@DocNum, @QCName, @QCDate, @CheckStepID, @ID_CA, @ProductionDate, GETDATE())

			SET @ID = SCOPE_IDENTITY()
		END

		DELETE dbo.QCDataDefect WHERE QCDataDetailsID NOT IN (SELECT ID FROM #TMPQCDataDetails WHERE ID_QC = @ID) AND QCDataDetailsID IN (SELECT ID FROM dbo.QCDataDetails WHERE ID_QC = @ID)
		DELETE dbo.QCDataDetails WHERE ID NOT IN (SELECT ID FROM #TMPQCDataDetails) AND QCDataDetails.ID_QC = @ID AND ID_QC = @ID

		UPDATE D
		SET D.PrOID = #T.PrOID,
			D.ItemID = #T.ItemID,
			D.MS_MAY = #T.MS_MAY,
			D.CheckQuantity = #T.CheckQuantity,
			D.Note = #T.Note
		FROM dbo.QCDataDetails D 
		INNER JOIN #TMPQCDataDetails #T ON #T.ID = D.ID AND ISNULL(#T.ID, -1) <> -1
		WHERE D.ID_QC = @ID

		UPDATE D
		SET D.ID_Defect = #T.ID_Defect,
			D.DefeactQuanity = #T.DefeactQuanity,
			D.Note = #T.Note
		FROM dbo.QCDataDefect D
		INNER JOIN #TMPQCDataDefect #T ON #T.QCDataDetailsID = D.QCDataDetailsID AND D.ID_Defect = #T.ID_Defect
		WHERE D.ID_Defect IN (SELECT ID_Defect FROM #TMPQCDataDefect WHERE QCDataDetailsID IN (SELECT ID FROM #TMPQCDataDetails WHERE ID_QC = @ID))

		DECLARE @Count INT = 0
		WHILE @Count <= (SELECT MAX(ID_TEMP) FROM #TMPQCDataDetails)
		BEGIN
			IF EXISTS (SELECT TOP 1 * FROM dbo.QCDataDetails WHERE ID = (SELECT TOP 1 ID FROM #TMPQCDataDetails WHERE ID_TEMP = @Count))
			BEGIN
			
				INSERT INTO dbo.QCDataDefect(QCDataDetailsID, ID_Defect, DefeactQuanity, Note)
				SELECT (SELECT TOP 1 ID FROM #TMPQCDataDetails WHERE ID_TEMP = @Count), ID_Defect, DefeactQuanity, Note FROM #TMPQCDataDefect WHERE ISNULL(QCDataDetailsID, -1) = -1 AND ID_TEMP = (SELECT TOP 1 ID_TEMP FROM #TMPQCDataDetails WHERE ID_TEMP = @Count)
			END

			IF EXISTS (SELECT TOP 1 * FROM #TMPQCDataDetails WHERE ID_TEMP = @Count) 
			AND NOT EXISTS (SELECT TOP 1 * FROM dbo.QCDataDetails WHERE ID = (SELECT TOP 1 ID FROM #TMPQCDataDetails WHERE ID_TEMP = @Count))
			BEGIN

				DBCC CHECKIDENT (QCDataDetails,RESEED,0)
				DBCC CHECKIDENT (QCDataDetails,RESEED)
				INSERT INTO dbo.QCDataDetails(ID_QC, PrOID, ItemID, MS_MAY, CheckQuantity, Note)
				SELECT @ID, PrOID, ItemID, MS_MAY, CheckQuantity, Note FROM #TMPQCDataDetails WHERE ID_TEMP = @Count

				
				INSERT INTO dbo.QCDataDefect(QCDataDetailsID, ID_Defect, DefeactQuanity, Note)
				SELECT SCOPE_IDENTITY(), ID_Defect, DefeactQuanity, Note FROM #TMPQCDataDefect WHERE ISNULL(QCDataDetailsID, -1) = -1 AND ID_TEMP = (SELECT TOP 1 ID_TEMP FROM #TMPQCDataDetails WHERE ID_TEMP = @Count)
			END

			SET @Count += 1
		END

		COMMIT TRANSACTION INS_QCData
		SELECT @ID
		END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION INS_QCData
		SELECT ERROR_MESSAGE()
	END CATCH
END	



