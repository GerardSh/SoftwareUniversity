CREATE TABLE NotificationEmails
(
Id INT PRIMARY KEY IDENTITY,
Recipient INT NOT NULL,
[Subject] VARCHAR(60),
Body VARCHAR(MAX) NOT NULL
)

CREATE TRIGGER tr_GenerateEmail
ON Logs FOR INSERT
AS
 INSERT INTO NotificationEmails
 SELECT 
 i.AccountId, 
 CONCAT_WS(' ', 'Balance change for account:', i.AccountId),
 CONCAT_WS(' ', 'On', GETDATE(), 'your balance was changed from', i.OldSum, 'to', i.NewSum + '.')
 FROM inserted AS i