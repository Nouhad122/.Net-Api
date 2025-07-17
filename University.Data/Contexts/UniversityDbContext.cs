using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using University.Data.ClassMappings;
using University.Data.Entities;
using University.Data.Entities.Identity;

namespace University.Data.Contexts
{
    public class UniversityDbContext : IdentityDbContext
        <
        User, 
        Role, 
        int, 
        UserClaim, 
        UserRole, 
        UserLogin, 
        RoleClaim, 
        UserToken
        >
    {

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }

        public UniversityDbContext(DbContextOptions<UniversityDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StudentMapping());
            modelBuilder.ApplyConfiguration(new CourseMapping());
            modelBuilder.ApplyConfiguration(new UserMapping());
            modelBuilder.ApplyConfiguration(new RoleMapping());
            modelBuilder.ApplyConfiguration(new UserClaimMapping());
            modelBuilder.ApplyConfiguration(new UserRoleMapping());
            modelBuilder.ApplyConfiguration(new UserLoginMapping());
            modelBuilder.ApplyConfiguration(new RoleClaimMapping());
            modelBuilder.ApplyConfiguration(new UserTokenMapping());
        }
    }
}
