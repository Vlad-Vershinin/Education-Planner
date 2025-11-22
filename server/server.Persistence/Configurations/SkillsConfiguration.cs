using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using server.Domain.Models;

namespace server.Persistence.Configurations{

    public class SkillsConfiguration : IEntityTypeConfiguration<Skill>
    {
        public void Configure(EntityTypeBuilder<Skill> builder)
        {

            builder.HasKey(x => x.Id);


            builder
                .HasMany(s => s.Profession)
                .WithMany(p => p.Skills);
        }
    }
}