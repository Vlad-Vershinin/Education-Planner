using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using server.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.Persistence.Configurations
{
    public class CourseTakenConfiguration : IEntityTypeConfiguration<CourseTaken>
    {
        public void Configure(EntityTypeBuilder<CourseTaken> builder)
        {
            builder.HasKey(ct => new { ct.UserId, ct.CourseId });
        }
    }
}
