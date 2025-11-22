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
        Task<Profession> GetProfession(int id);
        Task<List<Course>> GetProfessionCourses(int id);
        Task<List<Skill>> GetProfessionSkills(int id);
    }
}
