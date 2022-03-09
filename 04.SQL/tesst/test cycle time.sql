
DECLARE @TN DATETIME = GETDATE()

SELECT T.MS_MAY,
       T.ItemID,
	   T.ID_CA,
       T.UPTIME,
	   T.Dowtime,
       T.ActualQuantity,
       T.NumberPerCycle,
       T.WorkingCycle,
	   T.UPTIME/(T.ActualQuantity/T.NumberPerCycle)AS Workcycle
	   FROM (
SELECT DISTINCT C.MS_MAY,D.ID_CA,B.ItemID,DATEDIFF(SECOND,D.StartTime,D.EndTime) AS Uptime, (SELECT ISNULL(SUM(DATEDIFF(SECOND,F.TU_GIO,F.DEN_GIO)),0) FROM dbo.THOI_GIAN_DUNG_MAY F WHERE F.MS_MAY = C.MS_MAY AND F.TU_GIO BETWEEN D.StartTime AND D.EndTime) AS Dowtime
,D.ActualQuantity,C.WorkingCycle,C.NumberPerCycle
FROM dbo.ProductionOrder A
INNER JOIN dbo.PrODetails B ON	B.PrOID = A.ID
INNER JOIN dbo.ProSchedule C ON C.DetailsID = B.DetailsID
INNER JOIN dbo.ProductionRunDetails D ON D.MS_MAY = C.MS_MAY AND D.ItemID = B.ItemID AND D.PrOID = A.ID
WHERE CONVERT(DATE,C.PlannedStartTime) = CONVERT(DATE,@TN) 
GROUP BY C.MS_MAY,B.ItemID,D.ID_CA,A.StartDate,D.StartTime,D.EndTime,D.EndTime,D.ActualQuantity,C.WorkingCycle,C.NumberPerCycle) AS T
WHERE ISNULL(T.Uptime,0) <> 0
ORDER BY T.MS_MAY,T.ItemID,T.ID_CA

SELECT * FROM dbo.ActualHMI WHERE CONVERT(DATE,Date) = CONVERT(DATE,@TN) AND MS_MAY ='MOLD-05' ORDER BY Date