using EMS.Model.DataModel;
using Microsoft.EntityFrameworkCore;

namespace EMS.Repository.Context
{
    public class EMSDbContext : DbContext
    {
        public EMSDbContext(DbContextOptions options) : base(options){}

        public DbSet <Employee> Employees { get; set; }
        public DbSet<Department> Department { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Department)
                .WithMany(d => d.Employees)
                .HasForeignKey(e => e.DepartmentId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
