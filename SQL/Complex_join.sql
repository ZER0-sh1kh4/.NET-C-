SELECT D.DeptName, E.Salary AS HighestSalary, E.Name AS EmployeeName
FROM Employees E
JOIN Department D ON E.DeptId = D.DeptId
WHERE E.Salary = (SELECT MAX(E2.Salary) FROM Employees E2 WHERE E2.DeptId = E.DeptId)
AND E.DeptId IN (SELECT DeptId FROM Employees GROUP BY DeptId HAVING AVG(Salary) > 70000);
