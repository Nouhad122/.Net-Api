using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using University.Data.Entities;
using University.Data.Entities.Identity;

namespace University.Data.ClassMappings
{
    public class UserClaimMapping : IEntityTypeConfiguration<UserClaim>
    {
        public void Configure(EntityTypeBuilder<UserClaim> builder)
        {

            builder.ToTable("UserClaims");
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id).HasColumnName("UserClaimId");
        }
    }
}
