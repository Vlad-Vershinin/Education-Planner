using Microsoft.EntityFrameworkCore;
using server.Domain.Models;
using server.Persistence.Configurations;



namespace server.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Skill>               Skills              { get; set; }
        public DbSet<Course>              Courses             { get; set; }
        public DbSet<Profession>          Professions         { get; set; }
        public DbSet<LeveledSkill>        LeveledSkill        { get; set; }
        public DbSet<LeveledCourse>       LeveledCourses      { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new SkillsConfiguration());
            modelBuilder.ApplyConfiguration(new CoursesConfiguration());
      //      modelBuilder.ApplyConfiguration(new ProfessionsConfigurations());
      //      modelBuilder.ApplyConfiguration(new LeveledSkillsConfiguration());
            

            // other configurations here
            base.OnModelCreating(modelBuilder);
        }




        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
          //  optionsBuilder.UseNpgsql(source.db.env);
        }


    }
}
