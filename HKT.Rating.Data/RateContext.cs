using HKT.Rating.Entity;
using Microsoft.EntityFrameworkCore;

namespace HKT.Rating.Data
{
    public class RateContext : DbContext
    {
        public RateContext(DbContextOptions<RateContext> options)
            : base(options)
        {
            //Database.EnsureCreated();
        }

        DbSet<RatingCategory> RatingCategories { get; set; }

        DbSet<Entity.Rating> Ratings { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<RatingCategory>()
             .ForSqlServerToTable("RatingCategory");

            modelBuilder.Entity< Entity.Rating> ()
               .ForSqlServerToTable("EmployeeRate");



        }
    }
}
