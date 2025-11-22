using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using server.Domain.Models;

namespace server.Domain.Interfaces.Repositories
{
    public interface ISkillRepository
    {
        Task<List<Skill>> GetAllSkills();
        Task<List<Skill>> GetSkillsByParent(int id);
        Task<Skill> GetSkill(int id);
        Task<List<Course>> GetSkillCourses(int id);
        Task<List<Profession>> GetSkillProfession(int id);
    }
}
