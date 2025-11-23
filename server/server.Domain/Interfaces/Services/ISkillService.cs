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
        Task<List<SkillDto>> GetSkillsByParent(Guid Id);
        Task<SkillDto> GetSkillAsync(Guid Id);
        Task<List<ProfessionDto>> GetSkillProfessionsAsync();
        Task<List<CourseDto>> GetSkillCoursesAsync();
    }
}
