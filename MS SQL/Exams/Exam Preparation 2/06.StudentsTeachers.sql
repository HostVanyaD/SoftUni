SELECT 
	 s.FirstName
	,s.LastName
	,COUNT(st.TeacherId) AS TeachersCount
FROM Students AS s
JOIN StudentsTeachers AS st ON s.Id = st.StudentId
GROUP BY s.Id, s.FirstName, s.LastName
ORDER BY s.LastName

