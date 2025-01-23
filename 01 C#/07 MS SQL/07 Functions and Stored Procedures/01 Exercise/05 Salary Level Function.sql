CREATE FUNCTION ufn_GetSalaryLevel(@Salary DECIMAL(18,4))
RETURNS VARCHAR(7)
AS
BEGIN
	DECLARE @salaryLevel VARCHAR(10)
	IF(@salary < 30000)
	BEGIN
		SET @salaryLevel = 'Low'
	END

	 ELSE IF(@salary <= 50000)
	 BEGIN
		SET @salaryLevel = 'Average'
	 END

	 ELSE 
	 BEGIN
		SET @salaryLevel = 'High'
	 END

	 RETURN @salaryLevel;
END