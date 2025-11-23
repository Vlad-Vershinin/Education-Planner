using Microsoft.EntityFrameworkCore;
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
    public class ProfessionRepository : IProfessionRepository
    {
        private readonly ApplicationDbContext _context;


        public async Task<List<Profession>> GetAllProfessions()
        {
            return _context.Professions.ToList();
        }

        public async Task<Profession> GetProfession(Guid Id)
        {
            return _context.Professions.FirstOrDefault(x => x.Id == Id);
        }
        public async Task<List<Course>> GetProfessionCourses()
        {
            return await _context.Courses.Include(x => x.Professions).ToListAsync();
        }
        public async Task<List<Skill>> GetProfessionSkills()
        {
            return await _context.Skills.Include(x => x.Profession).ToListAsync();
        }
        public async Task<List<Profession>> GetSkillProfessions()
        {
            return await _context.Professions.Include(x => x.Skills).ToListAsync(); 
        }
    }
}
