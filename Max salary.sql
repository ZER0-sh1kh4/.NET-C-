select e.Dept, e.Name , e.Salary from Employee e join(select Dept, max(Salary) as maxx from Employee  group by Dept)m  on e.Dept = m.Dept and e.Salary = m.maxx;
