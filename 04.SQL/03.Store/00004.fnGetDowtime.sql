
ALTER FUNCTION [dbo].[fnGetDowtime]
(
	@MS_MAY NVARCHAR(30),
	@Ngay DATETIME = NULL,
	@Pland INT = 0
	--1 là có kế hoạch
	--0 là không có kế hoach
	-- -1 là cả 2
)
returns DECIMAL(18,2)
as 
begin
declare @Resulst DECIMAL(18,2)
	SET @Resulst =(SELECT SUM(A.THOI_GIAN_SUA_CHUA) AS SO_PHUT FROM dbo.THOI_GIAN_DUNG_MAY A
			INNER JOIN dbo.NGUYEN_NHAN_DUNG_MAY B ON B.MS_NGUYEN_NHAN = A.MS_NGUYEN_NHAN
			INNER JOIN dbo.DownTimeType C ON C.ID_DownTime = B.DownTimeTypeID
			WHERE dbo.fnGetNgayTheoCa(A.TU_GIO) = dbo.fnGetNgayTheoCa(@Ngay) AND (C.Planned = @Pland OR @Pland  = -1) AND A.MS_MAY =@MS_MAY AND (B.OEE = 1)
			/*trừ ra thằng nào không có đơn hàng*/
			GROUP BY CONVERT(DATE,A.TU_GIO),A.MS_MAY)
return ISNULL(@Resulst,0)
end
GO

