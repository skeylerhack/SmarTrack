--SELECT dbo.fnGetItemCode('MOLD-04',GETDATE())
ALTER FUNCTION [dbo].[fnGetItemCode]
(
	@MS_MAY NVARCHAR(30),
	@Ngay DATETIME = NULL
)
RETURNS NVARCHAR(1000)
AS	
BEGIN
DECLARE @EmployeeList Nvarchar(1000)
DECLARE @NHAN_VIEN Nvarchar(1000)



SELECT @EmployeeList =COALESCE(@EmployeeList + ' - ', '') +
CAST(ItemCode AS Nvarchar(1000))
FROM 
(
	SELECT DISTINCT TEMP.ItemCode FROM
	(
			SELECT DISTINCT b.PlannedStartTime,C.ItemCode + '('+ ISNULL(CONVERT(NVARCHAR(20),CONVERT(DECIMAL(18,2),SUM(DATEDIFF(SECOND,D.StartTime,D.EndTime))/SUM(D.ActualQuantity))),0) +')' AS ItemCode FROM dbo.PrODetails A 
			INNER JOIN dbo.ProSchedule B ON A.DetailsID = B.DetailsID
			INNER JOIN dbo.Item C ON C.ID = A.ItemID 
			LEFT JOIN dbo.ProductionRunDetails D ON D.PrOID = A.PrOID AND D.ItemID = A.ItemID AND D.MS_MAY = B.MS_MAY
			WHERE B.MS_MAY =@MS_MAY AND CONVERT(DATE,B.PlannedStartTime) = CONVERT(DATE,@Ngay)
			GROUP BY b.PlannedStartTime,C.ItemCode
	) TEMP
)T
RETURN ISNULL(@EmployeeList,'')
END
GO

