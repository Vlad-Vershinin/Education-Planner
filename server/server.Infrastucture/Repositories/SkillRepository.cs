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
        public async Task<List<Skill>> GetSkillsByParent(int id)
        {
            return  _context.Skills.Where(x => x.ParentId == id).ToList();
        }
        public async Task<Skill> GetSkill(int id)
        {
            return _context.Skills.ElementAt(id);
        }
        public async Task<List<Course>> GetSkillCourses()
        {
            return _context.Courses.Include(x => x.Skills).ToList();
        }
        public async Task<List<Profession>> GetSkillProfessions()
        {
            return _context.Professions.Include(x => x.Skills).ToList();
        }
    }
}
