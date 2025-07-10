using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using University.Data.Entities;

namespace University.Data.ClassMappings
{
    public class StudentMapping : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(s => s.Id).HasColumnName("StudentId");

            builder.Property(s => s.Name).HasMaxLength(256);
        }
    }
}
