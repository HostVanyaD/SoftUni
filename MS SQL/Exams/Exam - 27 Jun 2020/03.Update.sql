SELECT *
FROM Mechanics
WHERE [FirstName] = 'Ryan' AND [LastName] = 'Harnos'

UPDATE [Jobs]
SET [MechanicId] = 3 , [Status] = 'In Progress'
WHERE [Status] = 'Pending'