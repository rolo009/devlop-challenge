DROP TABLE employee;

CREATE TABLE employee (
    id int PRIMARY KEY IDENTITY,
    salary int
);

INSERT INTO Employee (salary)
VALUES (100), (500), (300), (1000), (2400);

DROP FUNCTION GetNthHighestSalary;
-- Create a function to get the N-th highest salary
CREATE FUNCTION GetNthHighestSalary (@N INT)
RETURNS INT
AS
BEGIN
-- Check if the provided ID (N) exists in the Employee table. If not, return NULL
	IF NOT EXISTS (
        SELECT 1
        FROM Employee
        WHERE ID = @N
    )
    RETURN NULL;
	
	-- Variable to store the highest salary
    DECLARE @MaxSalary INT;

    -- Get the highest salary where the ID is less than or equal to N
	-- Sort the salaries in descending order and select the first (highest) salary
    SELECT TOP 1 @MaxSalary = Salary
    FROM Employee
    WHERE ID <= @N
    ORDER BY Salary DESC;  -- Sorting in descending order to get the highest salary

	-- Return the found salary
    RETURN @MaxSalary;
END;

SELECT dbo.GetNthHighestSalary(2) AS 'GetNthHighestSalary(2)';

