using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using University.Data.Entities;
using University.Data.Entities.Identity;

namespace University.Data.ClassMappings
{
    public class UserMapping : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(s => s.Id);

            builder.Property(s => s.Id).HasColumnName("UserId");

        }
    }
}
