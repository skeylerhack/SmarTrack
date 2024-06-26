
ALTER PROCEDURE [dbo].[spGetListPrODetails]
    @PrOID BIGINT = 10079 ,
    @USERNAME NVARCHAR(250) = 'admin' ,
    @NNgu INT = 0
AS
    BEGIN
         SELECT   A.DetailsID, A.PrOID, A.ItemID, ItemName,(SELECT TOP 1 Barcode FROM dbo.Item WHERE ID = A.ItemID) AS Barcode, UOMID,
                A.PlannedStartTime, DueDate, A.PlannedQuantity, SUM(C.PlannedQuantity) AS ModerQuantity,
             (
               SELECT DISTINCT TOP 1 SUM(ISNULL(T.ActualQuantity, 0) - ISNULL(T.DefectQuantity1, 0))
               FROM dbo.ProductionRunDetails T
               WHERE T.PrOID = A.PrOID
                     AND T.ItemID = A.ItemID
           ) AS AllocatedQuantity,(SELECT dbo.fnGetDeviceByProID(A.PrOID,A.DetailsID)) AS MS_MAY
        FROM    dbo.PrODetails A
				LEFT JOIN dbo.ProSchedule C ON C.DetailsID = A.DetailsID
                LEFT JOIN dbo.ProductionRunDetails B ON B.PrOID = B.PrOID AND C.MS_MAY =B.MS_MAY AND B.ItemID = A.ItemID

        WHERE   A.PrOID = @PrOID
        GROUP BY A.DetailsID, A.PrOID, A.ItemID, ItemName, UOMID,
                A.PlannedStartTime, DueDate, A.PlannedQuantity
        ORDER BY A.ItemName ASC,A.PlannedStartTime
    END

	