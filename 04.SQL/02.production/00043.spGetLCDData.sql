


--SELECT * from dbo.LCD_MAY
ALTER PROCEDURE [dbo].[spGetLCDData]
	@iLoai INT = 1  --= 0 lcd may---- = 1 lcd bieu do
AS
BEGIN

DECLARE @sTTMayKhongSuDung NVARCHAR(50) = '127;127;127'  --TT 0 Máy không sử dụng hay không chạy    R127, G127, B: 127
DECLARE @sTTMayChayTren NVARCHAR(50) = '0;108;0'   --TT 1 trên - Xanh lá (máy chạy OEE trên target)
DECLARE @sTTMayChayDuoi NVARCHAR(50) = '255;196;9'   --TT 1 duoi- vàng đậm (máy chạy dưới taget) 
DECLARE @sTTMayDungNgoaiCoKeHoach NVARCHAR(50) = '67;60;200'  --TT 2 - Màu cam là dứng máy có kế hoạch   R238, G93, B: 0
DECLARE @sTTMayDungNgoaiKeHoach NVARCHAR(50) = '220;86;86'  --TT 3 - Màu đỏ là dừng máy ngoài kế hoạch    R238, G0, B: 0
--0- không chạy. 1- chậy,2 là DUNG MAY có kế hoạch, 3 là DUNG MAY không có kế hoạch ,4 là số lượn thực lớn hơn kế hoạch
DECLARE @NNgu INT = 0

DECLARE @Ngay DATETIME =GETDATE();
DECLARE @Ca NVARCHAR(50) = (SELECT CASE	@NNgu WHEN 0 THEN CA WHEN 1 THEN CA_ANH ELSE CA_HOA END FROM dbo.CA WHERE STT =(SELECT dbo.fnGetCa(@Ngay)))

DECLARE @sOEE NVARCHAR(50) = N'OEE :'
DECLARE @sTarget NVARCHAR(50) = N'Target :'
DECLARE @sPRODUCTION NVARCHAR(50) = N'PRODUCTION'

DECLARE @sActual NVARCHAR(50) = N'Actual :'
DECLARE @sUPTIME NVARCHAR(50) = N'UPTIME :'
DECLARE @sDowntime NVARCHAR(50) = N'Downtime :'

DECLARE @sYield NVARCHAR(50) = N'ITEM (s/pcs)'
DECLARE @sUnplanned NVARCHAR(50) = N'Unplanned :'

DECLARE @sPhut NVARCHAR(50) = N'min'

DECLARE @DDCa NVARCHAR(50) = N'0;0;0;Arial;30px;T;F;T;255;255;255;100%;45vh'
DECLARE @DD1 NVARCHAR(50) = N'255;255;255;Arial;38px;T;F;T'

DECLARE @tarOEE DECIMAL(18,2)

SELECT DISTINCT  
ROW_NUMBER() OVER(ORDER BY T2.MS_MAY) AS STT , 
@Ca AS Ca,
T2.MS_MAY,
CONVERT(NVARCHAR(20),ISNULL(CONVERT(DECIMAL(18,2),((SUM(T.OEE)/ (SELECT [dbo].[fnGetThoiGianChay](T2.MS_MAY,@Ngay)) * 100))),0)) AS OEE,
-------CONVERT(NVARCHAR(20),ABS(CHECKSUM(NewId())) % 100 ) AS OEE,

CONVERT(NVARCHAR(20), ISNULL(t1.OEE,0)) AS TargetOEE,
----CONVERT(NVARCHAR(20), ABS(CHECKSUM(NewId())) % 100) AS TargetOEE,

CONVERT(NVARCHAR(20),FORMAT(ISNULL(SUM(t.Actual),0),'#,##0')) AS Actual,

CONVERT(NVARCHAR(20), FORMAT(ISNULL(sum(CONVERT(INT,T.TargetPro)),0),'#,##0')) AS TargetPro,

