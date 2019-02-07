using System;
using System.Collections.Generic;
using System.Linq;
using Test.Entities.Models;

namespace Test.Entities.ViewModels
{
    public class CreateEmployeeViewModel
    {
        public List<EmployeeType> EmployeeTypes { get; } = EmployeeType.List().ToList();
        public List<Employee> Employees { get; set; }

        public string Name { get; set; }
        public int BasicSalary { get; set; }
        public DateTime DateDeployment { get; set; }
        public Guid? ChiefId { get; set; }
        public int EmployeeTypeValue { get; set; }
    }
}
