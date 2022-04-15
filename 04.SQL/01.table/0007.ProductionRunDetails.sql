if not exists(select * from sys.columns 
           where Name = N'RUN' and Object_ID = Object_ID(N'ProductionRunDetails'))
begin
ALTER TABLE dbo.ProductionRunDetails ADD RUN BIT END  