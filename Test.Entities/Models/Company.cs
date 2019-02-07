using System.Collections.Generic;

namespace Test.Entities.Models
{
    public class Company
    {
        public int Id { get; set; }
        public List<Employee> Employees { get; set; }

        public decimal GetSalaryAllEmployees()
        {
            decimal salary = 0;
            foreach (Employee e in Employees)
            {
                salary += e.GetSalary();
            }
            return salary;
        }
    }
}
