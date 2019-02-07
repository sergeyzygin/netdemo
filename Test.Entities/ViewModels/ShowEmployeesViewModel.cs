using System.Collections.Generic;
using Test.Entities.Models;

namespace Test.Entities.ViewModels
{
    public class ShowEmployeesViewModel
    {
        public List<Employee> Employees {get; set;}
        public Company Company { get; set; }
    }
}
