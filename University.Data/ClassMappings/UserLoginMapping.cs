using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using University.Data.Entities;
using University.Data.Entities.Identity;

namespace University.Data.ClassMappings
{
    public class UserLoginMapping : IEntityTypeConfiguration<UserLogin>
    {
        public void Configure(EntityTypeBuilder<UserLogin> builder)
        {

            builder.ToTable("UserLogins");
            builder.HasKey(u => u.UserId);
        }
    }
}
