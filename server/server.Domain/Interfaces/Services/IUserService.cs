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
        Task<UserDto> GetUserAsync(Guid Id);
        Task<List<CourseTakenDto>> GetUserCoursesAsync(Guid Id);
        Task<ProfessionDto> GetUserProfessionAsync(Guid Id);
        Task UpdateUserSkillsAsync(Guid user_id, List<LeveledSkillDto> skills);
        Task UpdateUserCourseProgressAsync(Guid user_id, Guid course_id, double progress);
        Task UpdateUserProfessionAsync(Guid user_id, Guid profession_id);
    }
}
