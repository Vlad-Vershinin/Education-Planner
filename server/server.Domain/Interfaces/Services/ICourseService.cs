using server.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.Domain.Interfaces.Services
{
    public interface ICourseService
    {
        Task<List<CourseDto>> GetAllCoursesAsync();
        Task<CourseDto> GetCourseAsync(Guid Id);
        Task<List<ProfessionDto>> GetCourseProfessionsAsync(Guid Id);
        Task<List<LeveledSkillDto>> GetCourseSkillsAsync(Guid Id);
    }
}
