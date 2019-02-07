using System.Collections.Generic;

namespace Test.Entities.Models
{
    public class Sales : Employee
    {
        public override EmployeeType EmployeeType { get; } = EmployeeType.Sales;

        public override decimal GetSalary()
        {
            decimal basicSalary = base.GetSalary();
            decimal rateForRachYear = base.GetSalaryRateForEachYear();
            decimal subordinatesSalary = GetSubordinatesSalary();

            return basicSalary + rateForRachYear + subordinatesSalary;
        }

        public override decimal GetSubordinatesSalary()
        {
            List<Employee> employees = GetAllSubordinate();
            decimal salary = 0;
            if (employees != null)
            {
                foreach (Employee emp in employees)
                {
                    salary += emp.GetSalary();
                }
            }
            return salary / 100 * EmployeeType.SalaryRateSubordinates;
        }
    }
}
