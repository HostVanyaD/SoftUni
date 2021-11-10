SELECT 
	CASE
		WHEN MiddleName IS NULL THEN CONCAT(FirstName, ' ', LastName)
		ELSE CONCAT(FirstName, ' ', MiddleName, ' ', LastName)
	END AS [Full Name]
FROM Students 
WHERE Id NOT IN (SELECT StudentId FROM StudentsSubjects)
ORDER BY [Full Name]
