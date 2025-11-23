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
        public DbSet<CourseTaken>       LeveledSkill        { get; set; }
        public DbSet<CourseTaken>       LeveledCourses      { get; set; }
        public DbSet<User>                User                { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new SkillsConfiguration());
            modelBuilder.ApplyConfiguration(new CoursesConfiguration());
            modelBuilder.ApplyConfiguration(new ProfessionsConfiguration());
            modelBuilder.ApplyConfiguration(new LeveledSkillConfiguration());
            modelBuilder.ApplyConfiguration(new UsersConfiguration());
            modelBuilder.ApplyConfiguration(new CourseTakenConfiguration());
      
            

            // other configurations here
            base.OnModelCreating(modelBuilder);
        }




        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
          //  optionsBuilder.UseNpgsql(source.db.env);
        }


    }
}
