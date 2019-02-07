using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Test.Common.Extensions;

namespace Test.Entities.Models
{
    public abstract class Employee
    {
        public Guid Id { get; set; }
        public int CompanyId { get; set; } = 1;
        public Guid? ChiefId { get; set; }
        public string Name { get; set; }
        public DateTime DateDeployment { get; set; }
        public int BasicSalary { get; set; }
        public List<Employee> Subordinates { get; set; }
        [ForeignKey("ChiefId")]
        public virtual Employee Chief { get; set; }
        public virtual EmployeeType EmployeeType { get; } = null;
        
        public virtual decimal GetSalary()
        {
            return GetBasicSalary();
        }

        public virtual decimal GetSubordinatesSalary()
        {
            return 0;
        }

        public decimal GetBasicSalary()
        {
            return BasicSalary / 100;
        }

        public List<Employee> GetAllSubordinate()
        {
            List<Employee> employees = new List<Employee>();
            if (Subordinates != null)
            {
                foreach (Employee e in Subordinates)
                {
                    employees.Add(e);
                    employees.AddRange(e.GetAllSubordinate());
                }
            }
            return employees;
        }

        public decimal GetSalaryRateForEachYear()
        {
            decimal percent = EmployeeType.SalaryRateForEachYear * DatetimeExtension.GetYearLeft(DateDeployment);
            percent = percent > EmployeeType.MaxSalaryRateForEachYear ? EmployeeType.MaxSalaryRateForEachYear : percent;
            return GetBasicSalary() / 100 * percent;
        }
    }
}