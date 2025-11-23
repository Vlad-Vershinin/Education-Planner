using server.Domain.Interfaces.Repositories;
using server.Domain.Models;
using server.Persistence;

namespace server.Infrastucture.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly ApplicationDbContext _context;

        public async Task<List<Course>> GetAllCourses()
        {
            return _context.Courses.ToList();
        }
        public async Task<Course> GetCourse(int id)
        {
            return _context.Courses.ElementAt(id);
        }
        public async Task<List<Profession>> GetCourseProfessions(int id)
        {
            return _context.Courses.ElementAt(id).Professions;
        }
        public async Task<List<LeveledSkill>> GetCourseSkills(int id)
        {
            return _context.Courses.ElementAt(id).Skills;
        }
    }
}
