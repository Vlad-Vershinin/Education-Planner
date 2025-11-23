using server.Domain.Interfaces.Repositories;
using server.Domain.Interfaces.Services;
using server.Domain.DTOs;
using server.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace server.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public async Task<UserDto> AuthorizeAsync(string login, string password)
        {
            return new UserDto(await _userRepository.GetUserByLogin(login));
        }

        public async Task<UserDto> GetUserAsync(Guid Id)
        {
            return new UserDto(await _userRepository.GetUserById(id));
        }

        public async Task<List<CourseTakenDto>> GetUserCoursesAsync(Guid Id)
        {
            return _userRepository.GetUserCourses(id).Result.Select(course => new CourseTakenDto(course)).ToList();
        }

        public async Task<ProfessionDto> GetUserProfessionAsync(Guid Id)
        {
            return new ProfessionDto(await _userRepository.GetUserProfession(id));
        }

        public async Task UpdateUserSkillsAsync(int user_id, List<LeveledSkillDto> skills)
        {
            await _userRepository.UpdateUserSkills(user_id, skills);
        }

        public async Task UpdateUserCourseProgressAsync(int user_id, int course_id, double progress)
        {
            await _userRepository.UpdateUserCourseProgress(user_id, course_id, progress);
        }

        public async Task UpdateUserProfessionAsync(int user_id, int profession_id)
        {
            await _userRepository.UpdateUserProfession(user_id, profession_id);
        }
    }
}
