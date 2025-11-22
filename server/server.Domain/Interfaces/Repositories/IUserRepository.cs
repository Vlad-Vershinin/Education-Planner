using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using server.Domain.Models;

namespace server.Domain.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllUsers();
        Task<User> GetUserById(Guid id);
        Task<User> GetUserByLogin(string login);
        Task<List<LeveledSkill>> GetUserSkills(int id);
        Task<List<CourseTaken>> GetUserCourses(int id);
        Task<Profession> GetUserProfession(int id);
        Task UpdateUserSkills(List<LeveledSkill> skills);
        Task UpdateUserCourseProgress(int user_id, double progress);
    }
}
