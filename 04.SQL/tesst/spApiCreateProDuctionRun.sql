

ALTER proc [dbo].[spApiCreateProDuctionRun]
	@Ngay DATETIME ='2022-02-24 08:20:01.337',
	@MS_MAY NVARCHAR(30) = 'MOLD-01',
	@ID_Operator BIGINT = 20026,
	@ItemID BIGINT=12,
	@PrOID BIGINT=150,
	@ActualQuantity NUMERIC(18,2) = 2652
	AS
BEGIN
		
		DECLARE @Actual NUMERIC(18,2)
		DECLARE @flag INT = NULL
		DECLARE @NgayHT DATETIME = GETDATE()
		SET @Ngay = (SELECT dbo.fnGetNgayTheoCa(GETDATE()))

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
		--SELECT @IDRun,@ID_CA

		--kiểm lệnh sản xuất có nằm trong ngày hiện tại hay không.
			IF NOT EXISTS(SELECT * FROM dbo.ProductionOrder WHERE ID =@PrOID AND CONVERT(DATE,StartDate) = @Ngay)
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
		IF NOT EXISTS(SELECT * FROM dbo.ProductionRunDetails WHERE PrOID = @PrOID AND ItemID = @ItemID  AND MS_MAY =@MS_MAY AND ID_CA = @ID_CA AND (SELECT dbo.fnGetNgayTheoCa(StartTime)) = CONVERT(DATE,@Ngay)) AND ISNULL(@flag,1) = 1
		BEGIN
			-- nếu chưa tồn tại insert vào details
			INSERT INTO dbo.ProductionRunDetails(ProductionRunID,PrOID,ItemID,MS_HE_THONG,MS_MAY,OperatorID,StartTime,EndTime,ActualQuantity,DefectQuantity,DefectQuantity1,ActualSpeed,StandardSpeed,StandardOutput,
			WorkingCycle,NumberPerCycle,DownTimeRecord,ID_CA)
			SELECT TOP 1 @IDRun,@PrOID,@ItemID,A.MS_HE_THONG,@MS_MAY,@ID_Operator,@NgayHT,@NgayHT,0,0,0,0,A.StandardSpeed,A.StandardOutput,
			A.WorkingCycle,A.NumberPerCycle,A.DownTimeRecord,@ID_CA
			FROM dbo.ProSchedule A
			INNER JOIN dbo.PrODetails B ON B.DetailsID = A.DetailsID
			WHERE A.PrOID =@PrOID AND B.ItemID =@ItemID AND A.MS_MAY = @MS_MAY
			AND CONVERT(DATE,@Ngay) BETWEEN CONVERT(DATE,A.PlannedStartTime) AND CONVERT(DATE,A.DueTime) 
			 --thêm dữ liệu vào bảng để đối chiếu
		END
		ELSE
        BEGIN
		
			SET @IDRunDetails = (SELECT TOP 1 DetailID FROM dbo.ProductionRunDetails WHERE PrOID = @PrOID AND ItemID = @ItemID  AND MS_MAY =@MS_MAY AND ID_CA = @ID_CA AND (SELECT dbo.fnGetNgayTheoCa(StartTime)) = CONVERT(DATE,@Ngay))
			SET @Actual = (SELECT SUM(ActualQuantity) FROM dbo.ProductionRunDetails WHERE PrOID = @PrOID AND ItemID = @ItemID  AND MS_MAY =@MS_MAY AND DetailID != @IDRunDetails)
			-- thêm dữ liệu vào bảng để đối chiếu
			
			IF @flag IS NULL
			BEGIN
			UPDATE dbo.ProductionRunDetails 
			SET ActualQuantity = ABS(@ActualQuantity - ISNULL(@Actual,0)),
			EndTime = @NgayHT,
			OperatorID =@ID_Operator
			WHERE PrOID =@PrOID AND ItemID =@ItemID AND MS_MAY = @MS_MAY  AND ID_CA = @ID_CA AND (SELECT dbo.fnGetNgayTheoCa(StartTime)) = CONVERT(DATE,@Ngay)
			END
			-- thêm dữ liệu vào bảng để đối chiếu
		END
			INSERT INTO dbo.ActualHMI(Date,MS_MAY,ProID,ItemID,OperatorID,ID_CA,ActualQuanity) VALUES(@NgayHT,@MS_MAY,@PrOID,@ItemID,@ID_Operator,@ID_CA,@ActualQuantity)
			UPDATE dbo.MAY SET TT_HMI = 1 WHERE MS_MAY = @MS_MAY
END	


