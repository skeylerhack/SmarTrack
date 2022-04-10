
ALTER proc [dbo].[spApiGetProDuction]
	@MS_MAY NVARCHAR(30) = 'IMM-02'
AS
BEGIN
		SELECT DISTINCT
		 substring(C.PrOrNumber,8,2) +'-'+ 
		E.ItemCode  AS 'ORDER', CONVERT(INT,D.NumberPerCyle) AS 'QTY',CONVERT(INT,A.PlannedQuantity) AS 'PLAN',
		ABS(SUM(CONVERT(INT,ISNULL(F.ActualQuantity,0)))) AS 'Actual',
		0 AS 'RUN',
		CONVERT(INT,D.DataCollectionCycle) AS DataCollectionCycle,CONVERT(INT,(D.WorkingCycle * 1.25) + 1) AS WorkingCycle,B.ItemID,C.ID AS 'PROID'
		INTO #TMP
		FROM     dbo.ProSchedule A INNER JOIN dbo.PrODetails B ON A.DetailsID = B.DetailsID
		INNER JOIN dbo.ProductionOrder C ON C.ID = B.PrOID
		INNER JOIN dbo.ItemMay D ON D.ItemID = B.ItemID AND D.MS_MAY = A.MS_MAY
		INNER JOIN dbo.Item E ON E.ID = D.ItemID
		LEFT JOIN dbo.ProductionRunDetails F ON F.PrOID = C.ID AND F.ItemID = E.ID AND F.MS_MAY = A.MS_MAY
		LEFT JOIN  dbo.CA G ON G.STT = A.CaID
		WHERE A.MS_MAY = @MS_MAY 
		AND (SELECT dbo.fnGetNgayTheoCa( DATEADD(DAY,0,GETDATE())))  BETWEEN (SELECT dbo.fnGetNgayTheoCa(A.PlannedStartTime)) AND (SELECT dbo.fnGetNgayTheoCa(A.DueTime))	 
		GROUP BY  C.PrOrNumber,E.ItemCode,D.NumberPerCyle,A.PlannedQuantity,D.DataCollectionCycle,D.WorkingCycle,B.ItemID,C.ID

		IF (SELECT COUNT(*) FROM #TMP) = 0
		BEGIN
			UPDATE dbo.MAY SET TT_HMI = 0 WHERE MS_MAY = @MS_MAY
		END
		SELECT * FROM #TMP
END	



