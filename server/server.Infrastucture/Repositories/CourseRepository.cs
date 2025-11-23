using server.Domain.Interfaces.Repositories;
using server.Domain.Models;
using server.Persistence;
using server.Persistence.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.Infrastucture.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly ApplicationDbContext _context;


        public async Task<List<Course>> GetAllCourses()
        {
            return _context.Courses.ToList();
        }
        public async Task<Course> GetCourse(Guid Id)
        {
            return _context.Courses.ElementAt(id);
        }
        public async Task<List<Profession>> GetCourseProfessions(Guid Id)
        {
            return _context.Courses.ElementAt(id).Professions;
        }
        public async Task<List<LeveledSkill>> GetCourseSkills(Guid Id)
        {
            return _context.Courses.ElementAt(id).Skills;
        }
    }
}
