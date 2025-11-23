using Microsoft.EntityFrameworkCore;
using server.Domain.Interfaces.Repositories;
using server.Domain.Models;
using server.Persistence;
<<<<<<< HEAD
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

=======
using server.Persistence.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
>>>>>>> origin/Jacob

namespace server.Infrastucture.Repositories
{
    public class ProfessionRepository : IProfessionRepository
    {
        private readonly ApplicationDbContext _context;


        public async Task<List<Profession>> GetAllProfessions()
        {
            return _context.Professions.ToList();
        }
        public async Task<Profession> GetProfession(Guid Id)
        {
            return _context.Professions.ElementAt(id);
        }
        public async Task<List<Course>> GetProfessionCourses()
        {
            return _context.Courses.Include(x => x.Professions).ToList();
        }
        public async Task<List<Skill>> GetProfessionSkills()
        {
            return _context.Skills.Include(x => x.Profession).ToList();
        }
        public async Task<List<Profession>> GetSkillProfessions()
        {
            return _context.Professions.Include(x => x.Skills).ToList(); 
        }
    }
}
