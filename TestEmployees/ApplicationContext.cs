using Microsoft.EntityFrameworkCore;
using TestEmployees.Models;

namespace TestEmployees
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasAlternateKey(e => e.Name);
        }
    }
}
