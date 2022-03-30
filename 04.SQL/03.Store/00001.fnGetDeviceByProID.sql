CREATE FUNCTION [dbo].[fnGetDeviceByProID]
(
	@ProID BIGINT,
	@DetailsID BIGINT
)
RETURNS NVARCHAR(1000)
AS
BEGIN
DECLARE @May Nvarchar(1000)

SELECT @May =COALESCE(@May + ' - ', '') +
CAST(MS_MAY AS Nvarchar(1000))
FROM 
(
	SELECT MS_MAY FROM dbo.ProSchedule WHERE PrOID = @ProID AND DetailsID = @DetailsID
)T
RETURN @May
END



