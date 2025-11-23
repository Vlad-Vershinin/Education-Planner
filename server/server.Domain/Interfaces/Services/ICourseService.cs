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
        Task<CourseDto> GetCourseAsync(int id);
        Task<List<ProfessionDto>> GetCourseProfessionsAsync(int id);
        Task<List<LeveledSkillDto>> GetCourseSkillsAsync(int id);
    }
}
