ALTER PROCEDURE [dbo].[spGetItemMay]
	@ItemID BIGINT = 115,
	@Username NVARCHAR(100) ='admin',
	@NNgu INT =0,
	@sBT NVARCHAR(50)='BTadmin'
AS 
BEGIN
SELECT A.* INTO #MAY FROM dbo.MGetMayUserNgay(GETDATE(),@username,-1,-1,-1,-1,'-1','-1', @NNgu) A 	

DECLARE @DVT NVARCHAR(50)
SET @DVT = [dbo].[fnGetDVTCongSuat](@ItemID)
SELECT  A.MS_MAY AS 'DeviceID',A.MS_MAY,A.StandardOutput,A.MS_DV_TG_Output,A.StandardSpeed,A.MS_DV_TG_Speed,A.DataCollectionCycle,
A.DownTimeRecord,A.WorkingCycle,A.NumberPerCyle,A.TimeSendMgs,A.ShortStopLimit,A.SendMsg2 ,@DVT AS 'CapacityUOM',A.Consumption INTO #TMP FROM dbo.ItemMay A
INNER JOIN #MAY B ON B.MS_MAY = A.MS_MAY
WHERE A.ItemID = @ItemID
ORDER BY MS_MAY
IF	@sBT = 'NO'
BEGIN
SELECT * FROM #TMP
END
ELSE	
BEGIN
CREATE TABLE #TEMPItemMay
(
[CHON] [bit] NULL,
[MS_MAY] [nvarchar] (max),
[TEN_MAY] [nvarchar] (max),
[StandardSpeed] [real] NULL,
[DataCollectionCycle] [int] NULL,
[WorkingCycle] NUMERIC(18,2) NULL,
[NumberPerCyle] NUMERIC(18,2) NULL,
[TimeSendMgs] NUMERIC(18,2) NULL,
[ShortStopLimit]NUMERIC(18,2) NULL,
[SendMsg2]NUMERIC(18,2) NULL,
Consumption NUMERIC(18,2) NULL
) ON [PRIMARY] 
DECLARE @sSql nvarchar(4000)
set @sSql = 'INSERT INTO #TEMPItemMay SELECT * FROM ' + @sBT
EXEC (@sSql)
set @sSql = 'DROP TABLE ' + @sBT
EXEC (@sSql)

IF (SELECT COUNT(*) FROM #TEMPItemMay) > 0
BEGIN
SELECT A.* FROM #TMP A
INNER JOIN #TEMPItemMay B ON B.MS_MAY = A.MS_MAY
UNION
SELECT A.MS_MAY,A.MS_MAY,NULL AS StandardOutput,NULL AS MS_DV_TG_Output,A.StandardSpeed,NULL AS MS_DV_TG_Speed,A.DataCollectionCycle,NULL AS DownTimeRecord,
A.WorkingCycle,A.NumberPerCyle,A.TimeSendMgs,A.ShortStopLimit,A.SendMsg2,@DVT AS 'CapacityUOM',A.Consumption FROM #TEMPItemMay A
WHERE NOT EXISTS (SELECT * FROM #TMP B WHERE B.MS_MAY = A.MS_MAY)
END
ELSE
BEGIN
DELETE #TMP
SELECT * FROM #TMP ORDER BY MS_MAY
END	
END	
END	





