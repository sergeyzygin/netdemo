
namespace Test.Entities.Models
{
    public class Manager : Employee
    {
        public override EmployeeType EmployeeType { get; } = EmployeeType.Manager;

        public override decimal GetSalary()
        {
            decimal basicSalary = base.GetSalary();
            decimal rateForRachYear = base.GetSalaryRateForEachYear();
            decimal subordinatesSalary = GetSubordinatesSalary();

            return basicSalary + rateForRachYear + subordinatesSalary;
        }

        public override decimal GetSubordinatesSalary()
        {
            decimal salary = 0;
            if (Subordinates != null)
            {
                foreach (Employee emp in Subordinates)
                {
                    salary += emp.GetSalary();
                }
            }
            return salary / 100 * EmployeeType.SalaryRateSubordinates;
        }
    }
}
