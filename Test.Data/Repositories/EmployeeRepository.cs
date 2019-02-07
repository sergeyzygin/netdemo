using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Data.Context;
using Test.Entities.Models;
namespace Test.Data.Repositories
{
    public class EmployeeRepository
    {

        private readonly AppDbContext db;

        public EmployeeRepository(AppDbContext context)
        {
            db = context;
        }

        public async Task<List<Employee>> Get()
        {
            return await db.Employees.AsNoTracking().Include(c => c.Chief).Include(s => s.Subordinates).ToListAsync();
        }

        public async Task<Employee> Get(Guid Id)
        {
            return await db.Employees.AsNoTracking().Where(e => e.Id == Id).Include(c => c.Chief).FirstOrDefaultAsync();
        }


        public async Task<List<Manager>> GetManagers()
        {
            return await db.Managers.AsNoTracking().Include(c => c.Chief).ToListAsync();
        }

        public async Task<List<Sales>> GetSales()
        {
            return await db.Sales.AsNoTracking().Include(c => c.Chief).ToListAsync();
        }

        public void Create(Employee employee)
        {
            db.Employees.Add(employee);
            db.SaveChanges();
        }
    }
}
