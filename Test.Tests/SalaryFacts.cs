using System;
using Xunit;
using Test.Entities.Models;
using System.Collections.Generic;

namespace Test.Tests
{
    public class SalaryFacts
    {
        [Fact]
        public void SalaryWorker()
        {
            var worker = new Worker()
            {
                Name = "Worker",
                BasicSalary = 10000,
                DateDeployment = DateTime.Now.AddYears(-14)
            };

            decimal expected = 130;
            decimal actual = worker.GetSalary();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SalaryManager()
        {
            var testItem = new Manager()
            {
                Name = "Manager",
                BasicSalary = 20000,
                DateDeployment = DateTime.Now.AddYears(-18),
                Subordinates = GetTestSubWorkers()
            };

            decimal expected = 282.6m;
            decimal actual = testItem.GetSalary();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SalarySales()
        {
            var testItem = new Sales()
            {
                Name = "Sales",
                BasicSalary = 30000,
                DateDeployment = DateTime.Now.AddYears(-35),
                Subordinates = GetTestSubManager()
            };

            //decimal sw = 16 * 100 + (16 * 100 * 0.3m);
            //decimal sm = 4 * 200 + (sw / 100 * 0.5m) + (4 * 200 * 0.35m);
            //decimal ss = 300 + ((sw + sm) / 100 * 0.3m) + (300 * 0.35m);

            decimal expected = 414.5112m;
            decimal actual = testItem.GetSalary();

            Assert.Equal(expected, actual);
        }

        private List<Employee> GetTestSubWorkers()
        {
            var workers = new List<Employee>
            {
                new Worker { Name="Worker1", BasicSalary = 10000, DateDeployment = DateTime.Now.AddYears(-14) },
                new Worker { Name="Worker2", BasicSalary = 10000, DateDeployment = DateTime.Now.AddYears(-14) },
                new Worker { Name="Worker3", BasicSalary = 10000, DateDeployment = DateTime.Now.AddYears(-14) },
                new Worker { Name="Worker4", BasicSalary = 10000, DateDeployment = DateTime.Now.AddYears(-14) },
            };
            return workers;
        }

        private List<Employee> GetTestSubManager()
        {
            var managers = new List<Employee>
            {
                new Manager { Name="Manager1", BasicSalary = 20000, DateDeployment = DateTime.Now.AddYears(-7), Subordinates = GetTestSubWorkers() },
                new Manager { Name="Manager2", BasicSalary = 20000, DateDeployment = DateTime.Now.AddYears(-7), Subordinates = GetTestSubWorkers() },
                new Manager { Name="Manager4", BasicSalary = 20000, DateDeployment = DateTime.Now.AddYears(-7), Subordinates = GetTestSubWorkers() },
                new Manager { Name="Manager4", BasicSalary = 20000, DateDeployment = DateTime.Now.AddYears(-7), Subordinates = GetTestSubWorkers() }
            };
            return managers;
        }

    }
}