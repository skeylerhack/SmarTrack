SELECT * INTO #TMP  FROM (
SELECT StartTime,EndTime,PrOID,MS_MAY,ItemID,ID_CA,DATEDIFF(MINUTE,StartTime,EndTime) * (StandardOutput/60) AS LT 
,ActualQuantity
FROM dbo.ProductionRunDetails 
WHERE ActualQuantity < 2000 AND  CONVERT(DATE,StartTime) > '03/01/2022' ) A WHERE LT < A.ActualQuantity

UPDATE A
SET A.ActualQuantity = CONVERT(INT,(LT * 99 )/100)
FROM dbo.ProductionRunDetails A 
INNER JOIN #TMP B ON B.MS_MAY = A.MS_MAY AND B.ItemID = A.ItemID AND B.ID_CA = A.ID_CA AND B.PrOID = A.PrOID AND B.EndTime = A.EndTime

DROP TABLE #TMP

-- nếu LT < ACtul thi ac tual = ly thuyet