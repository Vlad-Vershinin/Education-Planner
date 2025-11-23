using server.Domain.Interfaces.Repositories;
using server.Domain.Models;
using server.Persistence;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace server.Infrastucture.Repositories
{
    public class ProfessionRepository : IProfessionRepository
    {
        private readonly ApplicationDbContext _context;


        public async Task<List<Profession>> GetAllProfessions()
        {
            return _context.Professions.ToList();
        }
        public async Task<Profession> GetProfession(int id)
        {
            return _context.Professions.ElementAt(id);
        }
        public async Task<List<Course>> GetProfessionCourses(int id)
        {
            return _context.Professions.ElementAt(id).Courses;
        }
        public async Task<List<Skill>> GetProfessionSkills(int id)
        {
            return _context.Professions.ElementAt(id).Skills;
        }
    }
}
