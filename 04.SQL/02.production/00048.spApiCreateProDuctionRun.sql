--DELETE FROM dbo.ProductionRunDetails WHERE MS_MAY = 'IMM-17'
--DELETE FROM dbo.ActualHMI WHERE MS_MAY = 'IMM-17'
--DELETE FROM dbo.THOI_GIAN_DUNG_MAY WHERE MS_MAY = 'IMM-17'
--SELECT *  FROM dbo.ActualHMI WHERE MS_MAY = 'IMM-17'
--SELECT *  FROM dbo.ProductionRunDetails WHERE MS_MAY = 'IMM-17'
--03-1007227	4	454	82	0	15	29	99	192
ALTER proc [dbo].[spApiCreateProDuctionRun]
	@Ngay DATETIME ='2022-04-03 06:03:35.337',
	@MS_MAY NVARCHAR(30) = 'IMM-17',
	@ID_Operator BIGINT = 20026,
	@ItemID BIGINT=99,
	@PrOID BIGINT=192,
	@ActualQuantity NUMERIC(18,2) = 25,
	@Run BIT = 0
	AS
BEGIN
		DECLARE @Actual NUMERIC(18,2)
		DECLARE @flag INT = NULL
		DECLARE @NgayHT DATETIME = GETDATE()
		DECLARE @NgayBD DATETIME = GETDATE()
		DECLARE @NgayCC DATETIME = GETDATE()
		DECLARE @TGCU DATETIME;
		DECLARE @SLCU INT;
		DECLARE @SLMOI INT;

		SET @Ngay = (SELECT dbo.fnGetNgayTheoCa(@NgayHT))
		IF NOT EXISTS(SELECT * FROM dbo.ProductionRun WHERE (SELECT dbo.fnGetNgayTheoCa(StartTime))  = CONVERT(DATE,@Ngay))
		BEGIN
			--nếu chưa tồn tại thì thêm mới production vào
			INSERT INTO dbo.ProductionRun(Code,DateCreate,StartTime,EndTime,Note)
			SELECT (SELECT dbo.AUTO_CREATE_SO_TDSX(@Ngay)),@Ngay,CONVERT(DATE,@Ngay) + MIN(TU_GIO), CONVERT(DATE,@Ngay) + MAX(TU_GIO),'HMI' FROM dbo.CA
		END

		--lấy ca hiện tại theo giờ hiện tại
		DECLARE @ID_CA INT = (SELECT dbo.fnGetCa(@NgayHT))
		--lấy production run
		DECLARE @IDRun BIGINT;
		DECLARE @IDRunDetails BIGINT;
		SET @IDRun = (SELECT TOP 1 ID FROM dbo.ProductionRun WHERE (SELECT dbo.fnGetNgayTheoCa(StartTime))  = CONVERT(DATE,@Ngay))

		--kiểm lệnh sản xuất có nằm trong ngày hiện tại hay không.
			IF NOT EXISTS(SELECT * FROM dbo.ProductionOrder WHERE ID = @PrOID AND CONVERT(DATE,StartDate) = @Ngay)
			BEGIN
				--nếu ngày sản xuất không nằm trong ngày hiện tại.
				IF EXISTS(SELECT * FROM dbo.PrODetails A
				INNER JOIN dbo.ProSchedule B ON B.DetailsID = A.DetailsID
				AND CONVERT(DATE,B.PlannedStartTime) = @Ngay AND B.MS_MAY =@MS_MAY AND A.ItemID =@ItemID)
				BEGIN
				--kiểm tra đơn hàng hiện tại có item đó không.
				SET @PrOID = (SELECT TOP 1 A.PrOID FROM dbo.PrODetails A
				INNER JOIN dbo.ProSchedule B ON B.DetailsID = A.DetailsID
				AND CONVERT(DATE,B.PlannedStartTime) = @Ngay AND B.MS_MAY =@MS_MAY AND A.ItemID =@ItemID)
					SET @flag = 1
				END
				ELSE
                BEGIN
					SET @flag = 0
				END
			END

		IF NOT EXISTS(SELECT * FROM dbo.ProductionRunDetails WHERE PrOID = @PrOID AND ItemID = @ItemID  AND MS_MAY =@MS_MAY AND ID_CA = @ID_CA AND 
		(SELECT dbo.fnGetNgayTheoCa(StartTime)) = CONVERT(DATE,@Ngay)) AND ISNULL(@flag,1) = 1
		BEGIN
			IF dbo.fnGetCa(@NgayHT) !=  dbo.fnGetCa(DATEADD(MINUTE,-6,@NgayHT))
			BEGIN
				--lấy thời gian vào số lượng ở ca trước
				SELECT TOP 1 @TGCU = MAX(Date),@SLCU = MAX(ActualQuanity) FROM dbo.ActualHMI WHERE ItemID = @ItemID AND MS_MAY = @MS_MAY AND Date > DATEADD(MINUTE,-6,@NgayHT) AND Date < @NgayHT
					IF(@SLCU IS NOT NULL)
					BEGIN
						--tính số lượng ca củ dựa vào tỉ l
						SELECT @NgayBD = @Ngay + TU_GIO FROM dbo.CA WHERE STT = dbo.fnGetCa(@NgayHT)
						 SET @SLMOI = ((@ActualQuantity - @SLCU) * DATEDIFF(SECOND,@TGCU,@NgayBD))/ DATEDIFF(SECOND,@TGCU,@NgayHT)
					 
						UPDATE dbo.ProductionRunDetails 
						SET ActualQuantity =ActualQuantity + @SLMOI + CONVERT(INT,(@SLMOI * 5/100)),
						EndTime = @NgayBD
						WHERE MS_MAY =@MS_MAY AND ItemID =@ItemID AND EndTime > DATEADD(MINUTE,-6,@NgayHT)  AND EndTime < @NgayHT
					END
			END
				INSERT INTO dbo.ProductionRunDetails(ProductionRunID,PrOID,ItemID,MS_HE_THONG,MS_MAY,OperatorID,StartTime,EndTime,ActualQuantity,DefectQuantity,DefectQuantity1,ActualSpeed,StandardSpeed,StandardOutput,
				WorkingCycle,NumberPerCycle,DownTimeRecord,ID_CA)
				SELECT TOP 1 @IDRun,@PrOID,@ItemID,A.MS_HE_THONG,@MS_MAY,@ID_Operator,@NgayBD,@NgayHT,0,0,0,0,A.StandardSpeed,A.StandardOutput,
				A.WorkingCycle,A.NumberPerCycle,A.DownTimeRecord,@ID_CA
				FROM dbo.ProSchedule A
				INNER JOIN dbo.PrODetails B ON B.DetailsID = A.DetailsID
				WHERE A.PrOID =@PrOID AND B.ItemID =@ItemID AND A.MS_MAY = @MS_MAY
				AND CONVERT(DATE,@Ngay) BETWEEN CONVERT(DATE,A.PlannedStartTime) AND CONVERT(DATE,A.DueTime) 
		END
		ELSE
        BEGIN
		--nếu tồn tại dữ liệu trong một ca
			SET @IDRunDetails = (SELECT MAX(DetailID)  FROM dbo.ProductionRunDetails WHERE PrOID = @PrOID AND ItemID = @ItemID  AND MS_MAY =@MS_MAY AND ID_CA = @ID_CA AND (SELECT dbo.fnGetNgayTheoCa(StartTime)) = CONVERT(DATE,@Ngay))
			SET @Actual = (SELECT SUM(ActualQuantity) FROM dbo.ProductionRunDetails WHERE PrOID = @PrOID AND ItemID = @ItemID  AND MS_MAY =@MS_MAY AND DetailID != @IDRunDetails)
			-- thêm dữ liệu vào bảng để đối chiếu
			

			IF @flag IS NULL
			BEGIN
				--nếu đơn hàng  nằm trong ngày hiện tại
				--kiểm tra run trước đó
				IF NOT EXISTS(SELECT * FROM dbo.ProductionRunDetails WHERE DetailID = @IDRunDetails)

				UPDATE dbo.ProductionRunDetails 
				SET ActualQuantity = ABS(@ActualQuantity - ISNULL(@Actual,0)),
				EndTime = @NgayHT,
				OperatorID =@ID_Operator
				WHERE PrOID =@PrOID AND ItemID =@ItemID AND MS_MAY = @MS_MAY  AND ID_CA = @ID_CA AND (SELECT dbo.fnGetNgayTheoCa(StartTime)) = CONVERT(DATE,@Ngay)

			END
			IF @flag = 0
			BEGIN

				--nếu đơn hàng không nằm trong ngày hiện tại và trong item không có item hiện tại 
				IF dbo.fnGetCa(@NgayHT) !=  dbo.fnGetCa(DATEADD(MINUTE,-6,@NgayHT))
				BEGIN
					--lấy thời gian vào số lượng ở ca trước
					SELECT TOP 1 @TGCU = MAX(Date),@SLCU = MAX(ActualQuanity) FROM dbo.ActualHMI WHERE ItemID = @ItemID AND MS_MAY = @MS_MAY AND Date > DATEADD(MINUTE,-6,@NgayHT) AND Date < @NgayHT
						IF(@SLCU IS NOT NULL)
						BEGIN
							--tính số lượng ca củ dựa vào tỉ l
							SELECT @NgayBD = @Ngay + TU_GIO FROM dbo.CA WHERE STT = dbo.fnGetCa(@NgayHT)
							 SET @SLMOI = ((@ActualQuantity - @SLCU) * DATEDIFF(SECOND,@TGCU,@NgayBD))/ DATEDIFF(SECOND,@TGCU,@NgayHT)
					 
							UPDATE dbo.ProductionRunDetails 
							SET ActualQuantity =ActualQuantity + @SLMOI,EndTime = @NgayBD
							WHERE MS_MAY =@MS_MAY AND ItemID =@ItemID AND EndTime > DATEADD(MINUTE,-6,@NgayHT)  AND EndTime < @NgayHT
						END
				END
			END
			-- thêm dữ liệu vào bảng để đối chiếu
		END
		INSERT INTO dbo.ActualHMI(Date,MS_MAY,ProID,ItemID,OperatorID,ID_CA,ActualQuanity) VALUES(@NgayHT,@MS_MAY,@PrOID,@ItemID,@ID_Operator,@ID_CA,@ActualQuantity)
		UPDATE dbo.MAY SET TT_HMI = 1 WHERE MS_MAY = @MS_MAY
END	



	
