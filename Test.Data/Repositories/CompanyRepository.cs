using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Data.Context;
using Test.Entities.Models;
namespace Test.Data.Repositories
{
    public class CompanyRepository
    {
        private readonly AppDbContext db;

        public CompanyRepository(AppDbContext context)
        {
            db = context;
        }

        public async Task<bool> IsEmpty()
        {
            return !(await db.Companies.AnyAsync());
        }

        public async Task<Company> Get(int Id)
        {
            return await db.Companies.AsNoTracking().Where(e => e.Id == Id).Include(e => e.Employees).ThenInclude(e => e.Subordinates).FirstOrDefaultAsync();
        }

        public async Task Create(Company company)
        {
            db.Companies.Add(company);
            await db.SaveChangesAsync();
        }
    }
}
