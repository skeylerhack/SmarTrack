SELECT DetailID, 
ActualQuantity, 
ISNULL([dbo].fnGetUptimeReport(DetailID, -1), 0) AS ActualOperatingTime, StandardOutput, 
(StandardOutput / 60) AS IdeaRunRate, 
--((ActualQuantity / ISNULL([dbo].fnGetUptimeReport(DetailID, -1), 0)) / (StandardOutput / 60)) * 100 AS Performance
((ISNULL(ActualQuantity, 0) / ISNULL(ISNULL([dbo].fnGetUptimeReport(DetailID, -1), 0), 0)) / (ISNULL(StandardOutput, 0) / 60) * 100) AS Performance
FROM dbo.ProductionRunDetails WHERE dbo.fnGetNgayTheoCa(StartTime) = '2022-04-04' AND MS_MAY = 'IMM-01'