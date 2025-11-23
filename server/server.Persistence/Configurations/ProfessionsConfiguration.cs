using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using server.Domain.Models;



namespace server.Persistence.Configurations{

    public class ProfessionsConfiguration : IEntityTypeConfiguration<Profession>
    {
        public void Configure(EntityTypeBuilder<Profession> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .HasMany(p => p.Skills)
                .WithMany(s => s.Profession);

            builder
                .HasMany(p => p.Courses)
                .WithMany(c => c.Professions);

        }
    }
}