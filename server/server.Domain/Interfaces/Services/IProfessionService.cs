using server.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.Domain.Interfaces.Services
{
    public interface IProfessionService
    {
        Task<List<Profession>> GetAllProfessionsAsync();
        Task<Profession> GetProfessionAsync(int id);
        Task<List<Course>> GetProfessionCoursesAsync(int id);
        Task<List<Skill>> GetProfessionSkillsAsync(int id);
    }
}
