ALTER	PROCEDURE [dbo].[spDownTimeType]
	@Loai NVARCHAR(50) = 'grd',
	@ID BIGINT = 3,
	@DownTimeTypeName NVARCHAR(250) = '-1',
	@DownTimeTypeNameA NVARCHAR(250) = '-1',
	@DownTimeTypeNameH NVARCHAR(250) = '-1',
	@Note NVARCHAR(500) = '-1',
	@HMIType BIT = 1,
	@Planned BIT = 0
AS
BEGIN
--Get luoi 
IF UPPER(@Loai) = UPPER('Grd')
BEGIN
   SELECT ID_DownTime, DownTimeTypeName, DownTimeTypeNameA, DownTimeTypeNameH, Note,ISNULL(HMIType,0) AS HMIType,Planned, ISNULL(NoEdit, 0) AS NoEdit FROM dbo.DownTimeType ORDER BY DownTimeTypeName
END

--Save
IF UPPER(@Loai) = UPPER('Save')
BEGIN
--THEM
	IF @ID = -1
	BEGIN
		INSERT INTO	dbo.DownTimeType ( DownTimeTypeName, DownTimeTypeNameA,
		                            DownTimeTypeNameH, Note,HMIType,Planned)
		VALUES(@DownTimeTypeName,@DownTimeTypeNameA,@DownTimeTypeNameH, @Note,@HMIType,@Planned)
		SELECT SCOPE_IDENTITY();
	END
--SUA
	ELSE
	BEGIN
		UPDATE dbo.DownTimeType SET DownTimeTypeName = @DownTimeTypeName,DownTimeTypeNameA = @DownTimeTypeNameA,DownTimeTypeNameH = @DownTimeTypeNameH, Note = @Note,HMIType =@HMIType,Planned = @Planned
		WHERE ID_DownTime = @ID
		SELECT @ID;
	END
	END

--Delete 
IF UPPER(@Loai) = UPPER('Delete')
BEGIN
	IF EXISTS (SELECT	* FROM dbo.NGUYEN_NHAN_DUNG_MAY WHERE DownTimeTypeID = @ID)
	BEGIN
		SELECT 1 AS TT		
	END
	ELSE
	BEGIN
		DELETE dbo.DownTimeType WHERE ID_DownTime = @ID
		DBCC CHECKIDENT (DownTimeType,RESEED,0)
		DBCC CHECKIDENT (DownTimeType,RESEED)
		SELECT 0 AS TT		
	END
END	

END


