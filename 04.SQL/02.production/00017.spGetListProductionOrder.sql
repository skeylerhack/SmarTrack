
ALTER PROCEDURE [dbo].[spGetListProductionOrder]
	@TuNgay DATE = '10/19/2020',
	@DenNgay DATE  ='10/31/2020',
	@USERNAME NVARCHAR(250) ='admin',
	@NNgu INT = 0
AS 
BEGIN
SELECT ID, PrOrNumber, OrderDate, StartDate, DueDate, Status, Note FROM dbo.ProductionOrder
WHERE CONVERT(DATE,StartDate) BETWEEN @TuNgay AND @DenNgay 	
ORDER BY PrOrNumber DESC
END
