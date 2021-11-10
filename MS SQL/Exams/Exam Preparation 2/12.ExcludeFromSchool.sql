CREATE PROC usp_ExcludeFromSchool(@StudentId INT)
AS
BEGIN
	IF(NOT EXISTS(SELECT Id FROM Students WHERE Id = @StudentId))
		THROW 50001,'This school has no student with the provided id!',1

	DELETE FROM StudentsSubjects
	WHERE StudentId = @StudentId

	DELETE FROM StudentsExams
	WHERE StudentId = @StudentId

	DELETE FROM StudentsTeachers
	WHERE StudentId = @StudentId

	DELETE FROM Students
	WHERE Id = @StudentId
END