CONVERT(NVARCHAR(20),(SELECT [dbo].[fnGetUptime](T2.MS_MAY,@Ngay,1))) AS UPTIME,
CONVERT(NVARCHAR(20),(SELECT [dbo].[fnGetDowtime](T2.MS_MAY,@Ngay,-1))) AS Dowtime,
CONVERT(NVARCHAR(20),(SELECT [dbo].[fnGetDowtime](T2.MS_MAY,@Ngay,0))) AS Unplanned, 
CONVERT(NVARCHAR(20),(SELECT [dbo].[fnGetYield](T2.MS_MAY,@Ngay))) AS Util,
CONVERT(NVARCHAR(1000),dbo.fnGetItemCode(T2.MS_MAY,GETDATE())) AS Item,
CASE ISNULL(T2.TT_HMI,0) WHEN 1 THEN CASE WHEN t1.OEE < ISNULL(CONVERT(DECIMAL(18,2),((SUM(T.OEE)/ (SELECT [dbo].[fnGetThoiGianChay](T2.MS_MAY,@Ngay)) * 100))),0) THEN 1 ELSE 4 END  ELSE ISNULL(T2.TT_HMI,0) END	 AS TT_HMI
-----ABS(CHECKSUM(NewId())) % 4 AS TT_HMI
INTO #LCD_TMP
FROM dbo.MAY T2
LEFT JOIN
(
SELECT DISTINCT C.MS_MAY,B.ItemID,ISNULL(dbo.fnGetActualByDate(B.PrOID,B.ItemID,C.MS_MAY,GETDATE(),1)/C.StandardOutput,0) AS OEE,C.StandardOutput,
dbo.fnGetActualByDate(B.PrOID,B.ItemID,C.MS_MAY,GETDATE(),0) AS Actual,ISNULL(C.PlannedQuantity,0) AS TargetPro
FROM dbo.ProductionOrder A
INNER JOIN dbo.PrODetails B ON	B.PrOID = A.ID
INNER JOIN dbo.ProSchedule C ON C.DetailsID = B.DetailsID
WHERE CONVERT(DATE,C.PlannedStartTime) = CONVERT(DATE,GETDATE())
GROUP BY B.PrOID,C.MS_MAY,B.ItemID,C.StandardOutput,C.PlannedQuantity
) AS T ON T.MS_MAY = T2.MS_MAY
LEFT JOIN dbo.Target T1 ON T1.MS_MAY = T2.MS_MAY AND DATEPART(MONTH,T1.MONTH) = DATEPART(MONTH,@Ngay) AND DATEPART(YEAR,T1.MONTH) = DATEPART(YEAR,@Ngay)
GROUP BY T2.MS_MAY,T2.TT_HMI,T1.OEE
ORDER BY T2.MS_MAY
--insert vao lcd may
IF @iLoai = 0
BEGIN
	INSERT INTO dbo.LCD_MAY(STT, COTMAUNEN, COT0, COT0DD, COT1, COT1DD, COT2, COT2DD, COT3, COT3DD, COT4, COT4DD, COT5, COT5DD, COT6, COT6DD, COT6MAUNEN, COT7, COT7DD, COT8, COT8DD, COT9, COT9DD, COT10, COT10DD, COT11, COT11DD, COT12, COT12DD, COT13, COT13DD, COT14, COT14DD, COT15, COT15DD, COT16, COT16DD, COT17, COT17DD, COT18, COT18DD, COT19, COT19DD)
	SELECT DISTINCT STT , 
	CASE ISNULL(T2.TT_HMI,0)	--0- không chạy. 1- chậy,2 là có kế hoạch, 3 là không có kế hoạch ,4 là số lượn thực lớn hơn kế hoạch
	WHEN 0 THEN @sTTMayKhongSuDung 
	WHEN 1 THEN  @sTTMayChayTren 
	WHEN 2 THEN @sTTMayDungNgoaiCoKeHoach 
	WHEN 3 THEN @sTTMayDungNgoaiKeHoach
	WHEN 4 THEN @sTTMayChayDuoi
	END AS COTMAUNEN, -- tinh trang may
	@Ca AS COT0,@DDCa AS COT0DD,
	T2.MS_MAY AS COT1,@DD1 AS COT1DD,
	@sOEE AS COT2,  N'255;255;255;Arial;30px;T;F;T' AS COT2DD,
	T2.OEE + '%' AS COT3  ,N'255;255;255;Arial;30px;T;F;T' AS COT3DD, -- GIA TRI 0EE 
	@sTarget AS COT4, N'255;255;255;Arial;23px;F;F;F' AS COT4DD,
	T2.TargetOEE + '%'  AS COT5, N'255;255;255;Arial;23px;F;F;F' AS COT5DD, 
	@sPRODUCTION  AS COT6,N'255;255;255;Arial;20px;T;F;F' AS COT6DD, N'255;255;255' AS COT6MAUNEN,
	@sActual AS COT7, N'255;255;255;Arial;28px;T;F;T' AS COT7DD, 
	T2.Actual AS COT8, N'255;255;255;Arial;28px;T;F;T' AS COT8DD, 
	@sTarget AS COT9, N'255;255;255;Arial;23px;F;F;F' AS COT9DD, 
	T2.TargetPro AS COT10,  --TargetPro,
	N'255;255;255;Arial;23px;F;F;F' AS COT10DD, 
	@sUPTIME AS COT11, N'255;255;255;Arial;25px;T;F;T' AS  COT11DD,
	T2.UPTIME + '%' AS COT12, N'255;255;255;Arial;25px;T;F;T' AS  COT12DD, -- UPTIME,
	@sDowntime AS COT13, N'255;255;255;Arial;23px;F;F;F' AS COT13DD,
	T2.Dowtime + ' ' + @sPhut AS COT14, N'255;255;255;Arial;23px;F;F;F' COT14DD, --Dowtime
	 @sYield AS COT15, N'255;255;255;Arial;30px;T;F;T' AS  COT15DD,
	T2.Util + '%' AS COT16, N'255;255;255;Arial;30px;T;F;T' AS  COT16DD,--Yield  -   Util, 
	T2.Item AS COT17, N'255;255;255;Arial;20px;F;F;T' AS  COT17DD,
	@sUnplanned AS COT18,N'255;255;255;Arial;20px;T;F;F' AS  COT18DD,
	T2.Unplanned + ' ' + @sPhut AS COT19, N'255;255;255;Arial;20px;T;F;F' AS  COT19DD--Unplanned, 
	FROM #LCD_TMP T2
	ORDER BY T2.STT	
