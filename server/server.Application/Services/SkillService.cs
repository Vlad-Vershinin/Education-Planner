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

        SkillService(ISkillRepository skillRepository) {
            _skillRepository = skillRepository;
        }

        public async Task<List<SkillDto>> GetAllSkillsAsync()
        {
            return _skillRepository.GetAllSkills().Result.Select(skill => new SkillDto(skill)).ToList();
        }

        public async Task<SkillDto> GetSkillAsync(Guid Id)
        {
            return new SkillDto(await _skillRepository.GetSkill(id));
        }

        public async Task<List<SkillDto>> GetSkillsByParent(Guid Id)
        {
            return _skillRepository.GetSkillsByParent(id).Result.Select(skill => new SkillDto(skill)).ToList();
        }

        public async Task<List<CourseDto>> GetSkillCoursesAsync(Guid Id)
        {
            return _skillRepository.GetSkillCourses(id).Result.Select(course => new CourseDto(course)).ToList();
        }

        public async Task<List<ProfessionDto>> GetSkillProfessionsAsync(Guid Id)
        {
            return _skillRepository.GetSkillProfessions(id).Result.Select(profession => new ProfessionDto(profession)).ToList();
        }
    }
}
