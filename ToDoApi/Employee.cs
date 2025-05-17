public abstract class Employee
{
    public string Name { get; }

    protected Employee(string name) => Name = name;

    public abstract decimal CalculateSalary();
}

public class HourlyEmployee : Employee
{
    private readonly decimal _hourRate;
    public int HoursWorked { get; }

    public HourlyEmployee(string name, decimal hourRate, int hours)
        : base(name) => (_hourRate, HoursWorked) = (hourRate, hours);

    public override decimal CalculateSalary() =>
        _hourRate * HoursWorked;
}

public class SalariedEmployee : Employee
{
    private readonly decimal _monthlyRate;
    public int MonthsWorked { get; }

    public SalariedEmployee(string name, decimal monthlyRate, int months)
        : base(name) => (_monthlyRate, MonthsWorked) = (monthlyRate, months);

    public override decimal CalculateSalary() =>
        _monthlyRate * MonthsWorked;
}