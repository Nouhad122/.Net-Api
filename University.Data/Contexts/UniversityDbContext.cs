using Microsoft.EntityFrameworkCore;
using University.Data.ClassMappings;
using University.Data.Entities;

namespace University.Data.Contexts
{
    public class UniversityDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\ProjectModels;Initial Catalog=UniversityDB;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StudentMapping());
        }
    }
}
