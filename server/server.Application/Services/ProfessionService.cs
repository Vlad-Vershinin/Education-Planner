using server.Domain.Interfaces.Repositories;
using server.Domain.Interfaces.Services;
using server.Domain.Models;
using server.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.Application.Services
{
    public class ProfessionService : IProfessionService
    {
        private readonly IProfessionRepository _professionRepository;

        public ProfessionService(IProfessionRepository professionRepository)
        {
            _professionRepository = professionRepository;
        }

        public async Task<List<ProfessionDto>> GetAllProfessionsAsync()
        {
            return _professionRepository.GetAllProfessions().Result.Select(profession => new ProfessionDto(profession)).ToList();
        }

        public async Task<ProfessionDto> GetProfessionAsync(Guid id)
        {
            return new ProfessionDto(await _professionRepository.GetProfession(id));
        }

        public async Task<List<CourseDto>> GetProfessionCoursesAsync()
        {
            return _professionRepository.GetProfessionCourses().Result.Select(course => new CourseDto(course)).ToList();
        }

        public async Task<List<SkillDto>> GetProfessionSkillsAsync()
        {
            return _professionRepository.GetProfessionSkills().Result.Select(skills => new SkillDto(skills)).ToList();
        }
    }
}
