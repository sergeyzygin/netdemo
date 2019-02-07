using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Test.Data.Context;
using Test.Data.Repositories;
using Test.Entities.ViewModels;
using Test.Entities.Models;
using System.Threading.Tasks;

namespace Test.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeRepository EmployeeRepository;
        private readonly CompanyRepository CompanyRepository;

        public EmployeeController(AppDbContext context)
        {
            EmployeeRepository = new EmployeeRepository(context);
            CompanyRepository = new CompanyRepository(context);
        }

        public async Task<IActionResult> Index()
        {
            var view = new ShowEmployeesViewModel
            {
                Company = await CompanyRepository.Get(1),
                Employees = await EmployeeRepository.Get()
            };

            return View(view);
        }

        public async Task<IActionResult> Create()
        {
            CreateEmployeeViewModel viewModel = new CreateEmployeeViewModel();
            await ConfigureEmployeeViewModel(viewModel);
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateEmployeeViewModel viewModel)
        {
            if (ModelState.IsValid)
            {

                Employee employee;
                if (viewModel.EmployeeTypeValue == EmployeeType.Manager.Value)
                {
                    employee = new Manager();
                }else if (viewModel.EmployeeTypeValue == EmployeeType.Sales.Value)
                {
                    employee = new Sales();
                }else
                {
                    employee = new Worker();
                }
                employee.Name = viewModel.Name;
                employee.BasicSalary = viewModel.BasicSalary;
                employee.DateDeployment = viewModel.DateDeployment;
                employee.ChiefId = viewModel.ChiefId;
                EmployeeRepository.Create(employee);
                return RedirectToAction("Index");
            }
            await ConfigureEmployeeViewModel(viewModel);
            return View(viewModel);
        }

        private async Task ConfigureEmployeeViewModel(CreateEmployeeViewModel viewModel)
        {
            var employees = new List<Employee>();
            employees.AddRange(await EmployeeRepository.GetManagers());
            employees.AddRange(await EmployeeRepository.GetSales());
            viewModel.Employees = employees;
        }
    }
}
