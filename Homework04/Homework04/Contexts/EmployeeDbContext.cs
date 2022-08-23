using Homework04.Models.Repository;
using Microsoft.EntityFrameworkCore;

namespace Homework04.Contexts
{
    internal sealed class EmployeeDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Database=testdb;Username=postgres;Password=1234;");
        }
    }
}
