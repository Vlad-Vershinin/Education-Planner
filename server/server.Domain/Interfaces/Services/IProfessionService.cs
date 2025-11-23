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
        Task<ProfessionDto> GetProfessionAsync(Guid Id);
        Task<List<CourseDto>> GetProfessionCoursesAsync(Guid Id);
        Task<List<SkillDto>> GetProfessionSkillsAsync(Guid Id);
    }
}
