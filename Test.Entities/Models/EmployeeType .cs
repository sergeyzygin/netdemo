using System.Collections.Generic;

namespace Test.Entities.Models
{
    public class EmployeeType
    {
        public static EmployeeType Worker { get; } = new EmployeeType(1, "Worker", 3, 30, 0);
        public static EmployeeType Manager { get; } = new EmployeeType(2, "Manager", 5, 40, 0.5m);
        public static EmployeeType Sales { get; } = new EmployeeType(3, "Sales", 1, 35, 0.3m);

        public int Value { get; }
        public string Title { get; }
        public decimal SalaryRateForEachYear { get; }
        public decimal MaxSalaryRateForEachYear { get; }
        public decimal SalaryRateSubordinates { get; }

        private EmployeeType(int value, string title, decimal salaryRateForEachYear, decimal maxSalaryRateForEachYear, decimal salaryRateSubordinates)
        {
            Value = value;
            Title = title;
            SalaryRateForEachYear = salaryRateForEachYear;
            MaxSalaryRateForEachYear = maxSalaryRateForEachYear;
            SalaryRateSubordinates = salaryRateSubordinates;
        }

        public static IEnumerable<EmployeeType> List()
        {
            return new[] { Worker, Manager, Sales };
        }
    }
}