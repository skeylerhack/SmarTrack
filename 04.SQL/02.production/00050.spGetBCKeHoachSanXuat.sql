ALTER PROCEDURE [dbo].[spGetBCKeHoachSanXuat] 
    @UserName NVARCHAR(100) ='admin',
    @NNgu INT =0,
    @TuNgay DATETIME =  '03/27/2022',
    @DenNgay DATETIME = '03/31/2022',
	@MS_MAY NVARCHAR(30) ='-1'
AS
BEGIN 
SELECT DISTINCT  B.MS_MAY,C.ItemCode,A.ItemName,AVG(B.StandardOutput) AS PPH,CONVERT(DATE,B.PlannedStartTime) AS NGAY
,SUM(DISTINCT A.PlannedQuantity) AS Planned,
SUM( D.ActualQuantity) AS Actual,
SUM( D.ActualQuantity) - SUM(DISTINCT A.PlannedQuantity) AS Differences,
SUM( D.ActualQuantity) / SUM(DISTINCT A.PlannedQuantity) AS EFF
 into #TMP
FROM dbo.PrODetails A
INNER JOIN dbo.ProSchedule B ON B.DetailsID = A.DetailsID
INNER JOIN dbo.Item C ON A.ItemID = C.ID
LEFT JOIN dbo.ProductionRunDetails D ON D.PrOID = A.PrOID AND D.ItemID = A.ItemID AND D.MS_MAY = B.MS_MAY
WHERE CONVERT(DATE,B.PlannedStartTime) BETWEEN CONVERT(DATE,@TuNgay) AND CONVERT(DATE,@DenNgay) AND (B.MS_MAY =@MS_MAY OR @MS_MAY = '-1')
GROUP BY B.MS_MAY,C.ItemCode,A.ItemName,CONVERT(DATE,B.PlannedStartTime) 
ORDER BY NGAY



SELECT DISTINCT MS_MAY,ItemCode,ItemName,PPH,NGAY,1 AS ID_Resulst,'Planned' AS Name_Resulst,ISNULL(Planned,0) AS Resulst INTO #TMP1 FROM #TMP
UNION
SELECT DISTINCT MS_MAY,ItemCode,ItemName,PPH,NGAY, 2 AS ID_Resulst,'Actual' AS Name_Resulst,Actual AS Resulst FROM #TMP
UNION
SELECT DISTINCT MS_MAY,ItemCode,ItemName,PPH,NGAY,3 AS ID_Resulst,'Differences' AS Name_Resulst,Differences AS Resulst FROM #TMP
UNION
SELECT DISTINCT MS_MAY,ItemCode,ItemName,PPH,NGAY, 4 AS ID_Resulst,'EFF' AS Name_Resulst,EFF AS Resulst FROM #TMP
ORDER BY  ItemCode,MS_MAY,PPH,ID_Resulst,NGAY


SELECT MS_MAY,ItemCode,ItemName,PPH,ID_Resulst,CASE WHEN ID_Resulst < 4 
THEN SUM(Resulst) ELSE ISNULL((SELECT SUM(Resulst) 
FROM #TMP1 A WHERE A.MS_MAY = C.MS_MAY AND A.ItemCode = C.ItemCode AND A.ID_Resulst = 2 AND A.PPH = C.PPH),0)
/(SELECT SUM(Resulst) FROM #TMP1 A WHERE A.MS_MAY = C.MS_MAY AND A.ItemCode = C.ItemCode AND A.ID_Resulst = 1 AND A.PPH = C.PPH)  END  AS TONG 
INTO #TMP3 FROM #TMP1 AS  C
GROUP BY MS_MAY,ItemCode,ItemName,PPH,ID_Resulst



                
DECLARE @sSql NVARCHAR(MAX)
DECLARE @sSqlL NVARCHAR(MAX)
DECLARE @sSqlSelect NVARCHAR(MAX) = ''
SET @sSql = ''
SET @sSqlSelect = ''
SELECT @sSql = COALESCE(ISNULL(@sSql,'') + CASE LEN(@sSql) WHEN 0 THEN '' ELSE ',' END , '') + ISNULL(NGAY,'')  ,
	@sSqlSelect = COALESCE(ISNULL(@sSqlSelect,'') + CASE LEN(@sSqlSelect) WHEN 0 THEN '' ELSE ',' END , '') + 
	' CASE ' + NGAY + ' WHEN 0 THEN NULL ELSE ' + NGAY + ' END AS '  + NGAY
	FROM 
(
	SELECT DISTINCT number,
	N' [' +CONVERT(NVARCHAR(10), DATEADD(day,number,@TuNgay),103)+N']'  AS NGAY
		from master.dbo.spt_values WHERE number between 0 and 1000 AND DATEADD(day,number,@TuNgay) <= @DenNgay
	) T1

                SET @sSqlL = 'SELECT pvt.* INTO #TMP2 FROM 
(SELECT MS_MAY,ItemCode,ItemName,PPH,CONVERT(NVARCHAR(10),NGAY,103) AS NGAY,ID_Resulst,Name_Resulst,Resulst FROM #TMP1
)
 A
		PIVOT
		(
			SUM(A.Resulst)
			FOR A.NGAY  IN (' + @sSql + ')
		)AS pvt
		SELECT A.MS_MAY,A.ItemCode,A.ItemName,A.PPH,A.Name_Resulst,'+@sSql+',  convert(nvarchar(50),TONG) as TONG  FROM #TMP2 A
			INNER JOIN #TMP3 B ON B.MS_MAY = A.MS_MAY AND B.ItemCode = A.ItemCode AND B.ID_Resulst = A.ID_Resulst AND A.PPH = B.PPH ORDER BY A.MS_MAY,A.ItemCode,A.PPH,A.ID_Resulst
'
            EXEC(@sSqlL)

            END



			