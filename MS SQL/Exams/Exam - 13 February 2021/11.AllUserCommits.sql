CREATE FUNCTION udf_AllUserCommits(@username VARCHAR(30))
RETURNS INT
AS
BEGIN
	DECLARE @countOfCommits INT = 
			(SELECT COUNT(c.Id)
			   FROM Users AS u
			   JOIN Commits AS c ON u.Id = c.ContributorId
			  WHERE u.Username = @username)

	RETURN @countOfCommits
END