using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Data.Repositories;
using Test.Data.Context;
using Test.Entities.Models;
namespace Test.Web.Managers
{
    public class DatabaseInitializer
    {
        private CompanyRepository CompanyRepository { get; }

        public DatabaseInitializer (AppDbContext context)
        {
            CompanyRepository = new CompanyRepository(context);
        }


        public async Task InitializeCompany()
        {
            if (await CompanyRepository.IsEmpty())
            {
                Company company = new Company();
                await CompanyRepository.Create(company);
            }
        } 
    }
}
