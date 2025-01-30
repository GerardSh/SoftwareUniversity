CREATE PROC usp_AssignProject(@emloyeeId INT, @projectID INT)
AS
BEGIN TRANSACTION
	DECLARE @countOfProjectsForTheEmployee INT = (SELECT COUNT(*) FROM EmployeesProjects WHERE EmployeeID = @emloyeeId);

	IF(@countOfProjectsForTheEmployee >= 3)
	BEGIN
		ROLLBACK;
		THROW 50003, 'The employee has too many projects!', 1
	END;

	INSERT INTO EmployeesProjects(EmployeeID, ProjectID) VALUES
		(@emloyeeId, @projectID);
COMMIT