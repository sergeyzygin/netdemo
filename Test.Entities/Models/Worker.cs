

namespace Test.Entities.Models
{
    public class Worker : Employee
    {
        public override EmployeeType EmployeeType { get; } = EmployeeType.Worker;

        public override decimal GetSalary()
        {
            return base.GetSalary() + base.GetSalaryRateForEachYear();
        }
    }
}
