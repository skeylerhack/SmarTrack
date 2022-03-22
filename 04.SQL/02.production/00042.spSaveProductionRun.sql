
ALTER PROCEDURE [dbo].[spSaveProductionRun]
    @iThem BIGINT = -1 ,
    @Code NVARCHAR(12) ='11' ,
    @StartTime DATETIME = '2020-12-18 16:19:32.133',
    @EndTime DATETIME ='2020-12-18 16:19:32.133',
    @DateCreate DATETIME ='2020-12-18 16:19:32.133',
    @Note NVARCHAR(500)  ='2321',
	@UserName NVARCHAR(30) ='admin',
    @sBT NVARCHAR(100) = 'TMPProDucRunDetailsadmin'
AS
    BEGIN
        CREATE TABLE #PROOD
            (
              [DetailID] [BIGINT] NULL ,
              [PrOID] [BIGINT] NULL ,
              [ItemID] [BIGINT] NULL ,
              [MS_HE_THONG] [INT] NULL ,
              [MS_MAY] [NVARCHAR](30) NULL ,
			  [ID_CA] INT NULL ,
              [OperatorID] [BIGINT] NULL ,
              [StartTime] [DATETIME] NULL ,
              [EndTime] [DATETIME] NULL ,
              [SumMinute] [INT] NULL ,
              [ActualQuantity] DECIMAL(18, 2) NULL ,
              [UOM] [BIGINT] NULL ,
              [ConvertQuantity] NVARCHAR(50) NULL ,
              [DefectQuantity] DECIMAL(18, 2) NULL ,
			  [DefectQuantity1] DECIMAL(18, 2) NULL ,
              [ActualSpeed] DECIMAL(18, 2) NULL ,
              [StandardSpeed] DECIMAL(18, 2) NULL ,
              [StandardOutput] DECIMAL(18, 2) NULL ,
              [WorkingCycle] DECIMAL(18, 2) NULL ,
              [NumberPerCycle] DECIMAL(18, 2) NULL
            )
        ON  [PRIMARY]
        DECLARE @sSql NVARCHAR(4000)
        SET @sSql = 'INSERT INTO #PROOD (DetailID, PrOID, ItemID, MS_HE_THONG,
                                        MS_MAY,ID_CA, OperatorID, StartTime, EndTime,
                                        SumMinute, ActualQuantity, UOM,
                                        ConvertQuantity, DefectQuantity,DefectQuantity1,
                                        ActualSpeed, StandardSpeed,
                                        StandardOutput, WorkingCycle,
                                        NumberPerCycle) SELECT DetailID, PrOID, ItemID, MS_HE_THONG,
                                        MS_MAY,ID_CA, OperatorID, StartTime, EndTime,
                                        SumMinute, ActualQuantity, UOM,
                                        ConvertQuantity, DefectQuantity,DefectQuantity1,
                                        ActualSpeed, StandardSpeed,
                                        StandardOutput, WorkingCycle,
                                        NumberPerCycle FROM ' + @sBT 
        EXEC (@sSql)
        IF @iThem = -1
            BEGIN
                INSERT  INTO dbo.ProductionRun ( Code, StartTime, EndTime,
                                                 DateCreate, Note )
                VALUES  ( @Code, @StartTime, -- StartTime - datetime
                          @EndTime, -- @ - datetime
                          @DateCreate, -- CaSTT - int
                          @Note  -- Note - nchar(500)
                          )
                SET @iThem = SCOPE_IDENTITY()
            END
        ELSE
            BEGIN
                UPDATE  dbo.ProductionRun
                SET     StartTime = @StartTime, EndTime = @EndTime,
                        DateCreate = @DateCreate, Note = @Note
                WHERE   ID = @iThem

            END

        SELECT  @iThem
--- thêm những cái chưa có trong bảng tạm
        INSERT  INTO dbo.ProductionRunDetails (ProductionRunID, PrOID, ItemID,
                                                MS_HE_THONG, MS_MAY,ID_CA,
                                                OperatorID, StartTime, EndTime,
                                                ActualQuantity, DefectQuantity,DefectQuantity1,
                                                ActualSpeed, StandardSpeed,
                                                StandardOutput, WorkingCycle,
                                                NumberPerCycle,DateEdit,UserEdit)
                SELECT  @iThem, PrOID, ItemID, MS_HE_THONG, MS_MAY,A.ID_CA, OperatorID,
                        StartTime, EndTime, ActualQuantity, DefectQuantity,A.DefectQuantity1,
                        ActualSpeed, StandardSpeed, StandardOutput,
                        WorkingCycle, NumberPerCycle,GETDATE(),@UserName
                FROM    #PROOD A
                WHERE   NOT EXISTS ( SELECT *
                                     FROM   dbo.ProductionRunDetails B
                                     WHERE  A.DetailID = B.DetailID)
--update những cái nào tồn tại trong bảng tạm
IF @iThem <> -1
BEGIN
        UPDATE  A
        SET     A.PrOID = B.PrOID, A.ItemID = B.ItemID,
                A.MS_HE_THONG = B.MS_HE_THONG, A.MS_MAY = B.MS_MAY,A.ID_CA=B.ID_CA,
                A.OperatorID = B.OperatorID, A.StartTime = B.StartTime,
                A.EndTime = B.EndTime, A.ActualQuantity = B.ActualQuantity,
                A.DefectQuantity = B.DefectQuantity,
				A.DefectQuantity1 = B.DefectQuantity1,
                A.ActualSpeed = B.ActualSpeed,
                A.StandardSpeed = B.StandardSpeed,
                A.StandardOutput = B.StandardOutput,
                A.WorkingCycle = B.WorkingCycle,
                A.NumberPerCycle = B.NumberPerCycle,
				A.DateEdit = GETDATE(),
				A.UserEdit =@UserName
        FROM    dbo.ProductionRunDetails A
                INNER JOIN #PROOD B ON A.DetailID = B.DetailID
        WHERE   A.ProductionRunID = @iThem
		-- delete những cái chưa có

		--DELETE A
		--FROM dbo.ProductionRunDetails A 
		--WHERE NOT EXISTS(SELECT * FROM #PROOD B WHERE A.PrOID =B.PrOID AND A.ItemID =B.ItemID AND A.MS_MAY =B.MS_MAY) AND A.ProductionRunID = @iThem

		  
		END	
    END

	





