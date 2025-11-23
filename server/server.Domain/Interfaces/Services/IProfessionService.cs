using server.Domain.Models;
using server.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.Domain.Interfaces.Services
{
    public interface IProfessionService
    {
        Task<List<ProfessionDto>> GetAllProfessionsAsync();
        Task<ProfessionDto> GetProfessionAsync(int id);
        Task<List<CourseDto>> GetProfessionCoursesAsync(int id);
        Task<List<SkillDto>> GetProfessionSkillsAsync(int id);
    }
}
