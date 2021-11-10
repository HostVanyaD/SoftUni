SELECT 
	 p.PartId
	,p.Description
	,pn.Quantity AS Required
	,p.StockQty AS [In Stock]
	,ISNULL(op.[Quantity], 0) AS [Ordered]
FROM Jobs AS j
LEFT JOIN PartsNeeded AS pn ON j.JobId = pn.JobId
LEFT JOIN Parts AS p ON p.PartId = pn.PartId
LEFT JOIN Orders AS o ON o.JobId = j.JobId
LEFT JOIN OrderParts AS op ON op.OrderId = o.OrderId
WHERE J.Status != 'Finished' AND pn.Quantity > p.StockQty AND (o.[Delivered] = 0 OR o.Delivered IS NULL)
ORDER BY p.PartId