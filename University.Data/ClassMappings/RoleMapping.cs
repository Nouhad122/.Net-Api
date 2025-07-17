using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using University.Data.Entities;
using University.Data.Entities.Identity;

namespace University.Data.ClassMappings
{
    public class RoleMapping : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {

            builder.ToTable("Roles");
            builder.HasKey(r => r.Id);
            builder.Property(r => r.Id).HasColumnName("RoleId");
        }
    }
}
