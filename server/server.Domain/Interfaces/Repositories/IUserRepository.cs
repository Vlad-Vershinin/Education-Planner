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
        Task<User> GetUserById(int id);
        Task<User> GetUserByLogin(string login);
        Task<List<LeveledSkill>> GetUserSkills(int id);
        Task<List<CourseTaken>> GetUserCourses(int id);
        Task<Profession> GetUserProfession(int id);
        Task UpdateUserSkills(int user_id, List<LeveledSkillDto> skills);
        Task UpdateUserCourseProgress(int user_id, int course_id, double progress);
        Task UpdateUserProfession(int user_id, int profession_id);
    }
}
