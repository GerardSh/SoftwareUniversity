CREATE PROC usp_TransferMoney(@SenderId INT, @ReceiverId INT, @Amount MONEY)
AS
BEGIN TRANSACTION

EXEC dbo.usp_WithdrawMoney @SenderId, @Amount
EXEC dbo.usp_DepositMoney @ReceiverId, @Amount

COMMIT