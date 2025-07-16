using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using University.Data.Entities;

namespace University.Data.ClassMappings
{
    public class CourseMapping : IEntityTypeConfiguration<Course>
    {
         public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasKey(c => c.CourseId);

            builder.Property(c => c.CourseId).HasColumnName("CourseId");

            builder.Property(c => c.CourseName).HasMaxLength(256);
        }
    }
}
