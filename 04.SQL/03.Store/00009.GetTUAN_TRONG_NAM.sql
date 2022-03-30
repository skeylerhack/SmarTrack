

ALTER procedure [dbo].[GetTUAN_TRONG_NAM]
@TU_NGAY NVARCHAR(10) ='01/01/2022',
@NGAY_CUOI NVARCHAR(10)='31/12/2022',
@TYPE INT =0
AS
IF EXISTS (SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES  WHERE TABLE_NAME = 'tmpTUAN_TRONG_NAM')
begin
   	DROP TABLE tmpTUAN_TRONG_NAM
end

declare @ngay datetime
declare @stt int
set @stt=1
set @ngay=dateadd(day,9- datepart(dw,convert(datetime,@TU_NGAY,103)),convert(datetime,@TU_NGAY,103))
declare @str nvarchar(255)
CREATE TABLE DBO.tmpTUAN_TRONG_NAM(TUAN INT,TEN_TUAN NVARCHAR(255))

INSERT INTO tmpTUAN_TRONG_NAM VALUES(@stt,CASE @TYPE WHEN 0 THEN N'Tuần ' else N'Week ' end + convert(nvarchar(3),@stt)+ ' '+@TU_NGAY +'_'+ convert(nvarchar(10),dateadd(day,8- datepart(dw,convert(datetime,@TU_NGAY,103)),convert(datetime,@TU_NGAY,103)),103) )
while @ngay<convert(datetime,@NGAY_CUOI,103)
begin
	set @stt=@stt+1
	INSERT INTO tmpTUAN_TRONG_NAM VALUES(@stt,CASE @TYPE WHEN 0 THEN N'Tuần ' else N'Week ' end + convert(nvarchar(3),@stt)+ ' '+convert(nvarchar(10),@ngay,103) +'_'+ case when dateadd(day,6,@ngay)>convert(datetime,@NGAY_CUOI,103)THEN @NGAY_CUOI ELSE convert(nvarchar(10),dateadd(day,6,@ngay),103)END )
	set @ngay=dateadd(day,7,@ngay)
continue
end
select * from   tmpTUAN_TRONG_NAM
DROP TABLE tmpTUAN_TRONG_NAM
