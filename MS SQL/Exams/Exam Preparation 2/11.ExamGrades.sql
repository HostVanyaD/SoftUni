CREATE FUNCTION udf_ExamGradesToUpdate(@studentId INT, @grade DECIMAL(3,2))
RETURNS VARCHAR(70)
AS
BEGIN
	IF(NOT EXISTS(SELECT Id FROM Students WHERE Id = @studentId))
	RETURN 'The student with provided id does not exist in the school!'
	ELSE IF(@grade > 6.00)
	RETURN 'Grade cannot be above 6.00!'

	DECLARE @countOfGrades INT = 
			(SELECT COUNT(se.Grade) AS [COUNT]
			FROM Students AS s
			JOIN StudentsExams AS se ON s.Id = se.StudentId
			WHERE s.Id = @studentId
			  AND (se.Grade BETWEEN @grade AND (@grade + 0.50)))
	DECLARE @studentFirstName NVARCHAR(30) = (SELECT FirstName FROM Students WHERE Id = @studentId)

	RETURN CONCAT('You have to update ', @countOfGrades, ' grades for the student ', @studentFirstName)
END


