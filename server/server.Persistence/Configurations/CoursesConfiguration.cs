using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using server.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.Persistence.Configurations{

    public class CoursesConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .HasMany(c => c.Professions)
                .WithMany(p => p.Courses);


            builder
                .HasMany(c => c.Skills)
                .WithMany(s => s.Courses);
        }

    }
}