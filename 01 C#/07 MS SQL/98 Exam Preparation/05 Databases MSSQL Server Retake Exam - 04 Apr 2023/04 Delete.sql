DELETE Invoices
WHERE ClientId IN (SELECT Id FROM Clients WHERE NumberVat LIKE 'IT%')

DELETE ProductsClients
WHERE ClientId IN (SELECT Id FROM Clients WHERE NumberVat LIKE 'IT%')

DELETE Clients
WHERE NumberVat LIKE 'IT%'