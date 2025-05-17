public abstract class Employee
{
    public string Name { get; }
    public decimal BaseRate { get; }

    protected Employee(string name, decimal baseRate) =>
        (Name, BaseRate) = (name, baseRate);
}

public class HourlyEmployee : Employee
{
    public int HoursWorked { get; }

    public HourlyEmployee(string name, decimal rate, int hours)
        : base(name, rate) => HoursWorked = hours;

    public decimal CalculateSalary() =>
        BaseRate * HoursWorked;
}

public class SalariedEmployee : Employee
{
    public int MonthsWorked { get; }

    public SalariedEmployee(string name, decimal rate, int months)
        : base(name, rate) => MonthsWorked = months;

    public decimal CalculateSalary() =>
        BaseRate * MonthsWorked;
}