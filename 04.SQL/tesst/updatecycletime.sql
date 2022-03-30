ALTER TABLE ProSchedule ALTER COLUMN WorkingCycle NUMERIC(18,2)

ALTER TABLE ProductionRunDetails ALTER COLUMN WorkingCycle NUMERIC(18,2)

 UPDATE A
 SET A.WorkingCycle = C.WorkingCycle
 FROM dbo.ProSchedule A
 INNER JOIN dbo.PrODetails B ON B.DetailsID = A.DetailsID
 INNER JOIN dbo.ItemMay C ON C.MS_MAY = A.MS_MAY AND C.ItemID = B.ItemID

 UPDATE A
 SET A.WorkingCycle = B.WorkingCycle
 FROM dbo.ProductionRunDetails A
 INNER JOIN dbo.ItemMay B ON A.MS_MAY = B.MS_MAY AND A.ItemID = B.ItemID