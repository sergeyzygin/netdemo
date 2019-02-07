using Microsoft.EntityFrameworkCore;
using Test.Entities.Models;
namespace Test.Data.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Company> Companies { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Sales> Sales { get; set; }

        protected override void OnModelCreating(Microsoft.EntityFrameworkCore.ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
            .HasDiscriminator<string>("Type")
            .HasValue<Worker>(EmployeeType.Worker.Title)
            .HasValue<Manager>(EmployeeType.Manager.Title)
            .HasValue<Sales>(EmployeeType.Sales.Title);
        }

        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
        }
    }
}
