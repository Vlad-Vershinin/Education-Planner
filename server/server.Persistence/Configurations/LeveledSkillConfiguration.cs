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
    public class LeveledSkillConfiguration : IEntityTypeConfiguration<LeveledSkill>
    {
        public void Configure(EntityTypeBuilder<LeveledSkill> builder)
        {
            builder.HasKey(ls => new { ls.CourseId, ls.SkillId });

            builder
                .HasOne(ls => ls.Course)
                .WithMany(c => c.Skills)
                .HasForeignKey(ls => ls.CourseId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(ls => ls.Skill)
                .WithMany(s => s.LeveledSkills)
                .HasForeignKey(ls => ls.SkillId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
