using Microsoft.EntityFrameworkCore;
using HKT.Employee.Entity;

namespace HKT.Employee.Data
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options)
            : base(options)
        {
            //Database.EnsureCreated();
        }
        DbSet<Department> Departments { get; set; }

        DbSet<Entity.Employee> Employees { get; set; }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Department>()
             .ForSqlServerToTable("Department");

            modelBuilder.Entity<Entity.Employee>()
               .ForSqlServerToTable("Employee");           

            modelBuilder.Entity<Entity.Employee>()
             .HasOne(p => p.Department);
            

        }
    }
}
