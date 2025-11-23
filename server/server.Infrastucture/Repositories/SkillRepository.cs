using server.Domain.Interfaces.Repositories;
using server.Domain.Models;
using server.Persistence;



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
        public async Task<List<Course>> GetSkillCourses(int id)
        {
            return _context.Skills.ElementAt(id).Courses;
        }
        public async Task<List<Profession>> GetSkillProfessions(int id)
        {
            return _context.Skills.ElementAt(id).Profession;
        }
    }
}
