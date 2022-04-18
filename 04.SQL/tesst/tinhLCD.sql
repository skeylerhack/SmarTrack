 DECLARE @Ngay DATETIME	= GETDATE()
 (SELECT [dbo].[fnGetThoiGianChay]('IMM-07',@Ngay))

SELECT DISTINCT  
ROW_NUMBER() OVER(ORDER BY T2.MS_MAY) AS STT , 
1 AS Ca,
T2.MS_MAY,
CONVERT(NVARCHAR(20),ISNULL(CONVERT(DECIMAL(18,2),((SUM(T.OEE)/ (SELECT [dbo].[fnGetThoiGianChay](T2.MS_MAY,@Ngay)) * 100))),0)) AS OEE,
-----CONVERT(NVARCHAR(20),ABS(CHECKSUM(NewId())) % 100 ) AS OEE,

CONVERT(NVARCHAR(20), ISNULL(t1.OEE,0)) AS TargetOEE,
----CONVERT(NVARCHAR(20), ABS(CHECKSUM(NewId())) % 100) AS TargetOEE,

CONVERT(NVARCHAR(20),FORMAT(ISNULL(SUM(t.Actual),0),'#,##0')) AS Actual,

CONVERT(NVARCHAR(20), FORMAT(ISNULL(sum(CONVERT(INT,T.TargetPro)),0),'#,##0')) AS TargetPro,

CONVERT(NVARCHAR(20),(SELECT [dbo].[fnGetUptime](T2.MS_MAY,@Ngay,1))) AS UPTIME,
CONVERT(NVARCHAR(20),(SELECT [dbo].[fnGetDowtime](T2.MS_MAY,@Ngay,-1))) AS Dowtime,
CONVERT(NVARCHAR(20),(SELECT [dbo].[fnGetDowtime](T2.MS_MAY,@Ngay,0))) AS Unplanned, 
CONVERT(NVARCHAR(20),(SELECT [dbo].[fnGetYield](T2.MS_MAY,@Ngay))) AS Util,
CONVERT(NVARCHAR(1000),dbo.fnGetItemCode(T2.MS_MAY,@Ngay)) AS Item,

ISNULL(T2.TT_HMI,0) AS TT_HMI
-----ABS(CHECKSUM(NewId())) % 4 AS TT_HMI
FROM dbo.MAY T2
LEFT JOIN
(
SELECT DISTINCT C.MS_MAY,B.ItemID,ISNULL(dbo.fnGetActualByDate(B.PrOID,B.ItemID,C.MS_MAY,@Ngay,1)/C.StandardOutput,0) AS OEE,C.StandardOutput,
dbo.fnGetActualByDate(B.PrOID,B.ItemID,C.MS_MAY,@Ngay,0) AS Actual,ISNULL(C.PlannedQuantity,0) AS TargetPro
FROM dbo.ProductionOrder A
INNER JOIN dbo.PrODetails B ON	B.PrOID = A.ID
INNER JOIN dbo.ProSchedule C ON C.DetailsID = B.DetailsID
WHERE CONVERT(DATE,C.PlannedStartTime) = CONVERT(DATE,@Ngay)
GROUP BY B.PrOID,C.MS_MAY,B.ItemID,C.StandardOutput,C.PlannedQuantity
) AS T ON T.MS_MAY = T2.MS_MAY
LEFT JOIN dbo.Target T1 ON T1.MS_MAY = T2.MS_MAY AND DATEPART(MONTH,T1.MONTH) = DATEPART(MONTH,@Ngay) AND DATEPART(YEAR,T1.MONTH) = DATEPART(YEAR,@Ngay)
GROUP BY T2.MS_MAY,T2.TT_HMI,T1.OEE
ORDER BY T2.MS_MAY

SELECT DISTINCT C.MS_MAY,B.ItemID,ISNULL(dbo.fnGetActualByDate(B.PrOID,B.ItemID,C.MS_MAY,@Ngay,1)/C.StandardOutput,0) AS OEE,C.StandardOutput,C.NumberPerCycle,C.WorkingCycle,
dbo.fnGetActualByDate(B.PrOID,B.ItemID,C.MS_MAY,@Ngay,0) AS Actual,ISNULL(C.PlannedQuantity,0) AS TargetPro
FROM dbo.ProductionOrder A
INNER JOIN dbo.PrODetails B ON	B.PrOID = A.ID
INNER JOIN dbo.ProSchedule C ON C.DetailsID = B.DetailsID
WHERE CONVERT(DATE,C.PlannedStartTime) = CONVERT(DATE,@Ngay)
GROUP BY B.PrOID,C.MS_MAY,B.ItemID,C.StandardOutput,C.PlannedQuantity,C.NumberPerCycle,C.WorkingCycle



	
