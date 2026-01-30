using System;

class Employee
{
    public virtual decimal GetPay()
    {
        return 0;
    }
}
class HourlyEmployee : Employee
{
    decimal rate, hours;
    public HourlyEmployee(decimal rate, decimal hours)
    {
        this.rate = rate;
        this.hours = hours;
    }
    public override decimal GetPay()
    {
        return rate * hours;
    }
}
class SalariedEmployee : Employee
{
    decimal salary;

    public SalariedEmployee(decimal salary)
    {
        this.salary = salary;
    }
    public override decimal GetPay()
    {
        return salary;
    }
}
class CommissionEmployee : Employee
{
    decimal commission, baseSalary;
    public CommissionEmployee(decimal commission, decimal baseSalary)
    {
        this.commission = commission;
        this.baseSalary = baseSalary;
    }
    public override decimal GetPay()
    {
        return baseSalary + commission;
    }
}
class Program
{
    static decimal CalculateTotalPay(string[] employees)
    {
        decimal total = 0;

        for (int i = 0; i < employees.Length; i++)
        {
            string[] parts = employees[i].Split(' ');
            Employee emp = null;

            if (parts[0] == "H")
            {
                decimal rate = Convert.ToDecimal(parts[1]);
                decimal hours = Convert.ToDecimal(parts[2]);
                emp = new HourlyEmployee(rate, hours);
            }
            else if (parts[0] == "S")
            {
                decimal salary = Convert.ToDecimal(parts[1]);
                emp = new SalariedEmployee(salary);
            }
            else if (parts[0] == "C")
            {
                decimal commission = Convert.ToDecimal(parts[1]);
                decimal baseSalary = Convert.ToDecimal(parts[2]);
                emp = new CommissionEmployee(commission, baseSalary);
            }

            total += emp.GetPay();
        }

        return Math.Round(total, 2);
    }

    static void Main()
    {
        string[] employees =
        {
            "H 20 40",
            "S 300",
            "C 500 200"
        };
        decimal totalPay = CalculateTotalPay(employees);
        Console.WriteLine(totalPay);
    }
}
