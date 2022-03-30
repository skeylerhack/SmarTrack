
ALTER PROCEDURE [dbo].[spSaveTGDM]
	@sBT NVARCHAR(500) = NULL,
	@UserName NVARCHAR(50) = NULL,
    @iThem BIGINT = -1,
	@MS_MAY NVARCHAR(30) = NULL,
	@TU_GIO DATETIME = NULL,
	@DEN_GIO DATETIME = NULL,
	@MS_NGUYEN_NHAN INT = NULL,
	@GHI_CHU NVARCHAR(500) = NULL,
	@ID_Operator BIGINT = NULL,
	@THOI_GIAN_SUA_CHUA FLOAT = NULL,
	@THOI_GIAN_SUA FLOAT = NULL,
	@NGUYEN_NHAN NVARCHAR(250) = NULL,
	@NGUYEN_NHAN_CU_THE NVARCHAR(255) = NULL,
	@HIEN_TUONG NVARCHAR (250) = NULL,
	@CaID INT = NULL,
	@ProductionRunDetailsID BIGINT = NULL,
	@ID_CHA BIGINT = NULL
	AS
    BEGIN
		CREATE TABLE #BT_TGDM(
		R_NUM INT,
		ID_CA INT,
		TGio DATETIME,
		DGio DATETIME)

		DECLARE @sql_#BT_TGDM NVARCHAR(MAX)
		SET @sql_#BT_TGDM = 'INSERT INTO #BT_TGDM SELECT ROW_NUMBER() OVER(ORDER BY NGAY_BD), * FROM ' + @sBT
		EXEC(@sql_#BT_TGDM)
		EXEC('DROP TABLE ' + @sBT)


		BEGIN TRY
			BEGIN TRANSACTION INS_TGDM
			SAVE TRANSACTION INS_TGDM
			IF @iThem = -1
			BEGIN
				DECLARE @R_COUNT INT = 1
				WHILE @R_COUNT <= (SELECT COUNT(*) FROM #BT_TGDM)
				BEGIN

					DECLARE @TGio DATETIME = (SELECT TOP 1 TGio FROM #BT_TGDM WHERE R_NUM = @R_COUNT)
					DECLARE @DGio DATETIME = (SELECT TOP 1 DGio FROM #BT_TGDM WHERE R_NUM = @R_COUNT)
					DECLARE @ID_CA INT = (SELECT TOP 1 ID_CA FROM #BT_TGDM WHERE R_NUM = @R_COUNT)
					IF(@MS_MAY <> '-1')
					BEGIN
					INSERT INTO dbo.THOI_GIAN_DUNG_MAY(MS_MAY, NGAY_DUNG, TU_GIO, TU_GIO_GOC, DEN_GIO, DEN_GIO_GOC, MS_NGUYEN_NHAN, MS_NGUYEN_NHAN_GOC, GHI_CHU, ID_Operator, THOI_GIAN_SUA_CHUA, THOI_GIAN_SUA, NGUYEN_NHAN, NGUYEN_NHAN_CU_THE, HIEN_TUONG, CaID, ProductionRunDetailsID, ID_CHA, UserEdit, DateEdit)
					VALUES(@MS_MAY, dbo.fnGetNgayTheoCa(@TGio), @TGio, @TGio, @DGio, @DGio, @MS_NGUYEN_NHAN, @MS_NGUYEN_NHAN, @GHI_CHU, @ID_Operator, @THOI_GIAN_SUA_CHUA, (CONVERT(FLOAT, (DATEDIFF(SECOND, @TGio, @DGio))) / 60), @NGUYEN_NHAN, @NGUYEN_NHAN_CU_THE, @HIEN_TUONG, @ID_CA, @ProductionRunDetailsID, CASE (SELECT TOP 1 R_NUM FROM #BT_TGDM WHERE R_NUM = @R_COUNT) WHEN 1 THEN NULL ELSE @iThem END, @UserName, GETDATE())
					END
					ELSE
                    BEGIN
						INSERT INTO dbo.THOI_GIAN_DUNG_MAY(MS_MAY, NGAY_DUNG, TU_GIO, TU_GIO_GOC, DEN_GIO, DEN_GIO_GOC, MS_NGUYEN_NHAN, MS_NGUYEN_NHAN_GOC, GHI_CHU, ID_Operator, THOI_GIAN_SUA_CHUA, THOI_GIAN_SUA, NGUYEN_NHAN, NGUYEN_NHAN_CU_THE, HIEN_TUONG, CaID, ProductionRunDetailsID, ID_CHA, UserEdit, DateEdit)
						SELECT MS_MAY, dbo.fnGetNgayTheoCa(@TGio), @TGio, @TGio, @DGio, @DGio, @MS_NGUYEN_NHAN, @MS_NGUYEN_NHAN, @GHI_CHU, @ID_Operator, @THOI_GIAN_SUA_CHUA, (CONVERT(FLOAT, (DATEDIFF(SECOND, @TGio, @DGio))) / 60), @NGUYEN_NHAN, @NGUYEN_NHAN_CU_THE, @HIEN_TUONG, @ID_CA, @ProductionRunDetailsID, CASE (SELECT TOP 1 R_NUM FROM #BT_TGDM WHERE R_NUM = @R_COUNT) WHEN 1 THEN NULL ELSE @iThem END, @UserName, GETDATE() FROM dbo.MAY
					END
					SET @iThem = SCOPE_IDENTITY()

					SET @R_COUNT = @R_COUNT + 1
				END
			END
			ELSE
			BEGIN
				UPDATE  dbo.THOI_GIAN_DUNG_MAY
				SET	MS_MAY = @MS_MAY,
				NGAY_DUNG = dbo.fnGetNgayTheoCa(@TGio),
				TU_GIO = @TU_GIO,
				DEN_GIO = @DEN_GIO,
				MS_NGUYEN_NHAN = @MS_NGUYEN_NHAN,
				GHI_CHU = @GHI_CHU,
				ID_Operator = @ID_Operator,
				THOI_GIAN_SUA_CHUA = @THOI_GIAN_SUA_CHUA,
				THOI_GIAN_SUA = @THOI_GIAN_SUA,
				NGUYEN_NHAN = @NGUYEN_NHAN,
				NGUYEN_NHAN_CU_THE = @NGUYEN_NHAN_CU_THE,
				HIEN_TUONG = @HIEN_TUONG,
				CaID = @CaID,
				ProductionRunDetailsID = @ProductionRunDetailsID,
				ID_CHA = @ID_CHA,
				UserEdit = @UserName,
				DateEdit = GETDATE()
				WHERE   ID = @iThem
			END
			COMMIT TRANSACTION INS_TGDM 
			SELECT @iThem
		END TRY
		BEGIN CATCH
			ROLLBACK TRANSACTION INS_TGDM
			SELECT 0
		END CATCH
    END

	





