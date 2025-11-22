using server.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.Domain.Interfaces.Services
{
    public interface ISkillService
    {
        Task<List<SkillDto>> GetAllSkillsAsync();
        Task<SkillDto> GetSkillAsync(int id);
        Task<List<ProfessionDto>> GetSkillProfessionsAsync(int id);
        Task<List<CourseDto>> GetSkillCoursesAsync(int id);
    }
}
