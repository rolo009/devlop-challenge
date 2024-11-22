DROP TABLE employee;

CREATE TABLE employee (
    id int PRIMARY KEY IDENTITY,
    salary int
);

INSERT INTO Employee (salary)
VALUES (100), (500), (300), (1000), (2400);

DROP FUNCTION GetNthHighestSalary;

CREATE FUNCTION GetNthHighestSalary (@N INT)
RETURNS INT
AS
BEGIN
	IF NOT EXISTS (
        SELECT 1
        FROM Employee
        WHERE ID = @N
    )
    BEGIN
        -- Se não houver registros com ID < N, retornar NULL
        RETURN NULL;
    END

    DECLARE @MaxSalary INT;

    -- Obtém o maior salário com ID menor que N
    SELECT TOP 1 @MaxSalary = Salary
    FROM Employee
    WHERE ID <= @N
    ORDER BY Salary DESC;  -- Ordena para pegar o maior salário

    RETURN @MaxSalary;
END;

SELECT dbo.GetNthHighestSalary(5);

