SELECT Dept, Name, Salary
FROM Employees E
WHERE Salary = (
    SELECT MAX(Salary)
    FROM Employees
    WHERE Dept = E.Dept
);
