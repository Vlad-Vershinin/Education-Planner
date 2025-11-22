using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using server.Persistence;
using server.Domain.Models;
using System.Runtime.Intrinsics.X86;
using server.Domain.Interfaces.Repositories;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using System.Reflection.Metadata.Ecma335;

namespace server.Infrastucture.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context) { 
            _context = context; 
        }
        public async Task<List<User>> GetAllUsers()
        {
            return await _context.User.ToListAsync();
        }

        public async Task<bool> UserExist(Guid id)
        {
            return await _context.User.AnyAsync(us => us.Id == id);
        }
        public async Task<bool> UserExist(string login)
        {
            return await _context.User.AnyAsync(us => us.Login == login);
        }

        public async Task<User> GetUserById(Guid id)
        {
            return await _context.User.FindAsync(id);
        }
        public async Task<User> GetUserByLogin(string login)
        {
            return await _context.User.FindAsync(login);
        }

        public async Task<List<LeveledSkill>> GetUserSkills(int id)
        {
            return _context.User.FindAsync(id).Result.SkillsHave;
        }
        Task<List<CourseTaken>> GetUserCourses(int id)
        {

        }
        Task<Profession> GetUserProfession(int id)
        {

        }
        Task UpdateUserSkills(List<LeveledSkill> skills)
        {

        }
        Task UpdateUserCourseProgress(int user_id, double progress)
        {

        }

    }
    
}
