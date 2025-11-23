using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using server.Domain.Models;

namespace server.Domain.Interfaces.Repositories
{
    public interface IProfessionRepository
    {
        Task<List<Profession>> GetAllProfessions();
        Task<Profession> GetProfessionById(Guid id);
        Task<List<Course>> GetProfessionCourses();
        Task<List<Skill>> GetProfessionSkills();
        Task<List<Profession>> GetSkillProfessions();

    }
}
