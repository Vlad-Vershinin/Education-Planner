using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using server.Domain.Models;

namespace server.Persistence.Configurations{

    public class CoursesConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .HasMany(c => c.Skills)
                .WithOne(ls => ls.Course);
            
            builder
                .HasMany(c => c.Professions)
                .WithMany(p => p.Courses);
        }

    }
}