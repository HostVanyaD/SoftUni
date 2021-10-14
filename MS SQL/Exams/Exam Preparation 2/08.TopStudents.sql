SELECT TOP(10) 
	 s.FirstName
	,s.LastName
	,CAST(AVG(se.Grade) AS DECIMAL (3,2)) AS Grade
FROM StudentsExams AS se
JOIN Students AS s ON s.Id = se.StudentId
GROUP BY s.FirstName, s.LastName
ORDER BY Grade DESC, s.FirstName, s.LastName

