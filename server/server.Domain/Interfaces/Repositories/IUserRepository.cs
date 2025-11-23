using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using server.Domain.Models;
using server.Domain.DTOs;

namespace server.Domain.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllUsers();
        Task<User> GetUserById(Guid id);
        Task<User> GetUserByLogin(string login);
        Task<List<LeveledSkill>> GetUserSkills(Guid id);
        Task<List<CourseTaken>> GetUserCourses(Guid id);
        Task<Profession> GetUserProfession(Guid id);
        Task UpdateUserSkills(Guid user_id, List<LeveledSkillDto> skills);
        Task UpdateUserCourseProgress(Guid user_id, Guid course_id, double progress);
        Task UpdateUserProfession(Guid user_id, Guid profession_id);
    }
}
