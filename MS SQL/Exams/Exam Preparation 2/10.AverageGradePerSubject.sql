SELECT 
	s.[Name]
	,AVG(ss.Grade) AS AverageGrade
FROM Subjects AS s
JOIN StudentsSubjects AS ss ON s.Id = ss.SubjectId
GROUP BY ss.SubjectId, s.[Name]
ORDER BY ss.SubjectId
