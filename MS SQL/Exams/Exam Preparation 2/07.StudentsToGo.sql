SELECT CONCAT(s.FirstName, ' ', s.LastName) AS [Full Name]
FROM Students AS s
LEFT JOIN StudentsExams AS se ON s.Id = se.StudentId
WHERE se.ExamId IS NULL
ORDER BY s.FirstName

