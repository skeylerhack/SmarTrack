ALTER proc [dbo].[spGetBaoCaoTargetMoldID]
AS
begin
	SELECT MAX(C.NGAY) AS NGAY,C.MOLD_ID,C.TarGetActual,(SELECT CONVERT(INT,(SUM(A.ActualQuantity/A.NumberPerCycle))) FROM dbo.ProductionRunDetails A
	INNER JOIN dbo.Item B ON A.ItemID = B.ID
	WHERE  B.Barcode = C.MOLD_ID AND CONVERT(DATE,A.StartTime) > MAX(C.NGAY)) AS SL  
	INTO #TMP
	FROM dbo.TargetMold C
	GROUP BY C.NGAY,C.MOLD_ID,C.TarGetActual
	SELECT T.NGAY,
           T.MOLD_ID,
           ISNULL(T.TarGetActual,0) AS TarGetActual,
           ISNULL(T.SL,0) AS SL,T.TSL FROM (
	SELECT NGAY,
           MOLD_ID,
           TarGetActual,
           SL,(SELECT CONVERT(INT,(SUM(A.ActualQuantity/A.NumberPerCycle))) FROM dbo.ProductionRunDetails A
	INNER JOIN dbo.Item B ON A.ItemID = B.ID
	WHERE  B.Barcode = MOLD_ID) AS TSL  FROM #TMP
	UNION	
	SELECT NULL, B.Barcode,NULL AS Target,CONVERT(INT,SUM(A.ActualQuantity/A.NumberPerCycle)) AS ActualQuantity,CONVERT(INT,SUM(A.ActualQuantity/A.NumberPerCycle)) AS TSL FROM dbo.ProductionRunDetails A
	INNER JOIN dbo.Item B ON A.ItemID = B.ID
	WHERE ISNULL(B.Barcode,'') !='' 
	AND B.Barcode NOT IN (SELECT MOLD_ID FROM #TMP)
	GROUP BY B.Barcode ) T
	ORDER BY T.MOLD_ID
END

