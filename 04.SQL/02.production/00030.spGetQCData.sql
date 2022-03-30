
ALTER PROCEDURE [dbo].[spGetQCData]
	@TuNgay DATE = '10/19/2020',
	@DenNgay DATE  ='10/31/2020',
	@USERNAME NVARCHAR(250) ='admin',
	@NNgu INT = 0
AS 
BEGIN
	SELECT ID, DocNum, QCName, QCDate, CheckStepID, ID_CA, ProductionDate FROM dbo.QCData 
	WHERE CONVERT(DATE,QCDate) BETWEEN @TuNgay AND @DenNgay 	
	ORDER BY DocNum DESC
END
