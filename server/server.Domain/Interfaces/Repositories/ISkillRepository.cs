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
        Task<List<Skill>> GetSkillsByParent(Guid id);
        Task<Skill> GetSkillById(Guid id);
        Task<List<Course>> GetSkillCourses();
        Task<List<Profession>> GetSkillProfessions();
    }
}
