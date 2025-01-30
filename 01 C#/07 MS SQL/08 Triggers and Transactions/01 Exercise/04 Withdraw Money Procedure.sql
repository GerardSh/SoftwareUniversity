CREATE PROC usp_WithdrawMoney(@AccountId INT, @MoneyAmount MONEY) 
AS
BEGIN TRANSACTION

UPDATE Accounts 
SET Balance -= @MoneyAmount 
WHERE Id = @AccountId;

IF @@ROWCOUNT <> 1 
BEGIN
    ROLLBACK
    RETURN
END

DECLARE @NewBalance MONEY;
SELECT @NewBalance = Balance FROM Accounts WHERE Id = @AccountId;

IF @NewBalance <= 0
BEGIN
    ROLLBACK
    RETURN
END

COMMIT