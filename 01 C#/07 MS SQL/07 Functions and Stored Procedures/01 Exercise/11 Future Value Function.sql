CREATE FUNCTION ufn_CalculateFutureValue (@sum DECIMAL(15,4),
@yearlyInterestRate FLOAT, @numberOfYears INT)
RETURNS DECIMAL(15,4)
AS
BEGIN
	RETURN @sum * (POWER((1 + @yearlyInterestRate),@numberOfYears));
END