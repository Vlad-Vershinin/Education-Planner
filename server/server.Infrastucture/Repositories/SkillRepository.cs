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
    public class SkillRepository : ISkillRepository
    {
        private readonly ApplicationDbContext _context;
        public async Task<List<Skill>> GetAllSkills()
        {
            return _context.Skills.ToList();
        }
        public async Task<List<Skill>> GetSkillsByParent(Guid id)
        {
            return  _context.Skills.Where(x => x.ParentId == id).ToList();
        }
        public async Task<Skill> GetSkillById(Guid id)
        {
            return _context.Skills.FirstOrDefault(x => x.Id == id);
        }
        public async Task<List<Course>> GetSkillCourses()
        {
            return await _context.Courses.Include(x => x.Skills).ToListAsync();
        }
        public async Task<List<Profession>> GetSkillProfessions()
        {
            return await _context.Professions.Include(x => x.Skills).ToListAsync();
        }
    }
}
