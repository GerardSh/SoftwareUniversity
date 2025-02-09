SELECT Id, FORMAT(OrderDate, 'MM-dd'), CustomerId, StoreId, ProductId
FROM Orders
WHERE OrderDate > '2025-01-01'
ORDER BY OrderDate DESC, CustomerId, StoreId, ProductId