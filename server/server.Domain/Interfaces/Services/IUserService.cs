using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using server.Domain.DTOs;
using server.Domain.Models;

namespace server.Domain.Interfaces.Services
{
    public interface IUserService
    {
        Task<UserDto> AuthorizeAsync(string login, string password);
        Task<UserDto> GetUserAsync(int id);
        Task<List<CourseTakenDto>> GetUserCoursesAsync(int id);
        Task<ProfessionDto> GetUserProfessionAsync(int id);
        Task UpdateUserSkillsAsync(int user_id, List<LeveledSkillDto> skills);
        Task UpdateUserCourseProgressAsync(int user_id, int course_id, double progress);
        Task UpdateUserProfessionAsync(int user_id, int profession_id);
    }
}