END
ELSE
BEGIN
INSERT INTO dbo.LCD_BD(STT, COTMAUCHUNG, COTMAUNEN, COT0, COT0DD, COT1, COT1DD, COT2, COT2DD, COT3, COT3DD, COT4, COT4DD, COT5, COT5DD, COT6, COT6DD, COT7, COT7DD, COT8, COT8DD, COT9BD, MAUBD, COT10BD, DNCOT9BD, DNCOT10BD)

--SELECT STT, N'255;255;255;100%;100vh;100%;5vh'COTMAUCHUNG, 
  --SELECT STT, N'255;255;255;100%;100vh;100%;5vh;25%'COTMAUCHUNG,
    SELECT STT, N'255;255;255;100%;100vh;100%;5vh;33%' AS COTMAUCHUNG, 
	--CASE ISNULL( CONVERT(INT,(RAND() * 4) + 1),0)
CASE ISNULL(T1.TT_HMI,0)	--0- không chạy. 1- chậy,2 là có kế hoạch, 3 là không có kế hoạch ,4 là số lượn thực lớn hơn kế hoạch
	WHEN 0 THEN @sTTMayKhongSuDung 
	WHEN 1 THEN @sTTMayChayTren
	WHEN 2 THEN @sTTMayDungNgoaiCoKeHoach 
	WHEN 3 THEN @sTTMayDungNgoaiKeHoach 
	WHEN 4 THEN @sTTMayChayDuoi 
	ELSE	@sTTMayKhongSuDung
	END AS COTMAUNEN, -- tinh trang may
@Ca AS COT0, N'0;0;0;Arial;30px;T;F;T' AS COT0DD,
T1.MS_MAY AS COT1, N'0;0;0;Arial;25px;F;F;T' AS COT1DD, 
T1.OEE + '%' AS COT2,N'0;0;0;Arial;25px;F;F;T' COT2DD, 
T1.Actual COT3, N'0;0;0;Arial;25px;F;F;T' COT3DD, 
T1.TargetOEE COT4, N'0;0;0;Arial;25px;F;F;T' COT4DD, 
T1.TargetPro COT5, N'0;0;0;Arial;25px;F;F;T' COT5DD, 
'' AS COT6, N'0;0;0;Arial;15px;F;F;F' AS COT6DD, 
'' AS COT7, N'0;0;0;Arial;15px;F;F;F' AS COT7DD, 
'' AS COT8, N'0;0;0;Arial;15px;F;F;F' AS COT8DD, 

T1.OEE AS COT9BD, 
--ABS(CHECKSUM(NewId())) % 100 AS COT9BD, 
'rgb(' + (
CASE ISNULL(T1.TT_HMI,0)	--0- không chạy. 1- chậy,2 là có kế hoạch, 3 là không có kế hoạch ,4 là số lượn thực lớn hơn kế hoạch
	WHEN 0 THEN REPLACE(@sTTMayKhongSuDung ,';',',')
	WHEN 1 THEN REPLACE(@sTTMayChayTren ,';',',')
	WHEN 2 THEN REPLACE(@sTTMayDungNgoaiCoKeHoach ,';',',')
	WHEN 3 THEN REPLACE(@sTTMayDungNgoaiKeHoach ,';',',')
	WHEN 4 THEN REPLACE(@sTTMayChayDuoi ,';',',')
	ELSE	REPLACE(@sTTMayKhongSuDung ,';',',')
	END ) + ')' AS 
	
	MAUBD, -- tinh trang may
T1.TargetOEE AS COT10BD, 
--ABS(CHECKSUM(NewId())) % 100 AS COT10BD, 
@sOEE DNCOT9BD, @sTarget DNCOT10BD FROM #LCD_TMP T1
    
END
END
	
