using server.Domain.DTOs;
using server.Domain.Models;
using server.Domain.Interfaces.Repositories;
using server.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.Application.Services
{
    public class SkillService : ISkillService
    {
        private readonly ISkillRepository _skillRepository;

        public SkillService(ISkillRepository skillRepository) {
            _skillRepository = skillRepository;
        }

        public async Task<List<SkillDto>> GetAllSkillsAsync()
        {
            return _skillRepository.GetAllSkills().Result.Select(skill => new SkillDto(skill)).ToList();
        }

        public async Task<SkillDto> GetSkillAsync(Guid Id)
        {
            return new SkillDto(await _skillRepository.GetSkillById(Id));
        }

        public async Task<List<SkillDto>> GetSkillsByParent(Guid Id)
        {
            return _skillRepository.GetSkillsByParent(Id).Result.Select(skill => new SkillDto(skill)).ToList();
        }

        public async Task<List<CourseDto>> GetSkillCoursesAsync()
        {
            return _skillRepository.GetSkillCourses().Result.Select(course => new CourseDto(course)).ToList();
        }

        public async Task<List<ProfessionDto>> GetSkillProfessionsAsync()
        {
            return _skillRepository.GetSkillProfessions().Result.Select(profession => new ProfessionDto(profession)).ToList();
        }
    }
}
