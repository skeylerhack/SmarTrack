ALTER PROCEDURE [dbo].[spGetListProductionRunDetails]
    @ProductionRunID BIGINT = 28,
    @USERNAME NVARCHAR(250) = 'admin',
    @NNgu INT = 0
AS
BEGIN
    SELECT A.DetailID,
           PrOID,
           ItemID,
		   B.ItemCode,
		   B.Barcode,
		   A.ID_CA,
           A.MS_HE_THONG,
           A.MS_MAY AS TEN_MAY,
           A.MS_MAY,
           OperatorID,
           StartTime,
           EndTime,
           DATEDIFF(MINUTE, A.StartTime, A.EndTime) AS SumMinute,
           ActualQuantity,
           (
               SELECT UOMID FROM dbo.UOMConversionGroupDetails WHERE ID = B.UOM
           ) AS UOM,
           [dbo].[fnGetConvertQuantity](A.ItemID, A.ActualQuantity) AS ConvertQuantity,
           A.DefectQuantity,
		   A.DefectQuantity1,
           A.ActualSpeed,
           A.StandardSpeed,
           A.StandardOutput,
           A.WorkingCycle,
           A.NumberPerCycle
    FROM dbo.ProductionRunDetails A
        INNER JOIN dbo.Item B
            ON A.ItemID = B.ID
    WHERE A.ProductionRunID = @ProductionRunID;
END;

