using server.Domain.Interfaces.Services;
using server.Domain.Interfaces.Repositories;
using server.Domain.DTOs;
using server.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.Application.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;

        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task<List<CourseDto>> GetAllCoursesAsync()
        {
            return _courseRepository.GetAllCourses().Result.Select(course => new CourseDto(course)).ToList();
        }

        public async Task<CourseDto> GetCourseAsync(Guid id)
        {
            return new CourseDto(await _courseRepository.GetCourseById(id));
        }

        public async Task<List<ProfessionDto>> GetCourseProfessionsAsync(int id)
        {
            return _courseRepository.GetCourseProfessions().Result.Select(profession => new ProfessionDto(profession)).ToList();
        }

        public async Task<List<LeveledSkill>> GetCourseSkillsAsync()
        {
            return _courseRepository.GetCourseSkills().Result.Select(skill => new LeveledSkillDto(skill).ToList());
        }
    }
}
